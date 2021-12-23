using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVInfo {

    public class TMDBStar {

        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public string character { get; set; }
        public int order { get; set; }
        public string profile_path { get; set; }

        public TMDBStar() {
        
        }

        public override string ToString() {

            string output = "";

            output += "ID:" + id + "\n";
            output += "Credit ID:" + credit_id + "\n";
            output += "Name:" + name + "\n";
            output += "Character:" + character + "\n";
            output += "Order:" + order + "\n";
            output += "Profile Path:" + profile_path + "\n";

            return output;

        }

    }
}
