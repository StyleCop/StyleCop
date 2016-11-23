// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopEnvironment.cs" company="https://github.com/StyleCop">
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
//   The environment used to interact with source code documents, settings, etc.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Xml;

    /// <summary>
    /// The environment used to interact with source code documents, settings, etc.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "StyleCop", Justification = "This is the correct casing.")]
    public abstract class StyleCopEnvironment
    {
        #region Public Properties

        /// <summary>
        /// Gets the StyleCop core instance.
        /// </summary>
        public StyleCopCore Core { get; internal set; }

        /// <summary>
        /// Gets a value indicating whether the environment supports settings documents
        /// which link directly to another settings document to merge with.
        /// </summary>
        public abstract bool SupportsLinkedSettings { get; }

        /// <summary>
        /// Gets a value indicating whether the environment supports reading and writing
        /// violation results caches.
        /// </summary>
        public abstract bool SupportsResultsCache { get; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Invoked when a new parser is loaded.
        /// </summary>
        /// <param name="parser">
        /// The new parser.
        /// </param>
        public abstract void AddParser(SourceParser parser);

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
        public abstract bool AddSourceCode(CodeProject project, string path, object context);

        /// <summary>
        /// Gets the path to the default settings file for the currently running StyleCop installation.
        /// </summary>
        /// <returns>Returns the path or null if there is none.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "API has already been published and should not be changed.")]
        public abstract string GetDefaultSettingsPath();

        /// <summary>
        /// Given the path to a settings document, determines the path to a parent settings file, if one exists.
        /// </summary>
        /// <param name="settingsPath">
        /// The path to the local settings document.
        /// </param>
        /// <returns>
        /// Returns the path to the parent settings document or null if none exists.
        /// </returns>
        /// <remarks>
        /// The environment should search through parent folders above the location of the
        /// given settings file to attempt to find a parent settings file.
        /// </remarks>
        public abstract string GetParentSettingsPath(string settingsPath);

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
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "The design is OK.")]
        public abstract Settings GetProjectSettings(CodeProject project, bool merge, out Exception exception);

        /// <summary>
        /// Gets the settings for the given project.
        /// </summary>
        /// <param name="project">
        /// The project containing the settings.
        /// </param>
        /// <param name="merge">
        /// Indicates whether to merge the settings with parent settings before returning them.
        /// </param>
        /// <returns>
        /// Returns the settings.
        /// </returns>
        public Settings GetProjectSettings(CodeProject project, bool merge)
        {
            Param.Ignore(project, merge);

            Exception exception;
            return this.GetProjectSettings(project, merge, out exception);
        }

        /// <summary>
        /// Gets the settings given the path to local settings.
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
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "The design is OK.")]
        public abstract Settings GetSettings(string settingsPath, bool merge, out Exception exception);

        /// <summary>
        /// Gets the settings given the path to local settings.
        /// </summary>
        /// <param name="settingsPath">
        /// The path to the settings to load.
        /// </param>
        /// <param name="merge">
        /// Indicates whether to merge the settings with parent settings before returning them.
        /// </param>
        /// <returns>
        /// Returns the settings.
        /// </returns>
        public Settings GetSettings(string settingsPath, bool merge)
        {
            Param.Ignore(settingsPath, merge);

            Exception exception;
            return this.GetSettings(settingsPath, merge, out exception);
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
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "The design is OK.")]
        public abstract WritableSettings GetWritableSettings(string settingsPath, out Exception exception);

        /// <summary>
        /// Loads or creates the settings at the given path, and returns them in writable mode.
        /// </summary>
        /// <param name="settingsPath">
        /// The path to the settings.
        /// </param>
        /// <returns>
        /// Returns the settings.
        /// </returns>
        public WritableSettings GetWritableSettings(string settingsPath)
        {
            Param.Ignore(settingsPath);

            Exception exception;
            return this.GetWritableSettings(settingsPath, out exception);
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
        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", 
            Justification = "Compliance would break well-defined API.")]
        public abstract XmlDocument LoadResultsCache(string location);

        /// <summary>
        /// Removes the analysis results at the given location.
        /// </summary>
        /// <param name="location">
        /// The location of the analysis results to remove.
        /// </param>
        public abstract void RemoveAnalysisResults(string location);

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
        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", 
            Justification = "Compliance would break the well-defined public API.")]
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "2#", Justification = "The design is OK.")]
        public abstract bool SaveAnalysisResults(string location, XmlDocument analysisResults, out Exception exception);

        /// <summary>
        /// Saves the given results cache.
        /// </summary>
        /// <param name="location">
        /// The location to save the results cache under.
        /// </param>
        /// <param name="resultsCache">
        /// The results cache to save.
        /// </param>
        [SuppressMessage("Microsoft.Design", "CA1059:MembersShouldNotExposeCertainConcreteTypes", MessageId = "System.Xml.XmlNode", 
            Justification = "Compliance would break well-defined API.")]
        public abstract void SaveResultsCache(string location, XmlDocument resultsCache);

        /// <summary>
        /// Saves the settings document at the path specified within the document.
        /// </summary>
        /// <param name="settings">
        /// The settings to save.
        /// </param>
        /// <param name="exception">
        /// If the document could not be saved, this returns the 
        /// resulting exception information.
        /// </param>
        /// <returns>
        /// Returns true if the document was successfully saved.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1021:AvoidOutParameters", MessageId = "1#", Justification = "The design is OK.")]
        public abstract bool SaveSettings(WritableSettings settings, out Exception exception);

        /// <summary>
        /// Saves the settings document at the path specified within the document.
        /// </summary>
        /// <param name="settings">
        /// The settings to save.
        /// </param>
        /// <returns>
        /// Returns true if the document was successfully saved.
        /// </returns>
        public bool SaveSettings(WritableSettings settings)
        {
            Param.Ignore(settings);

            Exception exception;
            return this.SaveSettings(settings, out exception);
        }

        #endregion
    }
}