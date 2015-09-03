// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopBootstrapper.cs" company="http://stylecop.codeplex.com">
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
    using JetBrains.Application;

    using StyleCop.ReSharper.Core;

    /// <summary>
    /// Holds a single instance of the core StyleCop API entry points
    /// </summary>
    [ShellComponent]
    public class StyleCopBootstrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopBootstrapper"/> class.
        /// </summary>
        public StyleCopBootstrapper()
        {
            this.Core = StyleCopCoreFactory.Create();

            // TODO: The way settings are handled is BAD
            // This leaks cache and FileSystemWatchers, by sharing them across solutions.
            // Making a single instance available improves the situation a little - previously
            // there was a new instance created for each quick fix or each time code cleanup
            // was called
            this.Settings = new StyleCopSettings(this.Core);
            this.Runner = new StyleCopRunnerInt(this.Core, this.Settings);
        }

        /// <summary>
        /// Gets a reference to the core StyleCop API
        /// </summary>
        public StyleCopCore Core { get; private set; }

        /// <summary>
        /// Gets a reference to the StyleCop runner API
        /// </summary>
        public StyleCopRunnerInt Runner { get; private set; }

        /// <summary>
        /// Gets a reference to the StyleCop settings API
        /// </summary>
        public StyleCopSettings Settings { get; private set; }
    }
}