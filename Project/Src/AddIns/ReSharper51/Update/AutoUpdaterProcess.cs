// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AutoUpdaterProcess.cs" company="http://stylecop.codeplex.com">
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
//   Provides automatic updating functionality for the plugin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Update
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Windows.Forms;

    using JetBrains.Application;
    using JetBrains.ComponentModel;

    using StyleCop.ReSharper.Diagnostics;
    using StyleCop.ReSharper.Options;
    using StyleCop.ReSharper.Properties;

    #endregion

    /// <summary>
    /// Provides automatic updating functionality for the plugin.
    /// </summary>
    [ShellComponentImplementation(ProgramConfigurations.ALL)]
    public class AutoUpdaterProcess : IShellComponent
    {
        /// <summary>
        /// Message box title.
        /// </summary>
        private const string MessageBoxTitle = Constants.ProductName;

        /// <summary>
        /// Question text.
        /// </summary>
        private const string QuestionText =
            "StyleCop {0} is now available.\r\n\nStyleCop {1} is currently installed.\r\n\r\nOnce downloaded and installed you'll need to restart Visual Studio.\r\n\r\nTo configure when new versions are checked for go to ReSharper->Options->Tools->StyleCop.\r\n\r\nDo you wish to download the latest version?";

        /// <summary>
        /// Initialises this IShellComponent.
        /// </summary>
        public void Init()
        {
            if (StyleCopOptions.Instance.AutomaticallyCheckForUpdates)
            {
                var lastUpdateCheckDate = DateTime.Parse(StyleCopOptions.Instance.LastUpdateCheckDate);
                var daysBetweenUpdateChecks = StyleCopOptions.Instance.DaysBetweenUpdateChecks;

                if (StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts || DateTime.UtcNow > lastUpdateCheckDate.AddDays(daysBetweenUpdateChecks))
                {
                    try
                    {
                        new StyleCop.AutoUpdater().CheckForUpdate(QuestionText);
                        
                        if (!StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts)
                        {
                            StyleCopOptions.Instance.LastUpdateCheckDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                        }
                    }
                    catch (Exception exception)
                    {
                        StyleCopTrace.Info(exception.Message);
                    }
                }
            }
        }

        /// <summary>
        /// Disposes any resources.
        /// </summary>
        public void Dispose()
        {
        }
    }
}