using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TVInfo {
    
    public class TMDBShow {

        // Search Provided Variables
        public string backdrop_path { get; set; }
        public int id { get; set; }
        public string original_name { get; set; }
        public string first_air_date { get; set; }
        public List<string> origin_country { get; set; }
        public string poster_path { get; set; }
        public string popularity { get; set; }
        public string name { get; set; }
        public double vote_average { get; set; }
        public double vote_count { get; set; }

        // Specific ID Provided Variables
        public List<TMDBCrew> created_by { get; set; }
        public List<int> episode_run_time { get; set; }
        public List<TMDBGeneral> genres { get; set; }
        public string homepage { get; set; }
        public bool in_production { get; set; }
        public string last_air_date { get; set; }
        public List<TMDBGeneral> networks { get; set; }
        public int number_of_episodes { get; set; }
        public int number_of_seasons { get; set; }
        public string original_language { get; set; }
        public string overview { get; set; }
        public List<TMDBGeneral> production_companies { get; set; }
        public List<TMDBSeason> seasons { get; set; }
        public string status { get; set; }
        public string type { get; set; }

        // Specific ID Credits Provided Variables
        public List<TMDBCrew> crew { get; set; }
        public List<TMDBStar> cast { get; set; }

        // Custom Variables
        public string country = "";
        public string dayOfWeek = "";
        public string nextDate = "";
        public string lastDate = "";
        public string endDate = "";
        public string nextEpisode = "";
        public string lastEpisode = "";
        public string endEpisode = "";
        public string genre = "";
        public string runTime = "";
        public int seasonEpCount = 0;

        public TMDBShow() {
        
        }

        public void expandInfo() {
        
            string url = "";
            string content = "";

            // Get Show Info
            url = Master.getTVInfoURL(id);
            content = Master.downloadText(url);

            JsonSerializerSettings serializer = new JsonSerializerSettings();
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.ObjectCreationHandling = ObjectCreationHandling.Replace;
            
            JsonConvert.PopulateObject(content, this, serializer);
            
            // Get Season Info
            foreach (TMDBSeason season in seasons) {

                season.showID = id;
                season.expandInfo();
            
            }

            updateInfo();
            
        }

        private void updateInfo() {

            setCountry();
            setDayOfWeek();
            setNextDate();
            setLastDate();
            setEndDate();
            setGenre();
            setRunTime();
            setSeasonEpCount();
                
        }

        public void setCountry() {

            if (origin_country.Count == 0) {

                country = "N/A";

            } else {

                foreach (string str in origin_country) {

                    country += str + "     ";
                
                }

                country.Trim().Replace("     ", ", ");

            }
            
        }

        public void setDayOfWeek() {
            
            DateTime temp = new DateTime();

            if (DateTime.TryParse(last_air_date, out temp)) {

                dayOfWeek = temp.DayOfWeek.ToString();

            } else {

                dayOfWeek = "N/A";
            
            }
        
        }

        public void setNextDate() {

            DateTime now = DateTime.Now.Date;
            DateTime tmp = new DateTime(1900, 01, 01);
            DateTime air;
            int dayDiff = -1;

            foreach (TMDBSeason season in seasons) {

                foreach (TMDBEpisode episode in season.episodes) {

                    if (Master.isDate(episode.air_date)) {

                        air = DateTime.Parse(episode.air_date).Date;

                        if (tmp == new DateTime(1900, 01, 01) && air >= now) {  // tmp not already set to a date

                            tmp = air;
                            dayDiff = (tmp - now).Days;
                            nextEpisode = episode.episode_number.ToString();

                        } else {

                                int tmpDiff = (air - now).Days;

                                if (tmpDiff >= 0 && tmpDiff < dayDiff) {

                                    tmp = air;
                                    dayDiff = tmpDiff;
                                    nextEpisode = episode.episode_number.ToString();

                                }

                        }
                    }
                }
            }

            nextDate = tmp.ToString("MM/dd/yyyy");

            if (status == "Ended") {

                nextDate = "N/A";

            } else if (nextDate == "01/01/1900") {

                nextDate = "Unknown";

            }
        
        }

        public void setLastDate() {

            DateTime now = DateTime.Now.Date;
            DateTime tmp = new DateTime(1900, 01, 01);
            DateTime air;
            int dayDiff = 1;

            foreach (TMDBSeason season in seasons) {

                foreach (TMDBEpisode episode in season.episodes) {

                    if (Master.isDate(episode.air_date)) {

                        air = DateTime.Parse(episode.air_date).Date;

                        if (tmp == new DateTime(1900, 01, 01) && air < now) {   // tmp not already set to a date

                            tmp = air;
                            dayDiff = (tmp - now).Days;
                            lastEpisode = episode.episode_number.ToString();

                        } else {

                            int tmpDiff = (air - now).Days;

                            if (tmpDiff < 0 && tmpDiff > dayDiff) {

                                tmp = air;
                                dayDiff = tmpDiff;
                                lastEpisode = episode.episode_number.ToString();

                            }

                        }
                    }
                }
            }

            lastDate = tmp.ToString("MM/dd/yyyy");

            if (lastDate == "01/01/1900") {

                lastDate = "Unknown";

            }

        }

        public void setEndDate() {

            DateTime now = DateTime.Now.Date;
            DateTime tmp = new DateTime(1900, 01, 01);
            DateTime air;

            foreach (TMDBSeason season in seasons) {

                foreach (TMDBEpisode episode in season.episodes) {

                    if (Master.isDate(episode.air_date)) {

                        air = DateTime.Parse(episode.air_date).Date;

                        if (tmp == new DateTime(1900, 01, 01) && air < now) {   // tmp not already set to a date

                            tmp = air;
                            endEpisode = episode.episode_number.ToString();

                        }
                        else {

                            if (air > tmp) {

                                tmp = air;
                                endEpisode = episode.episode_number.ToString();

                            }

                        }
                    }
                }
            }

            endDate = tmp.ToString("MM/dd/yyyy");

            if (endDate == "01/01/1900") {

                endDate = "Unknown";

            }

        }

        public void setSeasonEpCount() {

            foreach (TMDBSeason season in seasons) {

                if (season.season_number == number_of_seasons) {

                    seasonEpCount = season.episodes.Count;
                    break;

                }

            }

        }

        public void setNextEpisode() {

            //nextEpisode = "NYI";

        }

        public void setGenre() {

            if (genres.Count == 0) {

                genre = "N/A";

            } else {

                foreach (TMDBGeneral str in genres) {

                    genre += str.name + "     ";

                }

                genre.Trim().Replace("     ", ", ");

            }

        }

        public void setRunTime() {

            runTime = "NYI";

        }

        public void getCredits() {

            string url = "";
            string content = "";

            // Get Credits Info
            url = Master.getTVCreditsURL(id);
            content = Master.downloadText(url);

            JsonConvert.PopulateObject(content, this);
        
        }

        public override string ToString() {

            string output = "";

            output += "\n\n\n*********************************************************************\n\n";

            output += "Backdrop Path: " + backdrop_path + "\n";
            output += "ID: " + id + "\n";
            output += "Original Name: " + original_name + "\n";
            output += "First Air Date: " + first_air_date + "\n";
            output += "Origin Country: " + origin_country.Count() + "\n";
            output += "Poster Path: " + poster_path + "\n";
            output += "Popularity: " + poster_path + "\n";
            output += "Name: " + name + "\n";
            output += "Vote Average: " + vote_average + "\n";
            output += "Vote Count: " + vote_count + "\n";
            output += "Created By:" + created_by + "\n";
            output += "Episode Run Time:" + episode_run_time + "\n";
            output += "Genres:" + genres.Count() + "\n";
            output += "Homepage:" + homepage + "\n";
            output += "In Production:" + in_production + "\n";
            output += "Last Air Date:" + last_air_date + "\n";
            output += "Networks:" + networks + "\n";
            output += "Number of Episodes:" + number_of_episodes + "\n";
            output += "Number of Seasons:" + number_of_seasons + "\n";
            output += "Original Language:" + original_language + "\n";
            output += "Overview:" + overview + "\n";
            output += "Production Companies:" + production_companies + "\n";
            output += "Seasons:" + seasons.Count() + "\n";
            output += "Status:" + status + "\n";
            output += "Type:" + type + "\n\n";

            output += "---------------------------------------------------------------------\n\n";

            foreach (TMDBSeason season in seasons) {

                output += season.ToString();
                output += "\n";

            }

            output += "---------------------------------------------------------------------\n\n";

            foreach (TMDBStar star in cast) {

                output += star.ToString();
                output += "\n";
            
            }

            output += "*********************************************************************\n\n\n";

            return output;

        }

    }
}
