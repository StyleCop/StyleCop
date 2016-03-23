// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopApi.cs" company="http://stylecop.codeplex.com">
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
//   Bootstraps the StyleCop API
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.ShellComponents
{
    using JetBrains.Application.FileSystemTracker;
    using JetBrains.DataFlow;

    using StyleCop.ReSharper.Core;

    /// <summary>
    /// The style cop API.
    /// </summary>
    public class StyleCopApi
    {
        private readonly Lifetime lifetime;

        private readonly IFileSystemTracker fileSystemTracker;

        private readonly StyleCopCore core;

        private StyleCopSettings settings;

        private StyleCopRunnerInt runner;

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopApi"/> class.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime of the object.
        /// </param>
        /// <param name="core">
        ///     The core.
        /// </param>
        /// <param name="fileSystemTracker">
        /// The file system tracker.
        /// </param>
        public StyleCopApi(Lifetime lifetime, StyleCopCore core, IFileSystemTracker fileSystemTracker)
        {
            this.lifetime = lifetime;
            this.fileSystemTracker = fileSystemTracker;
            this.core = core;
        }

        /// <summary>
        /// Gets the settings.
        /// </summary>
        public StyleCopSettings Settings
        {
            get
            {
                return this.settings ?? (this.settings = new StyleCopSettings(this.lifetime, this.core, this.fileSystemTracker));
            }
        }

        /// <summary>
        /// Gets the runner.
        /// </summary>
        public StyleCopRunnerInt Runner
        {
            get
            {
                return this.runner ?? (this.runner = new StyleCopRunnerInt(this.core, this.Settings));
            }
        }

        /// <summary>
        /// Gets the core API.
        /// </summary>
        public StyleCopCore Core
        {
            get
            {
                return this.core;
            }
        }
    }
}