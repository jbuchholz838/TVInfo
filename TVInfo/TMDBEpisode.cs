using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVInfo {

    public class TMDBEpisode {

        public string air_date { get; set; }
        public List<TMDBCrew> crew { get; set; }
        public int episode_number { get; set; }
        public List<TMDBStar> guest_stars { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string production_code { get; set; }
        public int season_number { get; set; }
        public string still_path { get; set; }
        public double vote_average { get; set; }
        public double vote_count { get; set; }

        public TMDBEpisode() {

        }

        public override string ToString() {

            string output = "";

            output += "Air Date: " + air_date + "\n";
            output += "Crew: " + crew + "\n";
            output += "Episode Number: " + episode_number + "\n";
            output += "Guest Stars: " + guest_stars + "\n";
            output += "Name: " + name + "\n";
            output += "Overview: " + overview + "\n";
            output += "ID: " + id + "\n";
            output += "Production Code: " + production_code + "\n";
            output += "Season Number: " + season_number + "\n";
            output += "Still Path: " + still_path + "\n";
            output += "Vote Average: " + vote_average + "\n";
            output += "Vote Count: " + vote_count + "\n";

            return output;
        
        }

    }
}
