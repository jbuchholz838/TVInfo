using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TVInfo {

    public class TMDBQuery {

        public string query = "";
        public int page { get; set; }
        public List<JObject> results { get; set; }
        public string total_pages { get; set; }
        public string total_results { get; set; }

        public TMDBQuery() {
        
        }

        public void dispShows(){

            foreach (JObject obj in results) {

                TMDBShow show = obj.ToObject<TMDBShow>(); 

                Console.WriteLine(show.ToString());
                Console.WriteLine();
            
            }

        }

        public override string ToString() {

            string output = "";

            output += "Page: " + page + "\n";
            output += "Results: " + results + "\n";
            output += "Total Pages: " + total_pages + "\n";
            output += "Total Results: " + total_results + "\n";

            return output;
        
        }
    }
}
