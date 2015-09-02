// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopOptionsPage.cs" company="http://stylecop.codeplex.com">
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
//   Defines the StyleCopOptionsPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Options
{
    #region Using Directives

    using System;
    using System.Globalization;
    using System.IO;
    using System.Windows.Forms;

    using JetBrains.Application.Settings;
    using JetBrains.UI.CrossFramework;
    using JetBrains.UI.Options;

    #endregion

    /// <summary>
    /// Options page to allow the plugins options to be set from within the ReSharper Options window.
    /// </summary>
    [OptionsPage(StyleCopOptionsPage.PID, "StyleCop", (Type)null, ParentId = "Tools")]
    public partial class StyleCopOptionsPage : UserControl, IOptionsPage
    {
        #region Constants

        /// <summary>
        /// The unique name of this options page.
        /// </summary>
        private const string PID = "StyleCopOptionsPage";

        #endregion

        #region Static Fields

        /// <summary>
        /// The detected StyleCop path.
        /// </summary>
        private static string styleCopDetectedPath;

        #endregion

        #region Fields

        /// <summary>
        /// Reference to the IOptionsDialog that opened our page.
        /// </summary>
        private readonly IOptionsDialog dialog;

        /// <summary>
        /// The settings context to use.
        /// </summary>
        private readonly OptionsSettingsSmartContext smartContext;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the StyleCopOptionsPage class.
        /// </summary>
        /// <param name="settingsSmartContext">
        /// Our settings context. 
        /// </param>
        public StyleCopOptionsPage(OptionsSettingsSmartContext settingsSmartContext)
        {
            this.smartContext = settingsSmartContext;
            this.InitializeComponent();
            this.dashesCountMaskedTextBox.ValidatingType = typeof(int);
            this.warningPanel.Visible = !CodeStyleOptions.CodeStyleOptionsValid(settingsSmartContext);
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the Control to be shown as page.
        /// </summary>
        /// <value>
        /// </value>
        public EitherControl Control
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets the ID of this option page. <see cref="T:JetBrains.UI.Options.IOptionsDialog"/> or <see cref="T:JetBrains.UI.Options.OptionsPageDescriptor"/> could be used to retrieve the <see cref="T:JetBrains.UI.Options.OptionsManager"/> out of it.
        /// </summary>
        /// <value>
        /// </value>
        public string Id
        {
            get
            {
                return StyleCopOptionsPage.PID;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Invoked when OK button in the options dialog is pressed If the page returns <c>False.</c> , the the options dialog won't be closed, and focus will be put into this page.
        /// </summary>
        /// <returns>
        /// Returns a boolean to represent if the page should be closed. 
        /// </returns>
        public bool OnOk()
        {
            if (this.ValidatePage())
            {
                string newLocation = string.Empty;
                string oldLocation = this.smartContext.GetValue<StyleCopOptionsSettingsKey, string>(key => key.SpecifiedAssemblyPath);

                if (!this.autoDetectCheckBox.Checked)
                {
                    newLocation = this.StyleCopLocationTextBox.Text.Trim();
                }

                if (newLocation != oldLocation)
                {
                    MessageBox.Show(
                        "These changes may require you to restart Visual Studio before they take effect.", "StyleCop", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.smartContext.SetValue<StyleCopOptionsSettingsKey, string>(key => key.SpecifiedAssemblyPath, newLocation);
                }

                this.smartContext.SetValue<StyleCopOptionsSettingsKey, int>(key => key.ParsingPerformance, this.performanceTrackBar.Value);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.InsertTextIntoDocumentation, this.insertTextCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, int>(key => key.DashesCountInFileHeader, int.Parse(this.dashesCountMaskedTextBox.Text));
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.UseExcludeFromStyleCopSetting, this.useExcludeFromStyleCopCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, string>(
                    key => key.SuppressStyleCopAttributeJustificationText, this.justificationTextBox.Text.Trim());
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(
                    key => key.UseSingleLineDeclarationComments, this.useSingleLineForDeclarationCommentsCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalysisEnabled, this.enableAnalysisCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(
                    key => key.CheckReSharperCodeStyleOptionsAtStartUp, this.checkCodeStyleOptionsAtStartUpCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalyzeReadOnlyFiles, this.analyzeReadOnlyFilesCheckBox.Checked);
                this.smartContext.SetValue<StyleCopOptionsSettingsKey, bool>(key => key.InsertToDoText, this.insertToDoTextCheckBox.Checked);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the settings on the page are consistent, and page could be closed.
        /// </summary>
        /// <returns>
        /// <c>True.</c> if page data is consistent. 
        /// </returns>
        public bool ValidatePage()
        {
            if (!this.dashesCountMaskedTextBox.MaskCompleted || this.dashesCountMaskedTextBox.Text == string.Empty)
            {
                this.toolTip.ToolTipTitle = "Invalid number";
                this.toolTip.Show("Enter a valid number.", this.dashesCountMaskedTextBox, this.dashesCountMaskedTextBox.Width - 16, -50, 5000);
                return false;
            }

            return true;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.UserControl.Load"/> event.
        /// </summary>
        /// <param name="e">
        /// An <see cref="T:System.EventArgs"/> that contains the event data. 
        /// </param>
        protected override void OnLoad(EventArgs e)
        {
            this.toolTip.SetToolTip(this.dashesCountMaskedTextBox, string.Empty);
            base.OnLoad(e);
            this.Display();
        }

        private void Display()
        {
            this.autoDetectCheckBox.Checked = string.IsNullOrEmpty(this.smartContext.GetValue<StyleCopOptionsSettingsKey, string>(key => key.SpecifiedAssemblyPath));

            if (this.autoDetectCheckBox.Checked)
            {
            }
            else
            {
                this.ShowSpecifiedAssemblyLocation();
            }

            this.performanceTrackBar.Value = this.smartContext.GetValue<StyleCopOptionsSettingsKey, int>(key => key.ParsingPerformance);
            this.insertTextCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.InsertTextIntoDocumentation);
            this.dashesCountMaskedTextBox.Text =
                this.smartContext.GetValue<StyleCopOptionsSettingsKey, int>(key => key.DashesCountInFileHeader).ToString(CultureInfo.InvariantCulture);
            this.useExcludeFromStyleCopCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.UseExcludeFromStyleCopSetting);
            this.justificationTextBox.Text = this.smartContext.GetValue<StyleCopOptionsSettingsKey, string>(key => key.SuppressStyleCopAttributeJustificationText);
            this.useSingleLineForDeclarationCommentsCheckBox.Checked =
                this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.UseSingleLineDeclarationComments);
            this.enableAnalysisCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalysisEnabled);
            this.checkCodeStyleOptionsAtStartUpCheckBox.Checked =
                this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.CheckReSharperCodeStyleOptionsAtStartUp);
            this.analyzeReadOnlyFilesCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.AnalyzeReadOnlyFiles);
            this.insertToDoTextCheckBox.Checked = this.smartContext.GetValue<StyleCopOptionsSettingsKey, bool>(key => key.InsertToDoText);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the AutoDetectCheckBox control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event. 
        /// </param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data. 
        /// </param>
        private void AutoDetectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (this.autoDetectCheckBox.Checked)
            {
            }
            else
            {
                this.ShowSpecifiedAssemblyLocation();
            }
        }

        /// <summary>
        /// Handles the Click event of the BrowseButton control.
        /// </summary>
        /// <param name="sender">
        /// The source of the event. 
        /// </param>
        /// <param name="e">
        /// The <see cref="System.EventArgs"/> instance containing the event data. 
        /// </param>
        private void BrowseButton_Click(object sender, EventArgs e)
        {
            this.ShowFileDialog();
        }

        private void DashesCountMaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.toolTip.Hide(this.dashesCountMaskedTextBox);
        }

        private void ResetFormatOptionsButton_Click(object sender, EventArgs e)
        {
            CodeStyleOptions.CodeStyleOptionsReset(this.smartContext);
            MessageBox.Show(
                @"C# code style options have been set in order to fix StyleCop violations. Ensure your R# Settings are saved.", @"StyleCop", MessageBoxButtons.OK);
            this.resetFormatOptionsButton.Enabled = false;
        }

        /// <summary>
        /// Shows the file dialog.
        /// </summary>
        private void ShowFileDialog()
        {
            if (!string.IsNullOrEmpty(this.StyleCopLocationTextBox.Text))
            {
                string dir = Path.GetDirectoryName(this.StyleCopLocationTextBox.Text);

                if (!string.IsNullOrEmpty(dir))
                {
                    this.StyleCopLocationDialog.InitialDirectory = dir;
                }
            }

            if (this.StyleCopLocationDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            this.StyleCopLocationTextBox.Text = this.StyleCopLocationDialog.FileName;
        }

        /// <summary>
        /// Shows the specified assembly location.
        /// </summary>
        private void ShowSpecifiedAssemblyLocation()
        {
            this.StyleCopLocationTextBox.Text = this.smartContext.GetValue<StyleCopOptionsSettingsKey, string>(key => key.SpecifiedAssemblyPath);
            this.BrowseButton.Enabled = true;
            this.StyleCopLocationTextBox.Enabled = true;
        }

        #endregion
    }
}