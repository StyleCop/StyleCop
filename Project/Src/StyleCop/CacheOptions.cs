//-----------------------------------------------------------------------
// <copyright file="CacheOptions.cs">
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
namespace StyleCop
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Options dialog to choose which settings files to use.
    /// </summary>
    internal class CacheOptions : UserControl, IPropertyControlPage
    {
        #region Private Fields

        /// <summary>
        /// The WinForms components manager.
        /// </summary>
        private System.ComponentModel.Container components = null;

        /// <summary>
        /// Indicates whether the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// The page description.
        /// </summary>
        private Label label1;

        /// <summary>
        /// The tab control hosting this page.
        /// </summary>
        private PropertyControl tabControl;

        /// <summary>
        /// Indicates whether to enable writing of the cache.
        /// </summary>
        private CheckBox enableCache;

        /// <summary>
        /// Property descriptor.
        /// </summary>
        private PropertyDescriptor<bool> descriptor;

        /// <summary>
        /// The global value of the property.
        /// </summary>
        private BooleanProperty parentProperty;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the CacheOptions class.
        /// </summary>
        public CacheOptions()
        {
            this.InitializeComponent();
        }

        #endregion Public Constructors

        #region Public Properties

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

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Initializes the page.
        /// </summary>
        /// <param name="propertyControl">The tab control object.</param>
        public void Initialize(PropertyControl propertyControl)
        {
            Param.AssertNotNull(propertyControl, "propertyControl");

            this.tabControl = propertyControl;

            // Get the cache setting.
            this.descriptor = this.tabControl.Core.PropertyDescriptors["WriteCache"] as PropertyDescriptor<bool>;

            this.parentProperty = this.tabControl.ParentSettings == null ? 
                null : 
                this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.descriptor.PropertyName) as BooleanProperty;
            
            BooleanProperty mergedProperty = this.tabControl.MergedSettings == null ? 
                null : 
                this.tabControl.MergedSettings.GlobalSettings.GetProperty(this.descriptor.PropertyName) as BooleanProperty;

            this.enableCache.Checked = mergedProperty == null ? this.descriptor.DefaultValue : mergedProperty.Value;

            this.SetBoldState();

            // Reset the dirty flag to false now.
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
        /// <returns>Returns true if the data was saved, false if not.</returns>
        public bool Apply()
        {
            this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                new BooleanProperty(this.tabControl.Core, this.descriptor.PropertyName, this.enableCache.Checked));
            
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
        /// Refreshes the merged override state of properties on the page.
        /// </summary>
        public void RefreshSettingsOverrideState()
        {
            this.parentProperty = this.tabControl.ParentSettings == null ?
                null :
                this.tabControl.ParentSettings.GlobalSettings.GetProperty(this.descriptor.PropertyName) as BooleanProperty;

            this.SetBoldState();
        }

        #endregion Public Methods

        #region Protected Override Methods

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">Dispose param.</param>
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

        #endregion Protected Override Methods

        #region Private Methods

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CacheOptions));
            this.label1 = new System.Windows.Forms.Label();
            this.enableCache = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // enableCache
            // 
            resources.ApplyResources(this.enableCache, "enableCache");
            this.enableCache.Name = "enableCache";
            this.enableCache.UseVisualStyleBackColor = true;
            this.enableCache.CheckedChanged += new System.EventHandler(this.EnableCacheCheckedChanged);
            // 
            // CacheOptions
            // 
            this.Controls.Add(this.enableCache);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(246, 80);
            this.Name = "CacheOptions";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Called when the checkbox is checked or unchecked.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
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
        /// Sets the bold state of the checkbox.
        /// </summary>
        private void SetBoldState()
        {
            bool bold;

            if (this.parentProperty == null)
            {
                bold = this.enableCache.Checked != this.descriptor.DefaultValue;
            }
            else
            {
                bold = this.enableCache.Checked != this.parentProperty.Value;
            }

            if (bold)
            {
                this.enableCache.Font = new Font(this.enableCache.Font, FontStyle.Bold);
            }
            else
            {
                this.enableCache.Font = new Font(this.enableCache.Font, FontStyle.Regular);
            }
        }

        #endregion Private Methods
    }
}