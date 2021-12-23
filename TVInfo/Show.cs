using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace TVInfo {

    public class Show{

        private XmlNode showNode;

        public string name = "";
        public string showId = "";
        public string link = "";
        public string country = "";
        public string startDate = "";
        public string endDate = "";
        public string status = "";
        public string airTime = "";
        public string airDay = "";
        public int numSeasons;
        public string runtime = "";
        public string nextDate = "";
        public string lastDate = "";
        public int nextEpisode;
        public int nextSeason;

     
        public List<string> genres = new List<string>();
        public List<Season> seasons = new List<Season>();

        XmlDocument xdoc = new XmlDocument();
        
        public Show() {



        }

        public Show(XmlNode node) {

            showNode = node;
            getProperties();

        }

        public void setNode(XmlNode node) {

            showNode = node;
            getProperties();

        }

        private void getProperties() {      // Parses through the node's children to retrieve properties

            foreach (XmlNode node in showNode.ChildNodes) {

                checkNode(node);
            }

            getEpisodes();
            getNextDate();
            getLastDate();

        }

        private bool checkNode(XmlNode node) {

            string text = node.Name.ToUpper();
            string value = node.InnerText;

            switch (text) {

                case "NAME":
                case "SHOWNAME":

                    name = value;
                    return true;

                case "SHOWID":

                    showId = value;
                    return true;

                case "LINK":

                    link = value;
                    return true;

                case "COUNTRY":

                    country = value;
                    return true;

                case "STARTED":

                    startDate = value;
                    return true;

                case "ENDED":

                    endDate = value;
                    return true;

                case "SEASONS":

                    numSeasons = Convert.ToInt32(value);
                    return true;

                case "STATUS":

                    status = value;
                    return true;

                case "RUNTIME":

                    runtime = value;
                    return true;

                case "GENRES":

                    foreach (XmlNode gChild in node.ChildNodes) {

                        genres.Add(gChild.InnerText);

                    }

                    return true;

                case "AIRTIME":

                    airTime = value;
                    return true;

                case "AIRDAY":

                    airDay = value;
                    return true;


            } // END SWITCH

            return false;
        }

        public string toString() {

            string text = "NAME:\t\t" + name + Environment.NewLine +
                          "SHOWID:\t\t" + showId + Environment.NewLine +
                          "LINK:\t\t" + link + Environment.NewLine +
                          "COUNTRY:\t" + country + Environment.NewLine +
                          "STARTED:\t" + startDate + Environment.NewLine +
                          "ENDED:\t\t" + endDate + Environment.NewLine +
                          "SEASONS:\t" + numSeasons + Environment.NewLine +
                          "STATUS:\t\t" + status + Environment.NewLine +
                          "RUNTIME:\t" + runtime + Environment.NewLine +
                          "GENRES:\t\t" + displayGenres() + Environment.NewLine +
                          "AIRTIME:\t\t" + convertTime() + Environment.NewLine +
                          "AIRDATE:\t" + airDay + Environment.NewLine + 
                          "NEXT DATE:\t" + nextDate;
            return text;

        }

        public string convertTime() {

            string[] time = airTime.Split(':');

            int num = Convert.ToInt32(time[0]);
            string notation;

            if (num > 12) {

                time[0] = (num - 12).ToString();
                notation = "PM";

            } else if (num == 12) {

                time[0] = num.ToString();
                notation = "PM";

            }else if (num == 0) {

                time[0] = "12";
                notation = "AM";

            } else {

                time[0] = num.ToString();
                notation = "AM";
            }

            return time[0] + ":" + time[1] + " " + notation;
        }

        public string displayGenres() {

            string text = "";

            foreach (string str in genres) {

                if (text != "")

                    text += ", ";

                text += str;

            }

            return text;

        }

        private void getEpisodes() {

            try {

                string url = Master.getEpListURL(Convert.ToInt32(showId));
                xdoc.Load(url);

            } catch (Exception ex) {

                Console.WriteLine("Failed to retrieve XML Data for \"" + showId + "\" : " + ex.Message);
                return;

            }

            foreach (XmlNode epListNode in xdoc.ChildNodes[1].ChildNodes) {   // Searches for EpisodeList

                if (epListNode.Name.ToUpper() == "EPISODELIST") {

                    int i = 1;
                    foreach (XmlNode seasonNode in epListNode.ChildNodes) {   // Searches for latest season

                        seasons.Add(new Season(seasonNode, i));
                        i++;

                    }

                    return;

                }

            }
        }
        
        private void getNextDate() {

            string text = "Unknown";

            foreach (Season season in seasons) {

                if (season.seasonNum == numSeasons || true) {

                    foreach (Episode episode in season.episodes) {

                        bool breakFor = false;
                        bool retry = true;
                        int numRetry = 0;
                        bool estimate = false;
                        string dateStr = episode.airDate;
                        //dateStr = dateStr.Replace("-00-", "-31-");
                        //dateStr = dateStr.Replace("00-", "12-");
                        DateTime date;

                        while (retry && numRetry < 4) {

                            retry = false;

                            if (dateStr != "0000-00-00") {

                                if (Master.isDate(dateStr)) {

                                    date = Convert.ToDateTime(dateStr);

                                    if (date >= DateTime.Now.Date) {

                                        text = date.ToShortDateString();

                                        if (estimate)

                                            text += "*";

                                        nextEpisode = episode.seasonEpNum;
                                        nextSeason = season.seasonNum;

                                        breakFor = true;
                                        break;

                                    }

                                } else {

                                    string oldDateStr = dateStr;

                                    if (dateStr.Contains("-00-00")) {

                                        dateStr = dateStr.Replace("-00-00", "-12-31");
                                        //Console.WriteLine("HANDLED DATE CONVERT ERROR: " + oldDateStr + " to " + dateStr);
                                        retry = true;
                                        numRetry++;
                                        estimate = true;

                                    } else if (dateStr.Contains("-00") && !dateStr.Contains("-00-")) {

                                        dateStr = getEstDate(dateStr);
                                        //Console.WriteLine("HANDLED DATE CONVERT ERROR: " + oldDateStr + " to " + dateStr);
                                        retry = true;
                                        numRetry++;
                                        estimate = true;

                                    } else {

                                        //Console.WriteLine("UNHANDLED DATE CONVERT ERROR: " + dateStr);

                                    }

                                }   // END IF 3
                            }   // END IF 2
                        }   // END WHILE

                        if (breakFor)

                            break;

                    }   // END FOREACH 2
                }   // END IF 1
            }   // END FOREACH 1

            nextDate = text;

        }

        private string getEstDate(string strDate) {

            //0123456789
            //0000-00-00

            int month = Convert.ToInt32(strDate.Substring(5, 2));
            int year = Convert.ToInt32(strDate.Substring(0,4));
            int days = DateTime.DaysInMonth(year, month);

            return strDate.Replace("-00", "-" + days.ToString());

        }

        private void getLastDate() {

            DateTime date = new DateTime();
            DateTime tmpDate = new DateTime();
            DateTime now = DateTime.Now.Date;

            foreach (Season season in seasons) {

                foreach (Episode ep in season.episodes) {

                    if (Master.isDate(ep.airDate)) {

                        tmpDate = DateTime.Parse(ep.airDate);

                        if (date == null || (tmpDate > date && tmpDate < now)) {

                            date = tmpDate;

                        }

                    }

                }
            }

            if (date == null) {

                lastDate = "Unknown";

            } else {

                lastDate = date.ToShortDateString();

            }
        }

        public Dictionary<string, string> getPropDict() {

            Dictionary<string, string> propDict = new Dictionary<string, string>();

            propDict.Add("Name", name);
            propDict.Add("Show ID", showId);
            propDict.Add("Link", link);
            propDict.Add("Country", country);
            propDict.Add("Start Date", startDate);
            propDict.Add("End Date", endDate);
            propDict.Add("Status", status);
            propDict.Add("Air Time", airTime);
            propDict.Add("Air Day", airDay);
            propDict.Add("Run Time", runtime);
            propDict.Add("Next Date", nextDate);
            propDict.Add("Seasons", numSeasons.ToString());
            propDict.Add("Next Episode", nextEpisode.ToString());
            propDict.Add("Last Date", lastDate);

            return propDict;

        }

    }
}
