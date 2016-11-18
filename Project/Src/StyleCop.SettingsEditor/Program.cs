//-----------------------------------------------------------------------
// <copyright file="Program.cs">
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
//-----------------------------------------------------------------------
namespace StyleCopSettingsEditor
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Security;
    using System.Windows.Forms;
    using StyleCop;
    using StyleCop.SettingsEditor.Properties;

    /// <summary>
    /// The main entry point class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// The main entry point for the program.
        /// </summary>
        /// <param name="args">The event arguments.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "The default options are adequate.")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", Justification = "The spelling of args is fine here.")]
        [STAThread]
        public static void Main(string[] args)
        {
            Param.Ignore(args);

            if (args != null && args.Length > 0 && !string.IsNullOrEmpty(args[0]))
            {
                try
                {
                    string settingsFilePath = Path.GetFullPath(args[0]);
                    settingsFilePath = Environment.ExpandEnvironmentVariables(settingsFilePath);

                    if (File.Exists(settingsFilePath))
                    {
                        Application.EnableVisualStyles();
                        Application.SetCompatibleTextRenderingDefault(false);

                        StyleCopCore core = new StyleCopCore(null, null);
                        core.Initialize(null, true);
                        core.WriteResultsCache = false;
                        core.DisplayUI = true;
                        core.ShowSettings(settingsFilePath);
                    }
                    else
                    {
                        MessageBox.Show(string.Format(CultureInfo.CurrentUICulture, Resources.SettingsFileDoesNotExist, settingsFilePath), null, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (IOException ex)
                {
                    MessageBox.Show(
                        string.Format(CultureInfo.CurrentUICulture, Resources.SettingsFileCouldNotBeLoaded, ex.Message),
                        null,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (UnauthorizedAccessException ex)
                {
                    MessageBox.Show(
                        string.Format(CultureInfo.CurrentUICulture, Resources.SettingsFileCouldNotBeLoaded, ex.Message),
                        null,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (SecurityException ex)
                {
                    MessageBox.Show(
                        string.Format(CultureInfo.CurrentUICulture, Resources.SettingsFileCouldNotBeLoaded, ex.Message),
                        null,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                catch (ArgumentException ex)
                {
                    MessageBox.Show(
                        string.Format(CultureInfo.CurrentUICulture, Resources.SettingsFileCouldNotBeLoaded, ex.Message),
                        null,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Resources.InvalidArguments, null, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}