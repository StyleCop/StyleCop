// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectBasedEnvironment.cs" company="https://github.com/StyleCop">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   Delegate which is used to retrieve the <see cref="SourceCode" /> object corresponding to the given path.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Xml;

    /// <summary>
    /// Delegate which is used to retrieve the <see cref="SourceCode" /> object corresponding to the given path.
    /// </summary>
    /// <param name="path">The path to the source code object.</param>
    /// <param name="project">The project which contains the source code object.</param>
    /// <param name="parser">The parser for the source code type.</param>
    /// <param name="context">Optional context.</param>
    /// <returns>Returns the source code object.</returns>
    public delegate SourceCode SourceCodeFactory(string path, CodeProject project, SourceParser parser, object context);

    /// <summary>
    /// Delegate which is used to retrieve the <see cref="Settings" /> object corresponding to a given project path.
    /// </summary>
    /// <param name="path">The path to the project.</param>
    /// <param name="readOnly">Indicates whether to return a <see cref="Settings" /> object or a <see cref="WritableSettings" /> object.</param>
    /// <returns>Returns the settings object.</returns>
    public delegate Settings ProjectSettingsFactory(string path, bool readOnly);

    /// <summary>
    /// An environment which does not depend on the file system for loading source and settings files. Source files and settings
    /// files can be loaded from any arbitrary source (in memory, database, etc.).
    /// </summary>
    public class ObjectBasedEnvironment : StyleCopEnvironment
    {
        #region Fields

        /// <summary>
        /// The list of parsers and their associations.
        /// </summary>
        private readonly Dictionary<string, List<SourceParser>> fileTypes = new Dictionary<string, List<SourceParser>>();

        /// <summary>
        /// Callback which is used to retrieve Settings objects on demand.
        /// </summary>
        private readonly ProjectSettingsFactory settingsFactory;

        /// <summary>
        /// Callback which is used to retrieve SourceCode objects on demand.
        /// </summary>
        private readonly SourceCodeFactory sourceCodeFactory;

        /// <summary>
        /// The path to the default settings file, if any.
        /// </summary>
        private string defaultSettingsFilePath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ObjectBasedEnvironment class.
        /// </summary>
        /// <param name="sourceCodeFactory">
        /// Callback which is used to create <see cref="SourceCode"/> objects on demand.
        /// </param>
        /// <param name="settingsFactory">
        /// Optional callback which is used to create <see cref="Settings"/> objects on demand.
        /// </param>
        public ObjectBasedEnvironment(SourceCodeFactory sourceCodeFactory, ProjectSettingsFactory settingsFactory)
        {
            Param.RequireNotNull(sourceCodeFactory, "sourceCodeFactory");
            Param.Ignore(settingsFactory);

            this.sourceCodeFactory = sourceCodeFactory;
            this.settingsFactory = settingsFactory;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the environment supports settings documents
        /// which link directly to another settings document to merge with.
        /// </summary>
        public override bool SupportsLinkedSettings
        {
            get
            {
                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether the environment supports the use
        /// of the results cache.
        /// </summary>
        public override bool SupportsResultsCache
        {
            get
            {
                // In an object based environment, we do not support writing out a results cache.
                return false;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Invoked when a new parser is loaded.
        /// </summary>
        /// <param name="parser">
        /// The new parser.
        /// </param>
        public override void AddParser(SourceParser parser)
        {
            Param.RequireNotNull(parser, "parser");

            // Add the parser to the code extensions table.
            ICollection<string> fileTypesForParser = parser.FileTypes;

            if (fileTypesForParser != null)
            {
                // Loop through each of the file types.
                foreach (string fileTypeForParser in fileTypesForParser)
                {
                    if (fileTypeForParser != null)
                    {
                        List<SourceParser> list = null;
                        if (!this.fileTypes.TryGetValue(fileTypeForParser, out list))
                        {
                            list = new List<SourceParser>(1);
                            this.fileTypes.Add(fileTypeForParser, list);
                        }

                        list.Add(parser);
                    }
                }
            }
        }

        /// <summary>
        /// Adds a source code document to the given project.
        /// </summary>
        /// <param name="project">
        /// The project which should contain the source code instance.
        /// </param>
        /// <param name="path">
        /// The path to the source code document to add.
        /// </param>
        /// <param name="context">
        /// Optional context information.
        /// </param>
        /// <returns>
        /// Returns true if any source code documents were added to the project.
        /// </returns>
        public override bool AddSourceCode(CodeProject project, string path, object context)
        {
            Param.RequireNotNull(project, "project");
            Param.RequireValidString(path, "path");
            Param.Ignore(context);

            bool added = false;

            // Get the parsers for this file based on its extension.
            string extension = Path.GetExtension(path);
            if (extension != null && extension.Length > 0)
            {
                // Remove the leading dot and convert the extension to lower-case.
                extension = extension.Substring(1).ToUpperInvariant();

                ICollection<SourceParser> parserList = this.GetParsersForFileType(extension);
                if (parserList != null)
                {
                    // Create SourceCode objects representing this file, for each parser.
                    foreach (SourceParser parser in parserList)
                    {
                        // Create and return a SourceCode for this file.
                        SourceCode source = this.sourceCodeFactory(path, project, parser, context);
                        if (source == null)
                        {
                            throw new InvalidOperationException(Strings.SourceCodeFactoryReturnsNull);
                        }

                        project.AddSourceCode(source);
                        added = true;
                    }
                }
            }

            return added;
        }

        /// <summary>
        /// Gets the path to the default settings file for the currently running StyleCop installation.
        /// </summary>
        /// <returns>Returns the path or an empty string if there is none.</returns>
        public override string GetDefaultSettingsPath()
        {
            if (this.defaultSettingsFilePath == null)
            {
                this.defaultSettingsFilePath = string.Empty;

                // Get the path to the currently executing assembly. The default settings file must be located within
                // the same folder as this assembly.
                string assemblyLocation = Assembly.GetExecutingAssembly().Location;
                if (!string.IsNullOrEmpty(assemblyLocation))
                {
                    string assemblyPath = Path.GetDirectoryName(assemblyLocation);
                    if (!string.IsNullOrEmpty(assemblyPath) && Directory.Exists(assemblyPath))
                    {
                        // Look for a settings file at this location.
                        string settingsFilePath = Path.Combine(assemblyPath, Settings.DefaultFileName);
                        if (File.Exists(settingsFilePath))
                        {
                            this.defaultSettingsFilePath = settingsFilePath;
                        }
                        else
                        {
                            settingsFilePath = Path.Combine(assemblyPath, Settings.AlternateFileName);
                            if (File.Exists(settingsFilePath))
                            {
                                this.defaultSettingsFilePath = settingsFilePath;
                            }
                        }
                    }
                }
            }

            return this.defaultSettingsFilePath;
        }

        /// <summary>
        /// Given the path to a settings document, determines the path to a parent settings file, if one exists.
        /// </summary>
        /// <param name="settingsPath">
        /// The path to the local settings document.
        /// </param>
        /// <returns>
        /// Returns the path to the parent settings document or null if none exists.
        /// </returns>
        public override string GetParentSettingsPath(string settingsPath)
        {
            Param.Ignore(settingsPath);

            if (string.IsNullOrEmpty(settingsPath))
            {
                return null;
            }

            string currentFolder = Path.GetDirectoryName(settingsPath);
            while (!string.IsNullOrEmpty(currentFolder))
            {
                DirectoryInfo parentFolder = Directory.GetParent(currentFolder);
                if (parentFolder == null)
                {
                    break;
                }

                currentFolder = parentFolder.FullName;
                string parentPath = Path.Combine(currentFolder, Settings.DefaultFileName);

                if (!File.Exists(parentPath))
                {
                    string deprecatedSettingsFilePath = Path.Combine(currentFolder, Settings.AlternateFileName);
                    if (File.Exists(deprecatedSettingsFilePath))
                    {
                        parentPath = deprecatedSettingsFilePath;
                    }
                    else
                    {
                        deprecatedSettingsFilePath = Path.Combine(currentFolder, V101Settings.DefaultFileName);
                        if (File.Exists(deprecatedSettingsFilePath))
                        {
                            parentPath = deprecatedSettingsFilePath;
                        }
                    }
                }

                if (File.Exists(parentPath))
                {
                    return parentPath;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the collection of parsers registered for the given file extension.
        /// </summary>
        /// <param name="fileType">
        /// The file extension.
        /// </param>
        /// <returns>
        /// Returns the parsers for the file extension.
        /// </returns>
        public ICollection<SourceParser> GetParsersForFileType(string fileType)
        {
            Param.RequireValidString(fileType, "fileType");

            List<SourceParser> parsersForFileType;
            if (this.fileTypes.TryGetValue(fileType, out parsersForFileType))
            {
                return parsersForFileType;
            }

            return null;
        }

        /// <summary>
        /// Gets the settings for the given project.
        /// </summary>
        /// <param name="project">
        /// The project containing the settings.
        /// </param>
        /// <param name="merge">
        /// Indicates whether to merge the settings with parent settings before returning them.
        /// </param>
        /// <param name="exception">
        /// Returns an exception if one occurred while loading the settings.
        /// </param>
        /// <returns>
        /// Returns the settings.
        /// </returns>
        public override Settings GetProjectSettings(CodeProject project, bool merge, out Exception exception)
        {
            Param.RequireNotNull(project, "project");
            Param.Ignore(merge);
            Param.Ignore(merge);

            return this.GetSettings(project.Location, merge, out exception);
        }

        /// <summary>
        /// Gets the settings given the path to the local settings.
        /// </summary>
        /// <param name="settingsPath">
        /// The path to the settings to load.
        /// </param>
        /// <param name="merge">
        /// Indicates whether to merge the settings with parent settings before returning them.
        /// </param>
        /// <param name="exception">
        /// Returns an exception if one occurred while loading the settings.
        /// </param>
        /// <returns>
        /// Returns the settings.
        /// </returns>
        public override Settings GetSettings(string settingsPath, bool merge, out Exception exception)
        {
            Param.Ignore(settingsPath);
            Param.Ignore(merge);
            Param.Ignore(merge);

            // Load the settings file.
            Settings settings = this.LoadSettingsDocument(settingsPath, true, out exception);
            if (merge)
            {
                // If there are no local settings, create an empty settings file pointing
                // at the location where we expected the local settings to be. This
                // will allow us to do a parent merge from this location.
                if (settings == null)
                {
                    settings = new Settings(this.Core, settingsPath);
                }

                // Merge the file and return it.
                SettingsMerger merger = new SettingsMerger(settings, this);
                settings = merger.MergedSettings;
            }

            return settings;
        }

        /// <summary>
        /// Loads or creates the settings at the given path, and returns them in writable mode.
        /// </summary>
        /// <param name="settingsPath">
        /// The path to the settings.
        /// </param>
        /// <param name="exception">
        /// Returns an exception if one occurred loading or creating the settings.
        /// </param>
        /// <returns>
        /// Returns the settings.
        /// </returns>
        public override WritableSettings GetWritableSettings(string settingsPath, out Exception exception)
        {
            Param.RequireValidString(settingsPath, "settingsPath");
            return this.LoadSettingsDocument(settingsPath, false, out exception) as WritableSettings;
        }

        /// <summary>
        /// Loads the results cache at the given location.
        /// </summary>
        /// <param name="location">
        /// The location of the results cache to load.
        /// </param>
        /// <returns>
        /// Returns the results cache or null if there is no results cache at that location.
        /// </returns>
        public override XmlDocument LoadResultsCache(string location)
        {
            Param.Ignore(location);

            // The default object-based environment does not support results caching.
            return null;
        }

        /// <summary>
        /// Removes the analysis results at the given location.
        /// </summary>
        /// <param name="location">
        /// The location of the analysis results to remove.
        /// </param>
        public override void RemoveAnalysisResults(string location)
        {
            Param.Ignore(location);

            // The default object-based environment does not support analysis results files, so this is a no-op.
        }

        /// <summary>
        /// Saves the analysis results at the given location.
        /// </summary>
        /// <param name="location">
        /// The path to save the results under.
        /// </param>
        /// <param name="analysisResults">
        /// The results to save.
        /// </param>
        /// <param name="exception">
        /// Returns an exception if one occurs while saving the results.
        /// </param>
        /// <returns>
        /// Returns true if the results were saved successfully.
        /// </returns>
        public override bool SaveAnalysisResults(string location, XmlDocument analysisResults, out Exception exception)
        {
            Param.Ignore(location, analysisResults);

            // The default object-based environment does not support the ability to save out an analysis results file.
            exception = new NotSupportedException();
            return false;
        }

        /// <summary>
        /// Saves the given results cache.
        /// </summary>
        /// <param name="location">
        /// The location to save the results cache under.
        /// </param>
        /// <param name="resultsCache">
        /// The results cache to save.
        /// </param>
        public override void SaveResultsCache(string location, XmlDocument resultsCache)
        {
            Param.Ignore(location, resultsCache);

            // The default object-based environment does not support results caching. This method 
            // should never be called as we are passing false to the SupportsResultsCache property.
            throw new NotSupportedException();
        }

        /// <summary>
        /// Saves the settings file at the path specified within the settings document.
        /// </summary>
        /// <param name="settings">
        /// The settings to save.
        /// </param>
        /// <param name="exception">
        /// If the document could not be saved, this returns the 
        /// resulting exception information.
        /// </param>
        /// <returns>
        /// Returns true if the file was successfully saved.
        /// </returns>
        public override bool SaveSettings(WritableSettings settings, out Exception exception)
        {
            Param.Ignore(settings);

            // The default object-based environment does not support the ability to save modified settings.
            exception = new NotSupportedException();
            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the settings file at the given path.
        /// </summary>
        /// <param name="settingsFilePath">
        /// The path to the settings file.
        /// </param>
        /// <param name="readOnly">
        /// Indicates whether a read-only document should be returned.
        /// </param>
        /// <param name="exception">
        /// If the document could not be loaded, this returns the 
        /// resulting exception information.
        /// </param>
        /// <returns>
        /// Returns the settings if they could be loaded.
        /// </returns>
        private Settings LoadSettingsDocument(string settingsFilePath, bool readOnly, out Exception exception)
        {
            Param.Ignore(settingsFilePath);
            Param.Ignore(readOnly);

            exception = null;

            if (!string.IsNullOrEmpty(settingsFilePath) && this.settingsFactory != null)
            {
                try
                {
                    return this.settingsFactory(settingsFilePath, readOnly);
                }
                catch (Exception ex)
                {
                    exception = ex;
                }
            }

            return null;
        }

        #endregion
    }
}