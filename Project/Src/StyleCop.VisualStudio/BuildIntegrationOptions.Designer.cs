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
            this.radioButtonAsWarning = new System.Windows.Forms.RadioButton();
            this.radioButtonAsError = new System.Windows.Forms.RadioButton();
            this.descriptionTreat = new System.Windows.Forms.Label();
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
            // radioButtonAsWarning
            // 
            resources.ApplyResources(this.radioButtonAsWarning, "radioButtonAsWarning");
            this.radioButtonAsWarning.Name = "radioButtonAsWarning";
            this.radioButtonAsWarning.TabStop = true;
            this.radioButtonAsWarning.UseVisualStyleBackColor = true;
            this.radioButtonAsWarning.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // radioButtonAsError
            // 
            resources.ApplyResources(this.radioButtonAsError, "radioButtonAsError");
            this.radioButtonAsError.Name = "radioButtonAsError";
            this.radioButtonAsError.TabStop = true;
            this.radioButtonAsError.UseVisualStyleBackColor = true;
            this.radioButtonAsError.CheckedChanged += new System.EventHandler(this.RadioButtonCheckedChanged);
            // 
            // descriptionTreat
            // 
            resources.ApplyResources(this.descriptionTreat, "descriptionTreat");
            this.descriptionTreat.Name = "descriptionTreat";
            // 
            // BuildIntegrationOptions
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.radioButtonAsWarning);
            this.Controls.Add(this.radioButtonAsError);
            this.Controls.Add(this.descriptionTreat);
            this.Controls.Add(this.checkBox);
            this.Controls.Add(this.description);
            this.Name = "BuildIntegrationOptions";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton radioButtonAsWarning;
        private System.Windows.Forms.RadioButton radioButtonAsError;
        private System.Windows.Forms.Label descriptionTreat;
    }
}