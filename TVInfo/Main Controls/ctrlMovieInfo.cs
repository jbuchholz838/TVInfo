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

    public partial class ctrlMovieInfo : UserControl {

        private TMDBMovie movie;
        string favoritesPath = "favorites_TVDB.dat";

        public ctrlMovieInfo() {

            InitializeComponent();

        }

        public ctrlMovieInfo(TMDBMovie movie) {

            InitializeComponent();

            this.movie = movie;
            populate();
            checkFavorite();

        }

        public void setMovie(TMDBMovie movie) {

            this.movie = movie;
            populate();
        
        }

        private void populate() {

            propTitle.update("Movie Title:", movie.title + " (" + movie.id + ")");

            checkFavorite();

        }

        private void checkFavorite() {

            if (File.Exists(favoritesPath)) {

                StreamReader sr = new StreamReader(favoritesPath);

                while (!sr.EndOfStream) {

                    if (sr.ReadLine().Contains(movie.id.ToString())) {

                        btnFavorite.Tag = "Remove";
                        btnFavorite.Text = "Remove Favorite";
                        sr.Close();
                        break;

                    }
                }

                sr.Close();

            }
        }

        public void refresh() {

            checkFavorite();

        }

        private void addFavorite() {

            if (File.Exists(favoritesPath)) {

                StreamWriter sw = new StreamWriter(favoritesPath, true);

                sw.Write("\r\n" + "MOVIE|" + movie.id);

                sw.Close();
                MessageBox.Show("Show Added to Favorites List.");

            }
        }

        private void removeFavorite() {

            string txt = "";

            if (File.Exists(favoritesPath)) {

                StreamReader sr = new StreamReader(favoritesPath);

                while (!sr.EndOfStream) {

                    string line = sr.ReadLine();

                    if (line.Substring(0, 2) == "//" || !line.Contains(movie.id.ToString())) {

                        txt += line + "\r\n";

                    }
                }

                sr.Close();

                StreamWriter sw = new StreamWriter(favoritesPath);

                sw.WriteLine(txt);

                sw.Close();

                btnFavorite.Tag = "Add";
                btnFavorite.Text = "Add Favorite";

            }
        }

        private void btnFavorite_Click(object sender, EventArgs e) {

            if (btnFavorite.Tag.ToString() == "Add") {     // Adds show to favorites list

                addFavorite();

            } else {    // Removes show from favorites list

                removeFavorite();

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
    }
}
