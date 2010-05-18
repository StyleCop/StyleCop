//-----------------------------------------------------------------------
// <copyright file="StyleCopThread.cs" company="Microsoft">
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
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Text;
    using System.Threading;
    using Microsoft.Build.Framework;

    /// <summary>
    /// StyleCop analyze thread.
    /// </summary>
    internal partial class StyleCopThread
    {
        #region Private Fields

        /// <summary>
        /// The data for this worker thread.
        /// </summary>
        private Data data;

        /// <summary>
        /// Indicates whether the analysis of all files is complete.
        /// </summary>
        private bool complete;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the StyleCopThread class.
        /// </summary>
        /// <param name="data">The thread data.</param>
        public StyleCopThread(Data data)
        {
            Param.AssertNotNull(data, "data");
            this.data = data;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Event that is fired when the thread is completed.
        /// </summary>
        public event EventHandler<StyleCopThreadCompletedEventArgs> ThreadCompleted;

        #endregion Public Events

        #region Public Properties

        /// <summary>
        /// Gets a value indicating whether the analysis of all source code documents is complete.
        /// </summary>
        public bool Complete
        {
            get
            {
                return this.complete;
            }
        }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Runs the thread operation.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Cannot allow exception from plug-in to kill VS or build")]
        public void DoWork(object sender, DoWorkEventArgs e)
        {
            Param.Ignore(sender, e);

            // This flag will indicated whether any source code documents need to passed through 
            // another round of analysis after this one is completed.
            this.complete = true;

            SourceCode sourceCode = null;

            try
            {
                // Keep looping until all the source code documents have been processed.
                while (!this.data.Core.Cancel)
                {
                    DocumentAnalysisStatus documentStatus = null;

                    lock (this.data)
                    {
                        // Get the next document to analyze.
                        sourceCode = this.data.GetNextSourceCodeDocument();
                        if (sourceCode == null)
                        {
                            // There are no more documents. Break out of the loop.
                            break;
                        }

                        // Get the status object for this document.
                        documentStatus = this.data.GetDocumentStatus(sourceCode);
                        Debug.Assert(documentStatus != null, "There is no DocumentStatus for the given SourceCode.");
                    }

                    // If this is the first time we have seen this document, prepare it for analysis.
                    if (!documentStatus.Initialized)
                    {
                        // If the document does not exist, or if the document's analysis data can
                        // be loaded from the results cache, mark the document as completed.
                        if (!sourceCode.Exists || this.LoadSourceCodeFromResultsCache(sourceCode))
                        {
                            documentStatus.Complete = true;
                        }

                        // Note that the document status has been initialized now.
                        documentStatus.Initialized = true;
                    }

                    // Check whether this document needs further parsing.
                    if (!documentStatus.Complete)
                    {
                        this.ParseAndAnalyzeDocument(sourceCode, documentStatus);
                    }
                }
            }
            catch (OutOfMemoryException)
            {
                // Do not catch out of memory exceptions.
                throw;
            }
            catch (ThreadAbortException)
            {
                // The thread is being aborted. Stop this thread from doing any additional analysis.
            }
            catch (Exception ex)
            {
                // Catch exceptions from the parser and analyzer modules.
                System.Diagnostics.Trace.WriteLine(string.Format(CultureInfo.CurrentCulture, "Exception occurred: {0}, {1}", ex.GetType(), ex.Message));
                this.data.Core.CoreViolations.AddViolation(sourceCode, 1, Rules.ExceptionOccurred, ex.GetType(), FormatExceptionMessage(ex));

                // Do not re-throw the exception as this can crash Visual Studio or the build system that StyleCop is running under.
            }
            finally
            {
                // Send out the data object as the result of this worker thread so that the 
                // finalization event can get access to it.
                e.Result = this.data;

                // Fire the completion event if necessary. When running under Visual Studio using MSBuild, the standard
                // completion event from the BackgroundWorker class does not get fired. The reason is unknown. We fire
                // our own event instead to get around this problem.
                if (this.ThreadCompleted != null)
                {
                    this.ThreadCompleted(this, new StyleCopThreadCompletedEventArgs(this.data));
                }
            }
        }

        #endregion Public Methods

        #region Private Static Methods

        /// <summary>
        /// Loads the list of analyzers for the given project after looking at the project settings.
        /// </summary>
        /// <param name="core">The core instance.</param>
        /// <param name="project">The project to check.</param>
        /// <param name="parsers">The list of parsers current loaded.</param>
        /// <returns>Returns the list of analyzers discovered for this project.</returns>
        private static ICollection<SourceAnalyzer> DiscoverAnalyzerList(
            StyleCopCore core, CodeProject project, ICollection<SourceParser> parsers)
        {
            Param.AssertNotNull(core, "core");
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(parsers, "parsers");

            // Create the list of enabled analyzers and rules which will be returned.
            List<SourceAnalyzer> list = new List<SourceAnalyzer>();

            // Iterate through all loaded parsers.
            foreach (SourceParser parser in parsers)
            {
                // Iterate through each analyzer attached to this parser.
                foreach (SourceAnalyzer analyzer in parser.Analyzers)
                {
                    // Create a dictionary to hold each enabled rule for the analyzer.
                    Dictionary<string, Rule> enabledRulesForAnalyzer = new Dictionary<string, Rule>();

                    // Get the settings for this analyzer, if there are any.
                    AddInPropertyCollection analyzerSettings = project.Settings == null ?
                        null : project.Settings.GetAddInSettings(analyzer);

                    // Iterate through each of the analyzer's rules.
                    foreach (Rule rule in analyzer.AddInRules)
                    {
                        // Determine whether the rule is currently enabled.
                        bool ruleEnabled = !core.AddinsDisabledByDefault && rule.EnabledByDefault;

                        // Determine whether there is a setting which enables or disables the rules.
                        // If the rule is set to CanDisable = false, then ignore the setting unless
                        // we are in disabled by default mode.
                        if (analyzerSettings != null && (!ruleEnabled || rule.CanDisable))
                        {
                            BooleanProperty property = analyzerSettings[rule.Name + "#Enabled"] as BooleanProperty;
                            if (property != null)
                            {
                                ruleEnabled = property.Value;
                            }
                        }

                        // If the rule is enabled, add it to the enabled rules dictionary.
                        if (ruleEnabled)
                        {
                            enabledRulesForAnalyzer.Add(rule.Name, rule);
                        }
                    }

                    // If the analyzer has at least one enabled rule, add the analyzer to the list 
                    // of enabled analyzers.
                    if (enabledRulesForAnalyzer.Count > 0)
                    {
                        list.Add(analyzer);

                        // The enables rules dictionary should have been created.
                        Debug.Assert(analyzer.EnabledRules != null, "The enabled rules dictionary should not be null");

                        // The rules list should not already be set for this project on this analyzer.
                        // If so, something is wrong.
                        Debug.Assert(
                            !analyzer.EnabledRules.ContainsKey(project),
                            "The rule list for this analyzer on this code project should not be set yet.");

                        // Store the list of enabled rules within the analyzer so it can be quickly
                        // accessed at runtime.
                        analyzer.EnabledRules.Add(project, enabledRulesForAnalyzer);
                    }
                }
            }

            return list;
        }

        /// <summary>
        /// Formats the exception message and stack trace into a loggable string.
        /// </summary>
        /// <param name="ex">The exception.</param>
        /// <returns>Returns the formatted message.</returns>
        private static string FormatExceptionMessage(Exception ex)
        {
            Param.Ignore(ex);
            if (ex == null)
            {
                return string.Empty;
            }

            StringBuilder s = new StringBuilder();
            if (!string.IsNullOrEmpty(ex.Message))
            {
                s.Append(ex.Message);
                s.Append("\n");
            }

            if (!string.IsNullOrEmpty(ex.StackTrace))
            {
                s.Append(ex.StackTrace);
            }

            return s.ToString();
        }

        #endregion Private Static Methods

        #region Private Methods

        /// <summary>
        /// Parses and analyzes the given document.
        /// </summary>
        /// <param name="sourceCode">The document to parse and analyze.</param>
        /// <param name="documentStatus">The current status of the documents.</param>
        private void ParseAndAnalyzeDocument(SourceCode sourceCode, DocumentAnalysisStatus documentStatus)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(documentStatus, "documentStatus");

            // Signal the output for this document.
            this.data.Core.SignalOutput(
                MessageImportance.Low,
                string.Format(CultureInfo.CurrentCulture, "Pass {0}: {1}...\n", this.data.PassNumber + 1, sourceCode.Name));

            // Extract the document to parse.
            CodeDocument parsedDocument = documentStatus.Document;

            // Get or load the analyzer list for this project type.
            ICollection<SourceAnalyzer> analyzers = this.GetAnalyzersForProjectFile(
                sourceCode.Project, sourceCode, this.data.Core.Parsers);

            // Parse the document.
            bool parsingCompleted;
            try
            {
                parsingCompleted = !sourceCode.Parser.ParseFile(sourceCode, this.data.PassNumber, ref parsedDocument);
            }
            catch (System.Exception)
            {
                string details = string.Format(
                        CultureInfo.CurrentCulture,
                        "Exception thrown by parser '{0}' while processing '{1}'.",
                        sourceCode.Parser.Name,
                        sourceCode.Path);

                this.data.Core.SignalOutput(MessageImportance.High, details);
                throw;
            }

            if (parsingCompleted)
            {
                if (parsedDocument == null)
                {
                    documentStatus.Complete = true;
                }
                else if (this.TestAndRunAnalyzers(parsedDocument, sourceCode.Parser, analyzers, this.data.PassNumber))
                {
                    // Analysis of this document is completed.
                    documentStatus.Complete = true;

                    // Save the cache for this document and dispose it.
                    if (parsedDocument != null)
                    {
                        if (this.data.ResultsCache != null && sourceCode.Project.WriteCache)
                        {
                            this.data.ResultsCache.SaveDocumentResults(parsedDocument, sourceCode.Parser, sourceCode.Project.Settings.WriteTime);
                        }

                        parsedDocument.Dispose();
                        parsedDocument = null;
                    }
                }
            }

            if (!documentStatus.Complete)
            {
                // Analysis of this document is not complete, so we will need to 
                // perform another round of analysis after this one is finished.
                this.complete = false;

                // Cache the document if there is one.
                if (parsedDocument != null)
                {
                    documentStatus.Document = parsedDocument;
                }
            }
        }

        /// <summary>
        /// Runs the analyzers against the given document.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="parser">The parser that created the document.</param>
        /// <param name="analyzers">The analyzers to run against the document.</param>
        /// <param name="passNumber">The current pass number.</param>
        /// <returns>Returns true if analysis was run, or false if analysis was delayed until the next pass.</returns>
        private bool TestAndRunAnalyzers(
            CodeDocument document, SourceParser parser, ICollection<SourceAnalyzer> analyzers, int passNumber)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parser, "parser");
            Param.Ignore(analyzers);
            Param.Ignore(passNumber);

            if (analyzers == null)
            {
                return true;
            }

            // Determine whether any of the analyzers wish to delay parsing until the next pass.
            bool delay = false;
            foreach (SourceAnalyzer analyzer in analyzers)
            {
                if (analyzer.DelayAnalysis(document, passNumber))
                {
                    delay = true;
                    break;
                }
            }

            if (!delay)
            {
                this.RunAnalyzers(document, parser, analyzers);
            }

            return !delay;
        }

        /// <summary>
        /// Runs the list of analyzers against the given document.
        /// </summary>
        /// <param name="document">The document to analyze.</param>
        /// <param name="parser">The parser that created the document.</param>
        /// <param name="analyzers">The list of analyzsers to run against the document.</param>
        private void RunAnalyzers(
            CodeDocument document, SourceParser parser, ICollection<SourceAnalyzer> analyzers)
        {
            Param.AssertNotNull(document, "document");
            Param.AssertNotNull(parser, "parser");
            Param.Ignore(analyzers, "analyzers");

            if (analyzers != null)
            {
                if (parser.SkipAnalysisForDocument(document))
                {
                    this.data.Core.SignalOutput(
                        MessageImportance.Normal,
                        string.Format(CultureInfo.CurrentCulture, "Skipping {0}...", document.SourceCode.Name));
                }
                else
                {
                    // Loop through each of the analyzers attached to the parser.
                    foreach (SourceAnalyzer analyzer in analyzers)
                    {
                        // Make sure the user hasn't cancelled us.
                        if (this.data.Core.Cancel)
                        {
                            break;
                        }

                        SourceParser.ClearAnalyzerTags(document);
                        try
                        {
                            analyzer.AnalyzeDocument(document);
                        }
                        catch (System.Exception)
                        {
                            string details = string.Format(
                                    CultureInfo.CurrentCulture,
                                    "Exception thrown by analyzer '{0}' while processing '{1}'.",
                                    analyzer.Name,
                                    document.SourceCode.Path);

                            this.data.Core.SignalOutput(MessageImportance.High, details);
                            throw;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to load results for the given document from the cache.
        /// </summary>
        /// <param name="sourceCode">The source code document to load.</param>
        /// <returns>Returns true if the results were loaded from the cache.</returns>
        private bool LoadSourceCodeFromResultsCache(SourceCode sourceCode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");

            if (!this.data.IgnoreResultsCache && this.data.Core.Environment.SupportsResultsCache && this.data.ResultsCache != null)
            {
                // Check the project to see if the cache should be ignored.
                ProjectStatus projectStatus = this.data.GetProjectStatus(sourceCode.Project);
                Debug.Assert(projectStatus != null, "There is no status for the given project.");

                if (!projectStatus.IgnoreResultsCache)
                {
                    // Get the last write time for this file.
                    DateTime lastWriteTime = sourceCode.TimeStamp;

                    // Attempt to load the file from the cache.
                    if (this.data.ResultsCache.LoadResults(
                        sourceCode, sourceCode.Parser, lastWriteTime, sourceCode.Project.Settings.WriteTime))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the list of analyzers for the given source code document in the given project.
        /// </summary>
        /// <param name="project">The project containing the document.</param>
        /// <param name="sourceCode">The source code document.</param>
        /// <param name="parsers">The list of parsers current loaded.</param>
        /// <returns>Returns the analyzer list.</returns>
        private ICollection<SourceAnalyzer> GetAnalyzersForProjectFile(
            CodeProject project, SourceCode sourceCode, ICollection<SourceParser> parsers)
        {
            Param.AssertNotNull(project, "project");
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(parsers, "parsers");

            if (!string.IsNullOrEmpty(sourceCode.Type))
            {
                // Get the project status for this project.
                ProjectStatus projectStatus = this.data.GetProjectStatus(project);
                Debug.Assert(projectStatus != null, "There is no status for the given project.");

                lock (projectStatus.AnalyzerLists)
                {
                    // Get the analyzer list from cache if it's there.
                    ICollection<SourceAnalyzer> analyzers = null;
                    if (!projectStatus.AnalyzerLists.TryGetValue(sourceCode.Type, out analyzers))
                    {
                        // Load the list of disabled analyzers from the project settings and create the list of analyzers manually.
                        analyzers = StyleCopThread.DiscoverAnalyzerList(this.data.Core, project, parsers);
                        projectStatus.AnalyzerLists.Add(sourceCode.Type, analyzers);

                        foreach (SourceAnalyzer analyzer in analyzers)
                        {
                            this.data.Core.SignalOutput(
                                MessageImportance.Low,
                                string.Format(CultureInfo.CurrentCulture, "Loaded Analyzer: {0}...", analyzer.Name));
                        }
                    }

                    return analyzers;
                }
            }

            return null;
        }

        #endregion Private Methods
    }
}
