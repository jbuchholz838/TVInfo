namespace TVInfo {
    partial class ctrlShowInfo {
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
            this.lblCtrlShowInfo = new System.Windows.Forms.Label();
            this.btnFavorite = new System.Windows.Forms.Button();
            this.grpGeneral = new System.Windows.Forms.GroupBox();
            this.pnlGeneral = new System.Windows.Forms.Panel();
            this.lblLastDate = new System.Windows.Forms.Label();
            this.lblLastDateHead = new System.Windows.Forms.Label();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.lblNextDateHead = new System.Windows.Forms.Label();
            this.lblNextEpisode = new System.Windows.Forms.Label();
            this.lblNextEpisodeHead = new System.Windows.Forms.Label();
            this.lblGenres = new System.Windows.Forms.Label();
            this.lblNextDate = new System.Windows.Forms.Label();
            this.lblAirtime = new System.Windows.Forms.Label();
            this.lblAirday = new System.Windows.Forms.Label();
            this.lblSeasons = new System.Windows.Forms.Label();
            this.lblEnded = new System.Windows.Forms.Label();
            this.lblStarted = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblNameHead = new System.Windows.Forms.Label();
            this.lblGenresHead = new System.Windows.Forms.Label();
            this.lblStartedHead = new System.Windows.Forms.Label();
            this.lblEndedHead = new System.Windows.Forms.Label();
            this.lblSeasonsHead = new System.Windows.Forms.Label();
            this.lblAirdayHead = new System.Windows.Forms.Label();
            this.lblEndDateHead = new System.Windows.Forms.Label();
            this.lblAirtimeHead = new System.Windows.Forms.Label();
            this.lblStatusHead = new System.Windows.Forms.Label();
            this.lblCountryHead = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.floShowInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.grpEpisodes = new System.Windows.Forms.GroupBox();
            this.pnlEpisodes = new System.Windows.Forms.Panel();
            this.btnEpisodes = new System.Windows.Forms.Button();
            this.grpGeneral.SuspendLayout();
            this.pnlGeneral.SuspendLayout();
            this.floShowInfo.SuspendLayout();
            this.grpEpisodes.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCtrlShowInfo
            // 
            this.lblCtrlShowInfo.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCtrlShowInfo.Location = new System.Drawing.Point(174, 0);
            this.lblCtrlShowInfo.Name = "lblCtrlShowInfo";
            this.lblCtrlShowInfo.Size = new System.Drawing.Size(609, 35);
            this.lblCtrlShowInfo.TabIndex = 4;
            this.lblCtrlShowInfo.Text = "Show Info";
            this.lblCtrlShowInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.pnlGeneral.Controls.Add(this.lblLastDate);
            this.pnlGeneral.Controls.Add(this.lblLastDateHead);
            this.pnlGeneral.Controls.Add(this.lblEndDate);
            this.pnlGeneral.Controls.Add(this.lblNextDateHead);
            this.pnlGeneral.Controls.Add(this.lblNextEpisode);
            this.pnlGeneral.Controls.Add(this.lblNextEpisodeHead);
            this.pnlGeneral.Controls.Add(this.lblGenres);
            this.pnlGeneral.Controls.Add(this.lblNextDate);
            this.pnlGeneral.Controls.Add(this.lblAirtime);
            this.pnlGeneral.Controls.Add(this.lblAirday);
            this.pnlGeneral.Controls.Add(this.lblSeasons);
            this.pnlGeneral.Controls.Add(this.lblEnded);
            this.pnlGeneral.Controls.Add(this.lblStarted);
            this.pnlGeneral.Controls.Add(this.lblStatus);
            this.pnlGeneral.Controls.Add(this.lblCountry);
            this.pnlGeneral.Controls.Add(this.lblNameHead);
            this.pnlGeneral.Controls.Add(this.lblGenresHead);
            this.pnlGeneral.Controls.Add(this.lblStartedHead);
            this.pnlGeneral.Controls.Add(this.lblEndedHead);
            this.pnlGeneral.Controls.Add(this.lblSeasonsHead);
            this.pnlGeneral.Controls.Add(this.lblAirdayHead);
            this.pnlGeneral.Controls.Add(this.lblEndDateHead);
            this.pnlGeneral.Controls.Add(this.lblAirtimeHead);
            this.pnlGeneral.Controls.Add(this.lblStatusHead);
            this.pnlGeneral.Controls.Add(this.lblCountryHead);
            this.pnlGeneral.Controls.Add(this.lblName);
            this.pnlGeneral.Location = new System.Drawing.Point(3, 24);
            this.pnlGeneral.MaximumSize = new System.Drawing.Size(923, 409);
            this.pnlGeneral.Name = "pnlGeneral";
            this.pnlGeneral.Size = new System.Drawing.Size(923, 409);
            this.pnlGeneral.TabIndex = 17;
            // 
            // lblLastDate
            // 
            this.lblLastDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastDate.Location = new System.Drawing.Point(162, 291);
            this.lblLastDate.Name = "lblLastDate";
            this.lblLastDate.Size = new System.Drawing.Size(733, 20);
            this.lblLastDate.TabIndex = 135;
            this.lblLastDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLastDateHead
            // 
            this.lblLastDateHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastDateHead.Location = new System.Drawing.Point(27, 291);
            this.lblLastDateHead.Name = "lblLastDateHead";
            this.lblLastDateHead.Size = new System.Drawing.Size(129, 20);
            this.lblLastDateHead.TabIndex = 134;
            this.lblLastDateHead.Text = "Last Date:";
            // 
            // lblEndDate
            // 
            this.lblEndDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDate.Location = new System.Drawing.Point(162, 321);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(733, 20);
            this.lblEndDate.TabIndex = 129;
            this.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNextDateHead
            // 
            this.lblNextDateHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDateHead.Location = new System.Drawing.Point(27, 260);
            this.lblNextDateHead.Name = "lblNextDateHead";
            this.lblNextDateHead.Size = new System.Drawing.Size(129, 20);
            this.lblNextDateHead.TabIndex = 113;
            this.lblNextDateHead.Text = "Next Date:";
            // 
            // lblNextEpisode
            // 
            this.lblNextEpisode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextEpisode.Location = new System.Drawing.Point(162, 352);
            this.lblNextEpisode.Name = "lblNextEpisode";
            this.lblNextEpisode.Size = new System.Drawing.Size(733, 20);
            this.lblNextEpisode.TabIndex = 133;
            this.lblNextEpisode.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNextEpisodeHead
            // 
            this.lblNextEpisodeHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextEpisodeHead.Location = new System.Drawing.Point(27, 352);
            this.lblNextEpisodeHead.Name = "lblNextEpisodeHead";
            this.lblNextEpisodeHead.Size = new System.Drawing.Size(129, 20);
            this.lblNextEpisodeHead.TabIndex = 132;
            this.lblNextEpisodeHead.Text = "Next Episode:";
            // 
            // lblGenres
            // 
            this.lblGenres.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenres.Location = new System.Drawing.Point(162, 383);
            this.lblGenres.Name = "lblGenres";
            this.lblGenres.Size = new System.Drawing.Size(733, 20);
            this.lblGenres.TabIndex = 131;
            // 
            // lblNextDate
            // 
            this.lblNextDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextDate.Location = new System.Drawing.Point(162, 260);
            this.lblNextDate.Name = "lblNextDate";
            this.lblNextDate.Size = new System.Drawing.Size(733, 20);
            this.lblNextDate.TabIndex = 130;
            this.lblNextDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAirtime
            // 
            this.lblAirtime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirtime.Location = new System.Drawing.Point(162, 228);
            this.lblAirtime.Name = "lblAirtime";
            this.lblAirtime.Size = new System.Drawing.Size(733, 20);
            this.lblAirtime.TabIndex = 128;
            this.lblAirtime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblAirday
            // 
            this.lblAirday.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirday.Location = new System.Drawing.Point(162, 197);
            this.lblAirday.Name = "lblAirday";
            this.lblAirday.Size = new System.Drawing.Size(733, 20);
            this.lblAirday.TabIndex = 127;
            this.lblAirday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSeasons
            // 
            this.lblSeasons.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeasons.Location = new System.Drawing.Point(162, 166);
            this.lblSeasons.Name = "lblSeasons";
            this.lblSeasons.Size = new System.Drawing.Size(733, 20);
            this.lblSeasons.TabIndex = 126;
            this.lblSeasons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblEnded
            // 
            this.lblEnded.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnded.Location = new System.Drawing.Point(162, 135);
            this.lblEnded.Name = "lblEnded";
            this.lblEnded.Size = new System.Drawing.Size(733, 20);
            this.lblEnded.TabIndex = 125;
            this.lblEnded.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStarted
            // 
            this.lblStarted.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStarted.Location = new System.Drawing.Point(162, 104);
            this.lblStarted.Name = "lblStarted";
            this.lblStarted.Size = new System.Drawing.Size(733, 20);
            this.lblStarted.TabIndex = 124;
            this.lblStarted.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(162, 73);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(733, 20);
            this.lblStatus.TabIndex = 123;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCountry
            // 
            this.lblCountry.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(162, 42);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(733, 20);
            this.lblCountry.TabIndex = 122;
            this.lblCountry.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblNameHead
            // 
            this.lblNameHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNameHead.Location = new System.Drawing.Point(27, 11);
            this.lblNameHead.Name = "lblNameHead";
            this.lblNameHead.Size = new System.Drawing.Size(129, 20);
            this.lblNameHead.TabIndex = 121;
            this.lblNameHead.Text = "Name:  ";
            // 
            // lblGenresHead
            // 
            this.lblGenresHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGenresHead.Location = new System.Drawing.Point(27, 383);
            this.lblGenresHead.Name = "lblGenresHead";
            this.lblGenresHead.Size = new System.Drawing.Size(129, 20);
            this.lblGenresHead.TabIndex = 120;
            this.lblGenresHead.Text = "Genres:";
            // 
            // lblStartedHead
            // 
            this.lblStartedHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartedHead.Location = new System.Drawing.Point(27, 104);
            this.lblStartedHead.Name = "lblStartedHead";
            this.lblStartedHead.Size = new System.Drawing.Size(129, 20);
            this.lblStartedHead.TabIndex = 119;
            this.lblStartedHead.Text = "Started:";
            // 
            // lblEndedHead
            // 
            this.lblEndedHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndedHead.Location = new System.Drawing.Point(27, 135);
            this.lblEndedHead.Name = "lblEndedHead";
            this.lblEndedHead.Size = new System.Drawing.Size(129, 20);
            this.lblEndedHead.TabIndex = 118;
            this.lblEndedHead.Text = "Ended:";
            // 
            // lblSeasonsHead
            // 
            this.lblSeasonsHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeasonsHead.Location = new System.Drawing.Point(27, 166);
            this.lblSeasonsHead.Name = "lblSeasonsHead";
            this.lblSeasonsHead.Size = new System.Drawing.Size(129, 20);
            this.lblSeasonsHead.TabIndex = 117;
            this.lblSeasonsHead.Text = "Seasons:";
            // 
            // lblAirdayHead
            // 
            this.lblAirdayHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirdayHead.Location = new System.Drawing.Point(27, 197);
            this.lblAirdayHead.Name = "lblAirdayHead";
            this.lblAirdayHead.Size = new System.Drawing.Size(129, 20);
            this.lblAirdayHead.TabIndex = 116;
            this.lblAirdayHead.Text = "Airday:";
            // 
            // lblEndDateHead
            // 
            this.lblEndDateHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEndDateHead.Location = new System.Drawing.Point(27, 321);
            this.lblEndDateHead.Name = "lblEndDateHead";
            this.lblEndDateHead.Size = new System.Drawing.Size(129, 20);
            this.lblEndDateHead.TabIndex = 115;
            this.lblEndDateHead.Text = "End Date:";
            // 
            // lblAirtimeHead
            // 
            this.lblAirtimeHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAirtimeHead.Location = new System.Drawing.Point(27, 228);
            this.lblAirtimeHead.Name = "lblAirtimeHead";
            this.lblAirtimeHead.Size = new System.Drawing.Size(129, 20);
            this.lblAirtimeHead.TabIndex = 114;
            this.lblAirtimeHead.Text = "Airtime:";
            // 
            // lblStatusHead
            // 
            this.lblStatusHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusHead.Location = new System.Drawing.Point(27, 73);
            this.lblStatusHead.Name = "lblStatusHead";
            this.lblStatusHead.Size = new System.Drawing.Size(129, 20);
            this.lblStatusHead.TabIndex = 112;
            this.lblStatusHead.Text = "Status:";
            // 
            // lblCountryHead
            // 
            this.lblCountryHead.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryHead.Location = new System.Drawing.Point(27, 42);
            this.lblCountryHead.Name = "lblCountryHead";
            this.lblCountryHead.Size = new System.Drawing.Size(129, 20);
            this.lblCountryHead.TabIndex = 111;
            this.lblCountryHead.Text = "Country:  ";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(162, 11);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(733, 20);
            this.lblName.TabIndex = 110;
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.floShowInfo.Controls.Add(this.grpEpisodes);
            this.floShowInfo.Location = new System.Drawing.Point(3, 38);
            this.floShowInfo.Name = "floShowInfo";
            this.floShowInfo.Size = new System.Drawing.Size(954, 543);
            this.floShowInfo.TabIndex = 17;
            // 
            // grpEpisodes
            // 
            this.grpEpisodes.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpEpisodes.Controls.Add(this.pnlEpisodes);
            this.grpEpisodes.Controls.Add(this.btnEpisodes);
            this.grpEpisodes.Location = new System.Drawing.Point(11, 448);
            this.grpEpisodes.Margin = new System.Windows.Forms.Padding(11, 0, 0, 4);
            this.grpEpisodes.MaximumSize = new System.Drawing.Size(930, 444);
            this.grpEpisodes.MinimumSize = new System.Drawing.Size(930, 29);
            this.grpEpisodes.Name = "grpEpisodes";
            this.grpEpisodes.Padding = new System.Windows.Forms.Padding(0);
            this.grpEpisodes.Size = new System.Drawing.Size(930, 29);
            this.grpEpisodes.TabIndex = 1;
            this.grpEpisodes.TabStop = false;
            this.grpEpisodes.Text = "Episodes";
            this.grpEpisodes.Visible = false;
            // 
            // pnlEpisodes
            // 
            this.pnlEpisodes.AutoScroll = true;
            this.pnlEpisodes.Location = new System.Drawing.Point(3, 24);
            this.pnlEpisodes.MaximumSize = new System.Drawing.Size(923, 409);
            this.pnlEpisodes.Name = "pnlEpisodes";
            this.pnlEpisodes.Size = new System.Drawing.Size(0, 0);
            this.pnlEpisodes.TabIndex = 17;
            // 
            // btnEpisodes
            // 
            this.btnEpisodes.AutoSize = true;
            this.btnEpisodes.Location = new System.Drawing.Point(828, -4);
            this.btnEpisodes.Name = "btnEpisodes";
            this.btnEpisodes.Size = new System.Drawing.Size(78, 29);
            this.btnEpisodes.TabIndex = 0;
            this.btnEpisodes.Text = "Expand";
            this.btnEpisodes.UseVisualStyleBackColor = true;
            this.btnEpisodes.Visible = false;
            this.btnEpisodes.Click += new System.EventHandler(this.btnEpisodes_Click);
            // 
            // ctrlShowInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.Controls.Add(this.floShowInfo);
            this.Controls.Add(this.btnFavorite);
            this.Controls.Add(this.lblCtrlShowInfo);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ctrlShowInfo";
            this.Size = new System.Drawing.Size(957, 584);
            this.grpGeneral.ResumeLayout(false);
            this.grpGeneral.PerformLayout();
            this.pnlGeneral.ResumeLayout(false);
            this.floShowInfo.ResumeLayout(false);
            this.grpEpisodes.ResumeLayout(false);
            this.grpEpisodes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblCtrlShowInfo;
        private System.Windows.Forms.Button btnFavorite;
        private System.Windows.Forms.GroupBox grpGeneral;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Panel pnlGeneral;
        private System.Windows.Forms.Label lblLastDate;
        private System.Windows.Forms.Label lblLastDateHead;
        private System.Windows.Forms.Label lblNextEpisode;
        private System.Windows.Forms.Label lblNextEpisodeHead;
        private System.Windows.Forms.Label lblGenres;
        private System.Windows.Forms.Label lblNextDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.Label lblAirtime;
        private System.Windows.Forms.Label lblAirday;
        private System.Windows.Forms.Label lblSeasons;
        private System.Windows.Forms.Label lblEnded;
        private System.Windows.Forms.Label lblStarted;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblNameHead;
        private System.Windows.Forms.Label lblGenresHead;
        private System.Windows.Forms.Label lblStartedHead;
        private System.Windows.Forms.Label lblEndedHead;
        private System.Windows.Forms.Label lblSeasonsHead;
        private System.Windows.Forms.Label lblAirdayHead;
        private System.Windows.Forms.Label lblEndDateHead;
        private System.Windows.Forms.Label lblAirtimeHead;
        private System.Windows.Forms.Label lblNextDateHead;
        private System.Windows.Forms.Label lblStatusHead;
        private System.Windows.Forms.Label lblCountryHead;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.FlowLayoutPanel floShowInfo;
        private System.Windows.Forms.GroupBox grpEpisodes;
        private System.Windows.Forms.Panel pnlEpisodes;
        private System.Windows.Forms.Button btnEpisodes;

    }
}
