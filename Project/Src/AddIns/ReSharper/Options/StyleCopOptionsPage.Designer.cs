//-----------------------------------------------------------------------
// <copyright file="">
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

namespace StyleCop.ReSharper.Options
{
    partial class StyleCopOptionsPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.autoDetectCheckBox = new System.Windows.Forms.CheckBox();
            this.StyleCopLocationTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StyleCopLocationDialog = new System.Windows.Forms.OpenFileDialog();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.performanceTrackBar = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.performanceGroupBox = new System.Windows.Forms.GroupBox();
            this.assemblyLocationGroupBox = new System.Windows.Forms.GroupBox();
            this.insertTextCheckBox = new System.Windows.Forms.CheckBox();
            this.autoUpdateCheckBox = new System.Windows.Forms.CheckBox();
            this.daysLabel = new System.Windows.Forms.Label();
            this.everyTimeRadioButton = new System.Windows.Forms.RadioButton();
            this.frequencyCheckRadioButton = new System.Windows.Forms.RadioButton();
            this.autoUpdatesGroupBox = new System.Windows.Forms.GroupBox();
            this.daysMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.numberOfDashesLabel = new System.Windows.Forms.Label();
            this.dashesCountMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.useExcludeFromStyleCopCheckBox = new System.Windows.Forms.CheckBox();
            this.justificationLlabel = new System.Windows.Forms.Label();
            this.justificationTextBox = new System.Windows.Forms.TextBox();
            this.useSingleLineForDeclarationCommentsCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.performanceTrackBar)).BeginInit();
            this.performanceGroupBox.SuspendLayout();
            this.assemblyLocationGroupBox.SuspendLayout();
            this.autoUpdatesGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoDetectCheckBox
            // 
            this.autoDetectCheckBox.AutoSize = true;
            this.autoDetectCheckBox.Location = new System.Drawing.Point(20, 111);
            this.autoDetectCheckBox.Name = "autoDetectCheckBox";
            this.autoDetectCheckBox.Size = new System.Drawing.Size(175, 17);
            this.autoDetectCheckBox.TabIndex = 1;
            this.autoDetectCheckBox.Text = "Automatically detect location";
            this.autoDetectCheckBox.UseVisualStyleBackColor = true;
            this.autoDetectCheckBox.CheckedChanged += new System.EventHandler(this.AutoDetectCheckBox_CheckedChanged);
            // 
            // StyleCopLocationTextBox
            // 
            this.StyleCopLocationTextBox.Location = new System.Drawing.Point(18, 152);
            this.StyleCopLocationTextBox.Name = "StyleCopLocationTextBox";
            this.StyleCopLocationTextBox.Size = new System.Drawing.Size(275, 22);
            this.StyleCopLocationTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "StyleCop Assembly Location";
            // 
            // StyleCopLocationDialog
            // 
            this.StyleCopLocationDialog.DefaultExt = "dll";
            this.StyleCopLocationDialog.FileName = "Microsoft.StyleCop.dll";
            this.StyleCopLocationDialog.Filter = "StyleCop Assembly|Microsoft.StyleCop.dll";
            this.StyleCopLocationDialog.Title = "StyleCop Location";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(211, 91);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // performanceTrackBar
            // 
            this.performanceTrackBar.Location = new System.Drawing.Point(81, 28);
            this.performanceTrackBar.Maximum = 9;
            this.performanceTrackBar.Name = "performanceTrackBar";
            this.performanceTrackBar.Size = new System.Drawing.Size(147, 42);
            this.performanceTrackBar.TabIndex = 0;
            this.performanceTrackBar.Value = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "Less\r\nResources\r\n(Delay)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(227, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "More\r\nResources\r\n(Real Time)";
            // 
            // performanceGroupBox
            // 
            this.performanceGroupBox.Controls.Add(this.label2);
            this.performanceGroupBox.Controls.Add(this.label3);
            this.performanceGroupBox.Location = new System.Drawing.Point(7, 3);
            this.performanceGroupBox.Name = "performanceGroupBox";
            this.performanceGroupBox.Size = new System.Drawing.Size(301, 77);
            this.performanceGroupBox.TabIndex = 7;
            this.performanceGroupBox.TabStop = false;
            this.performanceGroupBox.Text = "Performance";
            // 
            // assemblyLocationGroupBox
            // 
            this.assemblyLocationGroupBox.Controls.Add(this.BrowseButton);
            this.assemblyLocationGroupBox.Location = new System.Drawing.Point(7, 90);
            this.assemblyLocationGroupBox.Name = "assemblyLocationGroupBox";
            this.assemblyLocationGroupBox.Size = new System.Drawing.Size(301, 124);
            this.assemblyLocationGroupBox.TabIndex = 8;
            this.assemblyLocationGroupBox.TabStop = false;
            this.assemblyLocationGroupBox.Text = "StyleCop assembly location";
            // 
            // insertTextCheckBox
            // 
            this.insertTextCheckBox.AutoSize = true;
            this.insertTextCheckBox.Checked = true;
            this.insertTextCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.insertTextCheckBox.Location = new System.Drawing.Point(13, 18);
            this.insertTextCheckBox.Name = "insertTextCheckBox";
            this.insertTextCheckBox.Size = new System.Drawing.Size(269, 17);
            this.insertTextCheckBox.TabIndex = 8;
            this.insertTextCheckBox.Text = "Insert text into documentation and file headers";
            this.insertTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoUpdateCheckBox
            // 
            this.autoUpdateCheckBox.AutoSize = true;
            this.autoUpdateCheckBox.Checked = true;
            this.autoUpdateCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.autoUpdateCheckBox.Location = new System.Drawing.Point(13, 21);
            this.autoUpdateCheckBox.Name = "autoUpdateCheckBox";
            this.autoUpdateCheckBox.Size = new System.Drawing.Size(190, 17);
            this.autoUpdateCheckBox.TabIndex = 4;
            this.autoUpdateCheckBox.Text = "Automatically check for updates";
            this.autoUpdateCheckBox.UseVisualStyleBackColor = true;
            this.autoUpdateCheckBox.CheckedChanged += new System.EventHandler(this.AutoUpdateCheckBox_CheckedChanged);
            // 
            // daysLabel
            // 
            this.daysLabel.AutoSize = true;
            this.daysLabel.Location = new System.Drawing.Point(209, 69);
            this.daysLabel.Name = "daysLabel";
            this.daysLabel.Size = new System.Drawing.Size(36, 13);
            this.daysLabel.TabIndex = 13;
            this.daysLabel.Text = "day(s)";
            // 
            // everyTimeRadioButton
            // 
            this.everyTimeRadioButton.AutoSize = true;
            this.everyTimeRadioButton.Checked = true;
            this.everyTimeRadioButton.Location = new System.Drawing.Point(33, 44);
            this.everyTimeRadioButton.Name = "everyTimeRadioButton";
            this.everyTimeRadioButton.Size = new System.Drawing.Size(178, 17);
            this.everyTimeRadioButton.TabIndex = 5;
            this.everyTimeRadioButton.TabStop = true;
            this.everyTimeRadioButton.Text = "Every time Visual Studio starts";
            this.everyTimeRadioButton.UseVisualStyleBackColor = true;
            this.everyTimeRadioButton.CheckedChanged += new System.EventHandler(this.EveryTimeRadioButton_CheckedChanged);
            // 
            // frequencyCheckRadioButton
            // 
            this.frequencyCheckRadioButton.AutoSize = true;
            this.frequencyCheckRadioButton.Location = new System.Drawing.Point(33, 67);
            this.frequencyCheckRadioButton.Name = "frequencyCheckRadioButton";
            this.frequencyCheckRadioButton.Size = new System.Drawing.Size(148, 17);
            this.frequencyCheckRadioButton.TabIndex = 6;
            this.frequencyCheckRadioButton.Text = "Check for updates every";
            this.frequencyCheckRadioButton.UseVisualStyleBackColor = true;
            // 
            // autoUpdatesGroupBox
            // 
            this.autoUpdatesGroupBox.Controls.Add(this.daysMaskedTextBox);
            this.autoUpdatesGroupBox.Controls.Add(this.autoUpdateCheckBox);
            this.autoUpdatesGroupBox.Controls.Add(this.frequencyCheckRadioButton);
            this.autoUpdatesGroupBox.Controls.Add(this.everyTimeRadioButton);
            this.autoUpdatesGroupBox.Controls.Add(this.daysLabel);
            this.autoUpdatesGroupBox.Location = new System.Drawing.Point(7, 223);
            this.autoUpdatesGroupBox.Name = "autoUpdatesGroupBox";
            this.autoUpdatesGroupBox.Size = new System.Drawing.Size(301, 97);
            this.autoUpdatesGroupBox.TabIndex = 16;
            this.autoUpdatesGroupBox.TabStop = false;
            this.autoUpdatesGroupBox.Text = "Auto updates";
            // 
            // daysMaskedTextBox
            // 
            this.daysMaskedTextBox.AllowPromptAsInput = false;
            this.daysMaskedTextBox.CausesValidation = false;
            this.daysMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.daysMaskedTextBox.Location = new System.Drawing.Point(181, 66);
            this.daysMaskedTextBox.Mask = "999";
            this.daysMaskedTextBox.Name = "daysMaskedTextBox";
            this.daysMaskedTextBox.PromptChar = ' ';
            this.daysMaskedTextBox.RejectInputOnFirstFailure = true;
            this.daysMaskedTextBox.ResetOnPrompt = false;
            this.daysMaskedTextBox.ResetOnSpace = false;
            this.daysMaskedTextBox.Size = new System.Drawing.Size(26, 22);
            this.daysMaskedTextBox.TabIndex = 7;
            this.daysMaskedTextBox.Text = "2";
            this.daysMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.daysMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.daysMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DaysMaskedTextBox_KeyDown);
            // 
            // numberOfDashesLabel
            // 
            this.numberOfDashesLabel.AutoSize = true;
            this.numberOfDashesLabel.Location = new System.Drawing.Point(10, 70);
            this.numberOfDashesLabel.Name = "numberOfDashesLabel";
            this.numberOfDashesLabel.Size = new System.Drawing.Size(194, 13);
            this.numberOfDashesLabel.TabIndex = 17;
            this.numberOfDashesLabel.Text = "Number of dashes in file header text";
            // 
            // dashesCountMaskedTextBox
            // 
            this.dashesCountMaskedTextBox.AllowPromptAsInput = false;
            this.dashesCountMaskedTextBox.CausesValidation = false;
            this.dashesCountMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dashesCountMaskedTextBox.Location = new System.Drawing.Point(207, 67);
            this.dashesCountMaskedTextBox.Mask = "999";
            this.dashesCountMaskedTextBox.Name = "dashesCountMaskedTextBox";
            this.dashesCountMaskedTextBox.PromptChar = ' ';
            this.dashesCountMaskedTextBox.RejectInputOnFirstFailure = true;
            this.dashesCountMaskedTextBox.ResetOnPrompt = false;
            this.dashesCountMaskedTextBox.ResetOnSpace = false;
            this.dashesCountMaskedTextBox.Size = new System.Drawing.Size(30, 22);
            this.dashesCountMaskedTextBox.TabIndex = 9;
            this.dashesCountMaskedTextBox.Text = "116";
            this.dashesCountMaskedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.dashesCountMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.dashesCountMaskedTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DashesCountMaskedTextBox_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.useSingleLineForDeclarationCommentsCheckBox);
            this.groupBox1.Controls.Add(this.numberOfDashesLabel);
            this.groupBox1.Controls.Add(this.dashesCountMaskedTextBox);
            this.groupBox1.Controls.Add(this.insertTextCheckBox);
            this.groupBox1.Location = new System.Drawing.Point(7, 331);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 99);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Headers";
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // useExcludeFromStyleCopCheckBox
            // 
            this.useExcludeFromStyleCopCheckBox.AutoSize = true;
            this.useExcludeFromStyleCopCheckBox.Checked = true;
            this.useExcludeFromStyleCopCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.useExcludeFromStyleCopCheckBox.Location = new System.Drawing.Point(7, 438);
            this.useExcludeFromStyleCopCheckBox.Name = "useExcludeFromStyleCopCheckBox";
            this.useExcludeFromStyleCopCheckBox.Size = new System.Drawing.Size(268, 17);
            this.useExcludeFromStyleCopCheckBox.TabIndex = 20;
            this.useExcludeFromStyleCopCheckBox.Text = "Use ExcludeFromStyleCop setting in csproj files";
            this.useExcludeFromStyleCopCheckBox.UseVisualStyleBackColor = true;
            // 
            // justificationLlabel
            // 
            this.justificationLlabel.AutoSize = true;
            this.justificationLlabel.Location = new System.Drawing.Point(7, 467);
            this.justificationLlabel.Name = "justificationLlabel";
            this.justificationLlabel.Size = new System.Drawing.Size(228, 13);
            this.justificationLlabel.TabIndex = 22;
            this.justificationLlabel.Text = "Justification for SuppressStyleCopAttribute";
            // 
            // justificationTextBox
            // 
            this.justificationTextBox.Location = new System.Drawing.Point(18, 483);
            this.justificationTextBox.Name = "justificationTextBox";
            this.justificationTextBox.Size = new System.Drawing.Size(275, 22);
            this.justificationTextBox.TabIndex = 21;
            // 
            // useSingleLineForDeclarationCommentsCheckBox
            // 
            this.useSingleLineForDeclarationCommentsCheckBox.AutoSize = true;
            this.useSingleLineForDeclarationCommentsCheckBox.Location = new System.Drawing.Point(13, 43);
            this.useSingleLineForDeclarationCommentsCheckBox.Name = "useSingleLineForDeclarationCommentsCheckBox";
            this.useSingleLineForDeclarationCommentsCheckBox.Size = new System.Drawing.Size(229, 17);
            this.useSingleLineForDeclarationCommentsCheckBox.TabIndex = 14;
            this.useSingleLineForDeclarationCommentsCheckBox.Text = "Use single lines for declaration headers";
            this.useSingleLineForDeclarationCommentsCheckBox.UseVisualStyleBackColor = true;
            // 
            // StyleCopOptionsPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.justificationLlabel);
            this.Controls.Add(this.justificationTextBox);
            this.Controls.Add(this.useExcludeFromStyleCopCheckBox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.autoUpdatesGroupBox);
            this.Controls.Add(this.performanceTrackBar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StyleCopLocationTextBox);
            this.Controls.Add(this.autoDetectCheckBox);
            this.Controls.Add(this.performanceGroupBox);
            this.Controls.Add(this.assemblyLocationGroupBox);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StyleCopOptionsPage";
            this.Size = new System.Drawing.Size(322, 515);
            ((System.ComponentModel.ISupportInitialize)(this.performanceTrackBar)).EndInit();
            this.performanceGroupBox.ResumeLayout(false);
            this.performanceGroupBox.PerformLayout();
            this.assemblyLocationGroupBox.ResumeLayout(false);
            this.autoUpdatesGroupBox.ResumeLayout(false);
            this.autoUpdatesGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox autoDetectCheckBox;
        private System.Windows.Forms.TextBox StyleCopLocationTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog StyleCopLocationDialog;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TrackBar performanceTrackBar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox performanceGroupBox;
        private System.Windows.Forms.GroupBox assemblyLocationGroupBox;
        private System.Windows.Forms.CheckBox insertTextCheckBox;
        private System.Windows.Forms.CheckBox autoUpdateCheckBox;
        private System.Windows.Forms.Label daysLabel;
        private System.Windows.Forms.RadioButton everyTimeRadioButton;
        private System.Windows.Forms.RadioButton frequencyCheckRadioButton;
        private System.Windows.Forms.GroupBox autoUpdatesGroupBox;
        private System.Windows.Forms.MaskedTextBox daysMaskedTextBox;
        private System.Windows.Forms.Label numberOfDashesLabel;
        private System.Windows.Forms.MaskedTextBox dashesCountMaskedTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.CheckBox useExcludeFromStyleCopCheckBox;
        private System.Windows.Forms.Label justificationLlabel;
        private System.Windows.Forms.TextBox justificationTextBox;
        private System.Windows.Forms.CheckBox useSingleLineForDeclarationCommentsCheckBox;
    }
}