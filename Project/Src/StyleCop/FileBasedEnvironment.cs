// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FileBasedEnvironment.cs" company="https://github.com/StyleCop">
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
//   An environment which interacts with files on disk.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Security;
    using System.Xml;

    /// <summary>
    /// An environment which interacts with files on disk.
    /// </summary>
    public class FileBasedEnvironment : StyleCopEnvironment
    {
        #region Fields

        /// <summary>
        /// The list of file types and their associated parsers.
        /// </summary>
        private readonly Dictionary<string, List<SourceParser>> fileTypes = new Dictionary<string, List<SourceParser>>();

        /// <summary>
        /// The path to the default settings file, if any.
        /// </summary>
        private string defaultSettingsFilePath;

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
                return true;
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
                // Remove the leading dot and convert the extension to uppercase.
                extension = extension.Substring(1).ToUpperInvariant();

                ICollection<SourceParser> parserList = this.GetParsersForFileType(extension);
                if (parserList != null)
                {
                    // Create SourceCode objects representing this file, for each parser.
                    foreach (SourceParser parser in parserList)
                    {
                        // Create and return a SourceCode for this file.
                        SourceCode source = this.CreateCodeFile(path, project, parser, context);
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
            Param.RequireValidString(settingsPath, "settingsPath");

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

            // Create the full string to the local settings file.
            string path = Path.Combine(project.Location, Settings.DefaultFileName);

            if (!File.Exists(path))
            {
                string deprecatedSettingsFilePath = Path.Combine(project.Location, Settings.AlternateFileName);
                if (File.Exists(deprecatedSettingsFilePath))
                {
                    path = deprecatedSettingsFilePath;
                }
                else
                {
                    deprecatedSettingsFilePath = Path.Combine(project.Location, V101Settings.DefaultFileName);
                    if (File.Exists(deprecatedSettingsFilePath))
                    {
                        path = deprecatedSettingsFilePath;
                    }
                }
            }

            return this.GetSettings(path, merge, out exception);
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
            Param.RequireValidString(settingsPath, "settingsPath");
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

            WritableSettings localSettings = this.LoadSettingsDocument(settingsPath, false, out exception) as WritableSettings;
            if (localSettings == null)
            {
                if (exception is FileNotFoundException)
                {
                    localSettings = this.CreateSettingsDocument(settingsPath, out exception);
                }
            }

            return localSettings;
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
            Param.RequireValidString(location, "location");

            try
            {
                // Load the document if it exists and add it to the hashtable.
                string path = FileBasedEnvironment.GetResultsCachePath(location);

                if (File.Exists(path))
                {
                    XmlDocument resultsCache = new XmlDocument();
                    resultsCache.Load(path);

                    return resultsCache;
                }
            }
            catch (XmlException)
            {
            }
            catch (IOException)
            {
            }
            catch (SecurityException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }

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
            Param.RequireValidString(location, "location");

            try
            {
                // Delete the output file if it already exists.
                if (File.Exists(location))
                {
                    File.SetAttributes(location, FileAttributes.Normal);
                    File.Delete(location);
                }
            }
            catch (IOException)
            {
            }
            catch (SecurityException)
            {
            }
            catch (UnauthorizedAccessException)
            {
            }
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
            Param.RequireValidString(location, "location");
            Param.RequireNotNull(analysisResults, "analysisResults");

            exception = null;

            try
            {
                analysisResults.Save(location);
                return true;
            }
            catch (SecurityException secex)
            {
                exception = secex;
            }
            catch (UnauthorizedAccessException unauthex)
            {
                exception = unauthex;
            }
            catch (IOException ioex)
            {
                exception = ioex;
            }
            catch (XmlException xmlex)
            {
                exception = xmlex;
            }
            catch (ArgumentException argex)
            {
                exception = argex;
            }

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
            Param.RequireValidString(location, "location");
            Param.RequireNotNull(resultsCache, "resultsCache");

            try
            {
                string path = FileBasedEnvironment.GetResultsCachePath(location);

                try
                {
                    if (File.Exists(path))
                    {
                        File.SetAttributes(path, FileAttributes.Normal);
                        File.Delete(path);
                    }

                    resultsCache.Save(path);
                }
                catch (ArgumentException)
                {
                }
                catch (IOException)
                {
                }
                catch (SecurityException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }

                try
                {
                    if (File.Exists(path))
                    {
                        File.SetAttributes(path, FileAttributes.Hidden);
                    }
                }
                catch (ArgumentException)
                {
                }
                catch (IOException)
                {
                }
                catch (SecurityException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
            catch (XmlException)
            {
            }
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
            Param.RequireNotNull(settings, "settings");

            exception = null;

            if (settings.Location == null || settings.Contents == null)
            {
                throw new InvalidOperationException(Strings.SettingsFileHasNotBeenLoaded);
            }

            // Write the new settings to the document.
            XmlDocument document = settings.WriteSettingsToDocument(this);

            try
            {
                // Save the file.
                document.Save(settings.Location);

                // Update the write time.
                settings.WriteTime = File.GetLastWriteTime(settings.Location);

                return true;
            }
            catch (IOException ioex)
            {
                exception = ioex;
            }
            catch (SecurityException secex)
            {
                exception = secex;
            }
            catch (UnauthorizedAccessException unauthex)
            {
                exception = unauthex;
            }
            catch (XmlException xmlex)
            {
                exception = xmlex;
            }

            return false;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Creates a new <see cref="CodeFile"/> instance with the given values.
        /// </summary>
        /// <param name="path">
        /// The path to the code file.
        /// </param>
        /// <param name="project">
        /// The project that contains this file.
        /// </param>
        /// <param name="parser">
        /// The parser that created this file object.
        /// </param>
        /// <param name="context">
        /// Optional context information.
        /// </param>
        /// <returns>
        /// Returns the newly created <see cref="CodeFile"/>.
        /// </returns>
        protected virtual CodeFile CreateCodeFile(string path, CodeProject project, SourceParser parser, object context)
        {
            Param.Ignore(path, project, parser, context);
            return new CodeFile(path, project, parser);
        }

        /// <summary>
        /// Gets the expected full path for a cache file
        /// </summary>
        /// <param name="location">
        /// The location on which to base the cache file path
        /// </param>
        /// <returns>
        /// The expected path for the cache file
        /// </returns>
        private static string GetResultsCachePath(string location)
        {
            Param.AssertValidString(location, "location");

            if (File.Exists(location))
            {
                location = Path.GetDirectoryName(location);
            }

            return Path.GetFullPath(Path.Combine(location, "StyleCop.Cache"));
        }

        /// <summary>
        /// Creates an empty settings file at the given path.
        /// </summary>
        /// <param name="path">
        /// The path to the document to create.
        /// </param>
        /// <param name="exception">
        /// If the document could not be created, this returns the 
        /// resulting exception information.
        /// </param>
        /// <returns>
        /// Returns the document if it was successfully saved.
        /// </returns>
        private WritableSettings CreateSettingsDocument(string path, out Exception exception)
        {
            Param.AssertValidString(path, "path");

            exception = null;

            try
            {
                XmlDocument document = WritableSettings.NewDocument();
                document.Save(path);

                // Get the last write time for the file.
                DateTime writeTime = File.GetLastWriteTime(path);

                return new WritableSettings(this.Core, path, document, writeTime);
            }
            catch (ArgumentException argex)
            {
                exception = argex;
            }
            catch (IOException ioex)
            {
                exception = ioex;
            }
            catch (SecurityException secex)
            {
                exception = secex;
            }
            catch (UnauthorizedAccessException unauthex)
            {
                exception = unauthex;
            }
            catch (XmlException xmlex)
            {
                exception = xmlex;
            }

            return null;
        }

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
            Param.AssertValidString(settingsFilePath, "settingsFilePath");
            Param.Ignore(readOnly);

            exception = null;

            try
            {
                // Determine whether the file exists.
                if (!File.Exists(settingsFilePath))
                {
                    // The file does not exist.
                    exception = new FileNotFoundException();
                }
                else
                {
                    // Load the settings document.
                    XmlDocument document = new XmlDocument();
                    document.Load(settingsFilePath);

                    // Get the last write time for the time.
                    DateTime writeTime = File.GetLastWriteTime(settingsFilePath);

                    // Create the settings container.
                    Settings settings = readOnly
                                            ? new Settings(this.Core, settingsFilePath, document, writeTime)
                                            : new WritableSettings(this.Core, settingsFilePath, document, writeTime);

                    return settings;
                }
            }
            catch (IOException ioex)
            {
                exception = ioex;
            }
            catch (SecurityException secex)
            {
                exception = secex;
            }
            catch (UnauthorizedAccessException unauthex)
            {
                exception = unauthex;
            }
            catch (XmlException xmlex)
            {
                exception = xmlex;
            }

            return null;
        }

        #endregion
    }
}