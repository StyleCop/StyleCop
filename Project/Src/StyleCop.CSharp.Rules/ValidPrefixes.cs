// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ValidPrefixes.cs" company="https://github.com/StyleCop">
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
//   Options dialog to choose valid, non-Hungarian prefixes.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.CSharp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Options dialog to choose valid, non-Hungarian prefixes.
    /// </summary>
    internal class ValidPrefixes : UserControl, IPropertyControlPage
    {
        #region Fields

        /// <summary>
        /// The analyzer that this settings page is attached to.
        /// </summary>
        private readonly SourceAnalyzer analyzer;

        /// <summary>
        /// The Add button.
        /// </summary>
        private Button addButton;

        /// <summary>
        /// The add prefix box.
        /// </summary>
        private TextBox addPrefix;

        /// <summary>
        /// The default column on the ListView control.
        /// </summary>
        private ColumnHeader columnHeader1;

        /// <summary>
        /// True if the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// Stores the form's accept button while focus is on the addPrefix textbox.
        /// </summary>
        private IButtonControl formAcceptButton;

        /// <summary>
        /// The static text label.
        /// </summary>
        private Label label1;

        /// <summary>
        /// The static text label.
        /// </summary>
        private Label label2;

        /// <summary>
        /// Contains help text.
        /// </summary>
        private Label label3;

        /// <summary>
        /// The current prefixes box.
        /// </summary>
        private ListView prefixList;

        /// <summary>
        /// The Remove button.
        /// </summary>
        private Button removeButton;

        /// <summary>
        /// The tab control which hosts this page.
        /// </summary>
        private PropertyControl tabControl;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the ValidPrefixes class.
        /// </summary>
        public ValidPrefixes()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the ValidPrefixes class.
        /// </summary>
        /// <param name="analyzer">
        /// The analyzer that this settings page is attached to.
        /// </param>
        public ValidPrefixes(NamingRules analyzer)
            : this()
        {
            Param.AssertNotNull(analyzer, "analyzer");
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
                return Strings.HungarianTab;
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
                List<string> values = new List<string>(this.prefixList.Items.Count);

                foreach (ListViewItem prefix in this.prefixList.Items)
                {
                    // Only save local tags.
                    if ((bool)prefix.Tag)
                    {
                        values.Add(prefix.Text);
                    }
                }

                CollectionProperty list = new CollectionProperty(this.analyzer, NamingRules.AllowedPrefixesProperty, values);

                this.tabControl.LocalSettings.SetAddInSetting(this.analyzer, list);
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
            Param.AssertNotNull(propertyControl, "propertyControl");

            this.tabControl = propertyControl;

            if (this.analyzer != null)
            {
                // Get the list of allowed prefixes from the parent settings.
                this.AddParentPrefixes();

                // Get the list of allowed prefixes from the local settings.
                CollectionProperty localPrefixesProperty =
                    this.tabControl.LocalSettings.GetAddInSetting(this.analyzer, NamingRules.AllowedPrefixesProperty) as CollectionProperty;

                if (localPrefixesProperty != null && localPrefixesProperty.Values.Count > 0)
                {
                    foreach (string value in localPrefixesProperty)
                    {
                        if (!string.IsNullOrEmpty(value))
                        {
                            ListViewItem item = this.prefixList.Items.Add(value);
                            if (item != null)
                            {
                                item.Tag = true;
                                this.SetBoldState(item);
                            }
                        }
                    }
                }
            }

            // Select the first item in the list.
            if (this.prefixList.Items.Count > 0)
            {
                this.prefixList.Items[0].Selected = true;
            }

            this.EnableDisableRemoveButton();

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
            // Loop through the existing items and remove all parent items.
            List<ListViewItem> itemsToRemove = new List<ListViewItem>();
            foreach (ListViewItem prefix in this.prefixList.Items)
            {
                if (!(bool)prefix.Tag)
                {
                    itemsToRemove.Add(prefix);
                }
            }

            foreach (ListViewItem itemToRemove in itemsToRemove)
            {
                this.prefixList.Items.Remove(itemToRemove);
            }

            // Add any new parent items now.
            this.AddParentPrefixes();

            // Loop through the list again and set the bold state for locally added items.
            foreach (ListViewItem prefix in this.prefixList.Items)
            {
                if ((bool)prefix.Tag)
                {
                    this.SetBoldState(prefix);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Event that is fired when the add button is clicked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddButtonClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.addPrefix.Text.Length == 0 || this.addPrefix.Text.Length > 2)
            {
                AlertDialog.Show(this.tabControl.Core, this, Strings.EnterValidPrefix, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (ListViewItem item in this.prefixList.Items)
            {
                if (item.Text == this.addPrefix.Text)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    this.addPrefix.Clear();
                    return;
                }
            }

            ListViewItem addedItem = this.prefixList.Items.Add(this.addPrefix.Text);
            if (addedItem != null)
            {
                addedItem.Tag = true;
                addedItem.Selected = true;
                this.prefixList.EnsureVisible(addedItem.Index);
                this.SetBoldState(addedItem);
            }

            this.addPrefix.Clear();

            this.dirty = true;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Add prefixes from the parent settings.
        /// </summary>
        private void AddParentPrefixes()
        {
            CollectionProperty parentPrefixesProperty = null;

            if (this.tabControl.ParentSettings != null)
            {
                parentPrefixesProperty = this.tabControl.ParentSettings.GetAddInSetting(this.analyzer, NamingRules.AllowedPrefixesProperty) as CollectionProperty;

                if (parentPrefixesProperty != null)
                {
                    if (parentPrefixesProperty.Values.Count > 0)
                    {
                        foreach (string value in parentPrefixesProperty)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                ListViewItem item = this.prefixList.Items.Add(value);
                                if (item != null)
                                {
                                    item.Tag = false;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Called when the addPrefix TextBox receives the input focus.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddPrefixGotFocus(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            // Save the current form accept button, and then clear it. This will allow
            // the addPrefix textbox to capture the return key.
            this.formAcceptButton = this.ParentForm.AcceptButton;
            this.ParentForm.AcceptButton = null;
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the addPrefix textbox.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddPrefixKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Return)
            {
                if (this.addPrefix.Text.Length > 0)
                {
                    // Simulate a click of the add button.
                    this.AddButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// Called when the addPrefix TextBox loses the input focus.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddPrefixLostFocus(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            // Reset the form accept button now that the addPrefix textbox no longer has the input focus.
            if (this.formAcceptButton != null)
            {
                this.ParentForm.AcceptButton = this.formAcceptButton;
                this.formAcceptButton = null;
            }
        }

        /// <summary>
        /// Sets the enabled state of the remove button.
        /// </summary>
        private void EnableDisableRemoveButton()
        {
            if (this.prefixList.SelectedItems.Count > 0)
            {
                // Get the currently selected item.
                ListViewItem selectedItem = this.prefixList.SelectedItems[0];
                this.removeButton.Enabled = (bool)selectedItem.Tag;
            }
            else
            {
                this.removeButton.Enabled = false;
            }
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ValidPrefixes));
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.prefixList = new System.Windows.Forms.ListView();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();

            // removeButton
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.Name = "removeButton";
            this.removeButton.Click += this.RemoveButtonClick;

            // addButton
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.Click += this.AddButtonClick;

            // label2
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";

            // addPrefix
            resources.ApplyResources(this.addPrefix, "addPrefix");
            this.addPrefix.Name = "addPrefix";
            this.addPrefix.KeyDown += this.AddPrefixKeyDown;
            this.addPrefix.GotFocus += this.AddPrefixGotFocus;
            this.addPrefix.LostFocus += this.AddPrefixLostFocus;

            // label1
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";

            // prefixList
            resources.ApplyResources(this.prefixList, "prefixList");
            this.prefixList.Columns.AddRange(new[] { this.columnHeader1 });
            this.prefixList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.prefixList.HideSelection = false;
            this.prefixList.MultiSelect = false;
            this.prefixList.Name = "prefixList";
            this.prefixList.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.prefixList.UseCompatibleStateImageBehavior = false;
            this.prefixList.View = System.Windows.Forms.View.Details;
            this.prefixList.ItemSelectionChanged += this.PrefixListItemSelectionChanged;
            this.prefixList.KeyDown += this.PrefixListKeyDown;

            // columnHeader1
            resources.ApplyResources(this.columnHeader1, "columnHeader1");

            // label3
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";

            // ValidPrefixes
            this.Controls.Add(this.label3);
            this.Controls.Add(this.prefixList);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addPrefix);
            this.Controls.Add(this.label1);
            this.Name = "ValidPrefixes";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Called when the current selection changes in the ListView.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void PrefixListItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Param.Ignore(sender, e);
            this.EnableDisableRemoveButton();
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the prefix list.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void PrefixListKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Delete)
            {
                if (this.addPrefix.Text.Length > 0)
                {
                    // Simulate a click of the remove button.
                    this.RemoveButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// Event that is fired when the remove button is clicked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void RemoveButtonClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.prefixList.SelectedItems.Count > 0)
            {
                int index = this.prefixList.SelectedIndices[0];

                this.prefixList.Items.RemoveAt(index);
                this.EnableDisableRemoveButton();

                if (this.prefixList.Items.Count > index)
                {
                    this.prefixList.Items[index].Selected = true;
                }
                else if (this.prefixList.Items.Count > 0)
                {
                    this.prefixList.Items[this.prefixList.Items.Count - 1].Selected = true;
                }

                this.dirty = true;
                this.tabControl.DirtyChanged();
            }
        }

        /// <summary>
        /// Sets the bold state of the item.
        /// </summary>
        /// <param name="item">
        /// The item to set.
        /// </param>
        private void SetBoldState(ListViewItem item)
        {
            Param.AssertNotNull(item, "item");

            // Dispose the item's current font if necessary.
            if (item.Font != this.prefixList.Font && item.Font != null)
            {
                item.Font.Dispose();
            }

            // Create and set the new font.
            if ((bool)item.Tag)
            {
                item.Font = new Font(this.prefixList.Font, FontStyle.Bold);
            }
            else
            {
                item.Font = new Font(this.prefixList.Font, FontStyle.Regular);
            }
        }

        #endregion
    }
}