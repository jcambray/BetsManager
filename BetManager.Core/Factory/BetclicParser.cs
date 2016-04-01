using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Core.Model;
using BetManager.Parsers;
using BetManager.Parsers.BetClic;

namespace BetManager.Core.Factory
{
    class BetclicParser : IParser
    {
        public Dictionary<string, List<string>> UrlList { get; set; }

        public BetclicParser(Dictionary<string, List<string>> _urlList)
        {
            UrlList = _urlList;
        }

        public Dictionary<string, List<string>> Parse()
        {
            //TODO Foreach url, parse the pages to get the bets and return the dictionary with bets from all leagues
        }
    }
}
