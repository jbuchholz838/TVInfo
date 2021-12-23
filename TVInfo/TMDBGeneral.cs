using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVInfo {

    public class TMDBGeneral {

        public int id { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }    // Used for Created By, Crew
        public string iso_3166_1 { get; set; }      // Used for Movie Production Countries
        public string iso_639_1 { get; set; }       // Used for Movie Spoken Languages

        public TMDBGeneral() {
        
        }

        public override string ToString() {

            string output = "";

            output += "ID: " + id + "\n";
            output += "Name: " + name + "\n";
            output += "Profile Path: " + profile_path + "\n";

            return output;
        
        }

    }
}
