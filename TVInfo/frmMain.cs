using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;

namespace TVInfo {

    public partial class frmMain : Form {

        private ctrlShowInfo showInfo = new ctrlShowInfo();
        private ctrlMovieInfo movieInfo = new ctrlMovieInfo();
        private ctrlSearch search = new ctrlSearch();
        private ctrlAbout about = new ctrlAbout();
        private ctrlCalendar calendar = new ctrlCalendar();
        private ctrlSettings settings = new ctrlSettings();
        private ctrlHome home = new ctrlHome();
        private ctrlFavorites favorites = new ctrlFavorites();
        private DateTime lastDate;

        List<TMDBShow> tmdbShows = Master.tmdbFavShows;
        List<TMDBMovie> tmdbMovies = Master.tmdbFavMovies;

        private int emailInterval = 7200000;

        public frmMain() {

            InitializeComponent();

            lastDate = DateTime.Now.Date;

            lblDate.Text = DateTime.Now.ToString("dddd MMMM dd, yyyy");

            favorites.refresh(true);

            home.setup();
            pnlMain.Controls.Add(home);

            timEmail.Interval = emailInterval;
            timEmail.Start();

            #if DEBUG
                notNotification.Text += " - DEBUG";
            #else
                
            #endif

        }

        private void refreshControl() {

            Control ctrl = pnlMain.Controls[0];
            Type ctrlType = ctrl.GetType();

            if (ctrlType == typeof(ctrlShowInfo))

                (ctrl as ctrlShowInfo).refresh();

            if (ctrlType == typeof(ctrlSearch))

                (ctrl as ctrlSearch).refresh();

            if (ctrlType == typeof(ctrlAbout))

                (ctrl as ctrlAbout).refresh();

            if (ctrlType == typeof(ctrlCalendar))

                (ctrl as ctrlCalendar).refresh();

            if (ctrlType == typeof(ctrlSettings))

                (ctrl as ctrlSettings).refresh();

            if (ctrlType == typeof(ctrlHome))

                (ctrl as ctrlHome).refresh();

            if (ctrlType == typeof(ctrlFavorites))

                (ctrl as ctrlFavorites).refresh(true);

            MessageBox.Show("Refresh Complete");

        }

        private void refreshLightControl() {

            Control ctrl = pnlMain.Controls[0];
            Type ctrlType = ctrl.GetType();

            if (ctrlType == typeof(ctrlShowInfo))

                (ctrl as ctrlShowInfo).refresh();

            if (ctrlType == typeof(ctrlSearch))

                (ctrl as ctrlSearch).refresh();

            if (ctrlType == typeof(ctrlAbout))

                (ctrl as ctrlAbout).refresh();

            if (ctrlType == typeof(ctrlCalendar))

                (ctrl as ctrlCalendar).refresh();

            if (ctrlType == typeof(ctrlSettings))

                (ctrl as ctrlSettings).refresh();

            if (ctrlType == typeof(ctrlHome))

                (ctrl as ctrlHome).refresh();

            if (ctrlType == typeof(ctrlFavorites))

                (ctrl as ctrlFavorites).refreshLight(true);

            MessageBox.Show("Refresh Complete");

        }

        public void displayShowInfo(Show show) {

            showInfo.setShow(show);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(showInfo);

        }

        public void displayShowInfo(TMDBShow show) {

            showInfo.setShow(show);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(showInfo);

        }

        public void displayMovieInfo(TMDBMovie movie) {

            movieInfo.setMovie(movie);
            pnlMain.Controls.Clear();
            pnlMain.Controls.Add(movieInfo);

        }

