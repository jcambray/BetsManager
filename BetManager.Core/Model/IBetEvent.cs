using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetManager.Core.Model
{
    /// <summary>
    /// Defines an event for which the probability that it happened is calculated
    /// regarding to a set of matches
    /// </summary>
    interface IBetEvent
    {
        double GetProbability();
    }
}
