// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PropertyControl.cs" company="https://github.com/StyleCop">
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
//   Hosts property pages.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Globalization;
    using System.Windows.Forms;

    /// <summary>
    /// Hosts property pages.
    /// </summary>
    public class PropertyControl : TabControl
    {
        #region Fields

        /// <summary>
        /// The context for the property pages.
        /// </summary>
        private object[] context;

        /// <summary>
        /// The StyleCop core instance.
        /// </summary>
        private StyleCopCore core;

        /// <summary>
        /// Indicates whether any of the pages are dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// The property page host.
        /// </summary>
        private IPropertyControlHost host;

        /// <summary>
        /// The settings file to read from and write to.
        /// </summary>
        private WritableSettings localSettings;

        /// <summary>
        /// The local settings merged with parent settings.
        /// </summary>
        private Settings mergedSettings;

        /// <summary>
        /// The pages to display.
        /// </summary>
        private IList<IPropertyControlPage> pageInterfaces;

        /// <summary>
        /// The pages to display.
        /// </summary>
        private UserControl[] pages;

        /// <summary>
        /// The settings one level up from the local settings file.
        /// </summary>
        private Settings parentSettings;

        /// <summary>
        /// Compares the local settings with the merged settings.
        /// </summary>
        private SettingsComparer settingsComparer;

        /// <summary>
        /// The pages to display.
        /// </summary>
        private TabPage[] tabPages;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the PropertyControl class.
        /// </summary>
        public PropertyControl()
        {
            this.InitializeComponent();

            this.Controls.AddRange(new Control[] { });
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the currently active page.
        /// </summary>
        public IPropertyControlPage ActivePage
        {
            get
            {
                if (this.host != null)
                {
                    return this.pageInterfaces[this.SelectedIndex];
                }

                return null;
            }
        }

        /// <summary>
        /// Gets the list of context objects passed to this property control.
        /// </summary>
        public IList<object> Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// Gets the StyleCop core instance.
        /// </summary>
        public StyleCopCore Core
        {
            get
            {
                return this.core;
            }
        }

        /// <summary>
        /// Gets a value indicating whether any of the pages are dirty.
        /// </summary>
        public bool IsDirty
        {
            get
            {
                return this.dirty;
            }
        }

        /// <summary>
        /// Gets the local settings file to read from and write to.
        /// </summary>
        public WritableSettings LocalSettings
        {
            get
            {
                return this.localSettings;
            }
        }

        /// <summary>
        /// Gets the local settings merged with all parent settings.
        /// </summary>
        public Settings MergedSettings
        {
            get
            {
                return this.mergedSettings;
            }
        }

        /// <summary>
        /// Gets the list of pages that are currently loaded on the property control.
        /// </summary>
        public IList<IPropertyControlPage> Pages
        {
            get
            {
                return this.pageInterfaces;
            }
        }

        /// <summary>
        /// Gets the settings which the local settings are merged with at runtime, or null if there are
        /// no settings to merge.
        /// </summary>
        public Settings ParentSettings
        {
            get
            {
                return this.parentSettings;
            }
        }

        /// <summary>
        /// Gets a comparer that can be used to determine whether local settings are overriding parent settings.
        /// </summary>
        public SettingsComparer SettingsComparer
        {
            get
            {
                return this.settingsComparer;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Called when the property control should be cancelled.
        /// </summary>
        public void Cancel()
        {
            this.host.Cancel();
        }

        /// <summary>
        /// Sets the dirty flag and notifies the host that the dirty status has changed.
        /// </summary>
        public void DirtyChanged()
        {
            bool pageDirty = false;

            foreach (IPropertyControlPage page in this.pageInterfaces)
            {
                if (page != null && page.Dirty)
                {
                    pageDirty = true;
                    break;
                }
            }

            if (pageDirty != this.dirty)
            {
                this.dirty = pageDirty;
                this.host.Dirty(pageDirty);
            }
        }

        /// <summary>
        /// Called when the parent settings have changed.
        /// </summary>
        public void RefreshMergedSettings()
        {
            // Set the contents of the parent settings file.
            SettingsMerger merger = new SettingsMerger(this.localSettings, this.core.Environment);
            this.parentSettings = merger.ParentMergedSettings;
            this.mergedSettings = merger.MergedSettings;

            // Set up the settings comparer.
            this.settingsComparer = new SettingsComparer(this.localSettings, this.parentSettings);

            for (int i = 0; i < this.pageInterfaces.Count; ++i)
            {
                if (this.pageInterfaces[i] != null)
                {
                    this.pageInterfaces[i].RefreshSettingsOverrideState();
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Applies the data on the property pages.
        /// </summary>
        /// <param name="dirtyPages">
        /// Returns true if any pages were dirty.
        /// </param>
        /// <returns>
        /// Returns false if any page returned false from it's apply call, in which case
        /// the apply failed.
        /// </returns>
        internal PropertyControlSaveResult Apply(out bool dirtyPages)
        {
            dirtyPages = false;

            // Call the apply method for each of the pages.
            PropertyControlSaveResult result = PropertyControlSaveResult.Success;
            bool cancel = false;

            bool[] pageDirtyState = new bool[this.pageInterfaces.Count];

            // Pre-apply the pages.
            for (int i = 0; i < this.pageInterfaces.Count; ++i)
            {
                if (this.pageInterfaces[i] != null)
                {
                    pageDirtyState[i] = this.pageInterfaces[i].Dirty;
                    if (!this.pageInterfaces[i].PreApply())
                    {
                        cancel = true;
                        break;
                    }
                }
            }

            if (!cancel)
            {
                // Apply the pages.
                int breakIndex = -1;
                for (int i = 0; i < this.pageInterfaces.Count; ++i)
                {
                    if (this.pageInterfaces[i] != null && this.pageInterfaces[i].Dirty)
                    {
                        dirtyPages = true;

                        if (!this.pageInterfaces[i].Apply())
                        {
                            result = PropertyControlSaveResult.PageAbort;
                            breakIndex = i;
                            break;
                        }
                    }
                }

                // Post-apply the pages.
                int lastIndex = breakIndex == -1 ? this.pageInterfaces.Count - 1 : breakIndex;
                for (int i = 0; i <= lastIndex; ++i)
                {
                    if (this.pageInterfaces[i] != null)
                    {
                        this.pageInterfaces[i].PostApply(pageDirtyState[i]);
                    }
                }

                if (breakIndex == -1)
                {
                    // Save the settings files.
                    Exception exception = null;
                    if (!this.core.Environment.SaveSettings(this.localSettings, out exception))
                    {
                        AlertDialog.Show(
                            this.core, 
                            this, 
                            string.Format(CultureInfo.CurrentUICulture, Strings.CouldNotSaveSettingsFile, exception.Message), 
                            Strings.Title, 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);

                        result = PropertyControlSaveResult.SaveError;

                        // Reset the dirty flag on each page.
                        for (int i = 0; i < this.pageInterfaces.Count; ++i)
                        {
                            if (this.pageInterfaces[i] != null)
                            {
                                this.pageInterfaces[i].Dirty = pageDirtyState[i];
                            }
                        }
                    }
                    else
                    {
                        this.dirty = false;
                        this.host.Dirty(false);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// The control must be initialized by calling this method during the host's OnLoad event.
        /// </summary>
        /// <param name="hostInstance">
        /// Interface implemented by the host object.
        /// </param>
        /// <param name="propertyPages">
        /// The array of pages to display on the tab control.
        /// </param>
        /// <param name="settings">
        /// The settings to read from and write to.
        /// </param>
        /// <param name="coreInstance">
        /// The StyleCop core instance.
        /// </param>
        /// <param name="contextItem">
        /// The context for the property control.
        /// </param>
        internal void Initialize(
            IPropertyControlHost hostInstance, 
            IList<IPropertyControlPage> propertyPages, 
            WritableSettings settings, 
            StyleCopCore coreInstance, 
            params object[] contextItem)
        {
            Param.AssertNotNull(hostInstance, "hostInstance");
            Param.Assert(propertyPages != null && propertyPages.Count > 0, "propertyPages", "Cannot be null or empty");
            Param.AssertNotNull(settings, "settings");
            Param.AssertNotNull(coreInstance, "coreInstance");
            Param.Ignore(contextItem);

            // Make sure we haven't already been intialized.
            if (this.host != null)
            {
                throw new StyleCopException(Strings.PropertyControlAlreadyInitialized);
            }

            this.host = hostInstance;
            this.pageInterfaces = propertyPages;
            this.localSettings = settings;
            this.core = coreInstance;
            this.context = contextItem;

            // Set the contents of the parent settings file.
            SettingsMerger merger = new SettingsMerger(this.localSettings, this.core.Environment);
            this.parentSettings = merger.ParentMergedSettings;
            this.mergedSettings = merger.MergedSettings;

            // Set up the settings comparer.
            this.settingsComparer = new SettingsComparer(this.localSettings, this.parentSettings);

            // Make sure the context is non-null.
            if (this.context == null)
            {
                this.context = new object[] { };
            }

            this.tabPages = new TabPage[propertyPages.Count];
            this.pages = new UserControl[propertyPages.Count];

            // Add each of the property pages.
            int pageCount = 0;

            // Initialize the settings pages.
            for (int i = 0; i < propertyPages.Count; ++i)
            {
                this.pages[pageCount] = (UserControl)this.pageInterfaces[i];
                TabPage tabPage = new TabPage(this.pageInterfaces[i].TabName);

                this.tabPages[pageCount] = tabPage;
                tabPage.Controls.Add(this.pages[i]);
                this.Controls.Add(tabPage);

                this.pages[i].Dock = DockStyle.Fill;
                this.SizePage(i);

                // The first page has already been initialized.
                this.pageInterfaces[i].Initialize(this);

                ++pageCount;
            }

            // Activate the first page.
            if (this.TabPages[0] != null)
            {
                this.SelectedTab = this.tabPages[0];
                this.pageInterfaces[0].Activate(true);
            }

            this.SizeChanged += this.OnSizeChanged;
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();

            // PropertyControl
            this.Name = "PropertyControl";
            this.Size = new System.Drawing.Size(248, 216);
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Called when the size of the dialog changes.
        /// </summary>
        /// <param name="sender">
        /// The event sender..
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void OnSizeChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.SelectedIndex >= 0)
            {
                this.SizePage(this.SelectedIndex);
            }
        }

        /// <summary>
        /// Sets the size of a tab page to fill the sheet area.
        /// </summary>
        /// <param name="index">
        /// The index of the tab to size.
        /// </param>
        private void SizePage(int index)
        {
            Param.AssertValueBetween(index, 0, this.tabPages.Length - 1, "index");

            Rectangle rect = this.GetTabRect(index);

            this.tabPages[index].Height = rect.Height;
            this.tabPages[index].Width = rect.Width;
        }

        #endregion
    }
}