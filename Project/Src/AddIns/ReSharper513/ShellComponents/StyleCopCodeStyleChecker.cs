// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopCodeStyleChecker.cs" company="http://stylecop.codeplex.com">
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
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper513.ShellComponents
{
    #region Using Directives

    using System;
    using System.Windows.Forms;

    using JetBrains.Application;
    using JetBrains.ComponentModel;

    using Microsoft.Win32;

    using StyleCop.ReSharper513.Options;

    #endregion

    /// <summary>
    /// The StyleCop CodeStyle Checker.
    /// </summary>
    [ShellComponentImplementation(ProgramConfigurations.VS_ADDIN)]
    public class StyleCopCodeStyleChecker : IShellComponent
    {
        #region Implemented Interfaces

        #region IComponent

        /// <summary>
        /// Initializes our ShellComponent.
        /// </summary>
        public void Init()
        {
            var oneTimeInitializationRequiredRegistryKey = Utils.RetrieveFromRegistry("LastInitializationDate");

            var initializationDate = Convert.ToDateTime(oneTimeInitializationRequiredRegistryKey);

            string todayAsString = DateTime.Today.ToString("yyyy-MM-dd");

            RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\CodePlex\StyleCop");
            string value = null;
            if (registryKey != null)
            {
                value = registryKey.GetValue("InstallDate") as string;
            }

            DateTime lastInstalledDate;

            try
            {
                lastInstalledDate = Convert.ToDateTime(value);

                // If the installer stored a date that has now been read back in and seems to be in the future
                // then use the LocalUserInstallDate value.
                if (lastInstalledDate > DateTime.Today)
                {
                    lastInstalledDate = GetInstallDateFromLocalUserRegistry(todayAsString);
                }
            }
            catch (FormatException ex)
            {
                // In some locales the installer saves the date in a format we can't parse back out.
                // Use today as the installed date and store it in the HKCU key.
                lastInstalledDate = GetInstallDateFromLocalUserRegistry(todayAsString);
            }

            if (oneTimeInitializationRequiredRegistryKey == null || initializationDate < lastInstalledDate)
            {
                if (!StyleCopOptionsPage.CodeStyleOptionsValid(null))
                {
                    var result = MessageBox.Show(
                        @"Your ReSharper code style settings are not completely compatible with StyleCop. Would you like to reset them now?",
                        @"StyleCop",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question,
                        MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.Yes)
                    {
                        StyleCopOptionsPage.ResetCodeStyleOptions(null);
                    }
                }

                StyleCop.Utils.SetRegistry("LastInitializationDate", todayAsString, RegistryValueKind.String);
            }
        }

        #endregion

        #region IDisposable

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
        }

        #endregion

        #endregion

        #region Methods

        /// <summary>
        /// Loads the InstallDate registry key value.
        /// </summary>
        /// <param name="defaultDateAsString">The date to set the install date to if its value is not found in the registry.</param>
        /// <returns>The DateTime of the InstallDate LOCALUSER registry key.</returns>
        private static DateTime GetInstallDateFromLocalUserRegistry(string defaultDateAsString)
        {
            var installDateRegistryKey = Utils.RetrieveFromRegistry("InstallDate");
            if (installDateRegistryKey == null)
            {
                Utils.SetRegistry("InstallDate", defaultDateAsString, RegistryValueKind.String);
                return Convert.ToDateTime(defaultDateAsString);
            }

            return Convert.ToDateTime(installDateRegistryKey);
        }

        #endregion
    }
}