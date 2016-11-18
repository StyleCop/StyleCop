//-----------------------------------------------------------------------
// <copyright file="CompanyInformation.Designer.cs">
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
namespace StyleCop.CSharp
{
    /// <content>
    /// Designer information for the CompanyInformation class.
    /// </content>
    public partial class CompanyInformation
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// The check box.
        /// </summary>
        private System.Windows.Forms.CheckBox checkBox;

        /// <summary>
        /// The company name label.
        /// </summary>
        private System.Windows.Forms.Label companyNameLabel;

        /// <summary>
        /// The copyright label.
        /// </summary>
        private System.Windows.Forms.Label copyrightLabel;

        /// <summary>
        /// The company name text box.
        /// </summary>
        private System.Windows.Forms.TextBox companyName;

        /// <summary>
        /// The copyright text box.
        /// </summary>
        private System.Windows.Forms.TextBox copyright;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">Returns true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            Param.Ignore(disposing);

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyInformation));
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.companyNameLabel = new System.Windows.Forms.Label();
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.companyName = new System.Windows.Forms.TextBox();
            this.copyright = new System.Windows.Forms.TextBox();
            this.SuspendLayout();

            // checkBox

            resources.ApplyResources(this.checkBox, "checkBox");
            this.checkBox.Name = "checkBox";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);

            // companyNameLabel

            resources.ApplyResources(this.companyNameLabel, "companyNameLabel");
            this.companyNameLabel.Name = "companyNameLabel";

            // copyrightLabel

            resources.ApplyResources(this.copyrightLabel, "copyrightLabel");
            this.copyrightLabel.Name = "copyrightLabel";

            // companyName

            resources.ApplyResources(this.companyName, "companyName");
            this.companyName.Name = "companyName";
            this.companyName.TextChanged += new System.EventHandler(this.CompanyNameTextChanged);

            // copyright

            this.copyright.AcceptsReturn = true;
            resources.ApplyResources(this.copyright, "copyright");
            this.copyright.Name = "copyright";
            this.copyright.TextChanged += new System.EventHandler(this.CopyrightTextChanged);

            // CompanyInformation

            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.copyright);
            this.Controls.Add(this.companyName);
            this.Controls.Add(this.copyrightLabel);
            this.Controls.Add(this.companyNameLabel);
            this.Controls.Add(this.checkBox);
            this.Name = "CompanyInformation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}