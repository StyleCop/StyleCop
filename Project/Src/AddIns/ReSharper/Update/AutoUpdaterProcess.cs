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
            "StyleCop {0} is now available.\r\n\nStyleCop {1} is currently installed.\r\n\r\nOnce downloaded and installed you'll need to restart Visual Studio.\r\n\r\nTo cofigure when new version are checked for go to ReSharper->Options->Tools->StyleCop.\r\n\r\nDo you wish to download the latest version?";

#if DEBUG
        private const string VersionUrl = "http://www.stylecop.com/updates/4.5/version.dev.xml";
#else
        private const string VersionUrl = "http://www.stylecop.com/updates/4.5/version.xml";
#endif

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
                    var client = new WebClient();
                    client.DownloadStringCompleted += this.DownloadStringCompleted;

                    try
                    {
                        client.DownloadStringAsync(new Uri(VersionUrl));
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

        /// <summary>
        /// Prompt user for download.
        /// </summary>
        /// <param name="currentVersionNumber">
        /// The current version number.
        /// </param>
        /// <param name="newVersionNumber">
        /// The new version number.
        /// </param>
        /// <param name="messageText">
        /// The message text.
        /// </param>
        /// <returns>
        /// The prompt user for download.
        /// </returns>
        private static bool PromptUserForDownload(string currentVersionNumber, string newVersionNumber, string messageText)
        {
            if (string.IsNullOrEmpty(messageText))
            {
                return MessageBox.Show(String.Format(QuestionText, newVersionNumber, currentVersionNumber), MessageBoxTitle, MessageBoxButtons.YesNo) == DialogResult.Yes;
            }

            MessageBox.Show(messageText, MessageBoxTitle, MessageBoxButtons.OK);

            return false;
        }

        #region Event Handlers

        private void DownloadStringCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    return;
                }

                if (!StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts)
                {
                    StyleCopOptions.Instance.LastUpdateCheckDate = DateTime.UtcNow.ToString("yyyy-MM-dd");
                }

                var autoUpdate = Serialisation.CreateInstance<AutoUpdate>(e.Result);
                var currentVersionNumber = this.GetType().Assembly.GetName().Version;
                var newVersionNumber = autoUpdate.Version.CastAsSystemVersion();
                var newerPlugInAvailable = newVersionNumber.CompareTo(currentVersionNumber) > 0;

                if (newerPlugInAvailable && PromptUserForDownload(currentVersionNumber.ToString(), newVersionNumber.ToString(), autoUpdate.Message))
                {
                    // this will launch the default browser at the download url
                    Process.Start(autoUpdate.DownloadUrl);
                }
            }
            catch
            {
                // if anything at all goes wrong in here we just consume it and say nothing
                return;
            }
        }

        #endregion
    }
}