namespace TVInfo {
    partial class ctrlSettings {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.lblNYI = new System.Windows.Forms.Label();
            this.lblCtrlSettings = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblNYI
            // 
            this.lblNYI.AutoSize = true;
            this.lblNYI.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNYI.Location = new System.Drawing.Point(275, 273);
            this.lblNYI.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNYI.Name = "lblNYI";
            this.lblNYI.Size = new System.Drawing.Size(407, 39);
            this.lblNYI.TabIndex = 2;
            this.lblNYI.Text = "NOT YET IMPLEMENTED";
            // 
            // lblCtrlSettings
            // 
            this.lblCtrlSettings.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtrlSettings.Location = new System.Drawing.Point(174, 0);
            this.lblCtrlSettings.Name = "lblCtrlSettings";
            this.lblCtrlSettings.Size = new System.Drawing.Size(609, 35);
            this.lblCtrlSettings.TabIndex = 3;
            this.lblCtrlSettings.Text = "Settings";
            this.lblCtrlSettings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.lblCtrlSettings);
            this.Controls.Add(this.lblNYI);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlSettings";
            this.Size = new System.Drawing.Size(957, 584);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNYI;
        private System.Windows.Forms.Label lblCtrlSettings;

    }
}
