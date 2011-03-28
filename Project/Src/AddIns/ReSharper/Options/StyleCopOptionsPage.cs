// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopOptionsPage.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <summary>
//   Defines the StyleCopOptionsPage type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.Options
{
    #region Using Directives

    using System;
    using System.IO;
    using System.Windows.Forms;

    using JetBrains.UI.Options;

    using StyleCop.ReSharper.Core;

    #endregion

    /// <summary>
    /// Options page to allow the plugins options to be set from within the Resharper Options window.
    /// </summary>
    [OptionsPage(NAME, "StyleCop", "StyleCop.ReSharper.Resources.StyleCop.png", ParentId = "Tools")]
    public partial class StyleCopOptionsPage : UserControl, IOptionsPage
    {
        #region Constants and Fields

        /// <summary>
        /// The unique name of this options page.
        /// </summary>
        public const string NAME = "StyleCop.StyleCopOptionsPage";

        /// <summary>
        /// The instance of this options page.
        /// </summary>
        private static StyleCopOptionsPage instance;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="StyleCopOptionsPage"/> class.
        /// </summary>
        public StyleCopOptionsPage()
        {
            this.InitializeComponent();
            instance = this;
            this.daysMaskedTextBox.ValidatingType = typeof(int);
            this.dashesCountMaskedTextBox.ValidatingType = typeof(int);
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static StyleCopOptionsPage Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Gets the Control to be shown as page.
        /// </summary>
        /// <value>
        /// </value>
        public Control Control
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets the ID of this option page.
        /// <see cref="T:JetBrains.UI.Options.IOptionsDialog"/>or <see cref="T:JetBrains.UI.Options.OptionsPageDescriptor"/> could be used to retrieve the <see cref="T:JetBrains.UI.Options.OptionsManager"/> out of it.
        /// </summary>
        /// <value>
        /// </value>
        public string Id
        {
            get
            {
                return NAME;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Commits this instance.
        /// </summary>
        public void Commit()
        {
            string newLocation = null;
            var oldLocation = StyleCopOptions.Instance.SpecifiedAssemblyPath;

            if (!this.autoDetectCheckBox.Checked)
            {
                newLocation = this.StyleCopLocationTextBox.Text;
            }

            if (newLocation != oldLocation)
            {
                MessageBox.Show("These changes will require you to restart Visual Studio before they will take effect.", "StyleCop For ReSharper.", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                StyleCopOptions.Instance.SpecifiedAssemblyPath = newLocation;
            }

            StyleCopOptions.Instance.ParsingPerformance = this.performanceTrackBar.Value;

            StyleCopOptions.Instance.InsertTextIntoDocumentation = this.insertTextCheckBox.Checked;

            StyleCopOptions.Instance.AutomaticallyCheckForUpdates = this.autoUpdateCheckBox.Checked;

            StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts = this.everyTimeRadioButton.Checked;

            if (this.autoUpdateCheckBox.Checked && !this.everyTimeRadioButton.Checked)
            {
                StyleCopOptions.Instance.DaysBetweenUpdateChecks = int.Parse(this.daysMaskedTextBox.Text);
            }

            StyleCopOptions.Instance.DashesCountInFileHeader = int.Parse(this.dashesCountMaskedTextBox.Text);

            StyleCopOptions.Instance.UseExcludeFromStyleCopSetting = this.useExcludeFromStyleCopCheckBox.Checked;

            StyleCopOptions.Instance.SuppressStyleCopAttributeJustificationText = this.justificationTextBox.Text.Trim();

            StyleCopOptions.Instance.UseSingleLineDeclarationComments = this.useSingleLineForDeclarationCommentsCheckBox.Checked;
        }

        /// <summary>
        /// Displays this instance.
        /// </summary>
        public void Display()
        {
            this.autoDetectCheckBox.Checked = string.IsNullOrEmpty(StyleCopOptions.Instance.SpecifiedAssemblyPath);

            if (this.autoDetectCheckBox.Checked)
            {
                this.ShowDetectedAssemblyLocation();
            }
            else
            {
                this.ShowSpecifiedAssemblyLocation();
            }

            this.performanceTrackBar.Value = StyleCopOptions.Instance.ParsingPerformance;
            this.insertTextCheckBox.Checked = StyleCopOptions.Instance.InsertTextIntoDocumentation;
            this.autoUpdateCheckBox.Checked = StyleCopOptions.Instance.AutomaticallyCheckForUpdates;

            this.everyTimeRadioButton.Checked = StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts;
            this.frequencyCheckRadioButton.Checked = !StyleCopOptions.Instance.AlwaysCheckForUpdatesWhenVisualStudioStarts;
            this.daysMaskedTextBox.Text = StyleCopOptions.Instance.DaysBetweenUpdateChecks.ToString();
            this.dashesCountMaskedTextBox.Text = StyleCopOptions.Instance.DashesCountInFileHeader.ToString();
            this.daysMaskedTextBox.Enabled = !this.everyTimeRadioButton.Checked;

            this.useExcludeFromStyleCopCheckBox.Checked = StyleCopOptions.Instance.UseExcludeFromStyleCopSetting;
            this.justificationTextBox.Text = StyleCopOptions.Instance.SuppressStyleCopAttributeJustificationText;

            this.useSingleLineForDeclarationCommentsCheckBox.Checked = StyleCopOptions.Instance.UseSingleLineDeclarationComments;
        }

        /// <summary>
        /// Invoked when this page is selected/unselected in the tree.
        /// </summary>
        /// <param name="activated">
        /// True, when page is selected; false, when page is unselected.
        /// </param>
        public void OnActivated(bool activated)
        {
        }

        #endregion

        #region Implemented Interfaces

        #region IOptionsPage

        /// <summary>
        /// Invoked when OK button in the options dialog is pressed
        /// If the page returns 
        /// <c>False.</c>, the the options dialog won't be closed, and focus
        /// will be put into this page.
        /// </summary>
        /// <returns>
        /// Returns a boolean to represent if the page should be closed.
        /// </returns>
        public bool OnOk()
        {
            if (this.ValidatePage())
            {
                this.Commit();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Check if the settings on the page are consistent, and page could be closed.
        /// </summary>
        /// <returns>
        /// <c>True.</c>if page data is consistent.
        /// </returns>
        public bool ValidatePage()
        {
            if (!this.autoDetectCheckBox.Checked)
            {
                if (!StyleCopReferenceHelper.LocationValid(this.StyleCopLocationTextBox.Text))
                {
                    var message = string.Format("Unable to find StyleCop assembly ({0}) at specified location.", StyleCopReferenceHelper.StyleCopAssemblyName);

                    MessageBox.Show(message, "StyleCop", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if (this.daysMaskedTextBox.Enabled && (!this.daysMaskedTextBox.MaskCompleted || this.daysMaskedTextBox.Text == string.Empty))
            {
                this.toolTip.ToolTipTitle = "Invalid number";
                this.toolTip.Show("Enter a valid number.", this.daysMaskedTextBox, this.daysMaskedTextBox.Width - 16, -50, 5000);
                return false;
            }

            if (!this.dashesCountMaskedTextBox.MaskCompleted || this.dashesCountMaskedTextBox.Text == string.Empty)
            {
                this.toolTip.ToolTipTitle = "Invalid number";
                this.toolTip.Show("Enter a valid number.", this.dashesCountMaskedTextBox, this.dashesCountMaskedTextBox.Width - 16, -50, 5000);
                return false;
            }

            return true;
        }

        #endregion

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
            this.toolTip.SetToolTip(this.daysMaskedTextBox, string.Empty);

            base.OnLoad(e);

            this.Display();
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
                this.ShowDetectedAssemblyLocation();
            }
            else
            {
                this.ShowSpecifiedAssemblyLocation();
            }
        }

        private void AutoUpdateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.everyTimeRadioButton.Enabled = this.autoUpdateCheckBox.Checked;
            this.frequencyCheckRadioButton.Enabled = this.autoUpdateCheckBox.Checked;
            this.daysMaskedTextBox.Enabled = this.autoUpdateCheckBox.Checked && !this.everyTimeRadioButton.Checked;
            this.daysLabel.Enabled = this.autoUpdateCheckBox.Checked;
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

        private void DaysMaskedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            this.toolTip.Hide(this.daysMaskedTextBox);
        }

        private void EveryTimeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.daysMaskedTextBox.Enabled = !this.everyTimeRadioButton.Checked;
            this.toolTip.Hide(this.daysMaskedTextBox);
        }

        /// <summary>
        /// Shows the detected assembly location.
        /// </summary>
        private void ShowDetectedAssemblyLocation()
        {
            var location = StyleCopOptions.Instance.DetectStyleCopPath();

            if (string.IsNullOrEmpty(location))
            {
                this.StyleCopLocationTextBox.Text = "Failed to detect location.";
            }
            else
            {
                this.StyleCopLocationTextBox.Text = location;
            }

            this.BrowseButton.Enabled = false;
            this.StyleCopLocationTextBox.Enabled = false;
        }

        /// <summary>
        /// Shows the file dialog.
        /// </summary>
        private void ShowFileDialog()
        {
            if (!string.IsNullOrEmpty(this.StyleCopLocationTextBox.Text))
            {
                var dir = Path.GetDirectoryName(this.StyleCopLocationTextBox.Text);

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
            var location = StyleCopOptions.Instance.SpecifiedAssemblyPath;
            this.StyleCopLocationTextBox.Text = location;
            this.BrowseButton.Enabled = true;
            this.StyleCopLocationTextBox.Enabled = true;
        }

        #endregion
    }
}