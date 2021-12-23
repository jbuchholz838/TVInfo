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
using System.Xml;
using System.Xml.Linq;

using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;

namespace TVInfo {

    public partial class ctrlFavorites : UserControl {

        BackgroundWorker bgWorker = new BackgroundWorker();

        //string favoritesPath = "favorites.dat";       // LEGACY
        string favoritesPath = "favorites_TVDB.dat";

        // TV Rage
        XmlDocument xdoc = new XmlDocument();
        List<string> showIDs = new List<string>();
        List<Show> shows = Master.favShows;
        ListViewColumnSorter lvwColumnSorter;

        // The Movie DB
        List<TMDBShow> tmdbShows = Master.tmdbFavShows;
        List<TMDBMovie> tmdbMovies = Master.tmdbFavMovies;
        List<string> movieIDs = new List<string>();
        List<Favorite> tmdbFavorites = new List<Favorite>();

        frmProgressBar pgbStatus;
        int statusNum = 0;
        bool showPrompt = true;
        bool cancel = false;

        public ctrlFavorites() {

            InitializeComponent();

            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;

            //bgWorker.RunWorkerAsync();
            //setup();

        }

        public bool refresh(bool showPrompt) {

            lstTV.Items.Clear();
            lstMovie.Items.Clear();

            showIDs.Clear();
            movieIDs.Clear();

            tmdbShows.Clear();
            tmdbMovies.Clear();
            tmdbFavorites.Clear();

            shows.Clear();

            statusNum = 0;
            cancel = false;

            this.showPrompt = showPrompt;

            findFavorites();

            pgbStatus = new frmProgressBar(tmdbFavorites.Count * 2);
            pgbStatus.update(0, "Finding Favorite Shows...");
            
            bgWorker.RunWorkerAsync(true);

            if (!showPrompt) {

                pgbStatus.Visible = false;
            
            }

            if (pgbStatus.ShowDialog() == DialogResult.Cancel) {

                Master.logWrite(this.Name, "Favorites refresh cancelled.");
                cancel = true;
            
            }

            //setup();

            return true;

        }

        public bool refreshLight(bool showPrompt) {

            lstTV.Items.Clear();
            lstMovie.Items.Clear();

            statusNum = 0;
            cancel = false;

            this.showPrompt = showPrompt;

            pgbStatus = new frmProgressBar(tmdbFavorites.Count * 2);
            pgbStatus.update(0, "Finding Favorite Shows...");

            bgWorker.RunWorkerAsync(false);

            if (!showPrompt) {

                pgbStatus.Visible = false;

            }

            if (pgbStatus.ShowDialog() == DialogResult.Cancel) {

                Master.logWrite(this.Name, "Favorites refresh cancelled.");
                cancel = true;

            }

            return true;
        
        }

