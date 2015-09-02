//-----------------------------------------------------------------------
// <copyright file="BuildIntegrationOptions.Designer.cs">
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
namespace StyleCop.VisualStudio
{
    /// <content>
    /// Designer information for the BuildIntegrationOptions class.
    /// </content>
    public partial class BuildIntegrationOptions
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
        /// The description label.
        /// </summary>
        private System.Windows.Forms.Label description;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuildIntegrationOptions));
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.description = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // checkBox
            // 
            resources.ApplyResources(this.checkBox, "checkBox");
            this.checkBox.Name = "checkBox";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.CheckBoxCheckedChanged);
            // 
            // description
            // 
            resources.ApplyResources(this.description, "description");
            this.description.Name = "description";
            // 
            // BuildIntegrationOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.description);
            this.Controls.Add(this.checkBox);
            this.Name = "BuildIntegrationOptions";
            this.ResumeLayout(false);

        }

        #endregion
    }
}