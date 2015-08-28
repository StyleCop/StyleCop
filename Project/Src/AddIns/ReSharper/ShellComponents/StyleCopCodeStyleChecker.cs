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
// <summary>
//   The StyleCop CodeStyle Checker.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper800.ShellComponents
{
    #region Using Directives

    using System;
    using System.Windows.Forms;

    using JetBrains.Application;
    using JetBrains.Application.Components;
    using JetBrains.Application.Settings;
    using JetBrains.Application.Settings.Store.Implementation;

    using StyleCop.ReSharper800.Core;
    using StyleCop.ReSharper800.Options;

    #endregion

    /// <summary>
    /// The StyleCop CodeStyle Checker.
    /// </summary>
    [ShellComponent(ProgramConfigurations.ALL)]
    public class StyleCopCodeStyleChecker : IDisposable
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the StyleCopCodeStyleChecker class.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime for this instance.
        /// </param>
        public StyleCopCodeStyleChecker(JetBrains.DataFlow.Lifetime lifetime)
        {
            StyleCopReferenceHelper.EnsureStyleCopIsLoaded();
            this.Init(lifetime);
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// The initializer for this ShellComponent.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime for this object.
        /// </param>
        public void Init(JetBrains.DataFlow.Lifetime lifetime)
        {
            RegistryUtils registryUtils = new RegistryUtils();

            object oneTimeInitializationRequiredRegistryKey = registryUtils.CUGetValue("LastInitializationDate");
            DateTime initializationDate = Convert.ToDateTime(oneTimeInitializationRequiredRegistryKey);

            string todayAsString = DateTime.Today.ToString("yyyy-MM-dd");

            string value = registryUtils.LMGetValue("InstallDate") as string;

            DateTime lastInstalledDate;

            try
            {
                lastInstalledDate = Convert.ToDateTime(value);

                // If the installer stored a date that has now been read back in and seems to be in the future
                // then use the LocalUserInstallDate value.
                if (lastInstalledDate > DateTime.Today)
                {
                    lastInstalledDate = GetInstallDateFromLocalUserRegistry(registryUtils, todayAsString);
                }
            }
            catch (FormatException ex)
            {
                // In some locales the installer saves the date in a format we can't parse back out.
                // Use today as the installed date and store it in the HKCU key.
                lastInstalledDate = GetInstallDateFromLocalUserRegistry(registryUtils, todayAsString);
            }

            if (oneTimeInitializationRequiredRegistryKey == null || initializationDate < lastInstalledDate)
            {
                SettingsStore settingsStore = Shell.Instance.GetComponent<SettingsStore>();

                IContextBoundSettingsStoreLive settings = settingsStore.BindToContextLive(lifetime, ContextRange.ApplicationWide);

                bool checkReSharperCodeStyleOptionsAtStartUp = settings.GetValue((StyleCopOptionsSettingsKey key) => key.CheckReSharperCodeStyleOptionsAtStartUp);

                if (checkReSharperCodeStyleOptionsAtStartUp)
                {
                    if (!StyleCopOptionsPage.CodeStyleOptionsValid(settings))
                    {
                        DialogResult result =
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

            registryUtils.CUSetValue("LastInitializationDate", todayAsString);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the InstallDate registry key value.
        /// </summary>
        /// <param name="registryUtils">
        /// A <see cref="RegistryUtils"/> instance to access the registry.
        /// </param>
        /// <param name="defaultDateAsString">
        /// The date to set the install date to if its value is not found in the registry.
        /// </param>
        /// <returns>
        /// The DateTime of the InstallDate LOCALUSER registry key.
        /// </returns>
        private static DateTime GetInstallDateFromLocalUserRegistry(RegistryUtils registryUtils, string defaultDateAsString)
        {
            string installDateRegistryKey = registryUtils.CUGetValue("InstallDate") as string;

            if (installDateRegistryKey != null)
            {
                return Convert.ToDateTime(installDateRegistryKey);
            }

            registryUtils.CUSetValue("InstallDate", defaultDateAsString);

            return Convert.ToDateTime(defaultDateAsString);
        }

        #endregion
    }
}