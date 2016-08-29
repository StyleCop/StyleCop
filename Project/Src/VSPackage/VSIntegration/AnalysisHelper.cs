//--------------------------------------------------------------------------
// <copyright file="AnalysisHelper.cs">
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
//-----------------------------------------------------------------------
namespace StyleCop.VisualStudio
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;
    using System.Xml;
    using EnvDTE;

    using Microsoft.VisualStudio.Shell;

    using StyleCop.Diagnostics;

    /// <summary>
    /// Helper class that facilitates the analysis for the package.
    /// </summary>
    internal abstract class AnalysisHelper : IDisposable
    {
        #region Private Fields

        /// <summary>
        /// System service provider.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

        /// <summary>
        /// The collection of known VS project types and their properties.
        /// </summary>
        private readonly Dictionary<string, Dictionary<string, string>> projectTypes = new Dictionary<string, Dictionary<string, string>>();

        /// <summary>
        /// The StyleCop core object.
        /// </summary>
        private StyleCopCore core;

        /// <summary>
        /// The current violation count.
        /// </summary>
        private int violationCount;

        /// <summary>
        /// Stores the list of violations encountered.
        /// </summary>
        private List<ViolationInfo> violations;

        private AnalysisType analysisType;

        private string analysisFilePath;

        #endregion Private Fields

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the AnalysisHelper class.
        /// </summary>
        /// <param name="serviceProvider">System service provider.</param>
        /// <param name="core">StyleCop engine.</param>
        internal AnalysisHelper(IServiceProvider serviceProvider, StyleCopCore core)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");
            Param.AssertNotNull(core, "core");

            this.serviceProvider = serviceProvider;
            this.core = core;
        }

        #endregion Constructor

        #region Properties

        /// <summary>
        /// Gets the core instance.
        /// </summary>
        internal StyleCopCore Core
        {
            get
            {
                return this.core;
            }
        }

        /// <summary>
        /// Gets the list of known VS project types supported, and their properties.
        /// </summary>
        internal Dictionary<string, Dictionary<string, string>> ProjectTypes
        {
            get
            {
                return this.projectTypes;
            }
        }

        /// <summary>
        /// Gets the system service provider.
        /// </summary>
        protected IServiceProvider ServiceProvider
        {
            get { return this.serviceProvider; }
        }

        #endregion Properties

        #region IDisposable Members

        /// <summary>
        /// Disposed the object.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Initializes the object.
        /// </summary>
        internal void Initialize()
        {
            // Register for StyleCop events.
            this.core.ViolationEncountered += this.CoreViolationEncountered;
            this.core.OutputGenerated += this.CoreOutputGenerated;

            this.RegisterEnvironmentEvents();

            // Extract language specific information from the parsers configurations.
            this.RetrieveParserConfiguration();
        }

        /// <summary>
        /// Gathers the list of files to analyze and kicks off the worker thread.
        /// </summary>
        /// <param name="full">True if a full analyze should be performed.</param>
        /// <param name="type">Type of files that should be analyzed.</param>
        internal void Analyze(bool full, AnalysisType type)
        {
            Param.Ignore(full, type);
            StyleCopTrace.In(full, type);

            // Save any documents that have been changed.
            if (this.SaveOpenDocuments())
            {
                // Get the list of projects to be analyzed.
                // Depending on the AnalysisType we:
                //// 1. analyze all the files in the solution/project/folder
                //// 2. analyze the selected file in the solution browser/code pane
                //// 3. If its a single file we may still analyze multiple files. We do this if the selected file has a dependancy on another file.
                ////    so if you analyze a designer.cs file we actually analyze the parent file and all its dependants.
                ////    This is generally because we can only be sure of issues relating to partial
                ////    types if we have all the partial types to check against.
                IList<CodeProject> projects = ProjectUtilities.GetProjectList(this.core, type, out this.analysisFilePath, this);

                this.analysisType = type;
                this.ClearEnvironmentPriorToAnalysis();

                this.SignalAnalysisStarted();

                this.violationCount = 0;

                if (projects.Count == 0)
                {
                    this.NoFilesToAnalyze();
                }
                else
                {
                    AnalysisThread analyze = new AnalysisThread(full, projects, this.core);
                    analyze.Complete += this.AnalyzeComplete;
                    System.Threading.Thread thread = new System.Threading.Thread(analyze.AnalyzeProc);

                    if (thread != null)
                    {
                        thread.IsBackground = true;

                        this.violations = new List<ViolationInfo>();

                        thread.Start();
                    }
                }
            }

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Displays the settings for the local settings file.
        /// </summary>
        internal void LocalProjectSettings()
        {
            // Get the active project.
            Project project = ProjectUtilities.GetActiveProject();

            // Get the path to the local settings file for this project.
            string localSettingsFileFolder = ProjectUtilities.GetProjectPath(project);
            if (localSettingsFileFolder == null)
            {
                AlertDialog.Show(
                    this.core,
                    null,
                    Strings.CantGetProjectPath,
                    Strings.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                // Show the local settings dialog.
                string settingsFilePath = Path.Combine(localSettingsFileFolder, Settings.DefaultFileName);
                if (!File.Exists(settingsFilePath))
                {
                    string deprecatedSettingsFile = Path.Combine(localSettingsFileFolder, Settings.AlternateFileName);
                    if (File.Exists(deprecatedSettingsFile))
                    {
                        settingsFilePath = deprecatedSettingsFile;
                    }
                    else
                    {
                        deprecatedSettingsFile = Path.Combine(localSettingsFileFolder, V101Settings.DefaultFileName);
                        if (File.Exists(deprecatedSettingsFile))
                        {
                            settingsFilePath = deprecatedSettingsFile;
                        }
                    }
                }

                this.core.AddSettingsPages += this.StyleCopCoreAddSettingsPages;
                this.core.ShowSettings(settingsFilePath);
                this.core.AddSettingsPages -= this.StyleCopCoreAddSettingsPages;
            }
        }

        /// <summary>
        /// Cancels the currently running analysis.
        /// </summary>
        internal void Cancel()
        {
            this.core.Cancel = true;
        }

        #endregion Internal Methods

        #region Protected Methods

        /// <summary>
        /// Disposes the contents of the class.
        /// </summary>
        /// <param name="disposing">Indicates whether to dispose unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            Param.Ignore(disposing);

            if (disposing)
            {
                if (this.core != null)
                {
                    // Unregister for StyleCop events.
                    this.core.ViolationEncountered -= this.CoreViolationEncountered;
                    this.core.OutputGenerated -= this.CoreOutputGenerated;
                    this.core = null;
                }
            }
        }

        /// <summary>
        /// Clears the environment prior to analysis.
        /// </summary>
        protected virtual void ClearEnvironmentPriorToAnalysis()
        {
        }

        /// <summary>
        /// Signals the helper to output that analysis has begun.
        /// </summary>
        protected virtual void SignalAnalysisStarted()
        {
        }

        /// <summary>
        /// Signals the helper to indicate that no files were available for analysis.
        /// </summary>
        protected virtual void NoFilesToAnalyze()
        {
        }

        /// <summary>
        /// Saves any open document that matches a type specified by one of the parsers.
        /// </summary>
        /// <returns>Returns true if all documents were saved, or false if one or more
        /// documents were unable to be saved.</returns>
        protected virtual bool SaveOpenDocuments()
        {
            return true;
        }

        /// <summary>
        /// Register for the environment events.
        /// </summary>
        protected virtual void RegisterEnvironmentEvents()
        {
        }

        /// <summary>
        /// Provides the end analysis result to the user.
        /// </summary>
        /// <param name="violationsResult">The violations.</param>
        protected virtual void ProvideEndAnalysisResult(List<ViolationInfo> violationsResult)
        {
            Param.Ignore(violationsResult);
        }

        #endregion Protected Methods

        #region Private Methods

        /// <summary>
        /// Reads parser configuration xml and initializes the dictionary 'projectFullPaths' based on the information in it.
        /// </summary>
        /// <remarks>
        /// Format of the xml that must be found in "SourceParser" tag in the Parser xml:
        ///   <![CDATA[
        ///   <VsProjectLocation>
        ///     <!-- PropertyName is the property name in the EnvDTE.Project's properties collection that specifies the full path to the directory of the project file. -->
        ///     <PropertyName>FullPath</PropertyName>
        ///     <!-- ProjectKind is the guid that identifies the project kind, or in other words the language type C#/C++ etc.
        ///          The C# language kind is defined by prjKindCSharpProject in VSLangProj.DLL.
        ///          The VB language kind is defined by prjKindVBProject  in VSLangProj.DLL.
        ///          Also look at dte.idl for various vsProjectKind* constants that could be returned by other projects.  
        ///     -->
        ///     <ProjectKind>FAE04EC0-301F-11D3-BF4B-00C04F79EFBC</ProjectKind>
        ///   </VsProjectLocation>
        ///   ]]>
        /// </remarks>
        private void RetrieveParserConfiguration()
        {
            Debug.Assert(this.core != null, "core has not been initialized");
            Debug.Assert(this.core.Parsers != null, "core parsers has not been initialized.");

            foreach (SourceParser parser in this.core.Parsers)
            {
                XmlDocument document = StyleCopCore.LoadAddInResourceXml(parser.GetType(), null);

                // Using plenty of exceptions with regards to the information drawn from the configuration xml.
                // An alternative would of course be to validate against a schema.
                XmlNodeList projectTypeNodes = document.DocumentElement.SelectNodes("VsProjectTypes/VsProjectType");

                if (projectTypeNodes != null)
                {
                    foreach (XmlNode projectTypeNode in projectTypeNodes)
                    {
                        // Find the ProjectKind attribute
                        XmlNode projectKindNode = projectTypeNode.Attributes["ProjectKind"];
                        if (projectKindNode == null)
                        {
                            string errorMessage = Strings.MalFormedVsProjectLocationNode;
                            errorMessage = string.Format(CultureInfo.CurrentCulture, errorMessage, Strings.NoProjectKindNodeFound);
                            throw new InvalidDataException(errorMessage);
                        }

                        // Determine the project kind 
                        string projectKind = projectKindNode.InnerText.Trim();
                        if (string.IsNullOrEmpty(projectKind))
                        {
                            string errorMessage = Strings.MalFormedVsProjectLocationNode;
                            string subMessage = string.Format(CultureInfo.CurrentCulture, Strings.EmptyChildNode, "ProjectKind");
                            errorMessage = string.Format(CultureInfo.CurrentCulture, errorMessage, subMessage);
                            throw new InvalidDataException(errorMessage);
                        }

                        // Get or create the property collection for the project type.
                        Dictionary<string, string> projectProperties = null;
                        if (!this.projectTypes.TryGetValue(projectKind, out projectProperties))
                        {
                            projectProperties = new Dictionary<string, string>();
                            this.projectTypes.Add(projectKind, projectProperties);
                        }

                        // Determine the project path property name value
                        string projectPathPropertyName = null;
                        XmlNode projectPathPropertyNameNode = projectTypeNode.SelectSingleNode("ProjectPathPropertyName");
                        if (projectPathPropertyNameNode != null)
                        {
                            projectPathPropertyName = projectPathPropertyNameNode.InnerText.Trim();
                            if (string.IsNullOrEmpty(projectPathPropertyName))
                            {
                                string errorMessage = Strings.MalFormedVsProjectLocationNode;
                                string subMessage = string.Format(CultureInfo.CurrentCulture, Strings.EmptyChildNode, "PropertyName");
                                errorMessage = string.Format(CultureInfo.CurrentCulture, errorMessage, subMessage);
                                throw new InvalidDataException(errorMessage);
                            }
                        }

                        string existingPropertyName = null;
                        if (!projectProperties.TryGetValue("ProjectPath", out existingPropertyName))
                        {
                            // Add the new information to the dictionary
                            projectProperties.Add("ProjectPath", projectPathPropertyName);
                        }
                        else
                        {
                            // Allow this to succeed at runtime.
                            Debug.Fail("A previously loaded parser already registered a property name for the Project Full Path with regards to the project kind: " + projectKind);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when output should be added to the Output pane.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">Contains the output string.</param>
        private void CoreOutputGenerated(object sender, OutputEventArgs e)
        {
            Param.Ignore(sender, e);

            // Make sure this is running on the main thread.
            if (InvisibleForm.Instance.InvokeRequired)
            {
                EventHandler<OutputEventArgs> outputDelegate = this.CoreOutputGenerated;

                InvisibleForm.Instance.Invoke(outputDelegate, sender, e);
            }
            else
            {
                var pane = VSWindows.GetInstance(this.serviceProvider).OutputPane;
                if (pane != null)
                {
                    pane.OutputLine(e.Output);
                }
            }
        }

        /// <summary>
        /// Called when the analyze thread has completed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AnalyzeComplete(object sender, EventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(e);

            StyleCopTrace.In(sender, e);

            if (InvisibleForm.Instance.InvokeRequired)
            {
                EventHandler complete = this.AnalyzeCompleteMain;
                InvisibleForm.Instance.Invoke(complete, sender, e);
            }
            else
            {
                this.AnalyzeCompleteMain(sender, e);
            }

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Called when the analyze thread has completed.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AnalyzeCompleteMain(object sender, EventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(e);

            StyleCopTrace.In(sender, e);

            var pane = VSWindows.GetInstance(this.serviceProvider).OutputPane;
            if (pane != null)
            {
                if (this.core.Cancel)
                {
                    pane.OutputLine(string.Format(CultureInfo.InvariantCulture, Strings.MiniLogBreak, Strings.Cancelled));
                }
                else
                {
                    pane.OutputLine(string.Format(CultureInfo.InvariantCulture, Strings.MiniLogBreak, Strings.Done));
                    pane.OutputLine(string.Format(CultureInfo.InvariantCulture, Strings.ViolationCount, this.violationCount));
                }
            }

            if (this.violationCount > 0)
            {
                this.ProvideEndAnalysisResult(this.violations);
                this.violations = null;
            }

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Called when a violation is found.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void CoreViolationEncountered(object sender, ViolationEventArgs e)
        {
            Param.AssertNotNull(e, "e");
            Param.Ignore(sender);

            // Make sure this is running on the main thread.
            if (InvisibleForm.Instance.InvokeRequired)
            {
                EventHandler<ViolationEventArgs> violationDelegate = this.CoreViolationEncountered;
                InvisibleForm.Instance.Invoke(violationDelegate, sender, e);
            }
            else
            {
                // Check the violation only occured in the file we were analysing (or we were analysing a solution/project/folder)
                var sourceCodePath = e.SourceCode.Path;
                var documentFullName = this.analysisFilePath;

                if ((this.analysisType == AnalysisType.File && sourceCodePath.Equals(documentFullName, StringComparison.OrdinalIgnoreCase))
                    || this.analysisType == AnalysisType.Folder || this.analysisType == AnalysisType.Project || this.analysisType == AnalysisType.Solution
                    || this.analysisType == AnalysisType.Item)
                {
                    if (!e.Warning)
                    {
                        ++this.violationCount;
                    }

                    // Check the count. At some point we don't allow any more violations so we cancel the analyze run.
                    if (e.SourceCode.Project.MaxViolationCount > 0 && this.violationCount == e.SourceCode.Project.MaxViolationCount)
                    {
                        this.Cancel();
                    }

                    var element = e.Element;
                    var violationInfo = new ViolationInfo();

                    violationInfo.Severity = e.SourceCode.Project.ViolationsAsErrors ? TaskErrorCategory.Error : TaskErrorCategory.Warning;

                    var trimmedNamespace = e.Violation.Rule.Namespace.SubstringAfter("StyleCop.", StringComparison.Ordinal);
                    trimmedNamespace = trimmedNamespace.SubstringBeforeLast("Rules", StringComparison.Ordinal);

                    violationInfo.Description = string.Concat(e.Violation.Rule.CheckId, " : ", trimmedNamespace, " : ", e.Message);
                    violationInfo.LineNumber = e.LineNumber;

                    violationInfo.ColumnNumber = e.Location != null ? e.Location.Value.StartPoint.IndexOnLine : 1;

                    violationInfo.Rule = e.Violation.Rule;

                    if (element != null)
                    {
                        violationInfo.File = element.Document.SourceCode.Path;
                    }
                    else
                    {
                        string file = string.Empty;
                        if (e.SourceCode != null)
                        {
                            file = e.SourceCode.Path;
                        }

                        violationInfo.File = file;
                    }

                    this.violations.Add(violationInfo);
                }
            }
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "OK here.")]
        private void StyleCopCoreAddSettingsPages(object sender, AddSettingsPagesEventArgs e)
        {
            Param.Ignore(sender);
            Param.AssertNotNull(e, "e");

            Project project = ProjectUtilities.GetActiveProject();
            string fullName = ProjectUtilities.GetProjectFullName(project);
            if (string.IsNullOrEmpty(fullName))
            {
                return;
            }

            project.Save();

            var proj = new Microsoft.Build.Evaluation.Project(
                project.FullName, null, null, new Microsoft.Build.Evaluation.ProjectCollection());
            e.Add(new BuildIntegrationOptions(proj));
        }

        #endregion Private Methods
    }
}