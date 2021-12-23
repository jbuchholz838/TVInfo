using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

using Microsoft.Win32;
using System.IO;
using Newtonsoft.Json;
using System.Net;

namespace TVInfo {

    static class Master {

        public static List<Show> favShows = new List<Show>();
        public static List<TMDBShow> tmdbFavShows = new List<TMDBShow>();
        public static List<TMDBMovie> tmdbFavMovies = new List<TMDBMovie>();
        static Mutex GUI_Mutex = new Mutex();
        private static string lastLogLoc = "";
        public static string programDir = "C:\\Temp\\TV Show Program";
        public static string logFile = programDir + @"\TVShows.log";
        public static string cacheFile = programDir + "\\TVShows.cache";
        public static TVInfoSettings settings;

        // The Movie DB
        public static string apiKey = "";
        public static string baseURL = "http://api.themoviedb.org/3/";

        private static frmMain main;

        [STAThread]

        static void Main() {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SystemEvents.PowerModeChanged += OnPowerChange;

            if (!System.IO.Directory.Exists(programDir)) {

                System.IO.Directory.CreateDirectory(programDir);

            }

            logWrite("Master", "Application Starting.");

            LoadSettings();

            Cache cache = new Cache();
            cache.loadExisting(cacheFile);

            main = new frmMain();
            
            Application.Run(main);

            logWrite("Master", "Application Ending.");

        }

        private static void LoadSettings()
        {
            string tvInfoSettingsFile = @".\TVInfoSettings.json";

            if (File.Exists(tvInfoSettingsFile))
            {
                string settingsJSON = File.ReadAllText(tvInfoSettingsFile);
                settings = JsonConvert.DeserializeObject<TVInfoSettings>(settingsJSON);

                apiKey = settings.ApiKey;
            }
        }

        public static string getSearchURL(string showName) {

            return "http://services.tvrage.com/feeds/full_search.php?show=" + showName;

        }

        public static string getShowInfoURL(int showID) {

            return "http://services.tvrage.com/feeds/showinfo.php?sid=" + showID;

        }

        public static string getEpListURL(int showID) {

            return "http://services.tvrage.com/feeds/episode_list.php?sid=" + showID;

        }

        public static string getEpInfoURL(int showID, int season, int episode) {

            return "http://services.tvrage.com/feeds/episodeinfo.php?sid=" + showID + "&ep" + season + "x" + episode;

        }

        // The Movie DB

        public static string downloadText(string url) {     // All downloading from TMDB must come through this function!

            string content = "";

            using (WebClient client = new WebClient()) {

                Console.WriteLine("Downloading content from: " + url);
                content = client.DownloadString(url);

                for (int i = 0; i < client.ResponseHeaders.Count; i++) {

                    //Console.WriteLine(client.ResponseHeaders.GetKey(i) + " : " + client.ResponseHeaders.Get(i));

                }

                Thread.Sleep(250);  // The max number of requests is 40 within 10 seconds (10,000 ms) 10,000 / 40 = 250

            }

            return content;

        }

        public static string getTVSearchURL(string showName) {

            return baseURL + "search/tv?query=" + showName + "&" + apiKey;

        }

        public static string getTVInfoURL(int showID) {

            return baseURL + "tv/" + showID + "?" + apiKey;
        }

        public static string getTVInfoURL(string showID) {

            return baseURL + "tv/" + showID + "?" + apiKey;
        }

        public static string getTVSeasonInfoURL(int showID, int seasonNum) {

            return baseURL + "tv/" + showID + "/season/" + seasonNum + "?" + apiKey;
        
        }

        public static string getTVCreditsURL(int showID) {

            return baseURL + "tv/" + showID + "/credits?" + apiKey;

        }

        public static string getMovieSearchURL(string movie) {

            return baseURL + "search/movie?query=" + movie + "&" + apiKey;
        
        }

        public static string getMovieInfoURL(int movieID) {

            return baseURL + "movie/" + movieID + "?" + apiKey;

        }

        public static string getMovieInfoURL(string movieID) {

            return baseURL + "movie/" + movieID + "?" + apiKey;

        }

        public static object jsonPopulateObject(string content, object target) {

            JsonSerializerSettings serializer = new JsonSerializerSettings();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.ObjectCreationHandling = ObjectCreationHandling.Replace;

            JsonConvert.PopulateObject(content, target, serializer);

            return target;
        
        }

        public static TClass jsonDeserializeObject<TClass>(string content) {

            JsonSerializerSettings serializer = new JsonSerializerSettings();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.ObjectCreationHandling = ObjectCreationHandling.Replace;

            TClass obj = JsonConvert.DeserializeObject<TClass>(content, serializer);

            return obj;

        }

        public static bool isDate(string strDate) {

            DateTime date;

            return DateTime.TryParse(strDate, out date);

        }

        public static bool isNumber(string strNum) {

            double num;

            return double.TryParse(strNum, out num);

        }

        public static void logWrite(string formName, string text) {

            formName = formName.Replace("frm", "");
            formName = formName.Replace("ctr", "");
            bool newLine = false;

            if (lastLogLoc != formName) {

                newLine = true;

            }

            lastLogLoc = formName;

            string space = "";

            for (int i = formName.Length; i < 11; i++) {

                space += " ";

            }

            logActions("[" + formName + "]" + space + text, newLine);

        }

        private static void logActions(String Text, bool newLineBefore) {

            string newLine = "";

            if (newLineBefore)

                newLine = "\n";

            // IF LOGGING OFF THEN RETURN

            if (GUI_Mutex.WaitOne(500) == true) {

                try {

                    using (System.IO.StreamWriter log = new System.IO.StreamWriter(logFile, true)) {

                        log.WriteLine(newLine + DateTime.Now.ToString("hh:mm:ss tt") + ":    " + Text);

                    }
                } catch {

                }

                GUI_Mutex.ReleaseMutex();

            }
        }

        public static void writeToCache(string property, string value) {

            if (File.Exists(cacheFile)) {

                using (StreamWriter cache = new StreamWriter(cacheFile)) {
                
                    
                
                }
            
            }
        
        }

        public static void readCache() {
        
            
                
        }

        private static void OnPowerChange(object s, PowerModeChangedEventArgs e) {

            int waitTime = 10; // Time in minutes

            switch (e.Mode) {
                case PowerModes.Resume:
                    logWrite("Program", "Power Mode Change Detected: Resume. Restarting the timer.");
                    //Thread.Sleep(waitTime * 60000);
                    main.stopResumeTimer("Start");
                    break;
                case PowerModes.Suspend:
                    logWrite("Program", "Power Mode Change Detected: Suspend. Pausing the timer.");
                    main.stopResumeTimer("Stop");
                    break;
            }
        }

    }
}
