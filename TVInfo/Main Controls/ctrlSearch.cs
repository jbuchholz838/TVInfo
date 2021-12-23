using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TVInfo {

    public partial class ctrlSearch : UserControl {

        BackgroundWorker bgWorker = new BackgroundWorker();

        // TV RAGE PARAMETERS
        XmlDocument xdoc = new XmlDocument();
        List<XmlNode> showNodes = new List<XmlNode>();
        List<Show> shows = new List<Show>();

        // THE MOVIE DB PARAMETERS
        List<TMDBShow> tmdbShows = new List<TMDBShow>();
        List<TMDBMovie> tmdbMovies = new List<TMDBMovie>();


        // TV RAGE METHODS
        public ctrlSearch() {

            InitializeComponent();
            txtSearch.Focus();

            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += bgWorker_DoWork;
            bgWorker.ProgressChanged += bgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += bgWorker_RunWorkerCompleted;

        }

        private void search() {

            lblLoading.Visible = true;

            showNodes.Clear();
            shows.Clear();
            lstResults.Items.Clear();

            bgWorker.RunWorkerAsync();

        }

        public void refresh() {



        }

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {

            string url = Master.getSearchURL(txtSearch.Text);

           // xdoc.Load("http://services.tvrage.com/feeds/full_search.php?show=Buffy");
            xdoc.Load(url);

            try {

                displayResults();

            } catch (Exception ex) {

                Console.WriteLine(ex.Message + "   -   " + ex.Source + "    -   " + ex.StackTrace);

            }

        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {

            

        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {

            if (e.Error != null) {

                Console.WriteLine(e.Error.Message);

            }

            lblLoading.Visible = false;
            Console.WriteLine("DONE");

        }

        private void findShows() {

            foreach (XmlNode node in xdoc.ChildNodes) {

                if (node.Name == "Results") {

                    foreach (XmlNode sNode in node.ChildNodes) {

                        showNodes.Add(sNode);

                    }

                    return;

                }
            }
        }

        private void displayResults() {

            findShows();

            foreach(XmlNode node in showNodes){

                shows.Add(new Show(node));

            }

            foreach (Show show in shows) {

                //Console.WriteLine("\n\n" + show.toString());
                //txtResults.Text += show.toString() + Environment.NewLine + Environment.NewLine;
                ListViewItem item = new ListViewItem();
                item.SubItems[0] = new ListViewItem.ListViewSubItem(item, show.name);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, show.country));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, show.status));
                item.Tag = show.showId;
                lstResults.Items.Add(item);
            }
        }

        // THE MOVIE DB METHODS
        private void tmdbSearch() {
            
            string url = getURL();
            string content = "";

            tmdbShows.Clear();
            tmdbMovies.Clear();
            lstResults.Items.Clear();

            content = Master.downloadText(url);

            TMDBQuery query = JsonConvert.DeserializeObject<TMDBQuery>(content);

            if (cboSearchType.Text.Contains("TV - ")) {             // Search type set to TV

                foreach (JObject obj in query.results) {

                    TMDBShow show = obj.ToObject<TMDBShow>();
                    show.expandInfo();
                    tmdbShows.Add(show);

                }

            } else if (cboSearchType.Text.Contains("MOVIE - ")) {   // Search type set to Movie

                foreach (JObject obj in query.results) {

                    TMDBMovie movie = obj.ToObject<TMDBMovie>();
                    movie.expandInfo();
                    tmdbMovies.Add(movie);

                }
            }

            tmdbDisplayResults();
            
        }

        private string getURL() {

            string url = "";
            string searchType = cboSearchType.Text;
            string searchText = txtSearch.Text;

            switch (searchType) {
            
                case "TV - Search by Name":
                    url = Master.getTVSearchURL(searchText);
                    break;

                case "MOVIE - Search by Name":
                    url = Master.getMovieSearchURL(searchText);
                    break;
            
            }

            return url;
        
        }

        private void tmdbDisplayResults() {

            foreach (TMDBShow show in tmdbShows) {

                ListViewItem item = new ListViewItem();
                item.SubItems[0] = new ListViewItem.ListViewSubItem(item, show.name);

                string country = "N/A";
                
                if (show.origin_country.Count > 0)
                    country = show.origin_country[0];

                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, country));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, show.status));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, show.first_air_date));
                item.Tag = "TV" + show.id;
                lstResults.Items.Add(item);

            }

            foreach (TMDBMovie movie in tmdbMovies) {

                ListViewItem item = new ListViewItem();
                item.SubItems[0] = new ListViewItem.ListViewSubItem(item, movie.title);

                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, movie.country));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, movie.status));
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, movie.release_date));
                item.Tag = "MOVIE" + movie.id;
                lstResults.Items.Add(item);
            
            }
        
        }

        // SHARED METHODS
        private void btnSearch_Click(object sender, EventArgs e) {

            if (cboSearchType.Text == "LEGACY - TV Rage Search") {

                search();

            } else {

                tmdbSearch();
            
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e) {

            if (e.KeyValue == 13) {

                if (cboSearchType.Text == "LEGACY - TV Rage Search") {

                    search();

                } else {

                    tmdbSearch();

                }

            }
        }

        private void lstResults_DoubleClick(object sender, EventArgs e) {

            if (cboSearchType.Text == "LEGACY - TV Rage Search") {

                ListViewItem item = (sender as ListView).SelectedItems[0];

                foreach (Show show in shows) {

                    if (show.showId == item.Tag.ToString()) {

                        frmMain frm = (frmMain)this.Parent.Parent;
                        frm.displayShowInfo(show);
                        break;

                    }
                }
                
            } else {

                ListViewItem item = (sender as ListView).SelectedItems[0];
                string tag = item.Tag.ToString();

                if (tag.Contains("TV")) {

                    tag = tag.Replace("TV", "");

                    foreach (TMDBShow show in tmdbShows) {

                        if (show.id.ToString() == tag) {

                            frmMain frm = (frmMain)this.Parent.Parent;
                            //show.expandInfo();
                            frm.displayShowInfo(show);
                            break;

                        }
                    }

                } else if (tag.Contains("MOVIE")) {

                    tag = tag.Replace("MOVIE", "");

                    foreach (TMDBMovie movie in tmdbMovies) {

                        if (movie.id.ToString() == tag) {

                            frmMain frm = (frmMain)this.Parent.Parent;
                            //show.expandInfo();
                            frm.displayMovieInfo(movie);
                            break;

                        }
                    }
                }
            }
        }


    }
}
