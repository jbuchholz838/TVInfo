namespace TVInfo {
    partial class ctrlShowGeneral {
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
            this.lblHead = new System.Windows.Forms.Label();
            this.btnExpand = new System.Windows.Forms.Button();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // lblHead
            // 
            this.lblHead.AutoSize = true;
            this.lblHead.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHead.Location = new System.Drawing.Point(37, 3);
            this.lblHead.Name = "lblHead";
            this.lblHead.Size = new System.Drawing.Size(170, 20);
            this.lblHead.TabIndex = 0;
            this.lblHead.Text = "General Information";
            // 
            // btnExpand
            // 
            this.btnExpand.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpand.Location = new System.Drawing.Point(3, 0);
            this.btnExpand.Name = "btnExpand";
            this.btnExpand.Size = new System.Drawing.Size(28, 23);
            this.btnExpand.TabIndex = 1;
            this.btnExpand.Text = "+";
            this.btnExpand.UseVisualStyleBackColor = true;
            this.btnExpand.Click += new System.EventHandler(this.btnExpand_Click);
            // 
            // pnlInfo
            // 
            this.pnlInfo.AutoSize = true;
            this.pnlInfo.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlInfo.Location = new System.Drawing.Point(41, 35);
            this.pnlInfo.MaximumSize = new System.Drawing.Size(893, 0);
            this.pnlInfo.MinimumSize = new System.Drawing.Size(893, 0);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(893, 0);
            this.pnlInfo.TabIndex = 2;
            // 
            // ctrlShowGeneral
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnExpand);
            this.Controls.Add(this.lblHead);
            this.MaximumSize = new System.Drawing.Size(937, 0);
            this.MinimumSize = new System.Drawing.Size(937, 0);
            this.Name = "ctrlShowGeneral";
            this.Size = new System.Drawing.Size(937, 38);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHead;
        private System.Windows.Forms.Button btnExpand;
        private System.Windows.Forms.Panel pnlInfo;
    }
}
