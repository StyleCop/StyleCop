// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopApiPool.cs" company="http://stylecop.codeplex.com">
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
//   The style cop API pool.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.ShellComponents
{
    using System;

    using JetBrains.Application.FileSystemTracker;
    using JetBrains.Application.Settings;
    using JetBrains.DataFlow;
    using JetBrains.ProjectModel;
    using JetBrains.Util.Collections;

    using StyleCop.ReSharper.Core;

    /// <summary>
    /// The style cop API pool. Needs to be a solution component, because the API caches settings
    /// per solution
    /// </summary>
    [SolutionComponent]
    public class StyleCopApiPool
    {
        private readonly Lifetime componentLifetime;

        private readonly ISettingsStore settingsStore;

        private readonly IFileSystemTracker fileSystemTracker;

        private readonly Action reset;

        // StyleCopCore and StyleCopEnvironment depend on each other. StyleCopSettings depends
        // on StyleCopCore, StyleCopEnvironment and Settings. Settings depends on StyleCopCore.
        // They're also not thread safe - you can only run one analysis at a time (which might
        // even be multi-threaded) and that doesn't suit ReSharper. To top it all, the objects
        // are expensive to create - StyleCopCore loads assemblies and does reflection,
        // StyleCopSettings maintains a cache of merged Settings, oh, and both StyleCopSettings
        // and Settings leak FileSystemWatchers. Sigh.
        // Let's maintain a pool of ready made instances, that we can ruse. We don't need to
        // clean the pool up, it'll go out of scope when the solution closes.
        // That said, I've not seen the pool get over 1 object, but I'm not convinced on the
        // threading requirements for daemon processes
        private ObjectPool<StyleCopApi> pool;

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopApiPool"/> class.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <param name="settingsStore">The settings store</param>
        /// <param name="fileSystemTracker">
        /// The file system tracker.
        /// </param>
        public StyleCopApiPool(Lifetime lifetime, ISettingsStore settingsStore, IFileSystemTracker fileSystemTracker)
        {
            this.componentLifetime = lifetime;
            this.settingsStore = settingsStore;
            this.fileSystemTracker = fileSystemTracker;

            this.reset = () =>
                {
                    var initialObject = this.CreateApiObject();
                    this.pool = new ObjectPool<StyleCopApi>(this.CreateApiObject, new[] { initialObject });
                };
            this.reset();
        }

        /// <summary>
        /// The get instance.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <returns>
        /// The <see cref="StyleCopApi"/>.
        /// </returns>
        public StyleCopApi GetInstance(Lifetime lifetime)
        {
            return this.pool.GetObject(lifetime);
        }

        /// <summary>
        /// Reset the object pool. Used when the plugins path changes
        /// </summary>
        public void Reset()
        {
            // I wish ObjectPool had a reset method...
            this.reset();
        }

        private StyleCopApi CreateApiObject()
        {
            return new StyleCopApi(
                this.componentLifetime,
                StyleCopCoreFactory.Create(this.componentLifetime, this.settingsStore, this.fileSystemTracker),
                this.fileSystemTracker);
        }
    }
}