// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopCoreFactory.cs" company="http://stylecop.codeplex.com">
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
//   The style cop core factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper.Core
{
    using System.Collections.Generic;
    using System.Reflection;

    using JetBrains.Application.FileSystemTracker;
    using JetBrains.Application.Settings;
    using JetBrains.DataFlow;
    using JetBrains.Util;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper.Options;

    /// <summary>
    /// The style cop core factory.
    /// </summary>
    public static class StyleCopCoreFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <param name="settingsStore">The settings store.</param>
        /// <param name="fileSystemTracker">
        /// The file System Tracker.
        /// </param>
        /// <returns>
        /// A new StyleCopCore object.
        /// </returns>
        public static StyleCopCore Create(Lifetime lifetime, ISettingsStore settingsStore, IFileSystemTracker fileSystemTracker)
        {
            StyleCopTrace.In();

            ProjectSettingsFactory projectSettingsFactory = new ProjectSettingsFactory(lifetime, fileSystemTracker);
            SourceCodeFactory sourceCodeFactory = new SourceCodeFactory();

            ObjectBasedEnvironment environment = new ObjectBasedEnvironment(
                sourceCodeFactory.Create,
                projectSettingsFactory.Create);

            IContextBoundSettingsStore settings = settingsStore.BindToContextTransient(ContextRange.ApplicationWide);
            bool pluginsEnabled = settings.GetValue((StyleCopOptionsSettingsKey options) => options.PluginsEnabled);
            string pluginsPath = settings.GetValue((StyleCopOptionsSettingsKey options) => options.PluginsPath);

            // TODO: Is there a nicer way of finding out the ReSharper install location?
            string standardPath =
                FileSystemPath.Parse(Assembly.GetCallingAssembly().Location)
                    .Directory.Combine(@"Extensions\StyleCop.StyleCop\StyleCopAddins")
                    .FullPath;

            var paths = new List<string> { standardPath };
            if (pluginsEnabled && !string.IsNullOrEmpty(pluginsPath))
            {
                paths.Add(pluginsPath);
            }

            StyleCopObjectConsole styleCop = new StyleCopObjectConsole(environment, null, paths, false);

            projectSettingsFactory.StyleCopCore = styleCop.Core;

            return StyleCopTrace.Out(styleCop.Core);
        }
    }
}