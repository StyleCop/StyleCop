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
extern alias JB;

namespace StyleCop.ReSharper611.ShellComponents
{
    #region Using Directives

    using System;
    using System.Windows.Forms;

    using JetBrains.Application;
    using JetBrains.Application.Components;
    using JetBrains.Application.Settings;
    using JetBrains.Application.Settings.Store.Implementation;

    using Microsoft.Win32;

    using StyleCop.ReSharper611.Options;

    #endregion

    /// <summary>
    /// The StyleCop CodeStyle Checker.
    /// </summary>
    [ShellComponent(ProgramConfigurations.ALL)]
    public class StyleCopCodeStyleChecker : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the StyleCopCodeStyleChecker class.
        /// </summary>
        /// <param name="lifetime">The lifetime for this instance.</param>
        public StyleCopCodeStyleChecker(JB::JetBrains.DataFlow.Lifetime lifetime)
        {
            this.Init(lifetime);
        }

        #region Implemented Interfaces

        #region IComponent

        /// <summary>
        /// The initializer for this ShellComponent.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime for this object.
        /// </param>
        public void Init(JB::JetBrains.DataFlow.Lifetime lifetime)
        {
            var oneTimeInitializationRequiredRegistryKey = RetrieveFromRegistry("LastInitializationDate");

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
                var settingsStore = Shell.Instance.GetComponent<SettingsStore>();

                var settings = settingsStore.BindToContextLive(lifetime, ContextRange.ApplicationWide);

                var checkReSharperCodeStyleOptionsAtStartUp = settings.GetValue((StyleCopOptionsSettingsKey key) => key.CheckReSharperCodeStyleOptionsAtStartUp);

                if (checkReSharperCodeStyleOptionsAtStartUp)
                {
                    if (!StyleCopOptionsPage.CodeStyleOptionsValid(settings))
                    {
                        var result =
                            MessageBox.Show(
                                @"Your ReSharper code style settings are not completely compatible with StyleCop. Would you like to reset them now?",
                                @"StyleCop",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question,
                                MessageBoxDefaultButton.Button2);
                        if (result == DialogResult.Yes)
                        {
                            StyleCopOptionsPage.CodeStyleOptionsReset(settings);
                        }
                    }
                }
            }

            SetRegistry("LastInitializationDate", todayAsString, RegistryValueKind.String);
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
            var installDateRegistryKey = RetrieveFromRegistry("InstallDate");
            if (installDateRegistryKey == null)
            {
                SetRegistry("InstallDate", defaultDateAsString, RegistryValueKind.String);
                return Convert.ToDateTime(defaultDateAsString);
            }

            return Convert.ToDateTime(installDateRegistryKey);
        }

        /// <summary>
        /// Sets a registry key value in the registry.
        /// </summary>
        /// <param name="key">The sub key to create.</param>
        /// <param name="value">The value to use.</param>
        /// <param name="valueKind">The type of registry key value to set.</param>
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
        /// Retrieves a Registry Key value for the registry.
        /// </summary>
        /// <param name="key">The sub key to open.</param>
        /// <returns>The value of the registry key.</returns>
        private static object RetrieveFromRegistry(string key)
        {
            const string SubKey = @"SOFTWARE\CodePlex\StyleCop";

            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(SubKey);
            return registryKey == null ? null : registryKey.GetValue(key);
        }

        #endregion
    }
}