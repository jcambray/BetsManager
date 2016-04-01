using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.FootballData;

namespace BetManager.Core.Model
{
    class HomeWinBetEvent : IBetEvent
    {
        private IEnumerable<Fixture> matchList;


        public HomeWinBetEvent(IEnumerable<Fixture> _matchList)
        {

        }

        public double GetProbability()
        {
            throw new NotImplementedException();
        }
    }
}