        private void sendEmail(string body) {

            string fromAddress = "";
            string fromPassword = "";
            string toAddress = "";

            TVInfoSettings settings = Master.settings;

            if (settings != null)
            {
                fromAddress = settings.FromAddress;
                fromPassword = settings.FromPassword;
                toAddress = settings.ToAddress;
            }
            else
            {
                return;
            }

            MailAddress mailFrom = new MailAddress(fromAddress, "From Name");
            MailAddress mailTo = new MailAddress(toAddress, "To Name");
            string subject = "Daily TV Shows Update";
            
            var smtp = new SmtpClient {

                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(mailFrom.Address, fromPassword),
                Timeout = 20000

            };

            bool success = false;
            int count = 1;
            int maxRetry = 3;
            int waitTime = 5; //Wait time in seconds

            while (!success && count <= maxRetry) {

                try {

                    using (var message = new MailMessage(mailFrom, mailTo) {

                        Subject = subject,
                        Body = body

                    })

                    smtp.Send(message);

                    success = true;

                } catch(Exception ex) {

                    Master.logWrite(this.Name, "Failed to send email: " + ex.Message + ".");
                
                }

                count++;

                if (count <= maxRetry && !success) {

                    Master.logWrite(this.Name, "Will retry sending email in " + waitTime + " seconds.");
                    Thread.Sleep(waitTime * 1000);
                
                }
            }

            //MessageBox.Show("Email Sent");
        
        }

        private string getEmailBody() {

            string yesterday = "---- YESTERDAY'S SHOWS -----\n";
            string today = "\n\n------- TODAY'S SHOWS -------\n";
            string tomorrow = "\n\n----- TOMORROW'S  SHOWS -----\n";
            string other = "\n\n-------- OTHER SHOWS --------\n";
            string upcoming = "\n\n------ UPCOMING MOVIES ------\n";
            string recent = "\n\n------- RECENT MOVIES -------\n";
            string body = "";

            DateTime date = DateTime.Now.Date;
            string dateYesterday = date.AddDays(-1).ToString("MM/dd/yyyy");
            string dateToday = date.ToString("MM/dd/yyyy");
            string dateTomorrow = date.AddDays(1).ToString("MM/dd/yyyy");

            tmdbShows.Sort((x, y) => string.Compare(replaceDate(x.nextDate, "R"), replaceDate(y.nextDate, "R")));
            tmdbShows.Reverse();

            foreach (TMDBShow show in tmdbShows) {

                if (show.lastDate == dateYesterday) {

                    yesterday += "\n" + show.name + "   -   Season " + show.number_of_seasons + " Episode " + show.lastEpisode;
                
                }

                if (show.nextDate == dateToday) {

                    today += "\n" + show.name + "   -   Season " + show.number_of_seasons + " Episode " + show.nextEpisode;

                }

                if (show.nextDate == dateTomorrow) {

                    tomorrow += "\n" + show.name + "   -   Season " + show.number_of_seasons + " Episode " + show.nextEpisode;

                }

                if (show.nextDate != dateYesterday && show.nextDate != dateToday && show.nextDate != dateTomorrow) {

                    other += "\n" + show.name + "   -   Season " + show.number_of_seasons + " Episode " + show.nextEpisode + " on " + show.nextDate;
                
                }

            }

            // Upcoming Movies
            tmdbMovies.Sort((x, y) => string.Compare(replaceDate(x.release_date, "U"), replaceDate(y.release_date, "U")));

            for (int i = 0; i < 5 && i < tmdbMovies.Count; i++) {
            
                TMDBMovie movie = tmdbMovies[i];

                upcoming += "\n" + movie.title + "   -   " + movie.release_date;
            
            }

            // Recent Movies
            tmdbMovies.Sort((x, y) => string.Compare(replaceDate(x.release_date, "R"), replaceDate(y.release_date, "R")));
            tmdbMovies.Reverse();

            int count = 0;

            foreach (TMDBMovie movie in tmdbMovies) {

                if (Master.isDate(movie.release_date) && Convert.ToDateTime(movie.release_date) <= DateTime.Now.Date) {

                    recent += "\n" + movie.title + "   -   " + movie.release_date;
                    count++;

                }

                if (count == 5) {

                    break;
                
                }
            
            }

            body = yesterday + today + tomorrow + upcoming + recent + other;

            return body;
                
        }

