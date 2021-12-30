using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TVInfo {

    public class TMDBMovie {

        // Search Provided Variables
        public string adult { get; set; }
        public string backdrop_path { get; set; }
        public List<int> genre_ids { get; set; }
        public int id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public string release_date { get; set; }
        public string poster_path { get; set; }
        public string popularity { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public double vote_average { get; set; }
        public int vote_count { get; set; }

        // ID Specific Provided Variables
        public TMDBGeneral belongs_to_collection { get; set; }
        public long budget { get; set; }
        public List<TMDBGeneral> genres { get; set; }
        public string homepage { get; set; }
        public string imdb_id { get; set; }
        public List<TMDBGeneral> production_companies { get; set; }
        public List<TMDBGeneral> production_countries { get; set; }
        public long revenue { get; set; }
        public int runtime { get; set; }
        public List<TMDBGeneral> spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }

        // Specific ID Credits Provided Variables
        public List<TMDBCrew> crew { get; set; }
        public List<TMDBStar> cast { get; set; }

        // Custom Variables
        public string country = "";
        public string genre = "";
        public string collection = "";
        public string length = "";

        public TMDBMovie() {
        
        }

        public void expandInfo() {

            string url = "";
            string content = "";

            // Get Show Info
            url = Master.getMovieInfoURL(id);
            content = Master.downloadText(url);

            //JsonSerializerSettings serializer = new JsonSerializerSettings();
            //serializer.NullValueHandling = NullValueHandling.Ignore;
            //serializer.ObjectCreationHandling = ObjectCreationHandling.Replace;

            //JsonConvert.PopulateObject(content, this, serializer);

            Master.jsonPopulateObject(content, this);

            updateInfo();

        }

        private void updateInfo() {

            setCountry();
            setGenre();
            setCollection();
            setLength();
            convertDate();

        }

        private void setCountry() {

            foreach (TMDBGeneral gen in production_countries) {

                if (country == "") {

                    country = gen.iso_3166_1.Trim();

                } else {

                    country += ", " + gen.iso_3166_1.Trim();

                }
            }
        }

        private void setGenre() {

            foreach (TMDBGeneral gen in genres) {

                if (genre == "") {

                    genre = gen.name;

                } else {

                    genre += ", " + gen.name;

                }
            }
        }

        private void setCollection() {

            if (belongs_to_collection != null) {

                collection = belongs_to_collection.name;
            
            }
        
        }

        private void setLength() {

            if (runtime != null) {

                int hours = 0;
                int minutes = 0;

                hours = Convert.ToInt32(Math.Floor(Convert.ToDouble(runtime) / 60));
                minutes = runtime - (hours * 60);

                length = hours + "h " + minutes.ToString("D2") + "m"; 

            } else {

                length = "0h 00m";
            
            }
        
        }

        private void convertDate() {
        
            if (!String.IsNullOrEmpty(release_date)){

                DateTime tmp = Convert.ToDateTime(release_date);
                release_date = tmp.ToString("MM/dd/yyyy");

            }
        }

    }
}
