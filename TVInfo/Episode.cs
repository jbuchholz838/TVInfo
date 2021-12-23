using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace TVInfo {

    public class Episode {

        private XmlNode episodeNode;

        public int totEpNum;
        public int seasonEpNum;
        public string prodNum;
        public string link;
        public string title;
        public string airDate;

        public Episode(XmlNode node) {

            episodeNode = node;
            getProperties();

        }

        public Episode(XmlNode node, int epNum) {

            episodeNode = node;
            //this.totEpNum = epNum;
            getProperties();

        }

        private void getProperties() {

            foreach (XmlNode node in episodeNode.ChildNodes) {

                checkNode(node);
            }

        }

        private bool checkNode(XmlNode node) {

            string text = node.Name.ToUpper();
            string value = node.InnerText;

            if (value == null || value == "")

                return false;

           // Console.WriteLine("EPISODE PROPERTY VALUE  " + value);

            switch (text) {

                case "EPNUM":

                    totEpNum = Convert.ToInt32(value);
                    return true;

                case "SEASONNUM":

                    seasonEpNum = Convert.ToInt32(value);
                    return true;

                case "PRODNUM":

                    prodNum = value;
                    return true;

                case "AIRDATE":

                    airDate = value;
                    return true;

                case "LINK":

                    link = value;
                    return true;

                case "TITLE":

                    title = value;
                    return true;


            } // END SWITCH

            return false;
        }

    }
}
