// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopRunnerInt.cs" company="http://stylecop.codeplex.com">
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
//   Executes Microsoft StyleCop within the ReSharper Environment.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Core
{
    using System;
    using System.Collections.Generic;

    using JetBrains.DocumentModel;
    using JetBrains.ProjectModel;
    using JetBrains.ReSharper.Feature.Services.Daemon;
    using JetBrains.ReSharper.Psi.CSharp.Tree;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper.Violations;

    /// <summary>
    /// Executes Microsoft StyleCop within the ReSharper Environment.
    /// </summary>
    /// <remarks>
    /// Microsoft StyleCop currently requires physical files for parsing. <see cref="StyleCopRunnerInt"/>
    /// creates a shadow copy of the source file that is currently being parsed by ReSharper, 
    /// representing its current state during the editing process. This prevents the highlights from
    /// getting out of synch with the file in the IDE.
    /// </remarks>
    public class StyleCopRunnerInt : IDisposable
    {
        /// <summary>
        /// The core API
        /// </summary>
        private readonly StyleCopCore styleCopCore;

        /// <summary>
        /// The settings
        /// </summary>
        private readonly StyleCopSettings styleCopSettings;

        private IDocument document;

        /// <summary>
        /// Reference to the file currently being parsed by ReSharper.
        /// </summary>
        private IProjectFile file;

        /// <summary>
        /// List of encountered violations, passed back to <see cref="StyleCopStageProcess"/> so that
        /// violations can be highlighted within the IDE.
        /// </summary>
        private List<HighlightingInfo> violationHighlights = new List<HighlightingInfo>();

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopRunnerInt"/> class.
        /// </summary>
        /// <param name="core">
        /// A reference to the core API
        /// </param>
        /// <param name="settings">
        /// A reference to the settings API
        /// </param>
        public StyleCopRunnerInt(StyleCopCore core, StyleCopSettings settings)
        {
            this.styleCopCore = core;
            this.styleCopSettings = settings;

            core.DisplayUI = true;
            core.ViolationEncountered += this.OnViolationEncountered;
        }

        /// <summary>
        /// Gets List of encountered violations, passed back to <see cref="StyleCopStageProcess"/> so that
        /// violations can be highlighted within the IDE.
        /// </summary>
        /// <value>
        /// Gets a list of encountered violations.
        /// </value>
        public IList<HighlightingInfo> ViolationHighlights
        {
            get
            {
                return this.violationHighlights;
            }
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.file = null;

            if (this.styleCopCore != null)
            {
                this.styleCopCore.ViolationEncountered -= this.OnViolationEncountered;
            }

            this.violationHighlights.Clear();
            this.violationHighlights = null;
        }

        /// <summary>
        /// Executes <see cref="styleCopCore"/> within the <see cref="OnViolationEncountered"/>.
        /// </summary>
        /// <remarks>
        /// Violations are raised as events, handled by <see cref="IProjectFile"/>.
        /// </remarks>
        /// <param name="projectFile">
        /// <see cref="StyleCopStageProcess"/>representing the file currently being parsed by ReSharper.
        /// </param>
        /// <param name="document">
        /// The document being checked.
        /// </param>
        /// <param name="file">
        /// The file to analyze.
        /// </param>
        public void Execute(IProjectFile projectFile, IDocument document, ICSharpFile file)
        {
            StyleCopTrace.In(projectFile, document);

            if (projectFile == null)
            {
                return;
            }

            this.violationHighlights.Clear();

            if (!this.styleCopSettings.SkipAnalysisForDocument(projectFile))
            {
                FileHeader fileHeader = new FileHeader(file);

                if (!fileHeader.UnStyled)
                {
                    this.file = projectFile;
                    this.document = document;
                    this.RunStyleCop(document);
                }
            }

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Handles the ViolationEncountered Event, and 
        /// adds any violations to the <see cref="ViolationHighlights"/> Collection for display
        /// within the IDE.
        /// </summary>
        /// <param name="range">
        /// Text Range within the Document.
        /// </param>
        /// <param name="highlighting">
        /// Information to be highlighted.
        /// </param>
        private void CreateViolation(DocumentRange range, IHighlighting highlighting)
        {
            this.violationHighlights.Add(new HighlightingInfo(range, highlighting));
        }

        /// <summary>
        /// Called when the StyleCopCore.ViolationEncountered event is raised. Converts
        /// <see cref="ViolationEventArgs"/>into ReSharper Violation.
        /// </summary>
        /// <param name="sender">
        /// Object that raised the event.
        /// </param>
        /// <param name="e">
        /// Data Structure containing information about the Violation encountered.
        /// </param>
        private void OnViolationEncountered(object sender, ViolationEventArgs e)
        {
            if (e == null || e.SourceCode == null || e.SourceCode.Path == null || e.Violation == null)
            {
                return;
            }

            if (this.file == null || this.file.Location == null)
            {
                return;
            }

            string path = e.SourceCode.Path;
            int lineNumber = e.LineNumber;

            // if violations fire in the related files we ignore them as we only want to highlight in the current file
            if (path == this.file.Location.FullPath)
            {
                JetBrains.Util.TextRange textRange;

                if (e.Violation.Location == null)
                {
                    textRange = Utils.GetTextRange(this.file, ((JetBrains.Util.dataStructures.TypedIntrinsics.Int32<DocLine>)lineNumber).Minus1());
                }
                else
                {
                    textRange = Utils.GetTextRange(this.file, e.Violation.Location.Value);
                }

                // The TextRange could be a completely blank line. If it is just return the line and don't trim it.
                DocumentRange documentRange = new DocumentRange(this.document, textRange);

                if (!textRange.IsEmpty)
                {
                    // Once we have a TextRange for the entire line reduce it to not include whitespace at the left or whitespace at the right
                    // if it wasn't empty
                    documentRange = Utils.TrimWhitespaceFromDocumentRange(documentRange);
                }

                ISolution solution = this.file.GetSolution();

                IHighlighting violation = StyleCopHighlightingFactory.GetHighlight(solution, e, documentRange);

                this.CreateViolation(documentRange, violation);
            }
        }

        /// <summary>
        /// Runs StyleCop.
        /// </summary>
        /// <param name="document">
        /// The document we are checking.
        /// </param>
        private void RunStyleCop(IDocument document)
        {
            StyleCopTrace.In(document);

            try
            {
                CodeProject[] projects = Utils.GetProjects(this.styleCopCore, this.file, document);

                this.styleCopSettings.LoadSettingsFiles(projects, this.file);

                this.styleCopCore.FullAnalyze(projects);
            }
            catch (Exception exception)
            {
                JetBrains.Util.Logging.Logger.LogException(exception);
            }
            finally
            {
                StyleCopTrace.Out();
            }
        }
    }
}