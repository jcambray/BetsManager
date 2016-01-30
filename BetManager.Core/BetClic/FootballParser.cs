using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Core.Model;
using NSoup;
using System.Net;

namespace BetManager.Parsers.BetClic
{
    public class FootballParser : IParser
    {
        private string pageUrl;

        public string PageUrl
        {
            get
            {
                return pageUrl;
            }

            set
            {
                pageUrl = value;
            }
        }

        public FootballParser(string pageUrl)
        {
            PageUrl = pageUrl;
        }

        public IEnumerable<IBet> Parse()
        {
            var results = new List<FootballBet>();
            

            var htmlContent = new WebClient().DownloadString(PageUrl);
            var matchElements = NSoupClient.Parse(htmlContent).GetElementsByAttribute("data-track-event-name");

            foreach(var matchElmnt in matchElements)
            {
                var team1Name = matchElmnt.Attributes.GetValue("data-track-event-name").Split('-')[0].TrimEnd(' ');
                var team2Name = matchElmnt.Attributes.GetValue("data-track-event-name").Split('-')[1].TrimStart(' ');
                var team1Odd = double.Parse(matchElmnt.GetElementsByClass("match-odd").ElementAt(0).Text().Replace(',','.'));
                var team2Odd = double.Parse(matchElmnt.GetElementsByClass("match-odd").ElementAt(2).Text().Replace(',', '.'));
                var nullBetOdd = double.Parse(matchElmnt.GetElementsByClass("match-odd").ElementAt(1).Text().Replace(',', '.'));

                var dateString = matchElmnt.ParentNode.ParentNode.Attributes.GetValue("data-date").Split('-');
                var matchDate = new DateTime(
                    int.Parse(dateString[0]),
                    int.Parse(dateString[1]),
                    int.Parse(dateString[2]));

                var team1 = new Team { Name = team1Name, Odd = team1Odd };
                var team2 = new Team { Name = team2Name, Odd = team2Odd };
                var bet = new FootballBet(team1, team2, 0, nullBetOdd,matchDate);
                results.Add(bet);
            }

            
            return results;
        }
    }
}
