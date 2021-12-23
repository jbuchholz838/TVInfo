namespace TVInfo {
    partial class ctrlSearch {
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
            this.lblCtrlSearch = new System.Windows.Forms.Label();
            this.lblSearchBox = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.pnlResults = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.lstResults = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colCountry = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblResults = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboSearchType = new System.Windows.Forms.ComboBox();
            this.lblSearchType = new System.Windows.Forms.Label();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCtrlSearch
            // 
            this.lblCtrlSearch.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtrlSearch.Location = new System.Drawing.Point(174, 0);
            this.lblCtrlSearch.Name = "lblCtrlSearch";
            this.lblCtrlSearch.Size = new System.Drawing.Size(609, 35);
            this.lblCtrlSearch.TabIndex = 0;
            this.lblCtrlSearch.Text = "Search";
            this.lblCtrlSearch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSearchBox
            // 
            this.lblSearchBox.AutoSize = true;
            this.lblSearchBox.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchBox.Location = new System.Drawing.Point(218, 59);
            this.lblSearchBox.Name = "lblSearchBox";
            this.lblSearchBox.Size = new System.Drawing.Size(105, 19);
            this.lblSearchBox.TabIndex = 1;
            this.lblSearchBox.Text = "Show Name";
            // 
            // txtSearch
            // 
            this.txtSearch.AcceptsReturn = true;
            this.txtSearch.Location = new System.Drawing.Point(329, 56);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(329, 27);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // pnlResults
            // 
            this.pnlResults.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlResults.Controls.Add(this.lblLoading);
            this.pnlResults.Controls.Add(this.lstResults);
            this.pnlResults.Location = new System.Drawing.Point(130, 157);
            this.pnlResults.Name = "pnlResults";
            this.pnlResults.Size = new System.Drawing.Size(696, 411);
            this.pnlResults.TabIndex = 3;
            // 
            // lblLoading
            // 
            this.lblLoading.AutoSize = true;
            this.lblLoading.Location = new System.Drawing.Point(307, 185);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(80, 19);
            this.lblLoading.TabIndex = 5;
            this.lblLoading.Text = "Loading...";
            this.lblLoading.Visible = false;
            // 
            // lstResults
            // 
            this.lstResults.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colCountry,
            this.colStatus,
            this.colDate});
            this.lstResults.FullRowSelect = true;
            this.lstResults.GridLines = true;
            this.lstResults.Location = new System.Drawing.Point(3, 4);
            this.lstResults.Name = "lstResults";
            this.lstResults.Size = new System.Drawing.Size(688, 402);
            this.lstResults.TabIndex = 0;
            this.lstResults.TabStop = false;
            this.lstResults.UseCompatibleStateImageBehavior = false;
            this.lstResults.View = System.Windows.Forms.View.Details;
            this.lstResults.DoubleClick += new System.EventHandler(this.lstResults_DoubleClick);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 254;
            // 
            // colCountry
            // 
            this.colCountry.Text = "Country";
            this.colCountry.Width = 135;
            // 
            // colStatus
            // 
            this.colStatus.Text = "Status";
            this.colStatus.Width = 164;
            // 
            // lblResults
            // 
            this.lblResults.AutoSize = true;
            this.lblResults.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResults.Location = new System.Drawing.Point(134, 142);
            this.lblResults.Name = "lblResults";
            this.lblResults.Size = new System.Drawing.Size(69, 19);
            this.lblResults.TabIndex = 4;
            this.lblResults.Text = "Results";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(664, 55);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboSearchType
            // 
            this.cboSearchType.FormattingEnabled = true;
            this.cboSearchType.Items.AddRange(new object[] {
            "TV - Search by Name",
            "MOVIE - Search by Name",
            "LEGACY - TV Rage Search"});
            this.cboSearchType.Location = new System.Drawing.Point(329, 89);
            this.cboSearchType.Name = "cboSearchType";
            this.cboSearchType.Size = new System.Drawing.Size(329, 27);
            this.cboSearchType.TabIndex = 6;
            this.cboSearchType.Text = "TV - Search by Name";
            // 
            // lblSearchType
            // 
            this.lblSearchType.AutoSize = true;
            this.lblSearchType.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearchType.Location = new System.Drawing.Point(214, 92);
            this.lblSearchType.Name = "lblSearchType";
            this.lblSearchType.Size = new System.Drawing.Size(109, 19);
            this.lblSearchType.TabIndex = 7;
            this.lblSearchType.Text = "Search Type";
            // 
            // colDate
            // 
            this.colDate.Tag = "Date";
            this.colDate.Text = "Date";
            this.colDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colDate.Width = 107;
            // 
            // ctrlSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.lblSearchType);
            this.Controls.Add(this.cboSearchType);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblResults);
            this.Controls.Add(this.pnlResults);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.lblSearchBox);
            this.Controls.Add(this.lblCtrlSearch);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlSearch";
            this.Size = new System.Drawing.Size(957, 584);
            this.pnlResults.ResumeLayout(false);
            this.pnlResults.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCtrlSearch;
        private System.Windows.Forms.Label lblSearchBox;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel pnlResults;
        private System.Windows.Forms.Label lblResults;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ListView lstResults;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colCountry;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.Label lblLoading;
        private System.Windows.Forms.ComboBox cboSearchType;
        private System.Windows.Forms.Label lblSearchType;
        private System.Windows.Forms.ColumnHeader colDate;

    }
}
