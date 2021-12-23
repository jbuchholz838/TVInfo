using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TVInfo {

    public class TMDBSeason {

        public string air_date { get; set; }
        public List<TMDBEpisode> episodes { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }

        public int showID = 0;

        public TMDBSeason() {
        
        
        }

        public void expandInfo() {

            string url = Master.getTVSeasonInfoURL(showID, season_number);
            string content = Master.downloadText(url);

            JsonConvert.PopulateObject(content, this);

        }

        public override string ToString() {

            string output = "";

            output += "Air Date: " + air_date + "\n";
            output += "Episodes: " + episodes + "\n";
            output += "Name: " + name + "\n";
            output += "Overview: " + overview + "\n";
            output += "ID: " + id + "\n";
            output += "Poster Path: " + poster_path + "\n";
            output += "Season Number: " + season_number + "\n\n";

            output += "---------------------------------------------------------------------\n\n";

            foreach (TMDBEpisode episode in episodes) {

                output += episode.ToString();
                output += "\n";
            
            }

            return output;

        }
    }
}