        private void ctrlFavorites_Load(object sender, EventArgs e) {

            //Console.WriteLine("FAVORITES");

        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {    //Send True/False to indicate Loading Favorites from Server

            bool loadFavorites = true;

            if (e.Argument != null) {

                bool.TryParse(e.Argument.ToString(), out loadFavorites);
            
            }

            tmdbSetup(loadFavorites);

        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            
            string text = "";

            if (e.UserState != null) {

                if (typeof(ListViewItem) == e.UserState.GetType()) {

                    text = "Displayed Favorite " + (statusNum - tmdbFavorites.Count) + " / " + tmdbFavorites.Count + ": " + (e.UserState as ListViewItem).SubItems[0].Text;

                } else {

                    text = e.UserState.ToString();

                }

            }

            if (pgbStatus != null) {

                pgbStatus.update(e.ProgressPercentage, text);

            }

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {

            if (e.Error != null) {

                Console.WriteLine(e.Error.Message);
            
            }

            Console.WriteLine("DONE");
            pgbStatus.close();

        }

        private void setup() {
            
            xdoc = new XmlDocument();

            if (!loadShows()) {

                MessageBox.Show("Failed to load favorites from server.", "Favorites Load");
                return;

            }

            displayShows();

            if (this.InvokeRequired) {

                this.Invoke(new attachSorterDelegate(attachSorter), new object[] {  });

            } else {

                lvwColumnSorter = new ListViewColumnSorter();
                lstTV.ListViewItemSorter = lvwColumnSorter;

            }

            //lstFavorites.Visible = true;
            
        }

        private void tmdbSetup(bool loadFavorites) {

            DateTime start = DateTime.Now;

            Console.WriteLine("\nBegin Load Favorites: " + start);

            try {

                if (loadFavorites && !tmdbLoadFavorites()) {

                    MessageBox.Show("Failed to load favorites from server.", "Favorites Load");
                    return;

                } else if (!loadFavorites) {

                    statusNum = tmdbMovies.Count() + tmdbShows.Count();
                
                }

            } catch (Exception ex) {

                MessageBox.Show("Encountered an error while loading favorites from server. More information has been logged.", "Favorites Load");
                Master.logWrite(this.Name, "Encountered an error while loading favorites from server: " + ex.Message);
            
            }

            tmdbDisplayShows();
            tmdbDisplayMovies();

            if (this.InvokeRequired) {

                this.Invoke(new attachSorterDelegate(attachSorter), new object[] { });

            } else {

                lvwColumnSorter = new ListViewColumnSorter();
                lstTV.ListViewItemSorter = lvwColumnSorter;

            }

            DateTime end = DateTime.Now;
            Console.WriteLine("\nEnd Load Favorites: " + end + " (Elapsed: " + (end - start).ToString(@"hh\:mm\:ss") + ")");
        
        }

        private void findFavorites() {

            showIDs.Clear();
            tmdbFavorites.Clear();

            if (File.Exists(favoritesPath)){

                StreamReader sr = new StreamReader(favoritesPath);

                while (!sr.EndOfStream) {

                    string line = sr.ReadLine();

                    if (line.Length > 2 && line.Substring(0, 2) != "//") {

                        Favorite fav = new Favorite(line);

                        tmdbFavorites.Add(fav);
                            
                        
                    }
                }

                sr.Close();
            }
        }

        private bool loadShows() {

            shows.Clear();

            foreach (string showID in showIDs) {

                if (isNumber(showID)){

                    int id = Convert.ToInt32(showID);

                    try {

                        xdoc.Load(Master.getShowInfoURL(id));

                    } catch {

                        return false;

                    }
                    

                    Show newShow = findShow();

                    if (newShow != null) {

                        statusNum++;
                        bgWorker.ReportProgress(statusNum, "Loaded Show " + statusNum + "/" + showIDs.Count + ": " + newShow.name);

                    }

                }
            }

            if (shows.Count == 0)

                return false;

            else

                return true;

        }

        private bool tmdbLoadFavorites() {

            tmdbShows.Clear();

            foreach (Favorite fav in tmdbFavorites) {

                string url = "";
                string id = fav.id;
                string content = "";

                if (fav.type == "TV") {
                
                    url = Master.getTVInfoURL(id);

                    content = Master.downloadText(url);

                    //TMDBShow show = JsonConvert.DeserializeObject<TMDBShow>(content);

                    TMDBShow show = Master.jsonDeserializeObject<TMDBShow>(content);

                    if (show != null) {

                        show.expandInfo();
                        tmdbShows.Add(show);

                        statusNum++;
                        bgWorker.ReportProgress(statusNum, "Loaded Favorite " + statusNum + "/" + tmdbFavorites.Count + ": " + show.name);

                    }
                
                }else if (fav.type == "MOVIE"){

                    url = Master.getMovieInfoURL(id);

                    content = Master.downloadText(url);

                    //TMDBMovie movie = JsonConvert.DeserializeObject<TMDBMovie>(content);
                    TMDBMovie movie = Master.jsonDeserializeObject<TMDBMovie>(content);

                    if (movie != null) {

                        movie.expandInfo();
                        tmdbMovies.Add(movie);

                        statusNum++;
                        bgWorker.ReportProgress(statusNum, "Loaded Favorite " + statusNum + "/" + tmdbFavorites.Count + ": " + movie.title);

                    }

                }

                if (cancel) {

                    break;
                
                }         
            }

            if (tmdbShows.Count == 0 && tmdbMovies.Count == 0)

                return false;

            else

                return true;

        }

        private Show findShow() {

            foreach (XmlNode node in xdoc.ChildNodes) {

                if (node.Name == "Showinfo") {

                    Show newShow = new Show(node);

                    shows.Add(newShow);

                    //foreach (XmlNode sNode in node.ChildNodes) {

                    //    shows.Add(new Show(sNode));

                    //}

                    return newShow;

                }
            }

            return null;

        }

        private void displayShows() {

            foreach (Show show in shows) {

                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem sub;

                sub = new ListViewItem.ListViewSubItem(item, show.name);
                sub.Tag = show.name;
                item.SubItems[0] = sub;

                sub = new ListViewItem.ListViewSubItem(item, show.status);
                sub.Tag = show.status;
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.lastDate);
                sub.Tag = getDateSort(show.lastDate);
                //item.BackColor = getDateHighlight(show.lastDate);
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.nextDate);
                sub.Tag = getDateSort(show.nextDate);
                //item.BackColor = getDateHighlight(show.nextDate);
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.airDay);
                sub.Tag = getDayOfWeekSort(show.airDay);
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.nextSeason.ToString());
                sub.Tag = getNumberSort(show.nextSeason.ToString());
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.nextEpisode.ToString());
                sub.Tag = getNumberSort(show.nextEpisode.ToString());
                item.SubItems.Add(sub);