        public void stopResumeTimer(string action){

            int waitTime = 10;

            if (action == "Stop") {

                timEmail.Stop();
                timEmail.Interval = (waitTime * 60000);

            } else {

                timEmail.Start();
            
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

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {

            if (e.CloseReason == CloseReason.UserClosing) {

                notNotification.Visible = true;
                notNotification.Icon = SystemIcons.Application;

                notNotification.BalloonTipText = "Minimized";
                notNotification.BalloonTipTitle = "Your Application is Running in BackGround";
                notNotification.ShowBalloonTip(500);

                e.Cancel = true;
                this.Hide();

            }          

        }

        private void navTextColorChange(object sender, EventArgs e) {

            //ToolStripMenuItem tsmiNav = (ToolStripMenuItem)sender;

            //if (tsmiNav.ForeColor == Color.Gainsboro) {

            //    tsmiNav.ForeColor = Color.Black;

            //} else {

            //    tsmiNav.ForeColor = Color.Gainsboro;

            //}

            

        }

        private void sendEmailToolStripMenuItem_Click(object sender, EventArgs e) {

            //if (favorites.refresh(false)) {

                sendEmail(getEmailBody());
                Master.logWrite(this.Name, "Manual email request submitted.");
            
            //}
        }

        private void timEmail_Tick(object sender, EventArgs e) {

            string hour = DateTime.Now.ToString("HH");

            Master.logWrite(this.Name, "Checking last date to current date.");

            if (lastDate == null) {

                Master.logWrite(this.Name, "Last Date was NULL.");
                return;
            
            }

            Master.logWrite(this.Name, "Last Date: " + lastDate.ToShortDateString());

            if (lastDate != DateTime.Now.Date ) {

                Master.logWrite(this.Name, "Dates were different. Beginning email process.");

                lblDate.Text = DateTime.Now.ToString("dddd MMMM dd, yyyy");
                lastDate = DateTime.Now.Date;
                favorites.refresh(false);
                sendEmail(getEmailBody());

                Master.logWrite(this.Name, "Email Sent.");

                home.refresh();

            }else {

                Master.logWrite(this.Name, "Days were the same. Email not sent.");

            }

            timEmail.Interval = emailInterval;

        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e) {

            notNotification.Visible = true;
            notNotification.BalloonTipText = "Maximized";
            notNotification.BalloonTipTitle = "Application is Running in Foreground";
            notNotification.ShowBalloonTip(500);

            this.Show();

        }

        private void notNotification_Click(object sender, EventArgs e) {
            
            menMain.Show();

        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e) {

            Application.Exit();

        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e) {

            string url = @"http://api.themoviedb.org/3/search/tv?query=Haven&api_key=5ea215fca565c87f2551ca1de9cb4433";
            string content = "";

            content = Master.downloadText(url);

            TMDBQuery query = JsonConvert.DeserializeObject<TMDBQuery>(content);

            List<TMDBShow> shows = new List<TMDBShow>();

            foreach (JObject obj in query.results) {

                TMDBShow show = obj.ToObject<TMDBShow>();
                show.expandInfo();
                shows.Add(show);

                Console.WriteLine(show.ToString());

            }

            
            MessageBox.Show("DONE");
        }

        private void menuBar_OnClick(object sender, EventArgs e) {

            ToolStripMenuItem item = (ToolStripMenuItem)sender;

            string cmd = item.Text.ToUpper();

            switch (cmd) {

                case "REFRESH":
                    refreshControl();
                    break;

                case "REFRESH (LIGHT)":
                    refreshLightControl();
                    break;

                case "EXIT":

                    Application.Exit();
                    break;

                case "HOME":

                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(home);
                    break;

                case "FAVORITES":

                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(favorites);
                    // favorites.refresh();
                    break;

                case "CALENDAR":

                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(calendar);
                    break;

                case "SEARCH":

                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(search);
                    break;

                case "SHOW INFO":

                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(showInfo);
                    break;

                case "SETTINGS":

                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(settings);
                    break;

                case "ABOUT":

                    pnlMain.Controls.Clear();
                    pnlMain.Controls.Add(about);
                    break;

                default:

                    //Console.WriteLine("UNKNOWN MENU COMMAND");
                    break;

            }

        }

    }
}
