// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheOptions.cs" company="http://stylecop.codeplex.com">
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
//   Options dialog to choose which settings files to use.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;

    /// <summary>
    /// Options dialog to choose which settings files to use.
    /// </summary>
    internal class CacheOptions : UserControl, IPropertyControlPage
    {
        #region Fields

        private CheckBox autoUpdateCheckBox;

        private PropertyDescriptor<bool> autoUpdateCheckPropertyDescriptor;

        private BooleanProperty autoUpdateParentProperty;

        private Label checkForUpdatesLabel;

        private IContainer components;

        private ComboBox cultureComboBox;

        private StringProperty cultureParentProperty;

        private PropertyDescriptor<string> culturePropertyDescriptor;

        private Label daysLabel;

        private MaskedTextBox daysMaskedTextBox;

        private IntProperty daysToCheckParentProperty;

        private PropertyDescriptor<int> daysToCheckPropertyDescriptor;

        /// <summary>
        /// Indicates whether the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// Indicates whether to enable writing of the cache.
        /// </summary>
        private CheckBox enableCache;

        /// <summary>
        /// The page description.
        /// </summary>
        private Label label1;

        private Label label2;

        private Label label3;

        private Label label5;

        private MaskedTextBox maxViolationCountMaskedTextBox;

        private IntProperty maxViolationCountParentProperty;

        private PropertyDescriptor<int> maxViolationCountPropertyDescriptor;

        private Panel panel3;

        /// <summary>
        /// The tab control hosting this page.
        /// </summary>
        private PropertyControl tabControl;

        private ToolTip toolTip;

        /// <summary>
        /// The global value of the property.
        /// </summary>
        private BooleanProperty writeCacheParentProperty;

        private CheckBox violationsAsErrorsCheckBox;

        private PropertyDescriptor<bool> violationsAsErrorsPropertyDescriptor;

        private BooleanProperty violationsAsErrorsParentProperty;

        /// <summary>
        /// Property writeCachePropertyDescriptor.
        /// </summary>
        private PropertyDescriptor<bool> writeCachePropertyDescriptor;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the CacheOptions class.
        /// </summary>
        public CacheOptions()
        {
            this.InitializeComponent();
            this.daysMaskedTextBox.ValidatingType = typeof(int);
            this.maxViolationCountMaskedTextBox.ValidatingType = typeof(int);

            this.cultureComboBox.Items.Add("en-US");

            List<CultureInfo> cultures = new List<CultureInfo>(GetSatelliteLanguages("StyleCop.CSharp.Rules"));

            foreach (CultureInfo cultureInfo in cultures)
            {
                this.cultureComboBox.Items.Add(cultureInfo.IetfLanguageTag);
            }
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether the page is dirty.
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
        /// Gets the value to place on the page tab.
        /// </summary>
        public string TabName
        {
            get
            {
                return Strings.CacheTab;
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
        /// <returns>Returns true if the data was saved, false if not.</returns>
        public bool Apply()
        {
            if (this.ValidatePage())
            {
                this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                    new BooleanProperty(this.tabControl.Core, this.writeCachePropertyDescriptor.PropertyName, this.enableCache.Checked));

                this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                    new BooleanProperty(this.tabControl.Core, this.autoUpdateCheckPropertyDescriptor.PropertyName, this.autoUpdateCheckBox.Checked));

                this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                   new BooleanProperty(this.tabControl.Core, this.violationsAsErrorsPropertyDescriptor.PropertyName, this.violationsAsErrorsCheckBox.Checked));

                this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                    new IntProperty(this.tabControl.Core, this.daysToCheckPropertyDescriptor.PropertyName, Convert.ToInt32(this.daysMaskedTextBox.Text)));

                this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                    new IntProperty(
                        this.tabControl.Core, this.maxViolationCountPropertyDescriptor.PropertyName, Convert.ToInt32(this.maxViolationCountMaskedTextBox.Text)));

                this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                    new StringProperty(this.tabControl.Core, this.culturePropertyDescriptor.PropertyName, this.cultureComboBox.SelectedItem.ToString()));

                this.dirty = false;
                this.tabControl.DirtyChanged();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Initializes the page.
        /// </summary>
        /// <param name="propertyControl">
        /// The tab control object.
        /// </param>
        public void Initialize(PropertyControl propertyControl)
        {
            Param.AssertNotNull(propertyControl, "propertyControl");

            this.tabControl = propertyControl;

            // Get the cache setting.
            this.writeCachePropertyDescriptor = this.tabControl.Core.PropertyDescriptors["WriteCache"] as PropertyDescriptor<bool>;

            this.writeCacheParentProperty = this.tabControl.ParentSettings == null
                                                ? null
                                                : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.writeCachePropertyDescriptor.PropertyName) as
                                                  BooleanProperty;

            BooleanProperty mergedWriteCacheProperty = this.tabControl.MergedSettings == null
                                                           ? null
                                                           : this.tabControl.MergedSettings.GlobalSettings.GetProperty(this.writeCachePropertyDescriptor.PropertyName) as
                                                             BooleanProperty;

            this.enableCache.Checked = mergedWriteCacheProperty == null ? this.writeCachePropertyDescriptor.DefaultValue : mergedWriteCacheProperty.Value;

            // Auto update check
            this.autoUpdateCheckPropertyDescriptor = this.tabControl.Core.PropertyDescriptors["AutoCheckForUpdate"] as PropertyDescriptor<bool>;

            this.autoUpdateParentProperty = this.tabControl.ParentSettings == null
                                                ? null
                                                : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.autoUpdateCheckPropertyDescriptor.PropertyName) as
                                                  BooleanProperty;

            BooleanProperty mergedAutoUpdateProperty = this.tabControl.MergedSettings == null
                                                           ? null
                                                           : this.tabControl.MergedSettings.GlobalSettings.GetProperty(
                                                               this.autoUpdateCheckPropertyDescriptor.PropertyName) as BooleanProperty;

            this.autoUpdateCheckBox.Checked = mergedAutoUpdateProperty == null ? this.autoUpdateCheckPropertyDescriptor.DefaultValue : mergedAutoUpdateProperty.Value;

            // Days to Check
            this.daysToCheckPropertyDescriptor = this.tabControl.Core.PropertyDescriptors["DaysToCheckForUpdates"] as PropertyDescriptor<int>;

            this.daysToCheckParentProperty = this.tabControl.ParentSettings == null
                                                 ? null
                                                 : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.daysToCheckPropertyDescriptor.PropertyName) as
                                                   IntProperty;

            IntProperty mergedDaysToCheckProperty = this.tabControl.MergedSettings == null
                                                        ? null
                                                        : this.tabControl.MergedSettings.GlobalSettings.GetProperty(this.daysToCheckPropertyDescriptor.PropertyName) as
                                                          IntProperty;

            this.daysMaskedTextBox.Text = mergedDaysToCheckProperty == null
                                              ? this.daysToCheckPropertyDescriptor.DefaultValue.ToString(CultureInfo.InvariantCulture)
                                              : mergedDaysToCheckProperty.Value.ToString(CultureInfo.InvariantCulture);

            // Max Violation Count
            this.maxViolationCountPropertyDescriptor = this.tabControl.Core.PropertyDescriptors["MaxViolationCount"] as PropertyDescriptor<int>;

            this.maxViolationCountParentProperty = this.tabControl.ParentSettings == null
                                                       ? null
                                                       : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.maxViolationCountPropertyDescriptor.PropertyName)
                                                         as IntProperty;

            IntProperty mergedMaxViolationCountProperty = this.tabControl.MergedSettings == null
                                                              ? null
                                                              : this.tabControl.MergedSettings.GlobalSettings.GetProperty(
                                                                  this.maxViolationCountPropertyDescriptor.PropertyName) as IntProperty;

            this.maxViolationCountMaskedTextBox.Text = mergedMaxViolationCountProperty == null
                                                           ? this.maxViolationCountPropertyDescriptor.DefaultValue.ToString(CultureInfo.InvariantCulture)
                                                           : mergedMaxViolationCountProperty.Value.ToString(CultureInfo.InvariantCulture);

            // Culture
            this.culturePropertyDescriptor = this.tabControl.Core.PropertyDescriptors["Culture"] as PropertyDescriptor<string>;

            this.cultureParentProperty = this.tabControl.ParentSettings == null
                                             ? null
                                             : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.culturePropertyDescriptor.PropertyName) as StringProperty;

            StringProperty mergedCultureProperty = this.tabControl.MergedSettings == null
                                                       ? null
                                                       : this.tabControl.MergedSettings.GlobalSettings.GetProperty(this.culturePropertyDescriptor.PropertyName) as
                                                         StringProperty;

            this.cultureComboBox.SelectedIndex =
                this.cultureComboBox.FindStringExact(
                    mergedCultureProperty == null
                        ? this.culturePropertyDescriptor.DefaultValue.ToString(CultureInfo.InvariantCulture)
                        : mergedCultureProperty.Value.ToString(CultureInfo.InvariantCulture));

            // Errors As Warnings
            this.violationsAsErrorsPropertyDescriptor = this.tabControl.Core.PropertyDescriptors["ViolationsAsErrors"] as PropertyDescriptor<bool>;

            this.violationsAsErrorsParentProperty = this.tabControl.ParentSettings == null
                                                ? null
                                                : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.violationsAsErrorsPropertyDescriptor.PropertyName) as
                                                  BooleanProperty;

            BooleanProperty mergedViolationsAsErrorsProperty = this.tabControl.MergedSettings == null
                                                           ? null
                                                           : this.tabControl.MergedSettings.GlobalSettings.GetProperty(
                                                               this.violationsAsErrorsPropertyDescriptor.PropertyName) as BooleanProperty;

            this.violationsAsErrorsCheckBox.Checked = mergedViolationsAsErrorsProperty == null
                                                          ? this.violationsAsErrorsPropertyDescriptor.DefaultValue
                                                          : mergedViolationsAsErrorsProperty.Value;

            this.SetBoldState();

            // Reset the dirty flag to false now.
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
        /// Refreshes the merged override state of properties on the page.
        /// </summary>
        public void RefreshSettingsOverrideState()
        {
            this.writeCacheParentProperty = this.tabControl.ParentSettings == null
                                                ? null
                                                : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.writeCachePropertyDescriptor.PropertyName) as
                                                  BooleanProperty;

            this.autoUpdateParentProperty = this.tabControl.ParentSettings == null
                                                ? null
                                                : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.autoUpdateCheckPropertyDescriptor.PropertyName) as
                                                  BooleanProperty;

            this.daysToCheckParentProperty = this.tabControl.ParentSettings == null
                                                 ? null
                                                 : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.daysToCheckPropertyDescriptor.PropertyName) as
                                                   IntProperty;

            this.maxViolationCountParentProperty = this.tabControl.ParentSettings == null
                                                       ? null
                                                       : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.maxViolationCountPropertyDescriptor.PropertyName)
                                                         as IntProperty;

            this.cultureParentProperty = this.tabControl.ParentSettings == null
                                             ? null
                                             : this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.culturePropertyDescriptor.PropertyName) as StringProperty;

            this.violationsAsErrorsParentProperty = this.tabControl.ParentSettings == null
                                                        ? null
                                                        : this.tabControl.ParentSettings.GlobalSettings.GetProperty(
                                                            this.violationsAsErrorsPropertyDescriptor.PropertyName) as
                                                          BooleanProperty;

            this.SetBoldState();
        }

        /// <summary>
        /// The validate page.
        /// </summary>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ValidatePage()
        {
            if (this.daysMaskedTextBox.Enabled && (!this.daysMaskedTextBox.MaskCompleted || this.daysMaskedTextBox.Text == string.Empty))
            {
                this.toolTip.ToolTipTitle = "Invalid number";
                this.toolTip.Show("Enter a valid number.", this.daysMaskedTextBox, this.daysMaskedTextBox.Width, -20, 5000);
                return false;
            }

            if (!this.maxViolationCountMaskedTextBox.MaskCompleted || this.maxViolationCountMaskedTextBox.Text == string.Empty)
            {
                this.toolTip.ToolTipTitle = "Invalid number";
                this.toolTip.Show("Enter a valid number.", this.maxViolationCountMaskedTextBox, this.maxViolationCountMaskedTextBox.Width, -20, 5000);
                return false;
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">
        /// Dispose parameter.
        /// </param>
        protected override void Dispose(bool disposing)
        {
            Param.Ignore(disposing);

            if (disposing)
            {
                if (this.components != null)
                {
                    this.components.Dispose();
                }
            }

            base.Dispose(disposing);
        }

        /// <summary>
        /// Set up the tooltips.
        /// </summary>
        /// <param name="e">
        /// The arguments to use.
        /// </param>
        protected override void OnLoad(EventArgs e)
        {
            this.toolTip.SetToolTip(this.daysMaskedTextBox, string.Empty);
            base.OnLoad(e);
        }

        private static IEnumerable<CultureInfo> EnumSatelliteLanguages(string baseName)
        {
            string location = Assembly.GetExecutingAssembly().Location;
            string directoryName = Path.GetDirectoryName(location);

            foreach (string directory in Directory.GetDirectories(directoryName))
            {
                string name = Path.GetFileNameWithoutExtension(directory);

                if (name.Length > 5)
                {
                    continue;
                }

                CultureInfo culture = null;
                try
                {
                    culture = CultureInfo.GetCultureInfo(name);
                }
                catch (ArgumentNullException)
                {
                    continue;
                }
                catch (ArgumentException)
                {
                    continue;
                }

                string resName = baseName + ".resources.dll";
                if (File.Exists(Path.Combine(Path.Combine(directoryName, name), resName)))
                {
                    yield return culture;
                }
            }
        }

        private static IEnumerable<CultureInfo> GetSatelliteLanguages(string baseName)
        {
            if (baseName == null)
            {
                throw new ArgumentNullException("baseName");
            }

            return EnumSatelliteLanguages(baseName);
        }

        /// <summary>
        /// Called when the autoUpdate is checked or unchecked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AutoUpdateCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }

            this.checkForUpdatesLabel.Enabled = this.autoUpdateCheckBox.Checked;
            this.daysMaskedTextBox.Enabled = this.autoUpdateCheckBox.Checked;
            this.daysLabel.Enabled = this.autoUpdateCheckBox.Checked;

            this.SetBoldState();
        }

        private void CultureComboBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }

            this.SetBoldState();
        }

        private void DaysMaskedTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            this.toolTip.Hide(this.daysMaskedTextBox);
        }

        private void DaysMaskedTextBoxTextChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }

            this.SetBoldState();
        }

        /// <summary>
        /// Called when the checkbox is checked or unchecked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void EnableCacheCheckedChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }

            this.SetBoldState();
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CacheOptions));
            this.label1 = new System.Windows.Forms.Label();
            this.enableCache = new System.Windows.Forms.CheckBox();
            this.daysLabel = new System.Windows.Forms.Label();
            this.daysMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.checkForUpdatesLabel = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.autoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.maxViolationCountMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cultureComboBox = new System.Windows.Forms.ComboBox();
            this.violationsAsErrorsCheckBox = new System.Windows.Forms.CheckBox();
            this.panel3.SuspendLayout();
            this.SuspendLayout();

            // label1
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";

            // enableCache
            resources.ApplyResources(this.enableCache, "enableCache");
            this.enableCache.Name = "enableCache";
            this.enableCache.UseVisualStyleBackColor = true;
            this.enableCache.CheckedChanged += new System.EventHandler(this.EnableCacheCheckedChanged);

            // daysLabel
            resources.ApplyResources(this.daysLabel, "daysLabel");
            this.daysLabel.Name = "daysLabel";

            // daysMaskedTextBox
            this.daysMaskedTextBox.AllowPromptAsInput = false;
            this.daysMaskedTextBox.CausesValidation = false;
            this.daysMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            resources.ApplyResources(this.daysMaskedTextBox, "daysMaskedTextBox");
            this.daysMaskedTextBox.Name = "daysMaskedTextBox";
            this.daysMaskedTextBox.RejectInputOnFirstFailure = true;
            this.daysMaskedTextBox.ResetOnPrompt = false;
            this.daysMaskedTextBox.ResetOnSpace = false;
            this.daysMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.daysMaskedTextBox.TextChanged += new System.EventHandler(this.DaysMaskedTextBoxTextChanged);
            this.daysMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DaysMaskedTextBoxKeyDown);

            // panel3
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.checkForUpdatesLabel);
            this.panel3.Controls.Add(this.daysLabel);
            this.panel3.Controls.Add(this.daysMaskedTextBox);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.autoUpdateCheckBox);
            this.panel3.Name = "panel3";
 
            // checkForUpdatesLabel
            resources.ApplyResources(this.checkForUpdatesLabel, "checkForUpdatesLabel");
            this.checkForUpdatesLabel.Name = "checkForUpdatesLabel";

            // label5
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";

            // autoUpdateCheckBox
            resources.ApplyResources(this.autoUpdateCheckBox, "autoUpdateCheckBox");
            this.autoUpdateCheckBox.Checked = true;
            this.autoUpdateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
            this.autoUpdateCheckBox.UseVisualStyleBackColor = true;
            this.autoUpdateCheckBox.CheckedChanged += new System.EventHandler(this.AutoUpdateCheckBoxCheckedChanged);

            // label3
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
 
            // maxViolationCountMaskedTextBox
            this.maxViolationCountMaskedTextBox.AllowPromptAsInput = false;
            this.maxViolationCountMaskedTextBox.CausesValidation = false;
            this.maxViolationCountMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            resources.ApplyResources(this.maxViolationCountMaskedTextBox, "maxViolationCountMaskedTextBox");
            this.maxViolationCountMaskedTextBox.Name = "maxViolationCountMaskedTextBox";
            this.maxViolationCountMaskedTextBox.RejectInputOnFirstFailure = true;
            this.maxViolationCountMaskedTextBox.ResetOnPrompt = false;
            this.maxViolationCountMaskedTextBox.ResetOnSpace = false;
            this.maxViolationCountMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.maxViolationCountMaskedTextBox.TextChanged += new System.EventHandler(this.MaxViolationCountTextBoxTextChanged);
            this.maxViolationCountMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MaxViolationCountMaskedTextBoxKeyDown);

            // label2
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";

            // cultureComboBox
            this.cultureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cultureComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.cultureComboBox, "cultureComboBox");
            this.cultureComboBox.Name = "cultureComboBox";
            this.cultureComboBox.SelectedIndexChanged += new System.EventHandler(this.CultureComboBoxSelectedIndexChanged);

            // violationsAsErrorsCheckBox
            resources.ApplyResources(this.violationsAsErrorsCheckBox, "violationsAsErrorsCheckBox");
            this.violationsAsErrorsCheckBox.Name = "violationsAsErrorsCheckBox";
            this.violationsAsErrorsCheckBox.UseVisualStyleBackColor = true;
            this.violationsAsErrorsCheckBox.CheckedChanged += new System.EventHandler(this.ViolationsAsErrorsCheckBoxCheckedChanged);

            // CacheOptions
            this.Controls.Add(this.violationsAsErrorsCheckBox);
            this.Controls.Add(this.cultureComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.enableCache);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maxViolationCountMaskedTextBox);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(246, 80);
            this.Name = "CacheOptions";
            resources.ApplyResources(this, "$this");
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void MaxViolationCountMaskedTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            this.toolTip.Hide(this.maxViolationCountMaskedTextBox);
        }

        private void MaxViolationCountTextBoxTextChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }

            this.SetBoldState();
        }

        /// <summary>
        /// Sets the bold state of the checkboxes.
        /// </summary>
        private void SetBoldState()
        {
            bool bold;

            if (this.writeCachePropertyDescriptor != null)
            {
                bold = this.writeCacheParentProperty == null
                           ? this.enableCache.Checked != this.writeCachePropertyDescriptor.DefaultValue
                           : this.enableCache.Checked != this.writeCacheParentProperty.Value;

                this.enableCache.Font = bold ? new Font(this.enableCache.Font, FontStyle.Bold) : new Font(this.enableCache.Font, FontStyle.Regular);
            }

            if (this.autoUpdateCheckPropertyDescriptor != null)
            {
                bold = this.autoUpdateParentProperty == null
                           ? this.autoUpdateCheckBox.Checked != this.autoUpdateCheckPropertyDescriptor.DefaultValue
                           : this.autoUpdateCheckBox.Checked != this.autoUpdateParentProperty.Value;

                this.autoUpdateCheckBox.Font = bold ? new Font(this.autoUpdateCheckBox.Font, FontStyle.Bold) : new Font(this.autoUpdateCheckBox.Font, FontStyle.Regular);
            }

            if (this.violationsAsErrorsPropertyDescriptor != null)
            {
                bold = this.violationsAsErrorsParentProperty == null
                           ? this.violationsAsErrorsCheckBox.Checked != this.violationsAsErrorsPropertyDescriptor.DefaultValue
                           : this.violationsAsErrorsCheckBox.Checked != this.violationsAsErrorsParentProperty.Value;

                this.violationsAsErrorsCheckBox.Font = bold
                                                           ? new Font(
                                                                 this.violationsAsErrorsCheckBox.Font,
                                                                 FontStyle.Bold)
                                                           : new Font(
                                                                 this.violationsAsErrorsCheckBox.Font,
                                                                 FontStyle.Regular);
            }

            if (this.daysToCheckPropertyDescriptor != null)
            {
                bold = this.daysToCheckParentProperty == null
                           ? this.daysMaskedTextBox.Text != this.daysToCheckPropertyDescriptor.DefaultValue.ToString(CultureInfo.InvariantCulture)
                           : this.daysMaskedTextBox.Text != this.daysToCheckParentProperty.Value.ToString(CultureInfo.InvariantCulture);

                this.daysMaskedTextBox.Font = bold ? new Font(this.daysMaskedTextBox.Font, FontStyle.Bold) : new Font(this.daysMaskedTextBox.Font, FontStyle.Regular);
            }

            if (this.maxViolationCountPropertyDescriptor != null)
            {
                bold = this.maxViolationCountParentProperty == null
                           ? this.maxViolationCountMaskedTextBox.Text != this.maxViolationCountPropertyDescriptor.DefaultValue.ToString(CultureInfo.InvariantCulture)
                           : this.maxViolationCountMaskedTextBox.Text != this.maxViolationCountParentProperty.Value.ToString(CultureInfo.InvariantCulture);

                this.maxViolationCountMaskedTextBox.Font = bold
                                                               ? new Font(this.maxViolationCountMaskedTextBox.Font, FontStyle.Bold)
                                                               : new Font(this.maxViolationCountMaskedTextBox.Font, FontStyle.Regular);
            }

            if (this.culturePropertyDescriptor != null)
            {
                if (this.cultureParentProperty == null)
                {
                    bold = this.cultureComboBox.Text != this.culturePropertyDescriptor.DefaultValue.ToString(CultureInfo.InvariantCulture);
                }
                else
                {
                    bold = this.cultureComboBox.Text != this.cultureParentProperty.Value.ToString(CultureInfo.InvariantCulture);
                }

                this.cultureComboBox.Font = bold ? new Font(this.cultureComboBox.Font, FontStyle.Bold) : new Font(this.cultureComboBox.Font, FontStyle.Regular);
            }
        }

        #endregion

        private void ViolationsAsErrorsCheckBoxCheckedChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }

            this.SetBoldState();
        }
    }
}