                //sub = new ListViewItem.ListViewSubItem(item, show.convertTime());
                //sub.Tag = getNumberSort(show.airTime);
                //item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.endDate);
                sub.Tag = getDateSort(show.endDate);
                item.SubItems.Add(sub);

                item.Tag = show.showId;
                item.BackColor = getDateHighlight(show.lastDate, show.nextDate);

                statusNum++;
                bgWorker.ReportProgress(statusNum, item);

                Thread.Sleep(150);
            }
        }

        private void tmdbDisplayShows() {

            foreach (TMDBShow show in tmdbShows) {

                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem sub;

                sub = new ListViewItem.ListViewSubItem(item, show.name);
                sub.Tag = show.name;
                item.SubItems[0] = sub;

                sub = new ListViewItem.ListViewSubItem(item, show.status);
                sub.Tag = show.status;
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.lastDate);
                sub.Tag = getDateSort(show.lastDate);
                //item.BackColor = getDateHighlight(show.lastDate);
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.nextDate);
                sub.Tag = getDateSort(show.nextDate);
                //item.BackColor = getDateHighlight(show.nextDate);
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.dayOfWeek);
                sub.Tag = getDayOfWeekSort(show.dayOfWeek);
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.number_of_seasons.ToString());
                sub.Tag = getNumberSort(show.number_of_seasons.ToString());
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.nextEpisode);
                sub.Tag = getNumberSort(show.nextEpisode);
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, show.seasonEpCount.ToString());
                sub.Tag = getNumberSort(show.seasonEpCount.ToString());
                item.SubItems.Add(sub);

                item.Tag = show.id;
                item.BackColor = getDateHighlight(show.lastDate, show.nextDate);

                statusNum++;
                bgWorker.ReportProgress(statusNum, item);

                if (lstMovie.InvokeRequired) {

                    this.Invoke(new addTVItemDelegate(addTVItem), new object[] { item });

                } else {

                    addTVItem(item);

                }
                
                //lstTV.Items.Add(item);

                Thread.Sleep(150);
            }
        
        }

        private void tmdbDisplayMovies() {

            foreach (TMDBMovie movie in tmdbMovies) {

                ListViewItem item = new ListViewItem();
                ListViewItem.ListViewSubItem sub;

                sub = new ListViewItem.ListViewSubItem(item, movie.title);
                sub.Tag = movie.title;
                item.SubItems[0] = sub;

                sub = new ListViewItem.ListViewSubItem(item, movie.release_date);
                sub.Tag = getDateSort(movie.release_date);
                item.SubItems.Add(sub);

                //sub = new ListViewItem.ListViewSubItem(item, movie.country);
                //sub.Tag = movie.country;
                //item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, movie.genre);
                sub.Tag = movie.genre;
                item.SubItems.Add(sub);

                sub = new ListViewItem.ListViewSubItem(item, movie.length);
                sub.Tag = getNumberSort(movie.runtime.ToString());
                item.SubItems.Add(sub);

                item.Tag = movie.id;

                statusNum++;
                bgWorker.ReportProgress(statusNum, item);

                if (lstMovie.InvokeRequired) {

                    this.Invoke(new addMovieItemDelegate(addMovieItem), new object[] {item});

                }else {

                    addMovieItem(item);

                }

                //lstMovie.Items.Add(item);

                Thread.Sleep(150);
            }
        
        }

        private delegate void clearListDelegate();
        private void clearList() {

            lstTV.Clear();
            Console.WriteLine("Cleared Show from Favorites");
        }

        private delegate void addTVItemDelegate(ListViewItem item);
        private void addTVItem(ListViewItem item) {

            lstTV.Items.Add(item);

        }

        private delegate void addMovieItemDelegate(ListViewItem item);
        private void addMovieItem(ListViewItem item) {

            lstMovie.Items.Add(item);

        }

        private delegate void attachSorterDelegate();
        private void attachSorter() {

            lvwColumnSorter = new ListViewColumnSorter();
            lstTV.ListViewItemSorter = lvwColumnSorter;

        }

        private string getDayOfWeekSort(string dayOfWeek) {

            string sortStr = "";

            switch (dayOfWeek) {

                case "Sunday":

                    sortStr = "1";
                    break;

                case "Monday":

                    sortStr = "2";
                    break;

                case "Tuesday":

                    sortStr = "3";
                    break;

                case "Wednesday":

                    sortStr = "4";
                    break;

                case "Thursday":

                    sortStr = "5";
                    break;

                case "Friday":

                    sortStr = "6";
                    break;

                case "Saturday":

                    sortStr = "7";
                    break;

                default:

                    sortStr = "8";
                    break;

            }

            return sortStr;

        }

        private string getDateSort(string dateStr) {

            string sortStr = "";
            dateStr = dateStr.Replace("*", "");

            if (isDate(dateStr)) {

                DateTime date;
                DateTime.TryParse(dateStr, out date);

                //sortStr = date.Year.ToString("yyyy") + date.Month.ToString("MM") + date.Day.ToString("dd");
                sortStr = date.ToString("yyyyMMdd");
                //Console.WriteLine("Sort String: " + sortStr + " for Date String: " + dateStr);

            } else {

                sortStr = "99999999";

            }
            
            return sortStr;

        }

        private string getNumberSort(string nextEpisode) {

            string sortStr = "";
            string trailing = "00000";

            if (isNumber(nextEpisode)) {

                sortStr = trailing + nextEpisode;
                sortStr = sortStr.Substring(sortStr.Length - trailing.Length, trailing.Length);

            } else {

                sortStr = nextEpisode;

            }            

            return sortStr;
        }

        private string getTimeSort(string time) {

            // Time must be in MM:SS format
            string sortStr = "";

            sortStr = time.Replace(":", "");

            return sortStr;

        }

        private Color getDateHighlight(string dateStr) {

            Color clr = Color.White;
            string compDate = DateTime.Now.ToShortDateString();
            string lastDate = DateTime.Now.Date.AddDays(-1).ToShortDateString();
            //compDate = "1/9/2014";
            lastDate = "12/16/2013";
            DateTime date;

            if (isDate(dateStr)) {

                DateTime.TryParse(dateStr, out date);
                string dateCompStr = date.ToShortDateString();

                if (dateCompStr == compDate)

                    clr = Color.Gold;

                else if (dateCompStr == lastDate)

                    clr = Color.PaleGoldenrod;

            }
            //Console.WriteLine(dateStr + " to " + compDate + " " + clr.Name);
            return clr;

        }

        private Color getDateHighlight(string lastDate, string nextDate) {

            Color clr = Color.White;
            string today = DateTime.Now.ToShortDateString();
            string yesterday = DateTime.Now.Date.AddDays(-1).ToShortDateString();
            //today = "1/9/2014";   // TEST Value
            //yesterday = "12/16/2013";   // TEST Value
            DateTime date;

            if (isDate(lastDate)) {

                DateTime.TryParse(lastDate, out date);
                string lastDateStr = date.ToShortDateString();

                if (lastDateStr == yesterday)

                    clr = Color.PaleGoldenrod;

            }

            if (isDate(nextDate)) {

                DateTime.TryParse(nextDate, out date);
                string nextDateStr = date.ToShortDateString();

                if (nextDateStr == today)

                    clr = Color.Gold;

            }

            //Console.WriteLine(dateStr + " to " + compDate + " " + clr.Name);
            return clr;

        }

        private bool isNumber(string str) {

            double Num;
            bool isNum = double.TryParse(str, out Num);

            if (isNum)

                return true;

            else

                return false;

        }

        private bool isDate(string str) {

            DateTime date;
            bool isDate = DateTime.TryParse(str, out date);

            if (isDate)

                return true;

            else

                return false;

        }

        private void sortShowName() {



        }

        private void sortStatus() {



        }

        private void sortAirDay() {



        }

        private void sortNextDate() {



        }

        private void sortNextEpisode() {



        }

        private void sortSeasons() {



        }

        private void sortAirTime() {



        }

        private void lstFavorites_ColumnClick(object sender, ColumnClickEventArgs e) {
            
            Console.WriteLine("Col click");

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn) {

                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending) {

                    lvwColumnSorter.Order = SortOrder.Descending;

                } else {

                    lvwColumnSorter.Order = SortOrder.Ascending;

                }

            } else {

                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;

            }

            // Perform the sort with these new sort options.
            lstTV.Sort();

        }

        private void lstMovie_ColumnClick(object sender, ColumnClickEventArgs e) {

            Console.WriteLine("Col click");

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvwColumnSorter.SortColumn) {

                // Reverse the current sort direction for this column.
                if (lvwColumnSorter.Order == SortOrder.Ascending) {

                    lvwColumnSorter.Order = SortOrder.Descending;

                } else {

                    lvwColumnSorter.Order = SortOrder.Ascending;

                }

            } else {

                // Set the column number that is to be sorted; default to ascending.
                lvwColumnSorter.SortColumn = e.Column;
                lvwColumnSorter.Order = SortOrder.Ascending;

            }

            // Perform the sort with these new sort options.
            lstMovie.Sort();

        }

        private void lstFavorites_DoubleClick(object sender, EventArgs e) {

            ListViewItem item = (sender as ListView).SelectedItems[0];

            foreach (Show show in shows) {

                if (show.showId == item.Tag.ToString()) {

                    frmMain frm = (frmMain)this.Parent.Parent;
                    frm.displayShowInfo(show);
                    return;

                }
            }

            foreach (TMDBShow show in tmdbShows) {

                if (show.id.ToString() == item.Tag.ToString()) {

                    frmMain frm = (frmMain)this.Parent.Parent;
                    frm.displayShowInfo(show);
                    return;

                }
            }

            foreach (TMDBMovie movie in tmdbMovies) {

                if (movie.id.ToString() == item.Tag.ToString()) {

                    frmMain frm = (frmMain)this.Parent.Parent;
                    frm.displayMovieInfo(movie);
                    return;

                }
            
            }

        }

        private void btnExport_Click(object sender, EventArgs e) {

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Comma-Separated File|*.csv|Text File|*.txt|All Files|*.*";
            sfd.FilterIndex = 1;


            if (sfd.ShowDialog() == DialogResult.OK) {

                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.AutoFlush = true;

                string txt = "";

                foreach (ColumnHeader col in lstTV.Columns) {

                    txt += col.Text + ",";

                }

                txt = txt.Substring(0, txt.Length - 1);
                sw.WriteLine(txt);


                foreach (ListViewItem lvi in lstTV.Items) {

                    txt = "";

                    foreach (ListViewItem.ListViewSubItem sub in lvi.SubItems) {

                        txt += sub.Text + ",";

                    }

                    txt = txt.Substring(0, txt.Length - 1);

                    sw.WriteLine(txt);

                }

                sw.Close();
                MessageBox.Show("List Successfully Exported.", "Export");

            }
        }
    
    }
}
