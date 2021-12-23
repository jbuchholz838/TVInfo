using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace TVInfo {
    
    public class Season {

        private XmlNode seasonNode;
        public int seasonNum = -1;

        public List<Episode> episodes = new List<Episode>();

        public Season(XmlNode node, int num) {

            seasonNode = node;
            seasonNum = num;
            getProperties();

        }

        private void getProperties() {

            int epNum = 1; 

            foreach (XmlNode node in seasonNode.ChildNodes) {

                episodes.Add(new Episode(node, epNum));
                epNum++;

            }

            episodes.OrderBy(x => x.totEpNum);

        }

    }
}
