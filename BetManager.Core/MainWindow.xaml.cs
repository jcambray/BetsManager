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
using System.Threading;

namespace BetManager.Core
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Core core;

        public MainWindow()
        {
            InitializeComponent();
            core = new Core();
        }

        private void betsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            pageContainer.Navigate(new BetsList(core.BetClicParser.Parse() as List<FootballBet>));
        }
    }
}
