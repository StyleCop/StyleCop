//-----------------------------------------------------------------------
// <copyright file="SpellingTab.cs">
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
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Options dialog to manage words for spelling.
    /// </summary>
    internal class SpellingTab : UserControl, IPropertyControlPage
    {
        private const string RecognizedWordsPropertyName = "RecognizedWords";

        #region Private Fields

        /// <summary>
        /// The Remove button.
        /// </summary>
        private Button removeButton;

        /// <summary>
        /// The Add button.
        /// </summary>
        private Button addButton;

        /// <summary>
        /// The current words box.
        /// </summary>
        private ListView wordsListView;

        /// <summary>
        /// The static text label.
        /// </summary>
        private Label label2;

        /// <summary>
        /// The add prefix box.
        /// </summary>
        private TextBox addWordTextBox;

        /// <summary>
        /// The static text label.
        /// </summary>
        private Label label1;

        /// <summary>
        /// True if the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// The default column on the ListView control.
        /// </summary>
        private ColumnHeader columnHeader1;

        /// <summary>
        /// The tab control which hosts this page.
        /// </summary>
        private PropertyControl tabControl;

        /// <summary>
        /// Contains help text.
        /// </summary>
        private Label label3;
        
        /// <summary>
        /// Stores the form's accept button while focus is on the add textbox.
        /// </summary>
        private IButtonControl formAcceptButton;

        #endregion Private Fields

        #region Public Constructors

        /// <summary>
        /// Initializes a new instance of the SpellingTab class.
        /// </summary>
        public SpellingTab()
        {
            this.InitializeComponent();
        }
        
        #endregion Public Constructors

        #region Public Properties

        /// <summary>
        /// Gets the name of the the tab.
        /// </summary>
        public string TabName
        {
            get 
            { 
                return Strings.SpellingTab; 
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

        #region Public Methods

        /// <summary>
        /// Initializes the page.
        /// </summary>
        /// <param name="propertyControl">The tab control object.</param>
        public void Initialize(PropertyControl propertyControl)
        {
            Param.AssertNotNull(propertyControl, "propertyControl");

            this.tabControl = propertyControl;
            
            // Get the list of allowed words from the parent settings.
            this.AddParentWords();

            // Get the list of allowed words from the local settings.
            CollectionProperty recognizedWordsProperty = this.tabControl.LocalSettings.GlobalSettings.GetProperty(RecognizedWordsPropertyName) as CollectionProperty;

            if (recognizedWordsProperty != null && recognizedWordsProperty.Values.Count > 0)
            {
                foreach (string value in recognizedWordsProperty)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        ListViewItem item = this.wordsListView.Items.Add(value);
                        item.Tag = true;
                        this.SetBoldState(item);
                    }
                }
            }
            
            // Select the first item in the list.
            if (this.wordsListView.Items.Count > 0)
            {
                this.wordsListView.Items[0].Selected = true;
            }

            this.EnableDisableRemoveButton();

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
            List<string> values = new List<string>(this.wordsListView.Items.Count);

            foreach (ListViewItem word in this.wordsListView.Items)
            {
                // Only save local tags.
                if ((bool)word.Tag)
                {
                    values.Add(word.Text);
                }
            }

            this.tabControl.LocalSettings.GlobalSettings.SetProperty(new CollectionProperty(this.tabControl.Core, RecognizedWordsPropertyName, values));
            
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
            // Loop through the existing items and remove all parent items.
            List<ListViewItem> itemsToRemove = new List<ListViewItem>();
            foreach (ListViewItem prefix in this.wordsListView.Items)
            {
                if (!(bool)prefix.Tag)
                {
                    itemsToRemove.Add(prefix);
                }
            }

            foreach (ListViewItem itemToRemove in itemsToRemove)
            {
                this.wordsListView.Items.Remove(itemToRemove);
            }

            // Add any new parent items now.
            this.AddParentWords();

            // Loop through the list again and set the bold state for locally added items.
            foreach (ListViewItem prefix in this.wordsListView.Items)
            {
                if ((bool)prefix.Tag)
                {
                    this.SetBoldState(prefix);
                }
            }
        }

        #endregion Public Methods

        #region Private Methods

        #region Component Designer generated code
        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SpellingTab));
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.addWordTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wordsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // removeButton
            // 
            resources.ApplyResources(this.removeButton, "removeButton");
            this.removeButton.Name = "removeButton";
            this.removeButton.Click += new System.EventHandler(this.RemoveButtonClick);
            // 
            // addButton
            // 
            resources.ApplyResources(this.addButton, "addButton");
            this.addButton.Name = "addButton";
            this.addButton.Click += new System.EventHandler(this.AddButtonClick);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // addWordTextBox
            // 
            resources.ApplyResources(this.addWordTextBox, "addWordTextBox");
            this.addWordTextBox.Name = "addWordTextBox";
            this.addWordTextBox.GotFocus += new System.EventHandler(this.AddPrefixGotFocus);
            this.addWordTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddPrefixKeyDown);
            this.addWordTextBox.LostFocus += new System.EventHandler(this.AddPrefixLostFocus);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // wordsListView
            // 
            resources.ApplyResources(this.wordsListView, "wordsListView");
            this.wordsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.wordsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.wordsListView.HideSelection = false;
            this.wordsListView.MultiSelect = false;
            this.wordsListView.Name = "wordsListView";
            this.wordsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.wordsListView.UseCompatibleStateImageBehavior = false;
            this.wordsListView.View = System.Windows.Forms.View.Details;
            this.wordsListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.WordListItemSelectionChanged);
            this.wordsListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.WordListKeyDown);
            // 
            // columnHeader1
            // 
            resources.ApplyResources(this.columnHeader1, "columnHeader1");
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // SpellingTab
            // 
            this.Controls.Add(this.label3);
            this.Controls.Add(this.wordsListView);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addWordTextBox);
            this.Controls.Add(this.label1);
            this.Name = "SpellingTab";
            resources.ApplyResources(this, "$this");
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        /// <summary>
        /// Add prefixes from the parent settings.
        /// </summary>
        private void AddParentWords()
        {
            if (this.tabControl.ParentSettings != null)
            {
                CollectionProperty parentPrefixesProperty = this.tabControl.ParentSettings.GlobalSettings.GetProperty(RecognizedWordsPropertyName) as CollectionProperty;

                if (parentPrefixesProperty != null)
                {
                    if (parentPrefixesProperty.Values.Count > 0)
                    {
                        foreach (string value in parentPrefixesProperty)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                ListViewItem item = this.wordsListView.Items.Add(value);
                                item.Tag = false;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Sets the bold state of the item.
        /// </summary>
        /// <param name="item">The item to set.</param>
        private void SetBoldState(ListViewItem item)
        {
            Param.AssertNotNull(item, "item");

            // Dispose the item's current font if necessary.
            if (item.Font != this.wordsListView.Font && item.Font != null)
            {
                item.Font.Dispose();
            }

            // Create and set the new font.
            if ((bool)item.Tag)
            {
                item.Font = new Font(this.wordsListView.Font, FontStyle.Bold);
            }
            else
            {
                item.Font = new Font(this.wordsListView.Font, FontStyle.Regular);
            }
        }

        /// <summary>
        /// Event that is fired when the add button is clicked.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AddButtonClick(object sender, System.EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.addWordTextBox.Text.Length == 0 || this.addWordTextBox.Text.Length < 2)
            {
                AlertDialog.Show(
                    this.tabControl.Core,
                    this, 
                    Strings.EnterValidWord, 
                    Strings.Title, 
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Exclamation);
                return;
            }

            foreach (ListViewItem item in this.wordsListView.Items)
            {
                if (item.Text == this.addWordTextBox.Text)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    this.addWordTextBox.Clear();
                    return;
                }
            }

            ListViewItem addedItem = this.wordsListView.Items.Add(this.addWordTextBox.Text);
            addedItem.Tag = true;
            addedItem.Selected = true;
            this.wordsListView.EnsureVisible(addedItem.Index);
            this.SetBoldState(addedItem);

            this.addWordTextBox.Clear();
            
            this.dirty = true;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Event that is fired when the remove button is clicked.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void RemoveButtonClick(object sender, System.EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.wordsListView.SelectedItems.Count > 0)
            {
                int index = this.wordsListView.SelectedIndices[0];

                this.wordsListView.Items.RemoveAt(index);
                this.EnableDisableRemoveButton();

                if (this.wordsListView.Items.Count > index)
                {
                    this.wordsListView.Items[index].Selected = true;
                }
                else if (this.wordsListView.Items.Count > 0)
                {
                    this.wordsListView.Items[this.wordsListView.Items.Count - 1].Selected = true;
                }

                this.dirty = true;
                this.tabControl.DirtyChanged();
            }
        }

        /// <summary>
        /// Called when the current selection changes in the ListView.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void WordListItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Param.Ignore(sender, e);
            this.EnableDisableRemoveButton();
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the list.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void WordListKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Delete)
            {
                if (this.addWordTextBox.Text.Length > 0)
                {
                    // Simulate a click of the remove button.
                    this.RemoveButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// Sets the enabled state of the remove button.
        /// </summary>
        private void EnableDisableRemoveButton()
        {
            if (this.wordsListView.SelectedItems.Count > 0)
            {
                // Get the currently selected item.
                ListViewItem selectedItem = this.wordsListView.SelectedItems[0];
                this.removeButton.Enabled = (bool)selectedItem.Tag;
            }
            else
            {
                this.removeButton.Enabled = false;
            }
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the add textbox.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AddPrefixKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Return)
            {
                if (this.addWordTextBox.Text.Length > 0)
                {
                    // Simulate a click of the add button.
                    this.AddButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// Called when the add TextBox receives the input focus.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AddPrefixGotFocus(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            // Save the current form accept button, and then clear it. This will allow
            // the add textbox to capture the return key.
            this.formAcceptButton = this.ParentForm.AcceptButton;
            this.ParentForm.AcceptButton = null;
        }

        /// <summary>
        /// Called when the add TextBox loses the input focus.
        /// </summary>
        /// <param name="sender">The event sender.</param>
        /// <param name="e">The event arguments.</param>
        private void AddPrefixLostFocus(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            // Reset the form accept button now that the add textbox no longer has the input focus.
            if (this.formAcceptButton != null)
            {
                this.ParentForm.AcceptButton = this.formAcceptButton;
                this.formAcceptButton = null;
            }
        }

        #endregion Private Methods
    }
}