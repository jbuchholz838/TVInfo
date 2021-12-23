namespace TVInfo {
    partial class ctrlMovieInfo {
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
            this.lblCtrlMovieInfo = new System.Windows.Forms.Label();
            this.btnFavorite = new System.Windows.Forms.Button();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.floShowInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.propTitle = new TVInfo.ctrlProperty();
            this.grpGeneral.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.floShowInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCtrlMovieInfo
            // 
            this.lblCtrlMovieInfo.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtrlMovieInfo.Location = new System.Drawing.Point(174, 0);
            this.lblCtrlMovieInfo.Name = "lblCtrlMovieInfo";
            this.lblCtrlMovieInfo.Size = new System.Drawing.Size(609, 35);
            this.lblCtrlMovieInfo.TabIndex = 4;
            this.lblCtrlMovieInfo.Text = "Movie Info";
            this.lblCtrlMovieInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnFavorite
            // 
            this.btnFavorite.Location = new System.Drawing.Point(841, 0);
            this.btnFavorite.Margin = new System.Windows.Forms.Padding(0);
            this.btnFavorite.Name = "btnFavorite";
            this.btnFavorite.Size = new System.Drawing.Size(116, 31);
            this.btnFavorite.TabIndex = 16;
            this.btnFavorite.Tag = "Add";
            this.btnFavorite.Text = "Add Favorite";
            this.btnFavorite.UseVisualStyleBackColor = true;
            this.btnFavorite.Click += new System.EventHandler(this.btnFavorite_Click);
            // 
            // grpGeneral
            // 
            this.grpGeneral.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpGeneral.Controls.Add(this.pnlGeneral);
            this.grpGeneral.Controls.Add(this.btnGeneral);
            this.grpGeneral.Location = new System.Drawing.Point(11, 0);
            this.grpGeneral.Margin = new System.Windows.Forms.Padding(11, 0, 0, 4);
            this.grpGeneral.MaximumSize = new System.Drawing.Size(930, 444);
            this.grpGeneral.MinimumSize = new System.Drawing.Size(930, 29);
            this.grpGeneral.Name = "grpGeneral";
            this.grpGeneral.Padding = new System.Windows.Forms.Padding(0);
            this.grpGeneral.Size = new System.Drawing.Size(930, 444);
            this.grpGeneral.TabIndex = 0;
            this.grpGeneral.TabStop = false;
            this.grpGeneral.Text = "General Information";
            // 
            // pnlGeneral
            // 
            this.pnlGeneral.AutoScroll = true;
            this.pnlGeneral.Controls.Add(this.propTitle);
            this.pnlGeneral.Location = new System.Drawing.Point(3, 24);
            this.pnlGeneral.MaximumSize = new System.Drawing.Size(923, 409);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(923, 409);
            this.pnlGeneral.TabIndex = 17;
            // 
            // btnGeneral
            // 
            this.btnGeneral.AutoSize = true;
            this.btnGeneral.Location = new System.Drawing.Point(828, -4);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(78, 29);
            this.btnGeneral.TabIndex = 0;
            this.btnGeneral.Text = "Collapse";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // floShowInfo
            // 
            this.floShowInfo.Controls.Add(this.grpGeneral);
            this.floShowInfo.Location = new System.Drawing.Point(3, 38);
            this.floShowInfo.Name = "floShowInfo";
            this.floShowInfo.Size = new System.Drawing.Size(954, 543);
            this.floShowInfo.TabIndex = 17;
            // 
            // propTitle
            // 
            this.propTitle.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.propTitle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.propTitle.Location = new System.Drawing.Point(4, 8);
            this.propTitle.Margin = new System.Windows.Forms.Padding(4);
            this.propTitle.Name = "propTitle";
            this.propTitle.propName = "Title:";
            this.propTitle.propText = "<PROPERTY TEXT>";
            this.propTitle.Size = new System.Drawing.Size(915, 20);
            this.propTitle.TabIndex = 0;
            // 
            // ctrlMovieInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.floShowInfo);
            this.Controls.Add(this.btnFavorite);
            this.Controls.Add(this.lblCtrlMovieInfo);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlMovieInfo";
            this.Size = new System.Drawing.Size(957, 584);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.pnlGeneral.ResumeLayout(false);
            this.floShowInfo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCtrlMovieInfo;
        private System.Windows.Forms.Button btnFavorite;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.FlowLayoutPanel floShowInfo;
        private ctrlProperty propTitle;

    }
}
