using BetManager.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BetManager.Core
{
    /// <summary>
    /// Logique d'interaction pour BetsList.xaml
    /// </summary>
    public partial class BetsList : Page
    {
        public BetsList(IEnumerable<FootballBet> bets)
        {
            InitializeComponent();
            DataContext = new BetListViewModel(bets);
        }

    }
}
