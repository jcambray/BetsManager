using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetManager.Core.Model
{
    public class Team
    {
        public string Name { get; set; }
        public double Odd { get; set; }

        public override string ToString()
        {
            return String.Format("Name : {0} | Odd : {1}",Name,Odd);
        }
    }
}
