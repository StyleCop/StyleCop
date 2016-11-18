//-----------------------------------------------------------------------
// <copyright file="AnalysisThread.cs">
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

    using StyleCop.Diagnostics;

    /// <summary>
    /// Thread class that performs code analysis.
    /// </summary>
    internal class AnalysisThread
    {
        #region Private Fields

        /// <summary>
        /// True if a full analysis is being performed.
        /// </summary>
        private bool full;

        /// <summary>
        /// The analysis projects collection.
        /// </summary>
        private IList<CodeProject> projects;

        /// <summary>
        /// The StyleCop core object.
        /// </summary>
        private StyleCopCore core;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the AnalysisThread class.
        /// </summary>
        /// <param name="full">True if a full analysis should be performed.</param>
        /// <param name="projects">The collection of projects to analysis.</param>
        /// <param name="core">The StyleCop core object.</param>
        public AnalysisThread(bool full, IList<CodeProject> projects, StyleCopCore core)
        {
            Param.Ignore(full);
            Param.Assert(projects != null && projects.Count > 0, "projects", "The projects collection must not be empty.");
            Param.AssertNotNull(core, "core");

            this.full = full;
            this.projects = projects;
            this.core = core;
        }

        #endregion Public Constructors

        #region Public Events

        /// <summary>
        /// Called when the analysis has been completed.
        /// </summary>
        public event EventHandler Complete;

        #endregion Public Events

        #region Public Methods

        /// <summary>
        /// Runs the analysis on a second thread.
        /// </summary>
        public void AnalyzeProc()
        {
            StyleCopTrace.In();
            
            try
            {
                if (this.full)
                {
                    this.core.FullAnalyze(this.projects);
                }
                else
                {
                    this.core.Analyze(this.projects);
                }
            }
            finally
            {
                if (this.Complete != null)
                {
                    this.Complete(this, new EventArgs());
                }
            }

            StyleCopTrace.Out();
        }

        #endregion Public Methods
    }
}