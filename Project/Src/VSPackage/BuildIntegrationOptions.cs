//-----------------------------------------------------------------------
// <copyright file="BuildIntegrationOptions.cs">
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
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using Microsoft.Build.BuildEngine;
    using Microsoft.VisualStudio.Shell.Interop;

    /// <summary>
    /// Allows setting the company and copyright requirements.
    /// </summary>
    public partial class BuildIntegrationOptions : UserControl, IPropertyControlPage
    {
        #region Private Constants

        /// <summary>
        /// The name of the enabled property.
        /// </summary>
        private const string PropertyName = "StyleCopEnabled";

        #endregion Private Constants

        #region Private Fields

        /// <summary>
        /// The tab control which hosts this page.
        /// </summary>
        private PropertyControl tabControl;

        /// <summary>
        /// True if the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// The VS project.
        /// </summary>
        private Project project;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the BuildIntegrationOptions class.
        /// </summary>
        /// <param name="project">The MSBuild project.</param>
        public BuildIntegrationOptions(Project project)
        {
            Param.RequireNotNull(project, "project");

            this.project = project;
            this.InitializeComponent();
        }

        #endregion Public Constructors

        /// <summary>
        /// Treat Style Cop error as warnings or errors.
        /// </summary>
        private enum TreatError
        {
            AsWarning,
            AsError
        }

        #region Public Properties

        /// <summary>
        /// Gets the name of the the tab.
        /// </summary>
        public string TabName
        {
            get
            {
                return Strings.BuildIntegrationTabTitle;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether any data on the page is dirty.
        /// </summary>
        public bool Dirty
        {
            get
            {
                return this.dirty;
            }

            set
            {
                Param.Ignore(value); 
                
                if (this.dirty != value)
                {
                    this.dirty = value;
                    this.tabControl.DirtyChanged();
                }
            }
        }

        #endregion Public Properties

        #region Private Properties

        /// <summary>
        /// Gets a value indicating whether StyleCop build integration is enabled for the project.
        /// </summary>
        private bool IsBuildIntegrationEnabledInProject
        {
            get
            {
                return this.project.Imports.Cast<Import>().Any(p => string.Equals(p.ProjectPath, @"$(ProgramFiles)\MSBuild\StyleCop\v4.7\StyleCop.targets", StringComparison.OrdinalIgnoreCase));
            }
        }

        /// <summary>
        /// Gets current treat error setting in project.
        /// </summary>
        private TreatError TreatErrorInProject
        {
            get
            {
                return this.project.GetEvaluatedProperty("StyleCopTreatErrorsAsWarnings") == "false" ? TreatError.AsError : TreatError.AsWarning;
            }
        }

        #endregion Private Properties

        #region Public Methods

        /// <summary>
        /// Initializes the page.
        /// </summary>
        /// <param name="propertyControl">The tab control object.</param>
        public void Initialize(PropertyControl propertyControl)
        {
            Param.RequireNotNull(propertyControl, "propertyControl");

            this.tabControl = propertyControl;

            this.InitializeSettings();

            this.dirty = false;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Called before all pages are applied.
        /// </summary>
        /// <returns>Returns false if no pages should be applied.</returns>
        public bool PreApply()
        {
            return true;
        }

        /// <summary>
        /// Called after all pages have been applied.
        /// </summary>
        /// <param name="wasDirty">The dirty state of the page before it was applied.</param>
        public void PostApply(bool wasDirty)
        {
            Param.Ignore(wasDirty);
        }

        /// <summary>
        /// Saves the data and clears the dirty flag.
        /// </summary>
        /// <returns>Returns true if the data is saved, false if not.</returns>
        public bool Apply()
        {
            if (this.checkBox.Checked && !this.IsBuildIntegrationEnabledInProject)
            {
                this.EnableBuildIntegrationInProject();
            }
            else if (!this.checkBox.Checked && this.IsBuildIntegrationEnabledInProject)
            {
                this.DisableBuildIntegrationInProject();
            }

            if (this.radioButtonAsWarning.Checked && this.TreatErrorInProject != TreatError.AsWarning)
            {
                this.TreatErrorAsWarningInProject();
            }
            else if (this.radioButtonAsError.Checked && this.TreatErrorInProject != TreatError.AsError)
            {
                this.TreatErrorAsErrorInProject();
            }

            this.project.Save(this.project.FullFileName);

            this.dirty = false;
            this.tabControl.DirtyChanged();

            return true;
        }

        /// <summary>
        /// Called when the page is activated.
        /// </summary>
        /// <param name="activated">Indicates whether the page is being activated or deactivated.</param>
        public void Activate(bool activated)
        {
            Param.Ignore(activated);
        }

        /// <summary>
        /// Refreshes the bold state of items on the page.
        /// </summary>
        public void RefreshSettingsOverrideState()
        {
            if (this.dirty == false)
            {
                this.InitializeSettings();
            }
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        /// Initializes the settings on the page.
        /// </summary>
        private void InitializeSettings()
        {
            this.checkBox.Checked = this.IsBuildIntegrationEnabledInProject;
            this.radioButtonAsError.Checked = this.TreatErrorInProject == TreatError.AsError;
            this.radioButtonAsWarning.Checked = this.TreatErrorInProject == TreatError.AsWarning;
            this.SetTreatGroupEnabledState();
            this.SetBoldState();
        }

        /// <summary>
        /// Enables StyleCop build integration for the project.
        /// </summary>
        private void EnableBuildIntegrationInProject()
        {
            this.SetBuildIntegrationInProject(true);
        }

        /// <summary>
        /// Disables StyleCop build integration for the project.
        /// </summary>
        private void DisableBuildIntegrationInProject()
        {
            this.SetBuildIntegrationInProject(false);
        }

        /// <summary>
        /// Sets build integration setting in project.
        /// </summary>
        /// <param name="enable">Enable build integration.</param>
        private void SetBuildIntegrationInProject(bool enable)
        {
            Param.AssertNotNull(enable, "enable");

            var import = this.project
                .Imports
                .Cast<Import>()
                .FirstOrDefault(p => string.Equals(p.ProjectPath, @"$(ProgramFiles)\MSBuild\StyleCop\v4.7\StyleCop.targets", StringComparison.OrdinalIgnoreCase));
            if (enable && import == null)
            {
                this.project.AddNewImport(@"$(ProgramFiles)\MSBuild\StyleCop\v4.7\StyleCop.targets", string.Empty);
            }
            else if (!enable && import != null)
            {
                this.project.Imports.RemoveImport(import);
            }
        }

        /// <summary>
        /// Sets treat error setting as warnings.
        /// </summary>
        private void TreatErrorAsWarningInProject()
        {
            this.project.SetProperty("StyleCopTreatErrorsAsWarnings", "true", string.Empty);
        }

        /// <summary>
        /// Sets treat error setting as errors.
        /// </summary>
        private void TreatErrorAsErrorInProject()
        {
            this.project.SetProperty("StyleCopTreatErrorsAsWarnings", "false", string.Empty);
        }

        /// <summary>
        /// Called when the checkbox is checked or unchecked.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void CheckBoxCheckedChanged(object sender, System.EventArgs e)
        {
            Param.Ignore(sender, e);

            this.dirty = true;
            this.tabControl.DirtyChanged();

            this.SetTreatGroupEnabledState();
            this.SetBoldState();
        }

        /// <summary>
        /// Called when the radio button is checked or unchecked.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void RadioButtonCheckedChanged(object sender, System.EventArgs e)
        {
            Param.Ignore(sender, e);

            this.dirty = true;
            this.tabControl.DirtyChanged();

            this.SetBoldState();
        }

        /// <summary>
        /// Sets the bold state of the item.
        /// </summary>
        /// <param name="item">The item to set.</param>
        /// <param name="bold">The bold state.</param>
        private void SetBoldState(Control item, bool bold)
        {
            Param.AssertNotNull(item, "item");
            Param.Ignore(bold);

            // Dispose the item's current font if necessary.
            if (item.Font != this.Font && item.Font != null)
            {
                item.Font.Dispose();
            }

            // Create and set the new font.
            item.Font = bold ? new Font(this.Font, FontStyle.Bold) : new Font(this.Font, FontStyle.Regular);
        }

        /// <summary>
        /// Sets the bold state of the control items.
        /// </summary>
        private void SetBoldState()
        {
            this.SetBoldState(this.checkBox, this.checkBox.Checked != this.IsBuildIntegrationEnabledInProject);
            this.SetBoldState(this.radioButtonAsWarning, this.radioButtonAsWarning.Checked && this.TreatErrorInProject != TreatError.AsWarning);
            this.SetBoldState(this.radioButtonAsError, this.radioButtonAsError.Checked && this.TreatErrorInProject != TreatError.AsError);
        }

        /// <summary>
        /// Sets the enable state of the treat group items.
        /// </summary>
        private void SetTreatGroupEnabledState()
        {
            this.descriptionTreat.Enabled = this.radioButtonAsError.Enabled = this.radioButtonAsWarning.Enabled = this.checkBox.Checked;
        }

        #endregion Private Methods
    }
}