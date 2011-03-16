//-----------------------------------------------------------------------
// <copyright file="StyleCopThread.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace StyleCop
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
            ICodeDocument parsedDocument = documentStatus.Document;

            // Get or load the analyzer list.
            IEnumerable<SourceAnalyzer> analyzers = sourceCode.Settings.EnabledAnalyzers;

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
                else
                {
                    if (this.data.RunContext.AutoFix)
                    {
                        parsedDocument.ReadOnly = false;
                    }

                    if (this.TestAndRunAnalyzers(parsedDocument, sourceCode.Parser, analyzers, this.data.PassNumber))
                    {
                        // Analysis of this document is completed.
                        documentStatus.Complete = true;

                        // Save the cache for this document and dispose it.
                        if (parsedDocument != null)
                        {
                            if (this.data.ResultsCache != null && sourceCode.Project.WriteCache)
                            {
                                this.data.ResultsCache.SaveDocumentResults(parsedDocument, sourceCode.Parser, sourceCode.Settings.WriteTime);
                            }

                            // If auto-save is true, then save the doc.
                            if (this.data.RunContext.AutoFix && this.data.AutoSaveMode && parsedDocument.Dirty)
                            {
                                this.SaveDocumentToSource(sourceCode, parsedDocument);
                            }

                            parsedDocument.Dispose();
                            parsedDocument = null;
                        }
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
        /// Saves the fixed document back to the source location.
        /// </summary>
        /// <param name="sourceCode">The source code representing the source of the document.</param>
        /// <param name="document">The document to save to the source code location.</param>
        private void SaveDocumentToSource(SourceCode sourceCode, ICodeDocument document)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");
            Param.AssertNotNull(document, "document");

            Exception exception;
            if (!sourceCode.Write(document, out exception))
            {
                if (exception != null)
                {
                    this.data.Core.CoreViolations.AddViolation(null, 1, Rules.SaveExceptionOccurred, exception.GetType(), sourceCode.Path, exception.Message);
                }
                else
                {
                    this.data.Core.CoreViolations.AddViolation(null, 1, Rules.UnknownSaveExceptionOccurred, sourceCode.Path);
                }
            }
            else
            {
                document.Dirty = false;
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
            ICodeDocument document, SourceParser parser, IEnumerable<SourceAnalyzer> analyzers, int passNumber)
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
                if (!this.data.RunContext.AutoFix)
                {
                    if (analyzer.DelayAnalysis(document, passNumber))
                    {
                        delay = true;
                        break;
                    }
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
            ICodeDocument document, SourceParser parser, IEnumerable<SourceAnalyzer> analyzers)
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

                        // Only run the analyzers associated with the current parser.
                        if (analyzer.Parser == parser)
                        {
                            SourceParser.ClearAnalyzerTags(document);
                            try
                            {
                                // Check whether we are running in auto-fix mode, in which case we should call the
                                // AutoFixDocument method on analyzers that support it. Otherwise, we are simply running
                                // the rules and we should call the AnalyzeDocument method instead.
                                if (this.data.RunContext.AutoFix)
                                {
                                    analyzer.AutoFixDocument(document);
                                }
                                else
                                {
                                    analyzer.AnalyzeDocument(document);
                                }
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
        }

        /// <summary>
        /// Attempts to load results for the given document from the cache.
        /// </summary>
        /// <param name="sourceCode">The source code document to load.</param>
        /// <returns>Returns true if the results were loaded from the cache.</returns>
        private bool LoadSourceCodeFromResultsCache(SourceCode sourceCode)
        {
            Param.AssertNotNull(sourceCode, "sourceCode");

            if (!this.data.IgnoreResultsCache && !this.data.RunContext.AutoFix && this.data.Core.Environment.SupportsResultsCache && this.data.ResultsCache != null)
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

        #endregion Private Methods
    }
}
