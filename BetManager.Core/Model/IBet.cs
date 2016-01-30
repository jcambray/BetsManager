using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetManager.Core.Model
{
    public interface IBet
    {
        Double NullBet { get; set; }
        Double Odd { get; set; }
        DateTime Date { get; set; }
        bool Successful { get; set; }


    }
}
