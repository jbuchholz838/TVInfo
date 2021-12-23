namespace TVInfo {
    partial class ctrlCalendar {
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
            this.lblCtrlCalendar = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblCtrlCalendar
            // 
            this.lblCtrlCalendar.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtrlCalendar.Location = new System.Drawing.Point(174, 0);
            this.lblCtrlCalendar.Name = "lblCtrlCalendar";
            this.lblCtrlCalendar.Size = new System.Drawing.Size(609, 35);
            this.lblCtrlCalendar.TabIndex = 2;
            this.lblCtrlCalendar.Text = "Calendar";
            this.lblCtrlCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ctrlCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.lblCtrlCalendar);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlCalendar";
            this.Size = new System.Drawing.Size(957, 584);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCtrlCalendar;

    }
}
