namespace StyleCop
{
    partial class PropertyDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PropertyDialog));
            this.ok = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.apply = new System.Windows.Forms.Button();
            this.help = new System.Windows.Forms.Button();
            this.properties = new StyleCop.PropertyControl();
            this.SuspendLayout();
            // 
            // ok
            // 
            resources.ApplyResources(this.ok, "ok");
            this.ok.Name = "ok";
            this.ok.UseVisualStyleBackColor = true;
            this.ok.Click += new System.EventHandler(this.OkClick);
            // 
            // cancel
            // 
            resources.ApplyResources(this.cancel, "cancel");
            this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancel.Name = "cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.CancelClick);
            // 
            // apply
            // 
            resources.ApplyResources(this.apply, "apply");
            this.apply.Name = "apply";
            this.apply.UseVisualStyleBackColor = true;
            this.apply.Click += new System.EventHandler(this.ApplyClick);
            // 
            // help
            // 
            resources.ApplyResources(this.help, "help");
            this.help.Name = "help";
            this.help.UseVisualStyleBackColor = true;
            this.help.Click += new System.EventHandler(this.HelpClick);
            // 
            // properties
            // 
            resources.ApplyResources(this.properties, "properties");
            this.properties.HotTrack = true;
            this.properties.Name = "properties";
            this.properties.SelectedIndex = 0;
            // 
            // PropertyDialog
            // 
            this.AcceptButton = this.ok;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancel;
            this.Controls.Add(this.properties);
            this.Controls.Add(this.help);
            this.Controls.Add(this.apply);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.ok);
            this.Name = "PropertyDialog";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ok;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Button apply;
        private System.Windows.Forms.Button help;
        private PropertyControl properties;
    }
}