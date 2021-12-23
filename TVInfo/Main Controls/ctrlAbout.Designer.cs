namespace TVInfo {
    partial class ctrlAbout {
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
            this.lblCtrlAbout = new System.Windows.Forms.Label();
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
            this.lblNYI.TabIndex = 3;
            this.lblNYI.Text = "NOT YET IMPLEMENTED";
            // 
            // lblCtrlAbout
            // 
            this.lblCtrlAbout.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtrlAbout.Location = new System.Drawing.Point(174, 0);
            this.lblCtrlAbout.Name = "lblCtrlAbout";
            this.lblCtrlAbout.Size = new System.Drawing.Size(609, 35);
            this.lblCtrlAbout.TabIndex = 4;
            this.lblCtrlAbout.Text = "About";
            this.lblCtrlAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.lblCtrlAbout);
            this.Controls.Add(this.lblNYI);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlAbout";
            this.Size = new System.Drawing.Size(957, 584);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNYI;
        private System.Windows.Forms.Label lblCtrlAbout;

    }
}
