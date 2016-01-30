using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Core.Model;

namespace BetManager.Core
{
    public class Calculs
    {

        public static double CalculValueBet(Team selectedTeam, double prob)
        {
            var bookmakerOdd = selectedTeam.Odd;
             var result = (bookmakerOdd * 100) / prob;
            System.Diagnostics.Debug.WriteLine("CALCUL VALUEBET- RESULT= {0}", result);
            return result;
        }
    }
}
