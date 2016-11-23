// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SpellingTab.cs" company="https://github.com/StyleCop">
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
//   Options dialog to manage words for spelling.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Options dialog to manage words for spelling.
    /// </summary>
    internal class SpellingTab : UserControl, IPropertyControlPage
    {
        #region Constants

        /// <summary>
        /// The deprecated words property name.
        /// </summary>
        private const string DeprecatedWordsPropertyName = "DeprecatedWords";

        /// <summary>
        /// The dictionary folders property name.
        /// </summary>
        private const string DictionaryFoldersPropertyName = "DictionaryFolders";

        /// <summary>
        /// The recognized words property name.
        /// </summary>
        private const string RecognizedWordsPropertyName = "RecognizedWords";

        #endregion

        #region Fields

        /// <summary>
        /// The add alternate word text box.
        /// </summary>
        private TextBox addAlternateWordTextBox;

        /// <summary>
        /// The add deprecated word button.
        /// </summary>
        private Button addDeprecatedWordButton;

        /// <summary>
        /// The add deprecated word text box.
        /// </summary>
        private TextBox addDeprecatedWordTextBox;

        /// <summary>
        /// The add folder button.
        /// </summary>
        private Button addFolderButton;

        /// <summary>
        /// The add folder text box.
        /// </summary>
        private TextBox addFolderTextBox;

        /// <summary>
        /// The Add button.
        /// </summary>
        private Button addRecognizedWordButton;

        /// <summary>
        /// The add prefix box.
        /// </summary>
        private TextBox addRecognizedWordTextBox;

        /// <summary>
        /// The deprecated words column header.
        /// </summary>
        private ColumnHeader deprecatedWordsColumnHeader;

        /// <summary>
        /// The deprecated words list view.
        /// </summary>
        private ListView deprecatedWordsListView;

        /// <summary>
        /// The dictionary folders column header.
        /// </summary>
        private ColumnHeader dictionaryFoldersColumnHeader;

        /// <summary>
        /// True if the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// The folders list view.
        /// </summary>
        private ListView foldersListView;

        /// <summary>
        /// Stores the form's accept button while focus is on the add textbox.
        /// </summary>
        private IButtonControl formAcceptButton;

        /// <summary>
        /// The group box 2.
        /// </summary>
        private GroupBox groupBox2;

        /// <summary>
        /// The group box 3.
        /// </summary>
        private GroupBox groupBox3;

        /// <summary>
        /// The static text label.
        /// </summary>
        private Label label1;

        /// <summary>
        /// The label 10.
        /// </summary>
        private Label label10;

        /// <summary>
        /// The static text label.
        /// </summary>
        private Label label2;

        /// <summary>
        /// Contains help text.
        /// </summary>
        private Label label3;

        /// <summary>
        /// The label 4.
        /// </summary>
        private Label label4;

        /// <summary>
        /// The label 5.
        /// </summary>
        private Label label5;

        /// <summary>
        /// The label 6.
        /// </summary>
        private Label label6;

        /// <summary>
        /// The label 7.
        /// </summary>
        private Label label7;

        /// <summary>
        /// The label 8.
        /// </summary>
        private Label label8;

        /// <summary>
        /// The label 9.
        /// </summary>
        private Label label9;

        /// <summary>
        /// The default column on the ListView control.
        /// </summary>
        private ColumnHeader recognizedWordsColumnHeader;

        /// <summary>
        /// The current words box.
        /// </summary>
        private ListView recognizedWordsListView;

        /// <summary>
        /// The remove deprecated word button.
        /// </summary>
        private Button removeDeprecatedWordButton;

        /// <summary>
        /// The remove folder button.
        /// </summary>
        private Button removeFolderButton;

        /// <summary>
        /// The Remove button.
        /// </summary>
        private Button removeRecognizedWordButton;

        /// <summary>
        /// The table layout panel 1.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel1;

        /// <summary>
        /// The label 12.
        /// </summary>
        private Label label12;

        /// <summary>
        /// The table layout panel 2.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel2;

        /// <summary>
        /// The group box 1.
        /// </summary>
        private GroupBox groupBox1;

        /// <summary>
        /// The table layout panel 3.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel3;

        /// <summary>
        /// The label 11.
        /// </summary>
        private Label label11;

        /// <summary>
        /// The table layout panel 4.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel4;

        /// <summary>
        /// The table layout panel 5.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel5;

        /// <summary>
        /// The label 13.
        /// </summary>
        private Label label13;

        /// <summary>
        /// The tab control which hosts this page.
        /// </summary>
        private PropertyControl tabControl;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the SpellingTab class.
        /// </summary>
        public SpellingTab()
        {
            this.InitializeComponent();
            this.InitializeColumns();
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
                return Strings.SpellingTab;
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
            List<string> values = new List<string>(this.recognizedWordsListView.Items.Count);

            foreach (ListViewItem word in this.recognizedWordsListView.Items)
            {
                // Only save local tags.
                if ((bool)word.Tag)
                {
                    values.Add(word.Text);
                }
            }

            this.tabControl.LocalSettings.GlobalSettings.SetProperty(new CollectionProperty(this.tabControl.Core, RecognizedWordsPropertyName, values));

            values = new List<string>(this.deprecatedWordsListView.Items.Count);

            foreach (ListViewItem word in this.deprecatedWordsListView.Items)
            {
                // Only save local tags.
                if ((bool)word.Tag)
                {
                    values.Add(word.Text);
                }
            }

            this.tabControl.LocalSettings.GlobalSettings.SetProperty(new CollectionProperty(this.tabControl.Core, DeprecatedWordsPropertyName, values));

            values = new List<string>(this.deprecatedWordsListView.Items.Count);

            foreach (ListViewItem word in this.foldersListView.Items)
            {
                // Only save local tags.
                if ((bool)word.Tag)
                {
                    values.Add(word.Text);
                }
            }

            this.tabControl.LocalSettings.GlobalSettings.SetProperty(new CollectionProperty(this.tabControl.Core, DictionaryFoldersPropertyName, values));

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

            // Get the list of allowed words from the parent settings.
            this.AddParentSettingsValues();

            // Get the list of allowed words from the local settings.
            CollectionProperty recognizedWordsProperty = this.tabControl.LocalSettings.GlobalSettings.GetProperty(RecognizedWordsPropertyName) as CollectionProperty;

            if (recognizedWordsProperty != null && recognizedWordsProperty.Values.Count > 0)
            {
                foreach (string value in recognizedWordsProperty)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        ListViewItem item = this.recognizedWordsListView.Items.Add(value);
                        item.Tag = true;
                        this.SetBoldState(item, this.recognizedWordsListView);
                    }
                }
            }

            // Select the first item in the list.
            if (this.recognizedWordsListView.Items.Count > 0)
            {
                this.recognizedWordsListView.Items[0].Selected = true;
            }

            // Get the list of deprecated words from the local settings.
            CollectionProperty deprecatedWordsProperty = this.tabControl.LocalSettings.GlobalSettings.GetProperty(DeprecatedWordsPropertyName) as CollectionProperty;

            if (deprecatedWordsProperty != null && deprecatedWordsProperty.Values.Count > 0)
            {
                foreach (string value in deprecatedWordsProperty)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        string[] valueParts = value.Split(',');
                        if (valueParts.Length == 2)
                        {
                            ListViewItem item = this.deprecatedWordsListView.Items.Add(valueParts[0].Trim() + ", " + valueParts[1].Trim());
                            item.Tag = true;
                            this.SetBoldState(item, this.deprecatedWordsListView);
                        }
                    }
                }
            }

            // Select the first item in the list.
            if (this.deprecatedWordsListView.Items.Count > 0)
            {
                this.deprecatedWordsListView.Items[0].Selected = true;
            }

            // Get the list of folders from the local settings.
            CollectionProperty dictionaryFoldersProperty = this.tabControl.LocalSettings.GlobalSettings.GetProperty(DictionaryFoldersPropertyName) as CollectionProperty;

            if (dictionaryFoldersProperty != null && dictionaryFoldersProperty.Values.Count > 0)
            {
                foreach (string value in dictionaryFoldersProperty)
                {
                    if (!string.IsNullOrEmpty(value))
                    {
                        ListViewItem item = this.foldersListView.Items.Add(value);
                        item.Tag = true;
                        this.SetBoldState(item, this.foldersListView);
                    }
                }
            }

            // Select the first item in the list.
            if (this.foldersListView.Items.Count > 0)
            {
                this.foldersListView.Items[0].Selected = true;
            }

            this.EnableDisableRemoveButtons();

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
            foreach (ListViewItem prefix in this.recognizedWordsListView.Items)
            {
                if (!(bool)prefix.Tag)
                {
                    itemsToRemove.Add(prefix);
                }
            }

            foreach (ListViewItem itemToRemove in itemsToRemove)
            {
                this.recognizedWordsListView.Items.Remove(itemToRemove);
            }

            // Loop through the existing items and remove all parent items.
            itemsToRemove = new List<ListViewItem>();
            foreach (ListViewItem listViewItem in this.deprecatedWordsListView.Items)
            {
                if (!(bool)listViewItem.Tag)
                {
                    itemsToRemove.Add(listViewItem);
                }
            }

            foreach (ListViewItem itemToRemove in itemsToRemove)
            {
                this.deprecatedWordsListView.Items.Remove(itemToRemove);
            }

            // Loop through the existing items and remove all parent items.
            itemsToRemove = new List<ListViewItem>();
            foreach (ListViewItem prefix in this.foldersListView.Items)
            {
                if (!(bool)prefix.Tag)
                {
                    itemsToRemove.Add(prefix);
                }
            }

            foreach (ListViewItem itemToRemove in itemsToRemove)
            {
                this.foldersListView.Items.Remove(itemToRemove);
            }

            // Add any new parent items now.
            this.AddParentSettingsValues();

            // Loop through the list again and set the bold state for locally added items.
            foreach (ListViewItem listViewItem in this.recognizedWordsListView.Items)
            {
                if ((bool)listViewItem.Tag)
                {
                    this.SetBoldState(listViewItem, this.recognizedWordsListView);
                }
            }

            // Loop through the list again and set the bold state for locally added items.
            foreach (ListViewItem listViewItem in this.deprecatedWordsListView.Items)
            {
                if ((bool)listViewItem.Tag)
                {
                    this.SetBoldState(listViewItem, this.deprecatedWordsListView);
                }
            }

            // Loop through the list again and set the bold state for locally added items.
            foreach (ListViewItem listViewItem in this.foldersListView.Items)
            {
                if ((bool)listViewItem.Tag)
                {
                    this.SetBoldState(listViewItem, this.foldersListView);
                }
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// The initialize columns.
        /// </summary>
        private void InitializeColumns()
        {
            this.recognizedWordsListView.Columns.AddRange(new[] { this.recognizedWordsColumnHeader });
            this.deprecatedWordsListView.Columns.AddRange(new[] { this.deprecatedWordsColumnHeader });
            this.foldersListView.Columns.AddRange(new[] { this.dictionaryFoldersColumnHeader });
        }

        /// <summary>
        /// Event that is fired when the add deprecated word button is clicked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddDeprecatedWordButtonClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            string deprecatedText = this.addDeprecatedWordTextBox.Text;
            string alternateText = this.addAlternateWordTextBox.Text;

            if (deprecatedText.Length == 0 || deprecatedText.Length < 2 || alternateText.Length == 0 || alternateText.Length < 2 || deprecatedText.Contains(" ")
                || alternateText.Contains(" "))
            {
                AlertDialog.Show(this.tabControl.Core, this, Strings.EnterValidDeprecatedWord, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            string newDeprecatedAndAlternateText = string.Concat(deprecatedText.Trim(), ", ", alternateText.Trim());

            foreach (ListViewItem item in this.deprecatedWordsListView.Items)
            {
                if (item.Text == newDeprecatedAndAlternateText)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    this.addDeprecatedWordTextBox.Clear();
                    this.addAlternateWordTextBox.Clear();
                    return;
                }
            }

            ListViewItem addedItem = this.deprecatedWordsListView.Items.Add(newDeprecatedAndAlternateText);
            addedItem.Tag = true;
            addedItem.Selected = true;
            this.deprecatedWordsListView.EnsureVisible(addedItem.Index);
            this.SetBoldState(addedItem, this.deprecatedWordsListView);

            this.addDeprecatedWordTextBox.Clear();
            this.addAlternateWordTextBox.Clear();

            this.dirty = true;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the add textbox.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddDeprecatedWordKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Return)
            {
                if (this.addDeprecatedWordTextBox.Text.Length > 0 && this.addAlternateWordTextBox.Text.Length > 0)
                {
                    // Simulate a click of the add button.
                    this.AddDeprecatedWordButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// The add dictionary folder key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AddDictionaryFolderKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Return)
            {
                if (this.addFolderTextBox.Text.Length > 0)
                {
                    // Simulate a click of the add button.
                    this.AddFolderButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// The add folder button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void AddFolderButtonClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            string folderText = this.addFolderTextBox.Text;

            if (folderText.Length == 0 || folderText.Length < 2)
            {
                AlertDialog.Show(this.tabControl.Core, this, Strings.EnterValidFolder, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (ListViewItem item in this.foldersListView.Items)
            {
                if (item.Text == folderText)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    this.addFolderTextBox.Clear();
                    return;
                }
            }

            ListViewItem addedItem = this.foldersListView.Items.Add(folderText);
            addedItem.Tag = true;
            addedItem.Selected = true;
            this.foldersListView.EnsureVisible(addedItem.Index);
            this.SetBoldState(addedItem, this.foldersListView);

            this.addFolderTextBox.Clear();

            this.dirty = true;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Adds values from the parent settings.
        /// </summary>
        private void AddParentSettingsValues()
        {
            if (this.tabControl.ParentSettings != null)
            {
                PropertyCollection globalPropertyCollection = this.tabControl.ParentSettings.GlobalSettings;

                CollectionProperty parentProperty = globalPropertyCollection.GetProperty(RecognizedWordsPropertyName) as CollectionProperty;

                if (parentProperty != null)
                {
                    if (parentProperty.Values.Count > 0)
                    {
                        foreach (string value in parentProperty)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                ListViewItem item = this.recognizedWordsListView.Items.Add(value);
                                item.Tag = false;
                            }
                        }
                    }
                }

                parentProperty = globalPropertyCollection.GetProperty(DeprecatedWordsPropertyName) as CollectionProperty;

                if (parentProperty != null)
                {
                    if (parentProperty.Values.Count > 0)
                    {
                        foreach (string value in parentProperty)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                string[] splitValue = value.Split(',');
                                if (splitValue.Length == 2)
                                {
                                    ListViewItem item = this.deprecatedWordsListView.Items.Add(splitValue[0].Trim() + ", " + splitValue[1].Trim());
                                    item.Tag = false;
                                }
                            }
                        }
                    }
                }

                parentProperty = globalPropertyCollection.GetProperty(DictionaryFoldersPropertyName) as CollectionProperty;

                if (parentProperty != null)
                {
                    if (parentProperty.Values.Count > 0)
                    {
                        foreach (string value in parentProperty)
                        {
                            if (!string.IsNullOrEmpty(value))
                            {
                                ListViewItem item = this.foldersListView.Items.Add(value);
                                item.Tag = false;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Event that is fired when the add button is clicked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddRecognizedWordButtonClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            string recognizedText = this.addRecognizedWordTextBox.Text;

            if (recognizedText.Length == 0 || recognizedText.Length < 2 || recognizedText.Contains(" "))
            {
                AlertDialog.Show(this.tabControl.Core, this, Strings.EnterValidWord, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            foreach (ListViewItem item in this.recognizedWordsListView.Items)
            {
                if (item.Text == recognizedText)
                {
                    item.Selected = true;
                    item.EnsureVisible();
                    this.addRecognizedWordTextBox.Clear();
                    return;
                }
            }

            ListViewItem addedItem = this.recognizedWordsListView.Items.Add(recognizedText);
            addedItem.Tag = true;
            addedItem.Selected = true;
            this.recognizedWordsListView.EnsureVisible(addedItem.Index);
            this.SetBoldState(addedItem, this.recognizedWordsListView);

            this.addRecognizedWordTextBox.Clear();

            this.dirty = true;
            this.tabControl.DirtyChanged();
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the add textbox.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddRecognizedWordKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Return)
            {
                if (this.addRecognizedWordTextBox.Text.Length > 0)
                {
                    // Simulate a click of the add button.
                    this.AddRecognizedWordButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// Called when the add TextBox receives the input focus.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddWordGotFocus(object sender, EventArgs e)
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
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void AddWordLostFocus(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            // Reset the form accept button now that the add textbox no longer has the input focus.
            if (this.formAcceptButton != null)
            {
                this.ParentForm.AcceptButton = this.formAcceptButton;
                this.formAcceptButton = null;
            }
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the list.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void DeprecatedWordListKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Delete)
            {
                if (this.addDeprecatedWordTextBox.Text.Length > 0 && this.addAlternateWordTextBox.Text.Length > 0)
                {
                    // Simulate a click of the remove button.
                    this.RemoveDeprecatedWordButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// Resizes the column inside the ListView.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void DeprecatedWordsListViewSizeChanged(object sender, EventArgs e)
        {
            this.deprecatedWordsColumnHeader.Width = this.deprecatedWordsListView.Width - 64;
        }

        /// <summary>
        /// The dictionary folders key down.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DictionaryFoldersKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Delete)
            {
                if (this.addFolderTextBox.Text.Length > 0)
                {
                    // Simulate a click of the remove button.
                    this.RemoveFolderButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// The dictionary folders list view size changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void DictionaryFoldersListViewSizeChanged(object sender, EventArgs e)
        {
            this.dictionaryFoldersColumnHeader.Width = this.foldersListView.Width - 64;
        }

        /// <summary>
        /// Sets the enabled state of the remove buttons.
        /// </summary>
        private void EnableDisableRemoveButtons()
        {
            if (this.recognizedWordsListView.SelectedItems.Count > 0)
            {
                // Get the currently selected item.
                ListViewItem selectedItem = this.recognizedWordsListView.SelectedItems[0];
                this.removeRecognizedWordButton.Enabled = (bool)selectedItem.Tag;
            }
            else
            {
                this.removeRecognizedWordButton.Enabled = false;
            }

            if (this.deprecatedWordsListView.SelectedItems.Count > 0)
            {
                // Get the currently selected item.
                ListViewItem selectedItem = this.deprecatedWordsListView.SelectedItems[0];
                this.removeDeprecatedWordButton.Enabled = (bool)selectedItem.Tag;
            }
            else
            {
                this.removeDeprecatedWordButton.Enabled = false;
            }

            if (this.foldersListView.SelectedItems.Count > 0)
            {
                // Get the currently selected item.
                ListViewItem selectedItem = this.foldersListView.SelectedItems[0];
                this.removeFolderButton.Enabled = (bool)selectedItem.Tag;
            }
            else
            {
                this.removeFolderButton.Enabled = false;
            }
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(SpellingTab));
            this.removeRecognizedWordButton = new Button();
            this.addRecognizedWordButton = new Button();
            this.label2 = new Label();
            this.addRecognizedWordTextBox = new TextBox();
            this.label1 = new Label();
            this.recognizedWordsListView = new ListView();
            this.recognizedWordsColumnHeader = (ColumnHeader)(new ColumnHeader());
            this.label3 = new Label();
            this.label4 = new Label();
            this.addDeprecatedWordButton = new Button();
            this.addDeprecatedWordTextBox = new TextBox();
            this.label5 = new Label();
            this.addAlternateWordTextBox = new TextBox();
            this.label6 = new Label();
            this.deprecatedWordsListView = new ListView();
            this.deprecatedWordsColumnHeader = (ColumnHeader)(new ColumnHeader());
            this.removeDeprecatedWordButton = new Button();
            this.label7 = new Label();
            this.addFolderTextBox = new TextBox();
            this.foldersListView = new ListView();
            this.dictionaryFoldersColumnHeader = (ColumnHeader)(new ColumnHeader());
            this.removeFolderButton = new Button();
            this.addFolderButton = new Button();
            this.label9 = new Label();
            this.label10 = new Label();
            this.groupBox2 = new GroupBox();
            this.label8 = new Label();
            this.groupBox3 = new GroupBox();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.tableLayoutPanel5 = new TableLayoutPanel();
            this.label13 = new Label();
            this.tableLayoutPanel2 = new TableLayoutPanel();
            this.groupBox1 = new GroupBox();
            this.tableLayoutPanel3 = new TableLayoutPanel();
            this.label11 = new Label();
            this.tableLayoutPanel4 = new TableLayoutPanel();
            this.label12 = new Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();

            // removeRecognizedWordButton
            resources.ApplyResources(this.removeRecognizedWordButton, "removeRecognizedWordButton");
            this.removeRecognizedWordButton.Name = "removeRecognizedWordButton";
            this.removeRecognizedWordButton.Click += new EventHandler(this.RemoveRecognizedWordButtonClick);

            // addRecognizedWordButton
            resources.ApplyResources(this.addRecognizedWordButton, "addRecognizedWordButton");
            this.addRecognizedWordButton.Name = "addRecognizedWordButton";
            this.addRecognizedWordButton.Click += new EventHandler(this.AddRecognizedWordButtonClick);

            // label2
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";

            // addRecognizedWordTextBox
            resources.ApplyResources(this.addRecognizedWordTextBox, "addRecognizedWordTextBox");
            this.addRecognizedWordTextBox.Name = "addRecognizedWordTextBox";
            this.addRecognizedWordTextBox.GotFocus += new EventHandler(this.AddWordGotFocus);
            this.addRecognizedWordTextBox.KeyDown += new KeyEventHandler(this.AddRecognizedWordKeyDown);
            this.addRecognizedWordTextBox.LostFocus += new EventHandler(this.AddWordLostFocus);

            // label1
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";

            // recognizedWordsListView
            resources.ApplyResources(this.recognizedWordsListView, "recognizedWordsListView");
            this.recognizedWordsListView.HeaderStyle = ColumnHeaderStyle.None;
            this.recognizedWordsListView.HideSelection = false;
            this.recognizedWordsListView.MultiSelect = false;
            this.recognizedWordsListView.Name = "recognizedWordsListView";
            this.recognizedWordsListView.Sorting = SortOrder.Ascending;
            this.recognizedWordsListView.UseCompatibleStateImageBehavior = false;
            this.recognizedWordsListView.View = View.Details;
            this.recognizedWordsListView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.WordListItemSelectionChanged);
            this.recognizedWordsListView.SizeChanged += new EventHandler(this.RecognizedWordsListViewSizeChanged);
            this.recognizedWordsListView.KeyDown += new KeyEventHandler(this.RecognizedWordListKeyDown);

            // recognizedWordsColumnHeader
            resources.ApplyResources(this.recognizedWordsColumnHeader, "recognizedWordsColumnHeader");

            // label3
            resources.ApplyResources(this.label3, "label3");
            this.tableLayoutPanel1.SetColumnSpan(this.label3, 3);
            this.label3.Name = "label3";

            // label4
            resources.ApplyResources(this.label4, "label4");
            this.tableLayoutPanel1.SetColumnSpan(this.label4, 3);
            this.label4.Name = "label4";

            // addDeprecatedWordButton
            resources.ApplyResources(this.addDeprecatedWordButton, "addDeprecatedWordButton");
            this.addDeprecatedWordButton.Name = "addDeprecatedWordButton";
            this.addDeprecatedWordButton.Click += new EventHandler(this.AddDeprecatedWordButtonClick);

            // addDeprecatedWordTextBox
            resources.ApplyResources(this.addDeprecatedWordTextBox, "addDeprecatedWordTextBox");
            this.addDeprecatedWordTextBox.Name = "addDeprecatedWordTextBox";
            this.addDeprecatedWordTextBox.GotFocus += new EventHandler(this.AddWordGotFocus);
            this.addDeprecatedWordTextBox.KeyDown += new KeyEventHandler(this.AddDeprecatedWordKeyDown);
            this.addDeprecatedWordTextBox.LostFocus += new EventHandler(this.AddWordLostFocus);

            // label5
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";

            // addAlternateWordTextBox
            resources.ApplyResources(this.addAlternateWordTextBox, "addAlternateWordTextBox");
            this.addAlternateWordTextBox.Name = "addAlternateWordTextBox";
            this.addAlternateWordTextBox.GotFocus += new EventHandler(this.AddWordGotFocus);
            this.addAlternateWordTextBox.KeyDown += new KeyEventHandler(this.AddDeprecatedWordKeyDown);
            this.addAlternateWordTextBox.LostFocus += new EventHandler(this.AddWordLostFocus);

            // label6
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";

            // deprecatedWordsListView
            resources.ApplyResources(this.deprecatedWordsListView, "deprecatedWordsListView");
            this.deprecatedWordsListView.HeaderStyle = ColumnHeaderStyle.None;
            this.deprecatedWordsListView.HideSelection = false;
            this.deprecatedWordsListView.MultiSelect = false;
            this.deprecatedWordsListView.Name = "deprecatedWordsListView";
            this.deprecatedWordsListView.Sorting = SortOrder.Ascending;
            this.deprecatedWordsListView.UseCompatibleStateImageBehavior = false;
            this.deprecatedWordsListView.View = View.Details;
            this.deprecatedWordsListView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.WordListItemSelectionChanged);
            this.deprecatedWordsListView.SizeChanged += new EventHandler(this.DeprecatedWordsListViewSizeChanged);
            this.deprecatedWordsListView.KeyDown += new KeyEventHandler(this.DeprecatedWordListKeyDown);

            // deprecatedWordsColumnHeader
            resources.ApplyResources(this.deprecatedWordsColumnHeader, "deprecatedWordsColumnHeader");

            // removeDeprecatedWordButton
            resources.ApplyResources(this.removeDeprecatedWordButton, "removeDeprecatedWordButton");
            this.removeDeprecatedWordButton.Name = "removeDeprecatedWordButton";
            this.removeDeprecatedWordButton.Click += new EventHandler(this.RemoveDeprecatedWordButtonClick);

            // label7
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";

            // addFolderTextBox
            resources.ApplyResources(this.addFolderTextBox, "addFolderTextBox");
            this.addFolderTextBox.Name = "addFolderTextBox";
            this.addFolderTextBox.KeyDown += new KeyEventHandler(this.AddDictionaryFolderKeyDown);

            // foldersListView
            resources.ApplyResources(this.foldersListView, "foldersListView");
            this.foldersListView.HeaderStyle = ColumnHeaderStyle.None;
            this.foldersListView.HideSelection = false;
            this.foldersListView.MultiSelect = false;
            this.foldersListView.Name = "foldersListView";
            this.foldersListView.Sorting = SortOrder.Ascending;
            this.foldersListView.UseCompatibleStateImageBehavior = false;
            this.foldersListView.View = View.Details;
            this.foldersListView.ItemSelectionChanged += new ListViewItemSelectionChangedEventHandler(this.WordListItemSelectionChanged);
            this.foldersListView.SizeChanged += new EventHandler(this.DictionaryFoldersListViewSizeChanged);
            this.foldersListView.KeyDown += new KeyEventHandler(this.DictionaryFoldersKeyDown);

            // dictionaryFoldersColumnHeader
            resources.ApplyResources(this.dictionaryFoldersColumnHeader, "dictionaryFoldersColumnHeader");

            // removeFolderButton
            resources.ApplyResources(this.removeFolderButton, "removeFolderButton");
            this.removeFolderButton.Name = "removeFolderButton";
            this.removeFolderButton.Click += new EventHandler(this.RemoveFolderButtonClick);

            // addFolderButton
            resources.ApplyResources(this.addFolderButton, "addFolderButton");
            this.addFolderButton.Name = "addFolderButton";
            this.addFolderButton.Click += new EventHandler(this.AddFolderButtonClick);

            // label9
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";

            // label10
            resources.ApplyResources(this.label10, "label10");
            this.tableLayoutPanel1.SetColumnSpan(this.label10, 3);
            this.label10.Name = "label10";

            // groupBox2
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;

            // label8
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";

            // groupBox3
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;

            // tableLayoutPanel1
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel5, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.removeFolderButton, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.foldersListView, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.addFolderTextBox, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.addFolderButton, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.addDeprecatedWordButton, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.addAlternateWordTextBox, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.addDeprecatedWordTextBox, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.recognizedWordsListView, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.addRecognizedWordButton, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.addRecognizedWordTextBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.removeRecognizedWordButton, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.deprecatedWordsListView, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.removeDeprecatedWordButton, 2, 8);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";

            // tableLayoutPanel5
            resources.ApplyResources(this.tableLayoutPanel5, "tableLayoutPanel5");
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel5, 3);
            this.tableLayoutPanel5.Controls.Add(this.label13, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";

            // label13
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";

            // tableLayoutPanel2
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel2, 3);
            this.tableLayoutPanel2.Controls.Add(this.groupBox1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";

            // groupBox1
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.tableLayoutPanel3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;

            // tableLayoutPanel3
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";

            // label11
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";

            // tableLayoutPanel4
            resources.ApplyResources(this.tableLayoutPanel4, "tableLayoutPanel4");
            this.tableLayoutPanel1.SetColumnSpan(this.tableLayoutPanel4, 3);
            this.tableLayoutPanel4.Controls.Add(this.label12, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.groupBox3, 1, 0);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";

            // label12
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";

            // SpellingTab
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "SpellingTab";
            resources.ApplyResources(this, "$this");
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);
        }

        /// <summary>
        /// Called when a key is clicked while focus is on the list.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void RecognizedWordListKeyDown(object sender, KeyEventArgs e)
        {
            Param.AssertNotNull(sender, "sender");
            Param.AssertNotNull(e, "e");

            if (e.KeyCode == Keys.Delete)
            {
                if (this.addRecognizedWordTextBox.Text.Length > 0)
                {
                    // Simulate a click of the remove button.
                    this.RemoveRecognizedWordButtonClick(sender, e);
                }
            }
        }

        /// <summary>
        /// Resizes the column inside the ListView.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void RecognizedWordsListViewSizeChanged(object sender, EventArgs e)
        {
            this.recognizedWordsColumnHeader.Width = this.recognizedWordsListView.Width - 64;
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
        private void RemoveDeprecatedWordButtonClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.deprecatedWordsListView.SelectedItems.Count > 0)
            {
                int index = this.deprecatedWordsListView.SelectedIndices[0];

                this.deprecatedWordsListView.Items.RemoveAt(index);
                this.EnableDisableRemoveButtons();

                if (this.deprecatedWordsListView.Items.Count > index)
                {
                    this.deprecatedWordsListView.Items[index].Selected = true;
                }
                else if (this.deprecatedWordsListView.Items.Count > 0)
                {
                    this.deprecatedWordsListView.Items[this.deprecatedWordsListView.Items.Count - 1].Selected = true;
                }

                this.dirty = true;
                this.tabControl.DirtyChanged();
            }
        }

        /// <summary>
        /// The remove folder button click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void RemoveFolderButtonClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.foldersListView.SelectedItems.Count > 0)
            {
                int index = this.foldersListView.SelectedIndices[0];

                this.foldersListView.Items.RemoveAt(index);
                this.EnableDisableRemoveButtons();

                if (this.foldersListView.Items.Count > index)
                {
                    this.foldersListView.Items[index].Selected = true;
                }
                else if (this.foldersListView.Items.Count > 0)
                {
                    this.foldersListView.Items[this.foldersListView.Items.Count - 1].Selected = true;
                }

                this.dirty = true;
                this.tabControl.DirtyChanged();
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
        private void RemoveRecognizedWordButtonClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (this.recognizedWordsListView.SelectedItems.Count > 0)
            {
                int index = this.recognizedWordsListView.SelectedIndices[0];

                this.recognizedWordsListView.Items.RemoveAt(index);
                this.EnableDisableRemoveButtons();

                if (this.recognizedWordsListView.Items.Count > index)
                {
                    this.recognizedWordsListView.Items[index].Selected = true;
                }
                else if (this.recognizedWordsListView.Items.Count > 0)
                {
                    this.recognizedWordsListView.Items[this.recognizedWordsListView.Items.Count - 1].Selected = true;
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
        /// <param name="listView">
        /// The ListView to use.
        /// </param>
        private void SetBoldState(ListViewItem item, ListView listView)
        {
            Param.AssertNotNull(item, "item");

            // Dispose the item's current font if necessary.
            if (!object.Equals(item.Font, listView.Font) && item.Font != null)
            {
                item.Font.Dispose();
            }

            // Create and set the new font.
            if ((bool)item.Tag)
            {
                item.Font = new Font(listView.Font, FontStyle.Bold);
            }
            else
            {
                item.Font = new Font(listView.Font, FontStyle.Regular);
            }
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
        private void WordListItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            Param.Ignore(sender, e);
            this.EnableDisableRemoveButtons();
        }

        #endregion
    }
}