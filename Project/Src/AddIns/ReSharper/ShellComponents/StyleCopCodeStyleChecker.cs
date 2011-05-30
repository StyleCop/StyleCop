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

namespace StyleCop.ReSharper.ShellComponents
{
    #region Using Directives

    using System;
    using System.Windows.Forms;

    using JetBrains.Application;
    using JetBrains.ComponentModel;

    using Microsoft.Win32;

    using StyleCop.ReSharper.Options;

    #endregion

    /// <summary>
    /// The StyleCop CodeStyle Checker.
    /// </summary>
    [ShellComponentImplementation(ProgramConfigurations.ALL)]
    public class StyleCopCodeStyleChecker : IShellComponent
    {
        #region Implemented Interfaces

        #region IComponent

        /// <summary>
        /// The init.
        /// </summary>
        public void Init()
        {
            var oneTimeInitializationRequiredRegistryKey = RetrieveFromRegistry("LastInitializationDate");

            var initializationDate = Convert.ToDateTime(oneTimeInitializationRequiredRegistryKey);

            string todayAsString = DateTime.UtcNow.ToString("yyyy-MM-dd");

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
            }
            catch(FormatException ex)
            {
                // In some locales the installer saves the date in a format we can't parse back out.
                // Use today as the installed date and store it in the HKCU key.
                var installDateRegistryKey = RetrieveFromRegistry("InstallDate");
                if (installDateRegistryKey == null)
                {
                    SetRegistry("InstallDate", todayAsString, RegistryValueKind.String);
                    lastInstalledDate = Convert.ToDateTime(todayAsString);
                }
                else
                {
                    lastInstalledDate = Convert.ToDateTime(installDateRegistryKey);
                }
            }

            if (oneTimeInitializationRequiredRegistryKey == null || initializationDate < lastInstalledDate)
            {
                if (!StyleCopOptionsPage.CodeStyleOptionsValid(null))
                {
                  var result =  MessageBox.Show(
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

                SetRegistry("LastInitializationDate", todayAsString, RegistryValueKind.String);
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
        /// Sets a regkey value in the registry.
        /// </summary>
        /// <param name="key">The subkey to create.</param>
        /// <param name="value">The value to use</param>
        /// <param name="valueKind">The type of regkey value to set.</param>
        private static void SetRegistry(string key, object value, RegistryValueKind valueKind)
        {
            const string SubKey = @"SOFTWARE\CodePlex\StyleCop";

            RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(SubKey);
            if (registryKey != null)
            {
                registryKey.SetValue(key, value, valueKind);
            }
        }

        /// <summary>
        /// Retrieves a RegKey value for the registry.
        /// </summary>
        /// <param name="key">The subkey to open.</param>
        /// <returns>The value of the regkey.</returns>
        private static object RetrieveFromRegistry(string key)
        {
            const string SubKey = @"SOFTWARE\CodePlex\StyleCop";

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(SubKey);
            return registryKey == null ? null : registryKey.GetValue(key);
        }

        #endregion
    }
}