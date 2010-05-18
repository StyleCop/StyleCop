//-----------------------------------------------------------------------
// <copyright file="StyleCopConsole.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace Microsoft.StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Security;
    using System.Text;
    using System.Xml;

    /// <summary>
    /// Object model for hosting StyleCop within a custom command-line based application.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "StyleCop", Justification = "This is the correct casing.")]
    public sealed class StyleCopConsole : IDisposable
    {
        #region Private Fields

        /// <summary>
        /// The violation count.
        /// </summary>
        private int violationCount;

        /// <summary>
        /// The settings path.
        /// </summary>
        private string settingsPath;

        /// <summary>
        /// The output file path.
        /// </summary>
        private string outputFile;

        /// <summary>
        /// The violations document.
        /// </summary>
        private XmlDocument violations = new XmlDocument();

        /// <summary>
        /// The StyleCop core instance.
        /// </summary>
        private StyleCopCore core;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the StyleCopConsole class.
        /// </summary>
        /// <param name="settings">The path to the settings to load or
        /// null to use the default project settings files.</param>
        /// <param name="writeResultsCache">Indicates whether to write results cache files.</param>
        /// <param name="outputFile">Optional path to the results output file.</param>
        /// <param name="addInPaths">The list of paths to search under for parser and analyzer addins.
        /// Can be null if no addin paths are provided.</param>
        /// <param name="loadFromDefaultPath">Indicates whether to load addins
        /// from the default path, where the core binary is located.</param>
        public StyleCopConsole(
            string settings,
            bool writeResultsCache,
            string outputFile,
            ICollection<string> addInPaths,
            bool loadFromDefaultPath) 
            : this(settings, writeResultsCache, outputFile, addInPaths, loadFromDefaultPath, null)
        {
            Param.Ignore(settings, writeResultsCache, outputFile, addInPaths, loadFromDefaultPath);
        }

        /// <summary>
        /// Initializes a new instance of the StyleCopConsole class.
        /// </summary>
        /// <param name="settings">The path to the settings to load or
        /// null to use the default project settings files.</param>
        /// <param name="writeResultsCache">Indicates whether to write results cache files.</param>
        /// <param name="outputFile">Optional path to the results output file.</param>
        /// <param name="addInPaths">The list of paths to search under for parser and analyzer addins.
        /// Can be null if no addin paths are provided.</param>
        /// <param name="loadFromDefaultPath">Indicates whether to load addins
        /// from the default application path.</param>
        /// <param name="hostTag">An optional tag which can be set by the host.</param>
        public StyleCopConsole(
            string settings, 
            bool writeResultsCache, 
            string outputFile,
            ICollection<string> addInPaths,
            bool loadFromDefaultPath,
            object hostTag)
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

            this.core = new StyleCopCore(null, hostTag);
            this.core.Initialize(addInPaths, loadFromDefaultPath);
            this.core.WriteResultsCache = writeResultsCache;
            this.core.DisplayUI = false;
            this.core.ViolationEncountered += new EventHandler<ViolationEventArgs>(this.CoreViolationEncountered);
            this.core.OutputGenerated += new EventHandler<OutputEventArgs>(this.CoreOutputGenerated);

            XmlElement root = this.violations.CreateElement("StyleCopViolations");
            this.violations.AppendChild(root);
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Event that is fired when output is generated from the console during an analysis.
        /// </summary>
        public event EventHandler<OutputEventArgs> OutputGenerated;

        /// <summary>
        /// Event that is fired when output is generated from the console during an analysis.
        /// </summary>
        public event EventHandler<ViolationEventArgs> ViolationEncountered;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets the StyleCop core instance.
        /// </summary>
        public StyleCopCore Core
        {
            get
            {
                return this.core;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);

            if (this.core != null)
            {
                this.core.Dispose();
            }
        }

        /// <summary>
        /// Starts analyzing the source code documents contained within the given projects.
        /// </summary>
        /// <param name="projects">The projects to analyze.</param>
        /// <param name="fullAnalyze">Determines whether to ignore cache files and reanalyze
        /// every file from scratch.</param>
        /// <returns>Returns false if an error occurs during analysis.</returns>
        public bool Start(IList<CodeProject> projects, bool fullAnalyze)
        {
            Param.RequireNotNull(projects, "projects");
            Param.Ignore(fullAnalyze);

            bool error = false;

            try
            {
                // Load the settings files.
                this.LoadSettingsFiles(projects);

                // Reset the violation count.
                this.violationCount = 0;

                // Delete the output file if it already exists.
                if (!string.IsNullOrEmpty(this.outputFile))
                {
                    this.core.Environment.RemoveAnalysisResults(this.outputFile);
                }

                // Analyze the files.
                if (fullAnalyze)
                {
                    this.core.FullAnalyze(projects);
                }
                else
                {
                    this.core.Analyze(projects);    
                }

                if (this.violationCount > 0)
                {
                    this.OnOutputGenerated(new OutputEventArgs(string.Format(CultureInfo.CurrentCulture, Strings.ViolationsEncountered, this.violationCount)));
                }
                else
                {
                    this.OnOutputGenerated(new OutputEventArgs(Strings.NoViolationsEncountered));
                }

                // Write the output file
                Exception exception;
                if (!this.core.Environment.SaveAnalysisResults(this.outputFile, this.violations, out exception))
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

            return !error;
        }

        #endregion Public Methods

        #region Private Static Methods

        /// <summary>
        /// Creates a safe version of the element name that can be outputted to Xml.
        /// </summary>
        /// <param name="originalName">The original name.</param>
        /// <returns>Returns the safe name.</returns>
        private static string CreateSafeSectionName(string originalName)
        {
            Param.Ignore(originalName);

            if (originalName == null)
            {
                return null;
            }

            int index = originalName.IndexOf('<');
            if (index == -1)
            {
                return originalName;
            }

            StringBuilder builder = new StringBuilder(originalName.Length * 2);

            int startTagCount = 0;

            for (int i = 0; i < originalName.Length; ++i)
            {
                char character = originalName[i];

                if (character == '<')
                {
                    ++startTagCount;
                    builder.Append('`');
                }
                else if (startTagCount > 0)
                {
                    if (character == '>')
                    {
                        --startTagCount;
                    }
                    else if (character == ',')
                    {
                        builder.Append('`');
                    }
                    else if (!char.IsWhiteSpace(character))
                    {
                        builder.Append(character);
                    }
                }
                else
                {
                    builder.Append(character);
                }
            }

            return builder.ToString();
        }
    
        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Called when output is generated during an analysis.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        private void OnOutputGenerated(OutputEventArgs e)
        {
            Param.AssertNotNull(e, "e");

            if (this.OutputGenerated != null)
            {
                this.OutputGenerated(this, e);
            }
        }

        /// <summary>
        /// Called when a violation is encountered during an analysis.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        private void OnViolationEncountered(ViolationEventArgs e)
        {
            Param.AssertNotNull(e, "e");

            if (this.ViolationEncountered != null)
            {
                this.ViolationEncountered(this, e);
            }
        }

        /// <summary>
        /// Loads the settings files to use for the analysis.
        /// </summary>
        /// <param name="projects">The list of projects to use.</param>
        private void LoadSettingsFiles(IList<CodeProject> projects)
        {
            Param.AssertNotNull(projects, "projects");

            Settings mergedSettings = null;

            // Load the local settings without merging.
            Settings localSettings = null;
            if (this.settingsPath != null)
            {
                localSettings = this.core.Environment.GetSettings(this.settingsPath, false);
                if (localSettings != null)
                {
                    // Merge the local settings.
                    SettingsMerger merger = new SettingsMerger(localSettings, this.core.Environment);
                    mergedSettings = merger.MergedSettings;
                }
            }

            foreach (CodeProject project in projects)
            {
                Settings settingsToUse = mergedSettings;
                if (settingsToUse == null)
                {
                    settingsToUse = this.core.Environment.GetProjectSettings(project, true);
                }

                if (settingsToUse != null)
                {
                    project.Settings = settingsToUse;
                    project.SettingsLoaded = true;
                }
            }
        }

        /// <summary>
        /// Called when output should be added to the Output pane.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void CoreOutputGenerated(object sender, OutputEventArgs e)
        {
            Param.Ignore(sender, e);

            lock (this)
            {
                this.OnOutputGenerated(new OutputEventArgs(e.Output, e.Importance));
            }
        }

        /// <summary>
        /// Called when a violation is found.
        /// </summary> 
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void CoreViolationEncountered(object sender, ViolationEventArgs e)
        {
            Param.Ignore(sender, e);

            lock (this)
            {
                // Create the violation element.
                XmlElement violation = this.violations.CreateElement("Violation");
                XmlAttribute attrib = null;
                
                // Add the element section if it's not empty.
                if (e.Element != null)
                {
                    attrib = this.violations.CreateAttribute("Section");
                    attrib.Value = CreateSafeSectionName(e.Element.FullyQualifiedName);
                    violation.Attributes.Append(attrib);
                }

                // Add the line number.
                attrib = this.violations.CreateAttribute("LineNumber");
                attrib.Value = e.LineNumber.ToString(CultureInfo.InvariantCulture);
                violation.Attributes.Append(attrib);

                // Get the source code that this element is in.
                SourceCode sourceCode = e.SourceCode;
                if (sourceCode == null && e.Element != null && e.Element.Document != null)
                {
                    sourceCode = e.Element.Document.SourceCode;
                }

                // Add the source code path.
                if (sourceCode != null)
                {
                    attrib = this.violations.CreateAttribute("Source");
                    attrib.Value = sourceCode.Path;
                    violation.Attributes.Append(attrib);
                }

                // Add the rule namespace.
                attrib = this.violations.CreateAttribute("RuleNamespace");
                attrib.Value = e.Violation.Rule.Namespace;
                violation.Attributes.Append(attrib);

                // Add the rule name.
                attrib = this.violations.CreateAttribute("Rule");
                attrib.Value = e.Violation.Rule.Name;
                violation.Attributes.Append(attrib);

                // Add the rule ID.
                attrib = this.violations.CreateAttribute("RuleId");
                attrib.Value = e.Violation.Rule.CheckId;
                violation.Attributes.Append(attrib);
                
                violation.InnerText = e.Message;

                this.violations.DocumentElement.AppendChild(violation);
                this.violationCount++;
            }

            // Forward event
            this.OnViolationEncountered(new ViolationEventArgs(e.Violation));
        }

        #endregion Private Methods
    }
}
