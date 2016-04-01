using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Parsers;

namespace BetManager.Core.Factory
{
    public  class BetClicParserFactory : IParserFactory
    {
        private List<string> pageList;
        public IParser Create()
        {
            return new BetclicParser();
        }

        public BetClicParserFactory(List<string> _pageList)
        {
            pageList = _pageList;
        }
 
    }
}
