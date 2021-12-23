using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVInfo {

    public partial class ctrlHome : UserControl {

        List<Show> shows = Master.favShows;
        List<TMDBShow> tmdbShows = Master.tmdbFavShows;
        List<TMDBMovie> tmdbMovies = Master.tmdbFavMovies;

        public ctrlHome() {

            InitializeComponent();

        }

        public void setup() {

            findRecent();
            findUpcoming();

        }

        public void refresh() {

            findRecent();
            findUpcoming();

        }

        private void findRecent() {

            int num = 5;

            tmdbShows.Sort((x, y) => string.Compare(replaceDate(x.lastDate, "R"), replaceDate(y.lastDate, "R")));
            tmdbShows.Reverse();

            tmdbMovies.Sort((x, y) => string.Compare(replaceDate(x.release_date, "R"), replaceDate(y.release_date, "R")));
            tmdbMovies.Reverse();

            if (tmdbShows.Count >= num) {

                ctrRecShow1.update(tmdbShows[0].name, tmdbShows[0].lastDate);
                ctrRecShow2.update(tmdbShows[1].name, tmdbShows[1].lastDate);
                ctrRecShow3.update(tmdbShows[2].name, tmdbShows[2].lastDate);
                ctrRecShow4.update(tmdbShows[3].name, tmdbShows[3].lastDate);
                ctrRecShow5.update(tmdbShows[4].name, tmdbShows[4].lastDate);

                ctrRecShow1.Visible = true;
                ctrRecShow2.Visible = true;
                ctrRecShow3.Visible = true;
                ctrRecShow4.Visible = true;
                ctrRecShow5.Visible = true;
            
            }

            if (tmdbMovies.Count >= num) {

                ctrRecMovie1.update(tmdbMovies[0].title, tmdbMovies[0].release_date);
                ctrRecMovie2.update(tmdbMovies[1].title, tmdbMovies[1].release_date);
                ctrRecMovie3.update(tmdbMovies[2].title, tmdbMovies[2].release_date);
                ctrRecMovie4.update(tmdbMovies[3].title, tmdbMovies[3].release_date);
                ctrRecMovie5.update(tmdbMovies[4].title, tmdbMovies[4].release_date);

                if (replaceDate(ctrRecMovie1.getDate(), "R") != "00000001")
                    ctrRecMovie1.Visible = true;

                if (replaceDate(ctrRecMovie2.getDate(), "R") != "00000001")
                    ctrRecMovie2.Visible = true;

                if (replaceDate(ctrRecMovie3.getDate(), "R") != "00000001")
                    ctrRecMovie3.Visible = true;

                if (replaceDate(ctrRecMovie4.getDate(), "R") != "00000001")
                    ctrRecMovie4.Visible = true;

                if (replaceDate(ctrRecMovie5.getDate(), "R") != "00000001")
                    ctrRecMovie5.Visible = true;

            }

        }

        private void findUpcoming() {

            int num = 5;

            tmdbShows.Sort((x, y) => string.Compare(replaceDate(x.nextDate, "U"), replaceDate(y.nextDate, "U")));
            tmdbMovies.Sort((x, y) => string.Compare(replaceDate(x.release_date, "U"), replaceDate(y.release_date, "U")));

            if (tmdbShows.Count >= num) {

                ctrUpShow1.update(tmdbShows[0].name, tmdbShows[0].nextDate);
                ctrUpShow2.update(tmdbShows[1].name, tmdbShows[1].nextDate);
                ctrUpShow3.update(tmdbShows[2].name, tmdbShows[2].nextDate);
                ctrUpShow4.update(tmdbShows[3].name, tmdbShows[3].nextDate);
                ctrUpShow5.update(tmdbShows[4].name, tmdbShows[4].nextDate);

                ctrUpShow1.Visible = true;
                ctrUpShow2.Visible = true;
                ctrUpShow3.Visible = true;
                ctrUpShow4.Visible = true;
                ctrUpShow5.Visible = true;

            }

            if (tmdbMovies.Count >= num) {

                ctrUpMovie1.update(tmdbMovies[0].title, tmdbMovies[0].release_date);
                ctrUpMovie2.update(tmdbMovies[1].title, tmdbMovies[1].release_date);
                ctrUpMovie3.update(tmdbMovies[2].title, tmdbMovies[2].release_date);
                ctrUpMovie4.update(tmdbMovies[3].title, tmdbMovies[3].release_date);
                ctrUpMovie5.update(tmdbMovies[4].title, tmdbMovies[4].release_date);

                if (replaceDate(ctrUpMovie1.getDate(), "U") != "99999999")
                    ctrUpMovie1.Visible = true;

                if (replaceDate(ctrUpMovie2.getDate(), "U") != "99999999")
                    ctrUpMovie2.Visible = true;

                if (replaceDate(ctrUpMovie3.getDate(), "U") != "99999999")
                    ctrUpMovie3.Visible = true;

                if (replaceDate(ctrUpMovie4.getDate(), "U") != "99999999")
                    ctrUpMovie4.Visible = true;

                if (replaceDate(ctrUpMovie5.getDate(), "U") != "99999999")
                    ctrUpMovie5.Visible = true;

            }

        }

        private string replaceDate(string strDate, string type) {

            string txt = "";

            txt = strDate;
            txt = txt.Replace("*", "");

            if (Master.isDate(txt)) {

                DateTime date = Convert.ToDateTime(txt);
                txt = date.ToString("yyyyMMdd");

                if (type == "R" && date > DateTime.Now) {

                    txt = "00000001";

                } else if (type == "U" && date <= DateTime.Now) {

                    txt = "99999999";
                
                }

            }

            if (txt == "Unknown" || txt.Trim() == "") {

                if (type == "R") {

                    txt = "00000001";

                } else if (type == "U") {

                    txt = "99999999";
                
                }
            
            }

            return txt; 

        }

    }
}
