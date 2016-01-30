using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.FootballData;
using BetManager.Parsers.BetClic;

namespace BetManager.Core
{
    public class Core
    {
        private FootballData.FootballData dataProvider;
        public FootballData.FootballData DataProvider
        {
            get { return dataProvider; }
            set { dataProvider = value; }
        }

        private FootballParser betClicParser;
        public FootballParser BetClicParser
        {
            get { return betClicParser; }
            set { betClicParser = value; }
        }



        public Core()
        {
            dataProvider = new FootballData.FootballData();
            betClicParser = new FootballParser("https://www.betclic.fr/football/ligue-1-e4");

            var ligue1 = dataProvider.GetLeague("Ligue 1");
            var ligue1Bets = betClicParser.Parse();
        }


    }
}
