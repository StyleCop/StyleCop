//-----------------------------------------------------------------------
// <copyright file="ViolationTask.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
namespace Microsoft.StyleCop.VisualStudio
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Security;
    using System.Windows.Forms;
    using EnvDTE;
    using Microsoft.VisualStudio.Shell;

    /// <summary>
    /// A representation of a StyleCop violation in the error list.
    /// </summary>
    internal class ViolationTask : ErrorTask
    {
        #region Private Fields

        /// <summary>
        /// The StyleCop violation that this task represents.
        /// </summary>
        private ViolationInfo violation;

        /// <summary>
        /// Instance of the analysis core.
        /// </summary>
        private StyleCopCore core;

        #endregion Private Fields

        /// <summary>
        /// Initializes a new instance of the ViolationTask class.
        /// </summary>
        /// <param name="serviceProvider">System service provider.</param>
        /// <param name="violation">The StyleCop violation that this task represents.</param>
        internal ViolationTask(IServiceProvider serviceProvider, ViolationInfo violation)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");
            Param.Ignore(violation);

            this.violation = violation;
            this.Column = 0;
            this.Document = violation.File;
            this.Line = violation.LineNumber - 1;
            this.Text = violation.Description;
            this.ErrorCategory = TaskErrorCategory.Warning;

            StyleCopVSPackage package = serviceProvider.GetService(typeof(StyleCopVSPackage)) as StyleCopVSPackage;
            Debug.Assert(package != null, "Unable to locate the package");

            this.core = package.Core;
        }

        /// <summary>
        /// Fired when the user navigates to this task in the list.
        /// </summary>
        /// <param name="e">Parameter is not used.</param>
        protected override void OnNavigate(System.EventArgs e)
        {
            Param.Ignore(e);

            if (this.Document != null && this.Document.Length > 0)
            {
                try
                {
                    Document document = ProjectUtilities.GetCodeDocument(this.Document);
                    if (document == null)
                    {
                        AlertDialog.Show(
                            this.core,
                            null,
                            Strings.CouldNotNavigateToFile,
                            Strings.Title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                    }
                    else
                    {
                        document.Activate();
                        TextSelection selection = (TextSelection)document.DTE.ActiveDocument.Selection;

                        try
                        {
                            selection.GotoLine(this.violation.LineNumber, true);

                            VirtualPoint vp = selection.ActivePoint;
                            vp.TryToShow(vsPaneShowHow.vsPaneShowCentered, 0);
                        }
                        catch (ArgumentException)
                        {
                            // This happens when the line number passed to GotoLine is beyond the end of the file, or is otherwise
                            // invalid. This can happen if the user has modified the file after StyleCop was run, and then
                            // click an item in the error list which now points to an invalid line number.
                        }
                    }
                }
                catch (System.Runtime.InteropServices.COMException)
                {
                    AlertDialog.Show(
                        this.core,
                        null,
                        Strings.CouldNotNavigateToFile,
                        Strings.Title, 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                AlertDialog.Show(
                    this.core,
                    null,
                    Strings.UnknownFile,
                    Strings.Title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Called when the user selects the 'Show Error Help' menu item.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        [SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "StyleCop does not currently support RTL.")]
        protected override void OnHelp(EventArgs e)
        {
            Param.Ignore(e);

            base.OnHelp(e);

            // Make sure we have a valid rule.
            if (this.violation.Rule == null || !this.violation.Rule.CheckId.StartsWith("SA", StringComparison.Ordinal))
            {
                MessageBox.Show(Strings.ErrorHelpNotAvailable, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (!this.ShowErrorHelp())
                {
                    MessageBox.Show(Strings.FailedToLaunchRulesHelp, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Gets the path to the Windows folder.
        /// </summary>
        /// <returns>Returns the path.</returns>
        private static string GetWindowsFolder()
        {
            string systemFolder;

            try
            {
                systemFolder = Environment.GetEnvironmentVariable("windir");
            }
            catch (SecurityException)
            {
                systemFolder = Environment.GetFolderPath(Environment.SpecialFolder.System);
                int index = systemFolder.LastIndexOf('\\');
                if (index > -1)
                {
                    systemFolder = systemFolder.Substring(0, index);
                }
            }

            return systemFolder;
        }

        /// <summary>
        /// Shows error help for a StyleCop rule.
        /// </summary>
        /// <returns>Returns true if the help was successfully shown.</returns>
        private bool ShowErrorHelp()
        {
            // Track success.
            bool success = false;

            try
            {
                // Find the hh.exe application.
                string systemFolder = GetWindowsFolder();
                if (!string.IsNullOrEmpty(systemFolder))
                {
                    string hh = Path.Combine(systemFolder, "hh.exe");

                    if (File.Exists(hh))
                    {
                        // Find the documentation chm file.
                        string chm = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Docs\\StyleCop.chm");
                        if (File.Exists(chm))
                        {
                            // Create the path to the specific help topic to display.
                            string arguments = string.Format(CultureInfo.InvariantCulture, "{0}::/{1}.html", chm, this.violation.Rule.CheckId);

                            // Start the documentation process.
                            System.Diagnostics.Process.Start(hh, arguments);

                            // Indicate success.
                            success = true;
                        }
                    }
                }
            }
            catch (ArgumentException)
            {
                // Can be thrown if a null or invalid argument is passed.
            }
            catch (IOException)
            {
                // Can be thrown for any IO error in Path or Process.Start
            }
            catch (UnauthorizedAccessException)
            {
                // Can be thrown if the user does not have access to the paths used above.
            }
            catch (SecurityException)
            {
                // Can be thrown if the system detects a security violation while launching the process
            }
            catch (InvalidOperationException)
            {
                // Can be thrown by Process.Start
            }
            catch (Win32Exception)
            {
                // Can be thrown by Process.Start
            }

            return success;
        }
    }
}
