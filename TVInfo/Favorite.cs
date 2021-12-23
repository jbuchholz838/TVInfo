using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TVInfo {

    class Favorite {

        public string line = "";
        public string type = "";
        public string id = "";

        public Favorite() {
        
        
        }

        public Favorite(string line) {

            this.line = line.Trim();
            splitLine();
        
        }

        private void splitLine() {

            string[] arrLine = line.Split('|');

            if (arrLine.Length == 2) {

                type = arrLine[0].Trim();
                id = arrLine[1].Trim();

            } else {

                Master.logWrite("Favorite", "Malformed favorites line entry.");
            
            }
        }

        public string createLine() {

            line = type + "|" + id;
            return line;
        
        }

    }
}
