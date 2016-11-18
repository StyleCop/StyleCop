//--------------------------------------------------------------------------
// <copyright file="PackageCommandSet.cs">
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
    using System.Diagnostics;
    using Microsoft.VisualStudio.Shell;

    using StyleCop.Diagnostics;

    /// <summary>
    /// Handles the menu commands at the Package level.
    /// </summary>
    internal class PackageCommandSet : CommandSet
    {
        #region Private Fields

        /// <summary>
        /// The helper class for performing analysis.
        /// </summary>
        private AnalysisHelper helper;

        /// <summary>
        /// Instance of the analysis core.
        /// </summary>
        private StyleCopCore core;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the PackageCommandSet class.
        /// </summary>
        /// <param name="serviceProvider">Service Provider.</param>
        public PackageCommandSet(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            Param.AssertNotNull(serviceProvider, "serviceProvider");

            this.AddCommands();
        }

        #endregion Public Constructors

        /// <summary>
        /// Initializes the object instance.
        /// </summary>
        protected internal override void Initialize()
        {
            base.Initialize();

            StyleCopVSPackage package = this.ServiceProvider.GetService(typeof(StyleCopVSPackage)) as StyleCopVSPackage;
            Debug.Assert(package != null, "Unable to locate the package");

            this.core = package.Core;
            this.helper = package.Helper;
        }

        #region Private Methods

        /// <summary>
        /// Add Commands for the menu items handled by the package.
        /// </summary>
        private void AddCommands()
        {
            Debug.Assert(this.CommandList != null, "The internal command list has not been created.");

            // StyleCop -> Analyze
            // Solution Explorer Context menu item, for a single project item 
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeAnalyzeItem),
                    null,
                    new EventHandler(this.StatusAnalyzeSingleProjectItem),
                    CommandIdList.AnalyzeItem));

            // StyleCop -> Exclude
            // Solution Explorer Context menu item, for a single project item 
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeExcludeItem),
                    null,
                    new EventHandler(this.StatusExcludeSingleProjectItem),
                    CommandIdList.ExcludeItem));

            // StyleCop -> Include
            // Solution Explorer Context menu item, for a single project item 
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeIncludeItem),
                    null,
                    new EventHandler(this.StatusIncludeSingleProjectItem),
                    CommandIdList.IncludeItem));

            // StyleCop -> Analyze This File
            // Code editor Context menu item, for an open code editor
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeAnalyzeThisFile),
                    null,
                    new EventHandler(this.StatusAnalyzeThisFile),
                    CommandIdList.AnalyzeThisFile));

            // StyleCop -> Exclude This File
            // Code editor Context menu item, for an open code editor
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeExcludeThisFile),
                    null,
                    new EventHandler(this.StatusExcludeThisFile),
                    CommandIdList.ExcludeThisFile));

            // StyleCop -> Include This File
            // Code editor Context menu item, for an open code editor
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeIncludeThisFile),
                    null,
                    new EventHandler(this.StatusIncludeThisFile),
                    CommandIdList.IncludeThisFile));

            // StyleCop -> Analyze 
            // Tools Main Menu And Solution Explorer Context menu item, for the solution
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeAnalyzeSolution),
                    null,
                    new EventHandler(this.StatusAnalyzeSolution),
                    CommandIdList.AnalyzeSolution));

            // StyleCop -> Reanalyze 
            // Tools Main Menu And Solution Explorer Context menu item, for the solution
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeReanalyzeSolution),
                    null,
                    new EventHandler(this.StatusAnalyzeSolution),
                    CommandIdList.ReanalyzeSolution));

            // StyleCop -> Reanalyze 
            // Tools Main Menu And Solution Explorer Context menu item, for the project
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeReanalyzeProject),
                    null,
                    new EventHandler(this.StatusAnalyzeProject),
                    CommandIdList.ReanalyzeProject));

            // StyleCop -> Analyze
            // Solution Explorer Context menu item, for a single project 
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeAnalyzeProject),
                    null,
                    new EventHandler(this.StatusAnalyzeProject),
                    CommandIdList.AnalyzeProject));

            // StyleCop -> Analyze
            // Solution Explorer Context menu item, for a folder
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeAnalyzeFolder),
                    null,
                    new EventHandler(this.StatusAnalyzeFolder),
                    CommandIdList.AnalyzeFolder));

            // StyleCop -> Project Settings
            // Solution Explorer Context menu item
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeProjectSettings),
                    null,
                    new EventHandler(this.StatusProjectSettings),
                    CommandIdList.ProjectSettings));

            // StyleCop -> Cancel
            // Tools Main menu, Solution Explorer - & code editor Context menu item
            this.CommandList.Add(
                new OleMenuCommand(
                    new EventHandler(this.InvokeCancel),
                    null,
                    new EventHandler(this.StatusCancel),
                    CommandIdList.Cancel));
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Analyze" at the solution level.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusAnalyzeSolution(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.SupportsStyleCop(this.helper, AnalysisType.Solution);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand, show);
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Analyze Item" on a single project item.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusAnalyzeSingleProjectItem(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.SupportsStyleCop(this.helper, AnalysisType.Item);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand, show);
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Exclude Item" on a single project item.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusExcludeSingleProjectItem(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.IsItemIncluded(AnalysisType.Item);
            
            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand,  show);
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Include Item" on a single project item.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusIncludeSingleProjectItem(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.IsItemIncluded(AnalysisType.Item);
            
            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand, !show);
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Analyze" on the context menu of the code editor.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusAnalyzeThisFile(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.SupportsStyleCop(this.helper, AnalysisType.File);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand, show);
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Exclude" on the context menu of the code editor.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusExcludeThisFile(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.IsItemIncluded(AnalysisType.File);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand, show);
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Include" on the context menu of the code editor.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusIncludeThisFile(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.IsItemIncluded(AnalysisType.File);
            
            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand,  !show);
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Analyze Item" on a single project item.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusAnalyzeFolder(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.SupportsStyleCop(this.helper, AnalysisType.Folder);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand, show);
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Analyze Item" on a single project item.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusAnalyzeProject(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            // Get the active project.
            bool show = ProjectUtilities.SupportsStyleCop(this.helper, AnalysisType.Project);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand, show);
        }

        /// <summary>
        /// Base status handler for the analyzer menu items.
        /// </summary>
        /// <param name="menuCommand">The menu item object to set the status on.</param>
        /// <param name="visible">Indicates whether the menu item should be visible.</param>
        /// <returns>False if it has been determined that this menu item should be hidden/disabled.</returns>
        private bool StatusAnalyzeBase(OleMenuCommand menuCommand, bool visible)
        {
            Param.AssertNotNull(menuCommand, "menuCommand");
            Param.Ignore(visible);

            menuCommand.Supported = true;
            menuCommand.Visible = visible;
            menuCommand.Enabled = visible;
            
            if (visible && this.core.Analyzing)
            {
                menuCommand.Visible = false;
                menuCommand.Enabled = false;
            }

            return menuCommand.Enabled;
        }

        /// <summary>
        /// Fired when the user invokes the menu item "Analyze Item".
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeAnalyzeItem(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            this.helper.Analyze(false, AnalysisType.Item);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item "Exclude Item".
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeExcludeItem(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            // This is called from the solution Explorer context menu
            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            ProjectUtilities.SetItemExcluded(AnalysisType.Item, true);
          
            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item "Include Item".
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeIncludeItem(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            ProjectUtilities.SetItemExcluded(AnalysisType.Item, false);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item Analyze from a code editor window.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeAnalyzeThisFile(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            this.helper.Analyze(false, AnalysisType.File);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item Exclude from a code editor window.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeExcludeThisFile(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            // Exclude the file
            ProjectUtilities.SetItemExcluded(AnalysisType.File, true);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item Include from a code editor window.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeIncludeThisFile(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            // Include the file
            ProjectUtilities.SetItemExcluded(AnalysisType.File, false);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item Analyze on one or several projects.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeAnalyzeProject(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            this.helper.Analyze(false, AnalysisType.Project);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item Analyze on the solution.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeAnalyzeSolution(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            this.helper.Analyze(false, AnalysisType.Solution);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item Reanalyze on a project.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeReanalyzeProject(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            this.helper.Analyze(true, AnalysisType.Project);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item Reanalyze on the solution.
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeReanalyzeSolution(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            this.helper.Analyze(true, AnalysisType.Solution);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when the user invokes the menu item "Analyze Folder".
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeAnalyzeFolder(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            StyleCopTrace.In(sender, eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);

            this.helper.Analyze(false, AnalysisType.Folder);

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Global Settings".
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusProjectSettings(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            bool show = ProjectUtilities.SupportsStyleCop(this.helper, AnalysisType.Project);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            this.StatusAnalyzeBase(menuCommand, show);
        }

        /// <summary>
        /// Fired when the user invokes the menu item "Project Settings".
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeProjectSettings(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);
            this.helper.LocalProjectSettings();
        }

        /// <summary>
        /// Fired when status must be determined for the menu item "Cancel".
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void StatusCancel(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            menuCommand.Supported = true;
            menuCommand.Visible = this.core.Analyzing;
            menuCommand.Enabled = this.core.Analyzing;
        }

        /// <summary>
        /// Fired when the user invokes the menu item "Cancel".
        /// </summary>
        /// <param name="sender">The <c>OleMenuCommand</c> that represents the menu item.</param>
        /// <param name="eventArgs">The event arguments.</param>
        private void InvokeCancel(object sender, EventArgs eventArgs)
        {
            Param.AssertNotNull(sender, "sender");
            Param.Ignore(eventArgs);

            OleMenuCommand menuCommand = (OleMenuCommand)sender;
            CommandSet.CheckMenuItemValidity(menuCommand);
            this.helper.Cancel();
        }

        #endregion Private Methods
    }
}