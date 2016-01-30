using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Core.Model;

namespace BetManager.Parsers
{
    public interface IParser
    {
         String PageUrl { get; set; }
        IEnumerable<IBet> Parse();
    }
}
