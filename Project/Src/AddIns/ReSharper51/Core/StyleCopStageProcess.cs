// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopStageProcess.cs" company="http://stylecop.codeplex.com">
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
//   Stage Process that execute the Microsoft StyleCop against the
//   specified file.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper51.Core
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Linq;

    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.ExtensionsAPI.Tree;

    using StyleCop.ReSharper51.Diagnostics;
    using StyleCop.ReSharper51.Options;

    #endregion

    /// <summary>
    /// Stage Process that execute the Microsoft StyleCop against the
    /// specified file.
    /// </summary>
    /// <remarks>
    /// This type is created and executed every time a .cs file is modified in the IDE.
    /// </remarks>
    public class StyleCopStageProcess : IDaemonStageProcess
    {
        #region Constants and Fields

        /// <summary>
        /// Defines the max performance value - this is used to reverse the settings.
        /// </summary>
        private const int MaxPerformanceValue = 9;

        private readonly IDaemonProcess daemonProcess;

        /// <summary>
        /// First run flag.
        /// </summary>
        private static bool firstRunFlag = true;

        /// <summary>
        /// Used to reduce the number of calls to StyleCop to help with perfromance.
        /// </summary>
        private static Stopwatch performanceStopWatch;

        private static StyleCopRunnerInt styleCopRunner;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the StyleCopStageProcess class, using the specified
        /// <see cref="IDaemonProcess"/>.
        /// </summary>
        /// <param name="daemonProcess">
        /// <see cref="IDaemonProcess"/>to execute within.
        /// </param>
        public StyleCopStageProcess(IDaemonProcess daemonProcess)
        {
            StyleCopTrace.In(daemonProcess);

            this.daemonProcess = daemonProcess;
            InitialiseTimers();

            StyleCopTrace.Out();
        }

        #endregion

        #region Implemented Interfaces

        #region IDaemonStageProcess

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="commiter">
        /// The commiter.
        /// </param>
        public void Execute(Action<DaemonStageResult> commiter)
        {
            StyleCopTrace.In();

            // inverse the performance value - to ensure that "more resources" actually evaluates to a lower number
            // whereas "less resources" actually evaluates to a higher number. If Performance is set to max, then execute as normal.
            if ((firstRunFlag || StyleCopOptions.Instance.ParsingPerformance == StyleCopStageProcess.MaxPerformanceValue) ||
                (performanceStopWatch.Elapsed > new TimeSpan(0, 0, 0, StyleCopStageProcess.MaxPerformanceValue - StyleCopOptions.Instance.ParsingPerformance)))
            {
                if (this.daemonProcess.InterruptFlag)
                {
                    return;
                }

                if (!this.FileIsValid())
                {
                    return;
                }

                if (styleCopRunner == null)
                {
                    styleCopRunner = new StyleCopRunnerInt();
                }

                styleCopRunner.Execute(this.daemonProcess.ProjectFile, this.daemonProcess.Document);

                var violations = (from info in styleCopRunner.ViolationHighlights let range = info.Range let highlighting = info.Highlighting select new HighlightingInfo(range, highlighting)).ToList();

                commiter(new DaemonStageResult(violations));

                ResetPerformanceStopWatch();

                firstRunFlag = false;
            }

            StyleCopTrace.Out();
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Initialises the static timers used to regulate performance of file scavenging 
        /// and execution of StyleCop analysis.
        /// </summary>
        private static void InitialiseTimers()
        {
            if (performanceStopWatch == null)
            {
                performanceStopWatch = Stopwatch.StartNew();
                performanceStopWatch.Start();
            }
        }

        /// <summary>
        /// Resets the Performance Stopwatch.
        /// </summary>
        private static void ResetPerformanceStopWatch()
        {
            performanceStopWatch.Reset();
            performanceStopWatch.Start();
        }

        private bool FileIsValid()
        {
            var manager = PsiManager.GetInstance(this.daemonProcess.Solution);

            if (this.daemonProcess.ProjectFile == null)
            {
                return false;
            }

            if (!this.daemonProcess.ProjectFile.IsValid)
            {
                return false;
            }

            var file = manager.GetPsiFile(this.daemonProcess.ProjectFile, PsiLanguageType.GetByProjectFile(this.daemonProcess.ProjectFile));

            if (file == null)
            {
                return false;
            }

            var hasErrorElements = new RecursiveElementCollector<ErrorElement>().ProcessElement(file).GetResults().Any();
            StyleCopTrace.Info("File has error elements = {0}", hasErrorElements);

            return !hasErrorElements;
        }

        #endregion
    }
}