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

namespace StyleCop.ReSharper611.Options
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    using JetBrains.Application.Settings;
    using JetBrains.ReSharper.Psi;

    using StyleCop.ReSharper611.Core;

    partial class StyleCopOptionsPage
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
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
            this.insertTextCheckBox = new System.Windows.Forms.CheckBox();
            this.numberOfDashesLabel = new System.Windows.Forms.Label();
            this.dashesCountMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.useSingleLineForDeclarationCommentsCheckBox = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.useExcludeFromStyleCopCheckBox = new System.Windows.Forms.CheckBox();
            this.justificationLlabel = new System.Windows.Forms.Label();
            this.justificationTextBox = new System.Windows.Forms.TextBox();
            this.codeStyleWarningLabel = new System.Windows.Forms.Label();
            this.resetFormatOptionsButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.warningPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.enableAnalysisCheckBox = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.performanceTrackBar)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.warningPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // autoDetectCheckBox
            // 
            this.autoDetectCheckBox.AutoSize = true;
            this.autoDetectCheckBox.Location = new System.Drawing.Point(0, 23);
            this.autoDetectCheckBox.Name = "autoDetectCheckBox";
            this.autoDetectCheckBox.Size = new System.Drawing.Size(175, 17);
            this.autoDetectCheckBox.TabIndex = 1;
            this.autoDetectCheckBox.Text = "Automatically detect location";
            this.autoDetectCheckBox.UseVisualStyleBackColor = true;
            this.autoDetectCheckBox.CheckedChanged += new System.EventHandler(this.AutoDetectCheckBox_CheckedChanged);
            // 
            // StyleCopLocationTextBox
            // 
            this.StyleCopLocationTextBox.Location = new System.Drawing.Point(0, 69);
            this.StyleCopLocationTextBox.Name = "StyleCopLocationTextBox";
            this.StyleCopLocationTextBox.Size = new System.Drawing.Size(275, 22);
            this.StyleCopLocationTextBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "StyleCop Assembly Location";
            // 
            // StyleCopLocationDialog
            // 
            this.StyleCopLocationDialog.DefaultExt = "dll";
            this.StyleCopLocationDialog.FileName = "StyleCop.dll";
            this.StyleCopLocationDialog.Filter = "StyleCop Assembly|StyleCop.dll";
            this.StyleCopLocationDialog.Title = "StyleCop Location";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(281, 68);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(75, 23);
            this.BrowseButton.TabIndex = 3;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // performanceTrackBar
            // 
            this.performanceTrackBar.Location = new System.Drawing.Point(62, 46);
            this.performanceTrackBar.Maximum = 9;
            this.performanceTrackBar.Name = "performanceTrackBar";
            this.performanceTrackBar.Size = new System.Drawing.Size(147, 45);
            this.performanceTrackBar.TabIndex = 0;
            this.performanceTrackBar.Value = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(0, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 39);
            this.label2.TabIndex = 5;
            this.label2.Text = "Less\r\nResources\r\n(Delay)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(215, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 39);
            this.label3.TabIndex = 6;
            this.label3.Text = "More\r\nResources\r\n(Real Time)";
            // 
            // insertTextCheckBox
            // 
            this.insertTextCheckBox.AutoSize = true;
            this.insertTextCheckBox.Checked = true;
            this.insertTextCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.insertTextCheckBox.Location = new System.Drawing.Point(0, 23);
            this.insertTextCheckBox.Name = "insertTextCheckBox";
            this.insertTextCheckBox.Size = new System.Drawing.Size(269, 17);
            this.insertTextCheckBox.TabIndex = 8;
            this.insertTextCheckBox.Text = "Insert text into documentation and file headers";
            this.insertTextCheckBox.UseVisualStyleBackColor = true;
            // 
            // numberOfDashesLabel
            // 
            this.numberOfDashesLabel.AutoSize = true;
            this.numberOfDashesLabel.Location = new System.Drawing.Point(0, 3);
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
            this.dashesCountMaskedTextBox.Location = new System.Drawing.Point(200, 0);
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
            // useSingleLineForDeclarationCommentsCheckBox
            // 
            this.useSingleLineForDeclarationCommentsCheckBox.AutoSize = true;
            this.useSingleLineForDeclarationCommentsCheckBox.Location = new System.Drawing.Point(0, 76);
            this.useSingleLineForDeclarationCommentsCheckBox.Name = "useSingleLineForDeclarationCommentsCheckBox";
            this.useSingleLineForDeclarationCommentsCheckBox.Size = new System.Drawing.Size(229, 17);
            this.useSingleLineForDeclarationCommentsCheckBox.TabIndex = 14;
            this.useSingleLineForDeclarationCommentsCheckBox.Text = "Use single lines for declaration headers";
            this.useSingleLineForDeclarationCommentsCheckBox.UseVisualStyleBackColor = true;
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
            this.useExcludeFromStyleCopCheckBox.Location = new System.Drawing.Point(0, 23);
            this.useExcludeFromStyleCopCheckBox.Name = "useExcludeFromStyleCopCheckBox";
            this.useExcludeFromStyleCopCheckBox.Size = new System.Drawing.Size(268, 17);
            this.useExcludeFromStyleCopCheckBox.TabIndex = 20;
            this.useExcludeFromStyleCopCheckBox.Text = "Use ExcludeFromStyleCop setting in csproj files";
            this.useExcludeFromStyleCopCheckBox.UseVisualStyleBackColor = true;
            // 
            // justificationLlabel
            // 
            this.justificationLlabel.AutoSize = true;
            this.justificationLlabel.Location = new System.Drawing.Point(0, 46);
            this.justificationLlabel.Name = "justificationLlabel";
            this.justificationLlabel.Size = new System.Drawing.Size(230, 13);
            this.justificationLlabel.TabIndex = 22;
            this.justificationLlabel.Text = "Justification for SuppressMessage attribute";
            // 
            // justificationTextBox
            // 
            this.justificationTextBox.Location = new System.Drawing.Point(4, 63);
            this.justificationTextBox.Name = "justificationTextBox";
            this.justificationTextBox.Size = new System.Drawing.Size(275, 22);
            this.justificationTextBox.TabIndex = 21;
            // 
            // codeStyleWarningLabel
            // 
            this.codeStyleWarningLabel.Location = new System.Drawing.Point(0, 23);
            this.codeStyleWarningLabel.Name = "codeStyleWarningLabel";
            this.codeStyleWarningLabel.Size = new System.Drawing.Size(283, 51);
            this.codeStyleWarningLabel.TabIndex = 23;
            this.codeStyleWarningLabel.Text = "Your ReSharper C# code style options are not fully compatible with StyleCop. If y" +
    "ou reformat code then you are likely to see StyleCop violations.";
            // 
            // resetFormatOptionsButton
            // 
            this.resetFormatOptionsButton.AutoSize = true;
            this.resetFormatOptionsButton.Location = new System.Drawing.Point(133, 72);
            this.resetFormatOptionsButton.Name = "resetFormatOptionsButton";
            this.resetFormatOptionsButton.Size = new System.Drawing.Size(164, 23);
            this.resetFormatOptionsButton.TabIndex = 25;
            this.resetFormatOptionsButton.Text = "Reset C# Code Style Options";
            this.resetFormatOptionsButton.UseVisualStyleBackColor = true;
            this.resetFormatOptionsButton.Click += new System.EventHandler(this.ResetFormatOptionsButton_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.warningPanel);
            this.flowLayoutPanel1.Controls.Add(this.panel4);
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel6);
            this.flowLayoutPanel1.Controls.Add(this.panel5);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(365, 598);
            this.flowLayoutPanel1.TabIndex = 26;
            // 
            // warningPanel
            // 
            this.warningPanel.AutoSize = true;
            this.warningPanel.Controls.Add(this.resetFormatOptionsButton);
            this.warningPanel.Controls.Add(this.codeStyleWarningLabel);
            this.warningPanel.Controls.Add(this.label4);
            this.warningPanel.Location = new System.Drawing.Point(3, 3);
            this.warningPanel.Name = "warningPanel";
            this.warningPanel.Size = new System.Drawing.Size(300, 98);
            this.warningPanel.TabIndex = 31;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Warning";
            // 
            // panel4
            // 
            this.panel4.AutoSize = true;
            this.panel4.Controls.Add(this.useSingleLineForDeclarationCommentsCheckBox);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Controls.Add(this.panel2);
            this.panel4.Controls.Add(this.insertTextCheckBox);
            this.panel4.Location = new System.Drawing.Point(3, 107);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(272, 96);
            this.panel4.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Headers";
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.Controls.Add(this.numberOfDashesLabel);
            this.panel2.Controls.Add(this.dashesCountMaskedTextBox);
            this.panel2.Location = new System.Drawing.Point(0, 46);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(233, 31);
            this.panel2.TabIndex = 29;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.BrowseButton);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.StyleCopLocationTextBox);
            this.panel1.Controls.Add(this.autoDetectCheckBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 209);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(359, 94);
            this.panel1.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(0, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(98, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "StyleCop location";
            // 
            // panel6
            // 
            this.panel6.AutoSize = true;
            this.panel6.Controls.Add(this.enableAnalysisCheckBox);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label3);
            this.panel6.Controls.Add(this.label9);
            this.panel6.Controls.Add(this.performanceTrackBar);
            this.panel6.Location = new System.Drawing.Point(3, 309);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(279, 94);
            this.panel6.TabIndex = 36;
            // 
            // enableAnalysisCheckBox
            // 
            this.enableAnalysisCheckBox.AutoSize = true;
            this.enableAnalysisCheckBox.Checked = true;
            this.enableAnalysisCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.enableAnalysisCheckBox.Location = new System.Drawing.Point(0, 23);
            this.enableAnalysisCheckBox.Name = "enableAnalysisCheckBox";
            this.enableAnalysisCheckBox.Size = new System.Drawing.Size(156, 17);
            this.enableAnalysisCheckBox.TabIndex = 31;
            this.enableAnalysisCheckBox.Text = "Run StyleCop as you type";
            this.enableAnalysisCheckBox.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(119, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Analysis Performance";
            // 
            // panel5
            // 
            this.panel5.AutoSize = true;
            this.panel5.Controls.Add(this.label7);
            this.panel5.Controls.Add(this.justificationTextBox);
            this.panel5.Controls.Add(this.justificationLlabel);
            this.panel5.Controls.Add(this.useExcludeFromStyleCopCheckBox);
            this.panel5.Location = new System.Drawing.Point(3, 409);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(282, 88);
            this.panel5.TabIndex = 34;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(0, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Others";
            // 
            // StyleCopOptionsPage
            // 
            this.AutoSize = true;
            this.Controls.Add(this.flowLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StyleCopOptionsPage";
            this.Size = new System.Drawing.Size(378, 604);
            ((System.ComponentModel.ISupportInitialize)(this.performanceTrackBar)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.warningPanel.ResumeLayout(false);
            this.warningPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox autoDetectCheckBox;
        private TextBox StyleCopLocationTextBox;
        private Label label1;
        private OpenFileDialog StyleCopLocationDialog;
        private Button BrowseButton;
        private TrackBar performanceTrackBar;
        private Label label2;
        private Label label3;
        private CheckBox insertTextCheckBox;
        private Label numberOfDashesLabel;
        private MaskedTextBox dashesCountMaskedTextBox;
        private ToolTip toolTip;
        private CheckBox useExcludeFromStyleCopCheckBox;
        private Label justificationLlabel;
        private TextBox justificationTextBox;
        private CheckBox useSingleLineForDeclarationCommentsCheckBox;
        private Label codeStyleWarningLabel;
        private Button resetFormatOptionsButton;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label6;
        private Panel panel2;
        private Panel warningPanel;
        private Label label4;
        private Panel panel4;
        private Panel panel5;
        private Label label7;
        private Panel panel1;
        private Label label8;
        private Panel panel6;
        private Label label9;
        private CheckBox enableAnalysisCheckBox;
    }
}