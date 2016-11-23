// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopConsole.cs" company="https://github.com/StyleCop">
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
//   A lightweight host for StyleCop which loads source files and settings files from the file system.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Security;
    using System.Xml;

    using StyleCop.Diagnostics;

    /// <summary>
    /// A lightweight host for StyleCop which loads source files and settings files from the file system.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "StyleCop", Justification = "This is the correct casing.")]
    public sealed class StyleCopConsole : StyleCopRunner
    {
        #region Fields

        /// <summary>
        /// The output file path.
        /// </summary>
        private readonly string outputFile;

        /// <summary>
        /// The settings path.
        /// </summary>
        private readonly string settingsPath;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the StyleCopConsole class.
        /// </summary>
        /// <param name="settings">
        /// The path to the settings to load or
        /// null to use the default project settings files.
        /// </param>
        /// <param name="writeResultsCache">
        /// Indicates whether to write results cache files.
        /// </param>
        /// <param name="outputFile">
        /// Optional path to the results output file.
        /// </param>
        /// <param name="addInPaths">
        /// The list of paths to search under for parser and analyzer addins.
        /// Can be null if no addin paths are provided.
        /// </param>
        /// <param name="loadFromDefaultPath">
        /// Indicates whether to load addins
        /// from the default path, where the core binary is located.
        /// </param>
        public StyleCopConsole(string settings, bool writeResultsCache, string outputFile, ICollection<string> addInPaths, bool loadFromDefaultPath)
            : this(settings, writeResultsCache, outputFile, addInPaths, loadFromDefaultPath, null)
        {
            Param.Ignore(settings, writeResultsCache, outputFile, addInPaths, loadFromDefaultPath);
        }

        /// <summary>
        /// Initializes a new instance of the StyleCopConsole class.
        /// </summary>
        /// <param name="settings">
        /// The path to the settings to load or
        /// null to use the default project settings files.
        /// </param>
        /// <param name="writeResultsCache">
        /// Indicates whether to write results cache files.
        /// </param>
        /// <param name="outputFile">
        /// Optional path to the results output file.
        /// </param>
        /// <param name="addInPaths">
        /// The list of paths to search under for parser and analyzer addins.
        /// Can be null if no addin paths are provided.
        /// </param>
        /// <param name="loadFromDefaultPath">
        /// Indicates whether to load addins
        /// from the default application path.
        /// </param>
        /// <param name="hostTag">
        /// An optional tag which can be set by the host.
        /// </param>
        public StyleCopConsole(string settings, bool writeResultsCache, string outputFile, ICollection<string> addInPaths, bool loadFromDefaultPath, object hostTag)
        {
            Param.Ignore(settings);
            Param.Ignore(outputFile);
            Param.Ignore(writeResultsCache);
            Param.Ignore(addInPaths);
            Param.Ignore(loadFromDefaultPath);
            Param.Ignore(hostTag);

            this.settingsPath = settings;

            if (outputFile == null)
            {
                this.outputFile = "StyleCopViolations.xml";
            }
            else
            {
                this.outputFile = outputFile;
            }

            this.Core = new StyleCopCore(null, hostTag);
            this.CaptureViolations = true;
            this.Core.Initialize(addInPaths, loadFromDefaultPath);
            this.Core.WriteResultsCache = writeResultsCache;
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Starts analyzing the source code documents contained within the given projects.
        /// </summary>
        /// <param name="projects">
        /// The projects to analyze.
        /// </param>
        /// <param name="fullAnalyze">
        /// Determines whether to ignore cache files and reanalyze
        /// every file from scratch.
        /// </param>
        /// <returns>
        /// Returns false if an error occurs during analysis.
        /// </returns>
        public bool Start(IList<CodeProject> projects, bool fullAnalyze)
        {
            Param.RequireNotNull(projects, "projects");
            Param.Ignore(fullAnalyze);
            StyleCopTrace.In(projects, fullAnalyze);

            bool error = false;

            try
            {
                // Load the settings files.
                this.LoadSettingsFiles(projects);

                // Reset the violation count.
                this.Reset();

                // Delete the output file if it already exists.
                if (!string.IsNullOrEmpty(this.outputFile))
                {
                    this.Core.Environment.RemoveAnalysisResults(this.outputFile);
                }

                // Analyze the files.
                if (fullAnalyze)
                {
                    this.Core.FullAnalyze(projects);
                }
                else
                {
                    this.Core.Analyze(projects);
                }

                if (this.ViolationCount > 0)
                {
                    this.OnOutputGenerated(new OutputEventArgs(string.Format(CultureInfo.CurrentCulture, Strings.ViolationsEncountered, this.ViolationCount)));
                }
                else
                {
                    this.OnOutputGenerated(new OutputEventArgs(Strings.NoViolationsEncountered));
                }

                StyleCopTrace.Info("about to write analysis results");

                // Write the output file
                Exception exception;
                if (!this.Core.Environment.SaveAnalysisResults(this.outputFile, this.Violations, out exception))
                {
                    string message = (exception == null)
                                         ? Strings.CouldNotSaveViolationsFile
                                         : string.Format(CultureInfo.CurrentCulture, Strings.CouldNotSaveViolationsFileWithException, exception.Message);

                    this.OnOutputGenerated(new OutputEventArgs(message));
                    error = true;
                }
            }
            catch (IOException ioex)
            {
                this.OnOutputGenerated(new OutputEventArgs(string.Format(CultureInfo.CurrentCulture, Strings.AnalysisErrorOccurred, ioex.Message)));
                error = true;
            }
            catch (XmlException xmlex)
            {
                this.OnOutputGenerated(new OutputEventArgs(string.Format(CultureInfo.CurrentCulture, Strings.AnalysisErrorOccurred, xmlex.Message)));
                error = true;
            }
            catch (SecurityException secex)
            {
                this.OnOutputGenerated(new OutputEventArgs(string.Format(CultureInfo.CurrentCulture, Strings.AnalysisErrorOccurred, secex.Message)));
                error = true;
            }
            catch (UnauthorizedAccessException unauthex)
            {
                this.OnOutputGenerated(new OutputEventArgs(string.Format(CultureInfo.CurrentCulture, Strings.AnalysisErrorOccurred, unauthex.Message)));
                error = true;
            }

            StyleCopTrace.Out();

            return !error;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the settings files to use for the analysis.
        /// </summary>
        /// <param name="projects">
        /// The list of projects to use.
        /// </param>
        private void LoadSettingsFiles(IList<CodeProject> projects)
        {
            Param.AssertNotNull(projects, "projects");

            Settings mergedSettings = null;

            // Load the local settings without merging.
            Settings localSettings = null;
            if (this.settingsPath != null)
            {
                localSettings = this.Core.Environment.GetSettings(this.settingsPath, false);
                if (localSettings != null)
                {
                    // Merge the local settings.
                    SettingsMerger merger = new SettingsMerger(localSettings, this.Core.Environment);
                    mergedSettings = merger.MergedSettings;
                }
            }

            foreach (CodeProject project in projects)
            {
                Settings settingsToUse = mergedSettings;
                if (settingsToUse == null)
                {
                    settingsToUse = this.Core.Environment.GetProjectSettings(project, true);
                }

                if (settingsToUse != null)
                {
                    project.Settings = settingsToUse;
                    project.SettingsLoaded = true;
                }
            }
        }

        #endregion
    }
}