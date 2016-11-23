// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CompanyInformation.cs" company="https://github.com/StyleCop">
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
//   Allows setting the company and copyright requirements.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Allows setting the company and copyright requirements.
    /// </summary>
    public partial class CompanyInformation : UserControl, IPropertyControlPage
    {
        #region Fields

        /// <summary>
        /// The analyzer that this settings page is attached to.
        /// </summary>
        private readonly SourceAnalyzer analyzer;

        /// <summary>
        /// True if the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// The tab control which hosts this page.
        /// </summary>
        private PropertyControl tabControl;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CompanyInformation class.
        /// </summary>
        public CompanyInformation()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the CompanyInformation class.
        /// </summary>
        /// <param name="analyzer">
        /// The analyzer that this settings page is attached to.
        /// </param>
        public CompanyInformation(DocumentationRules analyzer)
            : this()
        {
            Param.RequireNotNull(analyzer, "analyzer");
            this.analyzer = analyzer;
        }

        #endregion

        #region Public Properties

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

        /// <summary>
        /// Gets the name of the the tab.
        /// </summary>
        public string TabName
        {
            get
            {
                return Strings.CompanyInformationTab;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when the page is activated.
        /// </summary>
        /// <param name="activated">
        /// Indicates whether the page is being activated or deactivated.
        /// </param>
        public void Activate(bool activated)
        {
            Param.Ignore(activated);
        }

        /// <summary>
        /// Saves the data and clears the dirty flag.
        /// </summary>
        /// <returns>Returns true if the data is saved, false if not.</returns>
        public bool Apply()
        {
            if (this.analyzer != null)
            {
                if (!this.checkBox.Checked)
                {
                    this.analyzer.ClearSetting(this.tabControl.LocalSettings, DocumentationRules.CompanyNameProperty);
                    this.analyzer.ClearSetting(this.tabControl.LocalSettings, DocumentationRules.CopyrightProperty);
                }
                else
                {
                    if (this.companyName.Text.Length == 0 || this.copyright.Text.Length == 0)
                    {
                        AlertDialog.Show(this.tabControl.Core, this, Strings.MissingCompanyOrCopyright, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);

                        return false;
                    }
                    else
                    {
                        this.analyzer.SetSetting(
                            this.tabControl.LocalSettings, new StringProperty(this.analyzer, DocumentationRules.CompanyNameProperty, this.companyName.Text));

                        this.analyzer.SetSetting(
                            this.tabControl.LocalSettings, new StringProperty(this.analyzer, DocumentationRules.CopyrightProperty, this.copyright.Text));
                    }
                }
            }

            this.dirty = false;
            this.tabControl.DirtyChanged();

            return true;
        }

        /// <summary>
        /// Initializes the page.
        /// </summary>
        /// <param name="propertyControl">
        /// The tab control object.
        /// </param>
        public void Initialize(PropertyControl propertyControl)
        {
            Param.RequireNotNull(propertyControl, "propertyControl");

            this.tabControl = propertyControl;

            this.InitializeSettings();
            this.DetectBoldState();

            this.dirty = false;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Called after all pages have been applied.
        /// </summary>
        /// <param name="wasDirty">
        /// The dirty state of the page before it was applied.
        /// </param>
        public void PostApply(bool wasDirty)
        {
            Param.Ignore(wasDirty);
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
        /// Refreshes the bold state of items on the page.
        /// </summary>
        public void RefreshSettingsOverrideState()
        {
            if (this.dirty == false)
            {
                this.InitializeSettings();
            }

            this.DetectBoldState();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Called when the checkbox is checked or unchecked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CheckBoxCheckedChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            this.dirty = true;
            this.tabControl.DirtyChanged();

            this.companyName.Enabled = this.checkBox.Checked;
            this.copyright.Enabled = this.checkBox.Checked;
        }

        /// <summary>
        /// Called when the company name text is changed.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CompanyNameTextChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            this.DetectCompanyNameBoldState();

            this.dirty = true;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Called when the copyright text is changed.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void CopyrightTextChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            this.DetectCopyrightBoldState();

            this.dirty = true;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Detects the bold state of the controls.
        /// </summary>
        private void DetectBoldState()
        {
            this.DetectCompanyNameBoldState();
            this.DetectCopyrightBoldState();
        }

        /// <summary>
        /// Detects the bold state of the company name text box.
        /// </summary>
        private void DetectCompanyNameBoldState()
        {
            if (this.analyzer != null)
            {
                StringProperty currentValue = new StringProperty(this.analyzer, DocumentationRules.CompanyNameProperty, this.companyName.Text);
                this.SetBoldState(
                    this.companyName, this.tabControl.SettingsComparer.IsAddInSettingOverwritten(this.analyzer, DocumentationRules.CompanyNameProperty, currentValue));
            }
        }

        /// <summary>
        /// Detects the bold state of the copyright text box.
        /// </summary>
        private void DetectCopyrightBoldState()
        {
            StringProperty currentValue = new StringProperty(this.analyzer, DocumentationRules.CopyrightProperty, this.copyright.Text);
            this.SetBoldState(
                this.copyright, this.tabControl.SettingsComparer.IsAddInSettingOverwritten(this.analyzer, DocumentationRules.CopyrightProperty, currentValue));
        }

        /// <summary>
        /// Initializes the settings on the page.
        /// </summary>
        private void InitializeSettings()
        {
            if (this.analyzer != null)
            {
                // Get the properties.
                StringProperty companyNameProperty = this.analyzer.GetSetting(this.tabControl.MergedSettings, DocumentationRules.CompanyNameProperty) as StringProperty;

                if (companyNameProperty != null)
                {
                    this.companyName.Text = companyNameProperty.Value;
                }

                StringProperty copyrightProperty = this.analyzer.GetSetting(this.tabControl.MergedSettings, DocumentationRules.CopyrightProperty) as StringProperty;

                if (copyrightProperty != null)
                {
                    this.copyright.Text = copyrightProperty.Value;
                }

                this.checkBox.Checked = companyNameProperty != null || copyrightProperty != null;
                this.CheckBoxCheckedChanged(this.checkBox, new EventArgs());
            }
        }

        /// <summary>
        /// Sets the bold state of the item.
        /// </summary>
        /// <param name="item">
        /// The item to set.
        /// </param>
        /// <param name="bold">
        /// The bold state.
        /// </param>
        private void SetBoldState(TextBox item, bool bold)
        {
            Param.AssertNotNull(item, "item");
            Param.Ignore(bold);

            // Dispose the item's current font if necessary.
            if (item.Font != this.Font && item.Font != null)
            {
                item.Font.Dispose();
            }

            // Create and set the new font.
            if (bold)
            {
                item.Font = new Font(this.Font, FontStyle.Bold);
            }
            else
            {
                item.Font = new Font(this.Font, FontStyle.Regular);
            }
        }

        #endregion
    }
}