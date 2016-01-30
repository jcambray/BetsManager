using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BetManager.Core.Model;
using System.Collections.ObjectModel;

namespace BetManager.Core
{
    public class BetViewModel
    {
   
        public Team Equipe1 { get; set; }
        public Team Equipe2 { get; set; }
        public double NullOdd { get; set; }
        public ObservableCollection<Team> SelectTeam { get; set; }


        //**************VALUE BET//**************
        public bool IsValueBet { get; set; }
        public Team SelectedTeam { get; set; }
        private string playerProb;
        public string PlayerProb {
            get { return playerProb; }
            set
            {
                playerProb = value;
                ValueBet();
            }
        }

        private  void ValueBet()
        {
            if (SelectedTeam == null)
                return;
            int value = 0;
            int.TryParse(playerProb, out value);
            if (value == 0)
                return;
            if (value < 0 || value > 100)
                return;
            if (Calculs.CalculValueBet(SelectedTeam, value) > 1)
                IsValueBet = true;
        }
        //****************************************

        public BetViewModel(FootballBet b)
        {
            Equipe1 = b.Team;
            Equipe2 = b.OtherTeam;
            NullOdd = b.NullBet;
            SelectTeam = new ObservableCollection<Team> { Equipe1, Equipe2 };
        }

        

    }
}
