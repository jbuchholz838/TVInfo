using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TVInfo {

    public partial class ctrlShowInfo : UserControl {

        private Show show;
        private TMDBShow tmdbShow;
        //string favoritesPath = "favorites.dat";     // LEGACY
        string favoritesPath = "favorites_TVDB.dat";

        public ctrlShowInfo(Show show) {

            InitializeComponent();

            this.show = show;
            populate();
            checkFavorite();

        }

        public ctrlShowInfo() {


            InitializeComponent();

        }

        public void setShow(Show show) {

            this.show = show;
            populate();

        }

        public void setShow(TMDBShow show) {

            this.tmdbShow = show;
            tmdbPopulate();
            checkFavorite();
        
        }

        private void populate() {

            lblName.Text = show.name;
            lblCountry.Text = show.country;
            lblStatus.Text = show.status;
            lblStarted.Text = show.startDate;
            lblEnded.Text =  show.endDate;
            lblSeasons.Text = show.numSeasons.ToString();
            lblAirday.Text = show.airDay;
            lblAirtime.Text = show.convertTime();
            lblEndDate.Text = show.runtime;
            lblNextDate.Text = show.nextDate;
            lblLastDate.Text = show.lastDate;
            lblNextEpisode.Text = show.nextEpisode.ToString();
            lblGenres.Text = show.displayGenres();

            checkFavorite();

        }

        private void tmdbPopulate() {

            lblName.Text = tmdbShow.name + " (" + tmdbShow.id + ")";
            lblCountry.Text = tmdbShow.country;
            lblStatus.Text = tmdbShow.status;
            lblStarted.Text = tmdbShow.first_air_date;
            lblEnded.Text = tmdbShow.last_air_date;
            lblSeasons.Text = tmdbShow.seasons.Count().ToString();
            lblAirday.Text = tmdbShow.dayOfWeek;
            lblAirtime.Text = tmdbShow.endDate;
            lblEndDate.Text = tmdbShow.runTime;
            lblNextDate.Text = tmdbShow.nextDate;
            lblLastDate.Text = tmdbShow.lastDate;
            lblNextEpisode.Text = tmdbShow.nextEpisode;
            lblGenres.Text = tmdbShow.genre;

        }

        private void checkFavorite() {

            if (File.Exists(favoritesPath) && tmdbShow != null) {

                StreamReader sr = new StreamReader(favoritesPath);

                while (!sr.EndOfStream) {

                    if (sr.ReadLine().Contains(tmdbShow.id.ToString())) {

                        btnFavorite.Tag = "Remove";
                        btnFavorite.Text = "Remove Favorite";
                        sr.Close();
                        break;

                    } else {

                        btnFavorite.Tag = "Add";
                        btnFavorite.Text = "Add Favorite";
                    
                    }
                }

                sr.Close();

            }
        }

        public void refresh() {

            checkFavorite();
            tmdbPopulate();

        }

        private void addFavorite() {

            if (File.Exists(favoritesPath)) {

                StreamWriter sw = new StreamWriter(favoritesPath, true);

                sw.Write("\r\n" + "TV|" + tmdbShow.id);

                sw.Close();

                Master.tmdbFavShows.Add(tmdbShow);

                MessageBox.Show("Show Added to Favorites List.");

            }
        }

        private void removeFavorite() {

            string txt = "";

            if (File.Exists(favoritesPath)) {

                StreamReader sr = new StreamReader(favoritesPath);

                while (!sr.EndOfStream) {

                    string line = sr.ReadLine();

                    if (line != "" && (line.Substring(0, 2) == "//" || !line.Contains(tmdbShow.id.ToString()))) {

                        txt += line + "\r\n";
                    
                    }
                }

                sr.Close();

                StreamWriter sw = new StreamWriter(favoritesPath);

                sw.WriteLine(txt);

                sw.Close();

                Master.tmdbFavShows.Remove(tmdbShow);

                btnFavorite.Tag = "Add";
                btnFavorite.Text = "Add Favorite";

            }
        }

        private void btnFavorite_Click(object sender, EventArgs e) {

            if (btnFavorite.Tag.ToString() == "Add") {     // Adds show to favorites list

                addFavorite();
                btnFavorite.Tag = "Remove";
                btnFavorite.Text = "Remove Favorite";


            } else if (btnFavorite.Tag.ToString() == "Remove") {    // Removes show from favorites list

                removeFavorite();
                btnFavorite.Tag = "Add";
                btnFavorite.Text = "Add Favorite";

            }
        }

        private void btnGeneral_Click(object sender, EventArgs e) {

            Button btn = (Button)sender;

            if (btn.Text == "Expand") {

                grpGeneral.Size = grpGeneral.MaximumSize;
                pnlGeneral.Size = pnlGeneral.MaximumSize;
                btn.Text = "Collapse";

            } else {

                grpGeneral.Size = grpGeneral.MinimumSize;
                pnlGeneral.Size = pnlGeneral.MinimumSize;
                btn.Text = "Expand";

            }
        }

        private void btnEpisodes_Click(object sender, EventArgs e) {

            Button btn = (Button)sender;

            if (btn.Text == "Expand") {

                grpEpisodes.Size = grpEpisodes.MaximumSize;
                pnlEpisodes.Size = pnlEpisodes.MaximumSize;
                btn.Text = "Collapse";

            } else {

                grpEpisodes.Size = grpEpisodes.MinimumSize;
                pnlEpisodes.Size = pnlEpisodes.MinimumSize;
                btn.Text = "Expand";

            }

        }

    }
}
