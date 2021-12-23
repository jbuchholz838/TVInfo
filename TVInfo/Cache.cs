using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace TVInfo {

    class Cache {

        string path = "";
        private List<Show> favShows = new List<Show>();

        public Cache() {
        
            
        
        }

        public bool loadExisting(string path) {

            this.path = path;

            if (File.Exists(path)) {

                return true;

            } else {

                return false;
            
            }
        
        }

        public bool update() {



            return true;
        
        }

    }

}
