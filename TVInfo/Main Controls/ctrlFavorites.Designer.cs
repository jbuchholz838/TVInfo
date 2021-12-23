namespace TVInfo {
    partial class ctrlFavorites {
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
            this.lblCtrlFavorites = new System.Windows.Forms.Label();
            this.lstTV = new System.Windows.Forms.ListView();
            this.colShowName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colLastDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNextDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAirDay = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSeasons = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNextEpisode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colEPCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnExport = new System.Windows.Forms.Button();
            this.tabFavorites = new System.Windows.Forms.TabControl();
            this.tabTV = new System.Windows.Forms.TabPage();
            this.tabMovie = new System.Windows.Forms.TabPage();
            this.lstMovie = new System.Windows.Forms.ListView();
            this.colTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colReleaseDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colGenre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRuntime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabFavorites.SuspendLayout();
            this.tabTV.SuspendLayout();
            this.tabMovie.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCtrlFavorites
            // 
            this.lblCtrlFavorites.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtrlFavorites.Location = new System.Drawing.Point(172, 0);
            this.lblCtrlFavorites.Name = "lblCtrlFavorites";
            this.lblCtrlFavorites.Size = new System.Drawing.Size(609, 35);
            this.lblCtrlFavorites.TabIndex = 2;
            this.lblCtrlFavorites.Text = "Favorites";
            this.lblCtrlFavorites.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstTV
            // 
            this.lstTV.BackColor = System.Drawing.SystemColors.Window;
            this.lstTV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colShowName,
            this.colStatus,
            this.colLastDate,
            this.colNextDate,
            this.colAirDay,
            this.colSeasons,
            this.colNextEpisode,
            this.colEPCount});
            this.lstTV.FullRowSelect = true;
            this.lstTV.GridLines = true;
            this.lstTV.HideSelection = false;
            this.lstTV.Location = new System.Drawing.Point(10, 6);
            this.lstTV.MultiSelect = false;
            this.lstTV.Name = "lstTV";
            this.lstTV.Size = new System.Drawing.Size(923, 476);
            this.lstTV.TabIndex = 3;
            this.lstTV.UseCompatibleStateImageBehavior = false;
            this.lstTV.View = System.Windows.Forms.View.Details;
            this.lstTV.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstFavorites_ColumnClick);
            this.lstTV.DoubleClick += new System.EventHandler(this.lstFavorites_DoubleClick);
            // 
            // colShowName
            // 
            this.colShowName.Tag = "String";
            this.colShowName.Text = "Show Name";
            this.colShowName.Width = 240;
            // 
            // colStatus
            // 
            this.colStatus.Tag = "String";
            this.colStatus.Text = "Status";
            this.colStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colStatus.Width = 142;
            // 
            // colLastDate
            // 
            this.colLastDate.Text = "Last Date";
            this.colLastDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colLastDate.Width = 107;
            // 
            // colNextDate
            // 
            this.colNextDate.Tag = "Date";
            this.colNextDate.Text = "Next Date";
            this.colNextDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNextDate.Width = 107;
            // 
            // colAirDay
            // 
            this.colAirDay.Tag = "Day";
            this.colAirDay.Text = "Day of Week";
            this.colAirDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colAirDay.Width = 101;
            // 
            // colSeasons
            // 
            this.colSeasons.Tag = "Number";
            this.colSeasons.Text = "Season";
            this.colSeasons.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colSeasons.Width = 69;
            // 
            // colNextEpisode
            // 
            this.colNextEpisode.Tag = "Number";
            this.colNextEpisode.Text = "EP #";
            this.colNextEpisode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNextEpisode.Width = 48;
            // 
            // colEPCount
            // 
            this.colEPCount.Tag = "Total EPs";
            this.colEPCount.Text = "Total EPs";
            this.colEPCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colEPCount.Width = 85;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(816, 30);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(121, 31);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export to CSV";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // tabFavorites
            // 
            this.tabFavorites.Controls.Add(this.tabTV);
            this.tabFavorites.Controls.Add(this.tabMovie);
            this.tabFavorites.Location = new System.Drawing.Point(3, 61);
            this.tabFavorites.Name = "tabFavorites";
            this.tabFavorites.SelectedIndex = 0;
            this.tabFavorites.Size = new System.Drawing.Size(951, 520);
            this.tabFavorites.TabIndex = 5;
            // 
            // tabTV
            // 
            this.tabTV.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabTV.Controls.Add(this.lstTV);
            this.tabTV.Location = new System.Drawing.Point(4, 28);
            this.tabTV.Name = "tabTV";
            this.tabTV.Padding = new System.Windows.Forms.Padding(3);
            this.tabTV.Size = new System.Drawing.Size(943, 488);
            this.tabTV.TabIndex = 0;
            this.tabTV.Text = "TV Shows";
            // 
            // tabMovie
            // 
            this.tabMovie.BackColor = System.Drawing.SystemColors.ControlDark;
            this.tabMovie.Controls.Add(this.lstMovie);
            this.tabMovie.Location = new System.Drawing.Point(4, 28);
            this.tabMovie.Name = "tabMovie";
            this.tabMovie.Padding = new System.Windows.Forms.Padding(3);
            this.tabMovie.Size = new System.Drawing.Size(943, 488);
            this.tabMovie.TabIndex = 1;
            this.tabMovie.Text = "Movies";
            // 
            // lstMovie
            // 
            this.lstMovie.BackColor = System.Drawing.SystemColors.Window;
            this.lstMovie.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTitle,
            this.colReleaseDate,
            this.colGenre,
            this.colRuntime});
            this.lstMovie.FullRowSelect = true;
            this.lstMovie.GridLines = true;
            this.lstMovie.HideSelection = false;
            this.lstMovie.Location = new System.Drawing.Point(10, 6);
            this.lstMovie.MultiSelect = false;
            this.lstMovie.Name = "lstMovie";
            this.lstMovie.Size = new System.Drawing.Size(923, 476);
            this.lstMovie.TabIndex = 4;
            this.lstMovie.UseCompatibleStateImageBehavior = false;
            this.lstMovie.View = System.Windows.Forms.View.Details;
            this.lstMovie.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstMovie_ColumnClick);
            this.lstMovie.DoubleClick += new System.EventHandler(this.lstFavorites_DoubleClick);
            // 
            // colTitle
            // 
            this.colTitle.Tag = "Movie Title";
            this.colTitle.Text = "Movie Title";
            this.colTitle.Width = 375;
            // 
            // colReleaseDate
            // 
            this.colReleaseDate.Tag = "Release Date";
            this.colReleaseDate.Text = "Release Date";
            this.colReleaseDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colReleaseDate.Width = 110;
            // 
            // colGenre
            // 
            this.colGenre.Tag = "Genre";
            this.colGenre.Text = "Genres";
            this.colGenre.Width = 350;
            // 
            // colRuntime
            // 
            this.colRuntime.Tag = "Runtime";
            this.colRuntime.Text = "Length";
            this.colRuntime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ctrlFavorites
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.tabFavorites);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.lblCtrlFavorites);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlFavorites";
            this.Size = new System.Drawing.Size(957, 584);
            this.Load += new System.EventHandler(this.ctrlFavorites_Load);
            this.tabFavorites.ResumeLayout(false);
            this.tabTV.ResumeLayout(false);
            this.tabMovie.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCtrlFavorites;
        private System.Windows.Forms.ListView lstTV;
        private System.Windows.Forms.ColumnHeader colShowName;
        private System.Windows.Forms.ColumnHeader colStatus;
        private System.Windows.Forms.ColumnHeader colAirDay;
        private System.Windows.Forms.ColumnHeader colNextDate;
        private System.Windows.Forms.ColumnHeader colEPCount;
        private System.Windows.Forms.ColumnHeader colSeasons;
        private System.Windows.Forms.ColumnHeader colNextEpisode;
        private System.Windows.Forms.ColumnHeader colLastDate;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TabControl tabFavorites;
        private System.Windows.Forms.TabPage tabTV;
        private System.Windows.Forms.TabPage tabMovie;
        private System.Windows.Forms.ListView lstMovie;
        private System.Windows.Forms.ColumnHeader colTitle;
        private System.Windows.Forms.ColumnHeader colReleaseDate;
        private System.Windows.Forms.ColumnHeader colGenre;
        private System.Windows.Forms.ColumnHeader colRuntime;

    }
}
