// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReferencedAnalyzersCache.cs" company="http://stylecop.codeplex.com">
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
//   Caches analyzers referenced in Visual Studio 2015
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.ShellComponents.VisualStudio2015
{
    using System;

    using JetBrains.Application.Components;
    using JetBrains.DataFlow;
    using JetBrains.ProjectModel;
    using JetBrains.ProjectModel.Tasks;
    using JetBrains.ReSharper.Daemon;
    using JetBrains.ReSharper.Resources.Shell;
    using JetBrains.Threading;
    using JetBrains.Util;
    using JetBrains.Util.Logging;
    using JetBrains.VsIntegration.ProjectDocuments.Projects.Builder;

    using NuGet.VisualStudio;

    using VSLangProj140;

    /// <summary>
    /// Cache of referenced analyzers
    /// </summary>
    [SolutionComponent]
    public class ReferencedAnalyzersCache : PreRoslynReferencedAnalyzersCache
    {
        private readonly ISolution solution;

        private readonly IThreading threading;

        private readonly ProjectModelSynchronizer projectModelSynchronizer;

        private readonly IVsPackageInstallerServices packageInstallerServices;

        private readonly IVsPackageInstallerEvents packageInstallerEvents;

        private readonly object syncObject;

        private readonly OneToSetMap<string, string> referencedAnalyzers;

        private readonly GroupingEvent groupingEvent;

        /// <summary>
        /// Initializes a new instance of the <see cref="ReferencedAnalyzersCache"/> class.
        /// </summary>
        /// <param name="lifetime">The lifetime of the component</param>
        /// <param name="solution">The current solution</param>
        /// <param name="threading">The threading API</param>
        /// <param name="solutionLoadTasksScheduler">Solution load task scheduler</param>
        /// <param name="projectModelSynchronizer">The project model synchronizer</param>
        /// <param name="packageInstallerServices">NuGet installer services API</param>
        /// <param name="packageInstallerEvents">NuGet installer events API</param>
        public ReferencedAnalyzersCache(
            Lifetime lifetime,
            ISolution solution,
            IThreading threading,
            ISolutionLoadTasksScheduler solutionLoadTasksScheduler,
            ProjectModelSynchronizer projectModelSynchronizer,
            Lazy<Optional<IVsPackageInstallerServices>> packageInstallerServices,
            Lazy<Optional<IVsPackageInstallerEvents>> packageInstallerEvents)
        {
            this.solution = solution;
            this.threading = threading;
            this.projectModelSynchronizer = projectModelSynchronizer;
            this.packageInstallerEvents = packageInstallerEvents.Value.CanBeNull;
            this.packageInstallerServices = packageInstallerServices.Value.CanBeNull;

            this.syncObject = new object();

            this.referencedAnalyzers = new OneToSetMap<string, string>();

            this.groupingEvent = threading.GroupingEvents.CreateEvent(
                lifetime,
                "StyleCop::AnalyzersCache",
                TimeSpan.FromSeconds(2),
                Rgc.Guarded,
                this.DoResetAnalyzersCache);

            if (!this.IsNuGetAvailable)
            {
                Logger.LogMessage(
                    LoggingLevel.VERBOSE,
                    "[StyleCop::AnalyzersCache] Unable to get NuGet interfaces. No exception thrown");
            }
            else
            {
                lifetime.AddBracket(
                    () =>
                        {
                            this.packageInstallerEvents.PackageInstalled += this.ResetAnalyzersCache;
                            this.packageInstallerEvents.PackageUninstalled += this.ResetAnalyzersCache;
                        },
                    () =>
                        {
                            this.packageInstallerEvents.PackageInstalled -= this.ResetAnalyzersCache;
                            this.packageInstallerEvents.PackageUninstalled -= this.ResetAnalyzersCache;
                        });
                solutionLoadTasksScheduler.EnqueueTask(new SolutionLoadTask("StyleCop.ReferencedAnalyzersCache", SolutionLoadTaskKinds.AfterDone,
                    () =>
                        {
                            this.ResetAnalyzersCache(null);
                        }));
            }
        }

        private bool IsNuGetAvailable
        {
            get
            {
                return this.packageInstallerServices != null && this.packageInstallerEvents != null;
            }
        }

        /// <summary>
        /// Returns true if the specified analyzer is referenced
        /// </summary>
        /// <param name="project">
        /// The project that the analyzer is referenced in
        /// </param>
        /// <param name="analyzerName">
        /// The name of the analyzer assembly, minus the '.dll' suffix
        /// </param>
        /// <returns>Returns true if the analyzer is referenced in the given project</returns>
        public override bool IsAnalyzerReferenced(IProject project, string analyzerName)
        {
            lock (this.syncObject)
            {
                return this.referencedAnalyzers[project.GetPersistentID()].Contains(analyzerName.ToLowerInvariant());
            }
        }

        private void DoResetAnalyzersCache()
        {
            this.threading.Dispatcher.AssertAccess();
            lock (this.syncObject)
            {
                this.referencedAnalyzers.Clear();
            }

            if (!this.solution.IsTemporary)
            {
                lock (this.syncObject)
                {
                    using (ReadLockCookie.Create())
                    {
                        // We don't actually look in nuget, we'll pull the data from the
                        // project system
                        foreach (var project in this.solution.GetTopLevelProjects())
                        {
                            var vsProjectInfo = this.projectModelSynchronizer.GetProjectInfoByProject(project);
                            if (vsProjectInfo != null)
                            {
                                var extProject = vsProjectInfo.GetExtProject();
                                if (extProject != null)
                                {
                                    var vsProject3 = extProject.Object as VSProject3;
                                    if (vsProject3 != null)
                                    {
                                        var projectId = project.GetPersistentID();

                                        var analyzerReferences = vsProject3.AnalyzerReferences;
                                        foreach (string analyzerReference in analyzerReferences)
                                        {
                                            var analyzerPath = FileSystemPath.Parse(analyzerReference);
                                            var analyzer = analyzerPath.NameWithoutExtension;
                                            this.referencedAnalyzers.Add(projectId, analyzer.ToLowerInvariant());
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Can't inject, get a circular reference
                DaemonBase.GetInstance(this.solution).Invalidate();
            }
        }

        private void ResetAnalyzersCache(IVsPackageMetadata metadata)
        {
            this.groupingEvent.FireIncoming();
        }
    }
}
