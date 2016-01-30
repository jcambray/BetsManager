using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BetManager.Core.Model
{
    public class FootballBet : IBet
    {
        private double odd, nullBet;
        Team team, otherTeam;
        
        private bool successful;

        public DateTime Date { get; set; }

        public double NullBet
        {
            get
            {
                return nullBet;
            }

             set
            {
                nullBet = value;
            }
        }

        public double Odd
        {
            get
            {
                return odd;
            }

             set
            {
                odd = value;
            }
        }

        public bool Successful
        {
            get
            {
                return successful;
            }

             set
            {
                successful = value;
            }
        }

        public Team Team { get { return team; } set { team = value; } }
        public Team OtherTeam { get { return otherTeam; } set { otherTeam = value; } }

        public FootballBet(Team team, Team otherTeam, double odd, double nullBet, DateTime date)
        {
            Team = team;
            OtherTeam = otherTeam;
            NullBet = nullBet;
            Odd = odd;
            Date = date;
        }

        public override string ToString()
        {
            return string.Format("team1 : {0} | team2 : {1} | Odd : {2} | NullBet : {3} | Date : {4} | Successful : {5}",
                team,otherTeam,odd,nullBet,Date,successful);
        }

    }
}
