//-----------------------------------------------------------------------
// <copyright file="ViolationTask.cs">
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
namespace StyleCop.VisualStudio
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

    using Microsoft.VisualStudio;
    using Microsoft.VisualStudio.Shell;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// A representation of a StyleCop violation in the error list.
    /// </summary>
    internal class ViolationTask : ErrorTask
    {
        #region Private Fields

        /// <summary>
        /// The service provider we are created with.
        /// </summary>
        private readonly IServiceProvider serviceProvider;

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
        /// <param name="hierarchyItem">The HierarchyItem for the violations File or null if we don't know it yet.</param>
        internal ViolationTask(IServiceProvider serviceProvider, ViolationInfo violation, IVsHierarchy hierarchyItem)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");
            Param.Ignore(violation);
            Param.Ignore(hierarchyItem);

            this.violation = violation;
            this.Column = violation.ColumnNumber - 1;
            this.Document = violation.File;
            this.Line = violation.LineNumber - 1;
            this.Text = violation.Description;
            this.ErrorCategory = violation.Severity;
            this.serviceProvider = serviceProvider;
            this.HierarchyItem = hierarchyItem ?? this.GetHierarchyItem();
        }

        /// <summary>
        /// Gets an instance of the StyleCopCore.
        /// </summary>
        internal StyleCopCore Core
        {
            get
            {
                if (this.core == null)
                {
                    StyleCopVSPackage package = this.serviceProvider.GetService(typeof(StyleCopVSPackage)) as StyleCopVSPackage;
                    Debug.Assert(package != null, "Unable to locate the package");
                    this.core = package.Core;
                }

                return this.core;
            }
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
                            this.Core,
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
                        this.Core,
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
                    this.Core,
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
        /// Gets the containing project of the file (The IVsHierarchy) if available.
        /// </summary>
        /// <returns>The IVsHierarchyItem for the current document.</returns>
        private IVsHierarchy GetHierarchyItem()
        {
            var solution = this.serviceProvider.GetService(typeof(SVsSolution)) as IVsSolution;

            if (solution == null || this.Document == null)
            {
                return null;
            }

            var project = ProjectUtilities.GetProject(this.Document);
            
            if (project == null)
            {
                return null;
            }

            IVsHierarchy hierarchyItem;
            var result = solution.GetProjectOfUniqueName(project.UniqueName, out hierarchyItem);
            if (result == VSConstants.S_OK)
            {
                return hierarchyItem;
            }

            return null;
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