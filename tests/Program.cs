using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Parsers.BetClic;
using BetManager.Core;
using BetManager.FootballData;
using NSoup;
using System.Windows.Forms;

namespace tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //var ligue1Parser = new FootballParser("https://www.betclic.fr/football/ligue-1-e4");
            //var ligaBBVAParser = new FootballParser("https://www.betclic.fr/football/espagne-liga-primera-e7");
            //var test1 = ligue1Parser.Parse();
            //var test2 = ligaBBVAParser.Parse();
            //var data = new FootballData().GetLeague("Ligue 1").Teams[0].Fixtures;

            var conn = NSoupClient.Connect("https://www.betclic.fr/sport/").Get();
            var browser = new WebBrowser();
            browser.Navigate("https://www.betclic.fr/football/ligue-1-e4");
            var elements = browser.Document.GetElementsByTagName("match-entry clearfix CompetitionEvtSpe");
            HtmlElement myElement;
            foreach(HtmlElement elemnt in elements)
            {
                var attr = elemnt.GetAttribute("data - track -event-name");
                if (string.IsNullOrEmpty(attr))
                    if (attr == "Nice - Lyon")
                        myElement = elemnt;

            }
            Console.Read();
        }
    }
}
