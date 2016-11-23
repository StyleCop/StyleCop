// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GlobalSettingsFileOptions.cs" company="https://github.com/StyleCop">
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
    using System.ComponentModel;
    using System.Drawing;
    using System.Globalization;
    using System.IO;
    using System.Security;
    using System.Windows.Forms;
    using System.Xml;

    /// <summary>
    /// Options dialog to choose which settings files to use.
    /// </summary>
    internal class GlobalSettingsFileOptions : UserControl, IPropertyControlPage
    {
        #region Fields

        /// <summary>
        /// The WinForms components manager.
        /// </summary>
        private readonly Container components = null;

        /// <summary>
        /// The browse button.
        /// </summary>
        private Button browse;

        /// <summary>
        /// Indicates whether the page is dirty.
        /// </summary>
        private bool dirty;

        /// <summary>
        /// Indicates whether the disable the linked settings options.
        /// </summary>
        private bool disableLinking;

        /// <summary>
        /// The edit button.
        /// </summary>
        private Button editLinkedSettingsFile;

        /// <summary>
        /// Edits the parent settings file.
        /// </summary>
        private Button editParentSettingsFile;

        /// <summary>
        /// The page description.
        /// </summary>
        private Label label1;

        /// <summary>
        /// The global file path textbox.
        /// </summary>
        private TextBox linkedFilePath;

        /// <summary>
        /// Location label.
        /// </summary>
        private Label locationLabel;

        /// <summary>
        /// Determines whether to merge with a linked settings file.
        /// </summary>
        private RadioButton mergeWithLinkedFile;

        /// <summary>
        /// Determines whether to merge with parent settings files.
        /// </summary>
        private RadioButton mergeWithParents;

        /// <summary>
        /// Determines whether not to merge the settings.
        /// </summary>
        private RadioButton noMerge;

        /// <summary>
        /// The table layout panel 1.
        /// </summary>
        private TableLayoutPanel tableLayoutPanel1;

        /// <summary>
        /// The tab control hosting this page.
        /// </summary>
        private PropertyControl tabControl;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the GlobalSettingsFileOptions class.
        /// </summary>
        public GlobalSettingsFileOptions()
        {
            this.InitializeComponent();
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
                return Strings.SettingsFilesTab;
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
            // Save the path to the linked settings file if necessary.
            if (this.mergeWithLinkedFile.Checked)
            {
                bool valid = false;

                // Validate the contents of the global file path textbox.
                try
                {
                    // Make sure the file exists.
                    if (File.Exists(this.linkedFilePath.Text))
                    {
                        // Make sure the file can be loaded and contains valid Xml.
                        XmlDocument document = new XmlDocument();
                        document.Load(this.linkedFilePath.Text);

                        // Make sure the file contains the correct type of root node.
                        if (document.DocumentElement.Name == "StyleCopSettings" || document.DocumentElement.Name == "SourceAnalysisSettings")
                        {
                            valid = true;
                        }
                    }
                }
                catch (ArgumentException)
                {
                }
                catch (SecurityException)
                {
                }
                catch (UnauthorizedAccessException)
                {
                }
                catch (IOException)
                {
                }
                catch (XmlException)
                {
                }

                if (valid)
                {
                    string relativePath = this.linkedFilePath.Text;
                    if (!relativePath.StartsWith(".", StringComparison.Ordinal))
                    {
                        // Create a URI pointing to the local project folder.
                        string localFolderPath = Path.GetDirectoryName(this.tabControl.LocalSettings.Location);
                        if (!localFolderPath.EndsWith("\\", StringComparison.Ordinal))
                        {
                            localFolderPath += "\\";
                        }

                        Uri uri = new Uri(localFolderPath);

                        // Create the relative path to the global file folder.
                        Uri relative = uri.MakeRelativeUri(new Uri(this.linkedFilePath.Text));
                        relativePath = ConvertBackslashes(relative.OriginalString);
                    }

                    this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                        new StringProperty(this.tabControl.Core, SettingsMerger.LinkedSettingsProperty, relativePath));
                    this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                        new StringProperty(this.tabControl.Core, SettingsMerger.MergeSettingsFilesProperty, SettingsMerger.MergeStyleLinked));
                }
                else
                {
                    AlertDialog.Show(this.tabControl.Core, this, Strings.NoLinkedSettingsFile, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return false;
                }
            }
            else
            {
                this.tabControl.LocalSettings.GlobalSettings.SetProperty(
                    new StringProperty(
                        this.tabControl.Core, 
                        SettingsMerger.MergeSettingsFilesProperty, 
                        this.noMerge.Checked ? SettingsMerger.MergeStyleNone : SettingsMerger.MergeStyleParent));
                this.tabControl.LocalSettings.GlobalSettings.Remove(SettingsMerger.LinkedSettingsProperty);
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

            // Get the merge style setting.
            StringProperty mergeTypeProperty = this.tabControl.LocalSettings.GlobalSettings.GetProperty(SettingsMerger.MergeSettingsFilesProperty) as StringProperty;
            string mergeType = mergeTypeProperty == null ? SettingsMerger.MergeStyleParent : mergeTypeProperty.Value;

            // If the merge style is set to link but the current environment doesn't support linking, change it to parent.
            if (!this.tabControl.Core.Environment.SupportsLinkedSettings && string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleLinked) == 0)
            {
                mergeType = SettingsMerger.MergeStyleParent;
                this.disableLinking = true;
            }

            if (string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleNone) == 0)
            {
                this.noMerge.Checked = true;
            }
            else if (string.CompareOrdinal(mergeType, SettingsMerger.MergeStyleLinked) == 0)
            {
                this.mergeWithLinkedFile.Checked = true;

                StringProperty linkedSettingsFileProperty =
                    this.tabControl.LocalSettings.GlobalSettings.GetProperty(SettingsMerger.LinkedSettingsProperty) as StringProperty;
                if (linkedSettingsFileProperty != null && !string.IsNullOrEmpty(linkedSettingsFileProperty.Value))
                {
                    // This mode assumes that StyleCop is running in a file-based environment.
                    string linkedSettingsFile = Environment.ExpandEnvironmentVariables(linkedSettingsFileProperty.Value);

                    if (linkedSettingsFile.StartsWith(".", StringComparison.Ordinal))
                    {
                        linkedSettingsFile = Utils.MakeAbsolutePath(Path.GetDirectoryName(this.tabControl.LocalSettings.Location), linkedSettingsFile);
                    }

                    this.linkedFilePath.Text = linkedSettingsFile;
                }
            }
            else
            {
                this.mergeWithParents.Checked = true;
            }

            this.EnableDisable();

            bool defaultSettings = this.tabControl.LocalSettings.DefaultSettings;

            // Disable the parent link controls if this is the default settings file.
            if (defaultSettings)
            {
                this.mergeWithParents.Enabled = false;
                this.editParentSettingsFile.Enabled = false;
                this.mergeWithLinkedFile.Enabled = false;
                this.locationLabel.Enabled = false;
                this.linkedFilePath.Enabled = false;
                this.browse.Enabled = false;
                this.editLinkedSettingsFile.Enabled = false;
            }

            if (!this.noMerge.Checked && defaultSettings)
            {
                this.noMerge.Checked = true;
            }

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

            if (wasDirty)
            {
                this.tabControl.RefreshMergedSettings();
            }
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
            // The page does not show any merged settings, so there is nothing to do.
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
        /// Converts forward slashes to backslashes in a path string.
        /// </summary>
        /// <param name="path">
        /// The path to convert.
        /// </param>
        /// <returns>
        /// Returns the converted string.
        /// </returns>
        private static string ConvertBackslashes(string path)
        {
            Param.AssertNotNull(path, "path");

            char[] newPath = new char[path.Length];
            for (int i = 0; i < path.Length; ++i)
            {
                char character = path[i];
                if (character == '/')
                {
                    newPath[i] = '\\';
                }
                else
                {
                    newPath[i] = character;
                }
            }

            return new string(newPath);
        }

        /// <summary>
        /// Called when the browse button is clicked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void BrowseClick(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.AddExtension = true;
                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.CreatePrompt = false;
                dialog.DefaultExt = "StyleCop";
                dialog.FileName = this.linkedFilePath.Text.Length == 0 ? Settings.DefaultFileName : this.linkedFilePath.Text;
                dialog.Filter = string.Format(CultureInfo.CurrentUICulture, Strings.SettingsFileMatchPaths, Strings.SettingsFiles, Strings.AllFiles);
                dialog.InitialDirectory = this.linkedFilePath.Text;
                dialog.OverwritePrompt = false;
                dialog.ShowHelp = false;
                dialog.Title = Strings.GlobalSettingsFile;
                dialog.ValidateNames = true;

                DialogResult result = dialog.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.linkedFilePath.Text = dialog.FileName;
                }
            }
        }

        /// <summary>
        /// Called when the edit linked settings file button is clicked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void EditLinkedSettingsFileClicked(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (string.IsNullOrEmpty(this.linkedFilePath.Text))
            {
                AlertDialog.Show(this.tabControl.Core, this, Strings.EmptySettingsFilePath, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                string expandedPath = Environment.ExpandEnvironmentVariables(this.linkedFilePath.Text);

                if (expandedPath.StartsWith(".", StringComparison.Ordinal) || !expandedPath.Contains("\\"))
                {
                    expandedPath = Utils.MakeAbsolutePath(Path.GetDirectoryName(this.tabControl.LocalSettings.Location), expandedPath);
                }

                // Check if there is a file at the given path. Create the settings file if needed.
                if (!File.Exists(expandedPath))
                {
                    // Create a new settings file at the given path.
                    Exception exception;

                    Settings createdSettingsFile = this.tabControl.Core.Environment.GetWritableSettings(expandedPath, out exception);
                    if (createdSettingsFile == null)
                    {
                        AlertDialog.Show(
                            this.tabControl.Core, 
                            this, 
                            string.Format(CultureInfo.CurrentUICulture, Strings.CannotLoadSettingsFilePath, exception == null ? string.Empty : exception.Message), 
                            Strings.Title, 
                            MessageBoxButtons.OK, 
                            MessageBoxIcon.Error);

                        expandedPath = null;
                    }
                }

                if (!string.IsNullOrEmpty(expandedPath))
                {
                    this.EditParentSettings(expandedPath);
                }
            }
        }

        /// <summary>
        /// Confirms and edits a parent settings file.
        /// </summary>
        /// <param name="settingsFile">
        /// The path to the parent settings.
        /// </param>
        private void EditParentSettings(string settingsFile)
        {
            Param.AssertValidString(settingsFile, "settingsFile");

            this.tabControl.Core.ShowSettings(settingsFile, StyleCopCore.ProjectSettingsPropertyPageIdProperty);
            this.tabControl.RefreshMergedSettings();
        }

        /// <summary>
        /// Called when the edit parent settings file button is clicked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void EditParentSettingsFileClicked(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            // Find the parent settings file.
            bool defaultSettings = false;
            string settingsPath = this.tabControl.Core.Environment.GetParentSettingsPath(this.tabControl.LocalSettings.Location);
            if (string.IsNullOrEmpty(settingsPath))
            {
                defaultSettings = true;
                settingsPath = this.tabControl.Core.Environment.GetDefaultSettingsPath();
            }

            if (string.IsNullOrEmpty(settingsPath))
            {
                AlertDialog.Show(this.tabControl.Core, this, Strings.NoParentSettingsFile, Strings.Title, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                if (defaultSettings)
                {
                    if (DialogResult.No
                        == AlertDialog.Show(
                            this.tabControl.Core, this, Strings.EditDefaultSettingsWarning, Strings.Title, MessageBoxButtons.YesNo, MessageBoxIcon.Warning))
                    {
                        return;
                    }
                }

                this.EditParentSettings(settingsPath);
            }
        }

        /// <summary>
        /// Enables or disables the file controls.
        /// </summary>
        private void EnableDisable()
        {
            this.locationLabel.Enabled = this.mergeWithLinkedFile.Checked;
            this.linkedFilePath.Enabled = this.mergeWithLinkedFile.Checked && !this.disableLinking;
            this.browse.Enabled = this.mergeWithLinkedFile.Checked && !this.disableLinking;
            this.editLinkedSettingsFile.Enabled = this.mergeWithLinkedFile.Checked && this.linkedFilePath.Text.Length > 0 && !this.disableLinking;
            this.editParentSettingsFile.Enabled = this.mergeWithParents.Checked;

            // If linking is diabled, hide the controls which are related to linking.
            this.linkedFilePath.Visible = !this.disableLinking;
            this.browse.Visible = !this.disableLinking;
            this.editLinkedSettingsFile.Visible = !this.disableLinking;
        }

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(GlobalSettingsFileOptions));
            this.browse = new Button();
            this.linkedFilePath = new TextBox();
            this.locationLabel = new Label();
            this.editLinkedSettingsFile = new Button();
            this.mergeWithParents = new RadioButton();
            this.noMerge = new RadioButton();
            this.mergeWithLinkedFile = new RadioButton();
            this.label1 = new Label();
            this.editParentSettingsFile = new Button();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();

            // browse
            resources.ApplyResources(this.browse, "browse");
            this.browse.Name = "browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += this.BrowseClick;

            // linkedFilePath
            resources.ApplyResources(this.linkedFilePath, "linkedFilePath");
            this.linkedFilePath.Name = "linkedFilePath";
            this.linkedFilePath.TextChanged += this.LinkedFilePathTextChanged;

            // locationLabel
            resources.ApplyResources(this.locationLabel, "locationLabel");
            this.locationLabel.Name = "locationLabel";

            // editLinkedSettingsFile
            resources.ApplyResources(this.editLinkedSettingsFile, "editLinkedSettingsFile");
            this.editLinkedSettingsFile.Name = "editLinkedSettingsFile";
            this.editLinkedSettingsFile.UseVisualStyleBackColor = true;
            this.editLinkedSettingsFile.Click += this.EditLinkedSettingsFileClicked;

            // mergeWithParents
            resources.ApplyResources(this.mergeWithParents, "mergeWithParents");
            this.tableLayoutPanel1.SetColumnSpan(this.mergeWithParents, 3);
            this.mergeWithParents.Name = "mergeWithParents";
            this.mergeWithParents.TabStop = true;
            this.mergeWithParents.UseVisualStyleBackColor = true;
            this.mergeWithParents.CheckedChanged += this.MergeWithParentsCheckedChanged;

            // noMerge
            resources.ApplyResources(this.noMerge, "noMerge");
            this.tableLayoutPanel1.SetColumnSpan(this.noMerge, 4);
            this.noMerge.Name = "noMerge";
            this.noMerge.TabStop = true;
            this.noMerge.UseVisualStyleBackColor = true;
            this.noMerge.CheckedChanged += this.NoMergeCheckedChanged;

            // mergeWithLinkedFile
            resources.ApplyResources(this.mergeWithLinkedFile, "mergeWithLinkedFile");
            this.tableLayoutPanel1.SetColumnSpan(this.mergeWithLinkedFile, 4);
            this.mergeWithLinkedFile.Name = "mergeWithLinkedFile";
            this.mergeWithLinkedFile.TabStop = true;
            this.mergeWithLinkedFile.UseVisualStyleBackColor = true;
            this.mergeWithLinkedFile.CheckedChanged += this.MergeWithLinkedFileCheckedChanged;

            // label1
            resources.ApplyResources(this.label1, "label1");
            this.tableLayoutPanel1.SetColumnSpan(this.label1, 4);
            this.label1.Name = "label1";

            // editParentSettingsFile
            resources.ApplyResources(this.editParentSettingsFile, "editParentSettingsFile");
            this.editParentSettingsFile.Name = "editParentSettingsFile";
            this.editParentSettingsFile.UseVisualStyleBackColor = true;
            this.editParentSettingsFile.Click += this.EditParentSettingsFileClicked;

            // tableLayoutPanel1
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.editLinkedSettingsFile, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.mergeWithLinkedFile, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.browse, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.editParentSettingsFile, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.linkedFilePath, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.noMerge, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.locationLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.mergeWithParents, 0, 2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";

            // GlobalSettingsFileOptions
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new Size(246, 80);
            this.Name = "GlobalSettingsFileOptions";
            resources.ApplyResources(this, "$this");
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        /// <summary>
        /// Called when the text in the global file path textbox changes.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void LinkedFilePathTextChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }

            this.editLinkedSettingsFile.Enabled = this.mergeWithLinkedFile.Checked && this.linkedFilePath.Text.Length > 0;
        }

        /// <summary>
        /// Called when the 'mergeWithLinkedFile' radio button is checked or unchecked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void MergeWithLinkedFileCheckedChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            this.EnableDisable();

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }
        }

        /// <summary>
        /// Called when the 'mergeWithParents' radio button is checked or unchecked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void MergeWithParentsCheckedChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            this.EnableDisable();

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }
        }

        /// <summary>
        /// Called when the 'noMerge' radio button is checked or unchecked.
        /// </summary>
        /// <param name="sender">
        /// The event sender.
        /// </param>
        /// <param name="e">
        /// The event arguments.
        /// </param>
        private void NoMergeCheckedChanged(object sender, EventArgs e)
        {
            Param.Ignore(sender, e);

            this.EnableDisable();

            if (!this.dirty)
            {
                this.dirty = true;
                this.tabControl.DirtyChanged();
            }
        }

        #endregion
    }
}