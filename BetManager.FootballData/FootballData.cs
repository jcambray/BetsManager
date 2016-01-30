using System;
using System.Net;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace BetManager.FootballData
{
    public class FootballData
    {
        
        private const string SOCCER_SEASONS_URI = "alpha/soccerseasons/";
        private List<League> leagues;

        public FootballData()
        {
            leagues = new List<League>();
        }
        
        private void GetLeagues()
        {
            var client = new WebClient();
            var result = client.DownloadString(API_Utils.BASE_URI + SOCCER_SEASONS_URI);
            var jsonArray = JArray.Parse(result);
            foreach(JObject o in jsonArray.Children())
            {
                var uri = (string)o["_links"]["teams"]["href"];
                var name = (string)o["caption"];
                var id = (string)o["league"];
                leagues.Add(new League { TeamsURI = uri, Name = name, Id = id });
            }

        }

        public League GetLeague(string name)
        {
            if (leagues.Count == 0)
                GetLeagues();
            return leagues.Single(X => X.Name.Contains(name));
        }

    }

    public class League
    {
        public string Name { get; set; }
        public string TeamsURI { get; set; }
        public string Id { get; set; }
        private List<Team> teams;
        public List<Team> Teams
        {
            get
            {
                if (teams == null)
                    DownLoadTeams();
                return teams;
            }
        }
        private void DownLoadTeams()
        {
            teams = new List<Team>();
            var response = new WebClient().DownloadString(TeamsURI);
            var jsonContent = JObject.Parse(response);
            foreach(JObject o in jsonContent["teams"])
            {
                var tempStr = (string)o["squadMarketValue"];
                teams.Add(new Team
                {
                    Name = (string)o["name"],
                    ShortName = (string)o["shortName"],
                    FixturesUrl = (string)o["_links"]["fixtures"]["href"],
                    MarketSquadValue = tempStr.Remove(tempStr.Length - 3) + (char)8364,
                    League = this,
                    Id = (string)o["_links"]["self"]["href"]
                });
            }
        }


    }

    public class Team
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string MarketSquadValue { get; set; }
        public string FixturesUrl { get; set; }
        public League League { get; set; }
        private List<Fixture> fixtures;
        public List<Fixture> Fixtures
        {
            get
            {
                if (fixtures == null)
                    DownloadFixtures();
                return fixtures;
            }
        }
        private void DownloadFixtures()
        {
            fixtures = new List<Fixture>();
            var result = new WebClient().DownloadString(FixturesUrl);
            var obj = JObject.Parse(result);
            var fixturesArray = (JArray)obj["fixtures"];
            foreach(JObject o in fixturesArray.Children())
            {
                var homeTeamId = (string)o["_links"]["homeTeam"]["href"];
                var awayTeamId = (string)o["_links"]["awayTeam"]["href"];
                var homeTeam = League.Teams.Single(X => X.Id == homeTeamId);
                var awayTeam = League.Teams.Single(X => X.Id == awayTeamId);
                var dateString = (string)o["date"];
                var date = new DateTime(int.Parse(dateString.Substring(6, 4)), int.Parse(dateString.Substring(0, 2)), int.Parse(dateString.Substring(3, 2)));
                var homeTeamScore = int.Parse((string)o["result"]["goalsHomeTeam"]);
                var awayTeamScore = int.Parse((string)o["result"]["goalsAwayTeam"]);
                Fixtures.Add(new Fixture { HomeTeam = homeTeam, AwayTeam = awayTeam, Date = date, HomeTeamScore = homeTeamScore, AwayTeamScore = awayTeamScore });
            }
           
        }

    }

    public class Fixture
    {
        public DateTime Date { get; set; }
        public Team HomeTeam { get; set; }
        public Team AwayTeam { get; set; }
        public int AwayTeamScore { get; set; }
        public int HomeTeamScore { get; set; }
    }

    public static class API_Utils
    {
        public static readonly  string API_KEY = "bafe07c7c0cb4baaaea544afa8424cef";
        public static readonly string BASE_URI = "http://api.football-data.org/";
    }


}
