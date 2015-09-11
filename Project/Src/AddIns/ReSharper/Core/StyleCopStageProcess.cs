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

namespace StyleCop.ReSharper.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using JetBrains.DataFlow;
    using JetBrains.DocumentModel;
    using JetBrains.ReSharper.Feature.Services.Daemon;
    using JetBrains.ReSharper.Psi;
    using JetBrains.ReSharper.Psi.CSharp.Tree;
    using JetBrains.ReSharper.Resources.Shell;
    using JetBrains.Threading;
    using JetBrains.Util;

    using StyleCop.Diagnostics;

    /// <summary>
    /// Stage Process that execute the Microsoft StyleCop against the specified file.
    /// </summary>
    /// <remarks>
    /// This type is created and executed every time a .cs file is modified in the IDE.
    /// </remarks>
    public class StyleCopStageProcess : IDaemonStageProcess
    {
        private static readonly Key<DaemonData> DaemonDataKey = new Key<DaemonData>("StyleCop::DaemonData");

        private static readonly TimeSpan PauseDuration = TimeSpan.FromSeconds(1);

        private readonly Lifetime lifetime;

        private readonly StyleCopRunnerInt runner;

        private readonly IDaemon daemon;

        private readonly IDaemonProcess daemonProcess;

        private readonly IThreading threading;

        private readonly ICSharpFile file;

        /// <summary>
        /// Initializes a new instance of the StyleCopStageProcess class, using the specified <see cref="IDaemonProcess"/> .
        /// </summary>
        /// <param name="lifetime">
        /// The <see cref="Lifetime"/> of the owning <see cref="IDaemonProcess"/>
        /// </param>
        /// <param name="runner">
        /// A reference to the StyleCop runner.
        /// </param>
        /// <param name="daemon">
        /// A reference to the <see cref="IDaemon"/> manager.
        /// </param>
        /// <param name="daemonProcess">
        /// <see cref="IDaemonProcess"/> to execute within. 
        /// </param>
        /// <param name="threading">
        /// A reference to the <see cref="IThreading"/> instance for timed actions.
        /// </param>
        /// <param name="file">
        /// The file to analyze.
        /// </param>
        public StyleCopStageProcess(Lifetime lifetime, StyleCopRunnerInt runner, IDaemon daemon, IDaemonProcess daemonProcess, IThreading threading, ICSharpFile file)
        {
            StyleCopTrace.In(daemonProcess, file);

            this.lifetime = lifetime;
            this.runner = runner;
            this.daemon = daemon;
            this.daemonProcess = daemonProcess;
            this.threading = threading;
            this.file = file;

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Gets the Daemon Process.
        /// </summary>
        public IDaemonProcess DaemonProcess
        {
            get
            {
                return this.daemonProcess;
            }
        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="committer">
        /// The committer. 
        /// </param>
        public void Execute(Action<DaemonStageResult> committer)
        {
            StyleCopTrace.In();
            try
            {
                if (this.daemonProcess == null)
                {
                    return;
                }

                if (this.daemonProcess.InterruptFlag)
                {
                    return;
                }

                DaemonData daemonData;
                bool shouldProcessNow;

                // TODO: Lock proper object. But what?
                lock (this.file)
                {
                    daemonData = this.file.UserData.GetOrCreateData(
                        DaemonDataKey,
                        () => new DaemonData(this.lifetime, this.threading, this.daemon, this.daemonProcess.Document));
                    shouldProcessNow = daemonData.OnDaemonCalled();
                }

                if (shouldProcessNow)
                {
                    this.runner.Execute(
                        this.daemonProcess.SourceFile.ToProjectFile(),
                        this.daemonProcess.Document,
                        this.file);

                    // TODO: Why is this a copy?
                    // Uh-oh. Looks like StyleCopRunnerInt shouldn't be shared. Need to check history
                    List<HighlightingInfo> violations =
                        (from info in this.runner.ViolationHighlights
                         select new HighlightingInfo(info.Range, info.Highlighting)).ToList();

                    committer(new DaemonStageResult(violations));
                }
                else
                {
                    // NOTE: This wouldn't be necessary if the StyleCop analysis were more lightweight,
                    // e.g. by using ReSharper's ASTs rather than re-parsing the file on each change
                    daemonData.ScheduleReHighlight();
                }
            }
            catch (JetBrains.Application.Progress.ProcessCancelledException)
            {
            }

            StyleCopTrace.Out();
        }

        private class DaemonData
        {
            private readonly IThreading threading;

            private readonly IDaemon daemon;

            private readonly IDocument document;

            private readonly SequentialLifetimes timedActionsLifetime;

            private DateTime lastCalledTimestamp;

            public DaemonData(Lifetime lifetime, IThreading threading, IDaemon daemon, IDocument document)
            {
                this.threading = threading;
                this.daemon = daemon;
                this.document = document;
                this.timedActionsLifetime = new SequentialLifetimes(lifetime);
                this.lastCalledTimestamp = DateTime.MinValue;
            }

            public bool OnDaemonCalled()
            {
                var hasExpired = DateTime.UtcNow.Ticks - PauseDuration.Ticks > this.lastCalledTimestamp.Ticks;
                this.lastCalledTimestamp = DateTime.UtcNow;
                return hasExpired;
            }

            public void ScheduleReHighlight()
            {
                this.timedActionsLifetime.Next(l =>
                {
                    // threading.GroupingEvents.CreateEvent().Incoming
                    this.threading.TimedActions.Queue(
                        l,
                        "StyleCop::ReHighlight",
                        () => ReadLockCookie.Execute(() => this.daemon.ForceReHighlight(this.document)),
                        PauseDuration,
                        TimedActionsHost.Recurrence.OneTime,
                        Rgc.Guarded);
                });
            }
        }
    }
}