using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVInfo {

    public class TMDBCrew {

        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string job { get; set; }
        public string profile_path { get; set; }

        public TMDBCrew() {
        
        }

        public override string ToString(){

            string output = "";

            output += "ID:" + id + "\n";
            output += "Credit ID:" + credit_id + "\n";
            output += "Name:" + name + "\n";
            output += "Department:" + department + "\n";
            output += "Job:" + job + "\n";
            output += "Profile Path:" + profile_path + "\n";

            return output;

        }

    }
}
