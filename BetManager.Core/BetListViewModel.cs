using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Core.Model;

namespace BetManager.Core
{
    public class BetListViewModel
    {
        public ObservableCollection<BetViewModel> BetViewModel { get; set; }

        public BetListViewModel(IEnumerable<FootballBet> bets)
        {
            BetViewModel = new ObservableCollection<BetManager.Core.BetViewModel>();
            foreach(var b in bets)
            {
                BetViewModel.Add(new BetViewModel(b));
            }
        }
    }
}
