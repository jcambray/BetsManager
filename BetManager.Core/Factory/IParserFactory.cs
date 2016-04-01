using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Parsers;

namespace BetManager.Core.Factory
{
    interface IParserFactory
    {
        IParser Create();
    }
}
