// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CacheOptions.cs" company="https://github.com/StyleCop">
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

        /// <summary>
        /// The components.
        /// </summary>
        private IContainer components;

        /// <summary>
        /// The culture combo box.
        /// </summary>
        private ComboBox cultureComboBox;

        /// <summary>
        /// The culture parent property.
        /// </summary>
        private StringProperty cultureParentProperty;

        /// <summary>
        /// The culture property descriptor.
        /// </summary>
        private PropertyDescriptor<string> culturePropertyDescriptor;

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

        /// <summary>
        /// The label 2.
        /// </summary>
        private Label label2;

        /// <summary>
        /// The label 3.
        /// </summary>
        private Label label3;

        /// <summary>
        /// The max violation count masked text box.
        /// </summary>
        private MaskedTextBox maxViolationCountMaskedTextBox;

        /// <summary>
        /// The max violation count parent property.
        /// </summary>
        private IntProperty maxViolationCountParentProperty;

        /// <summary>
        /// The max violation count property descriptor.
        /// </summary>
        private PropertyDescriptor<int> maxViolationCountPropertyDescriptor;

        /// <summary>
        /// The tab control hosting this page.
        /// </summary>
        private PropertyControl tabControl;

        /// <summary>
        /// The tool tip.
        /// </summary>
        private ToolTip toolTip;

        /// <summary>
        /// The global value of the property.
        /// </summary>
        private BooleanProperty writeCacheParentProperty;

        /// <summary>
        /// The violations as errors check box.
        /// </summary>
        private CheckBox violationsAsErrorsCheckBox;

        /// <summary>
        /// The violations as errors property descriptor.
        /// </summary>
        private PropertyDescriptor<bool> violationsAsErrorsPropertyDescriptor;

        /// <summary>
        /// The violations as errors parent property.
        /// </summary>
        private BooleanProperty violationsAsErrorsParentProperty;

        /// <summary>
        /// The table layout panel 1.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel1;

        /// <summary>
        /// The table layout panel 2.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel2;

        /// <summary>
        /// The needed to make last row fill.
        /// </summary>
        private Panel neededToMakeLastRowFill;

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
                   new BooleanProperty(this.tabControl.Core, this.violationsAsErrorsPropertyDescriptor.PropertyName, this.violationsAsErrorsCheckBox.Checked));

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
        /// Gets the satellite languages.
        /// </summary>
        /// <param name="baseName">
        /// The base name.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
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

        /// <summary>
        /// The get satellite languages.
        /// </summary>
        /// <param name="baseName">
        /// The base name.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable{T}"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// The <paramref name="baseName"/> argument was null.
        /// </exception>
        private static IEnumerable<CultureInfo> GetSatelliteLanguages(string baseName)
        {
            if (baseName == null)
            {
                throw new ArgumentNullException("baseName");
            }

            return EnumSatelliteLanguages(baseName);
        }

        /// <summary>
        /// The culture combo box selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.maxViolationCountMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cultureComboBox = new System.Windows.Forms.ComboBox();
            this.violationsAsErrorsCheckBox = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.neededToMakeLastRowFill = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // label1
            resources.ApplyResources(this.label1, "label1");
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 3);
            this.label1.Name = "label1";

            // enableCache
            resources.ApplyResources(this.enableCache, "enableCache");
            this.tableLayoutPanel1.SetColumnSpan(this.enableCache, 3);
            this.enableCache.Name = "enableCache";
            this.enableCache.UseVisualStyleBackColor = true;
            this.enableCache.CheckedChanged += new System.EventHandler(this.EnableCacheCheckedChanged);
            
            // label3
            resources.ApplyResources(this.label3, "label3");
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 2);
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
            this.tableLayoutPanel1.SetColumnSpan(this.cultureComboBox, 2);
            this.cultureComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cultureComboBox.FormattingEnabled = true;
            resources.ApplyResources(this.cultureComboBox, "cultureComboBox");
            this.cultureComboBox.Name = "cultureComboBox";
            this.cultureComboBox.SelectedIndexChanged += new System.EventHandler(this.CultureComboBoxSelectedIndexChanged);
            
            // violationsAsErrorsCheckBox
            resources.ApplyResources(this.violationsAsErrorsCheckBox, "violationsAsErrorsCheckBox");
            this.tableLayoutPanel1.SetColumnSpan(this.violationsAsErrorsCheckBox, 3);
            this.violationsAsErrorsCheckBox.Name = "violationsAsErrorsCheckBox";
            this.violationsAsErrorsCheckBox.UseVisualStyleBackColor = true;
            this.violationsAsErrorsCheckBox.CheckedChanged += new System.EventHandler(this.ViolationsAsErrorsCheckBoxCheckedChanged);
            
            // tableLayoutPanel1
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.maxViolationCountMaskedTextBox, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.enableCache, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cultureComboBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.violationsAsErrorsCheckBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.neededToMakeLastRowFill, 0, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            
            // tableLayoutPanel2
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            
            // neededToMakeLastRowFill
            this.tableLayoutPanel1.SetColumnSpan(this.neededToMakeLastRowFill, 3);
            resources.ApplyResources(this.neededToMakeLastRowFill, "neededToMakeLastRowFill");
            this.neededToMakeLastRowFill.Name = "neededToMakeLastRowFill";
            
            // CacheOptions
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(123, 40);
            this.Name = "CacheOptions";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// The max violation count masked text box key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MaxViolationCountMaskedTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            this.toolTip.Hide(this.maxViolationCountMaskedTextBox);
        }

        /// <summary>
        /// The max violation count text box text changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
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

        /// <summary>
        /// The violations as errors check box checked changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
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