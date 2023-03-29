using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsingCards;

namespace Tarneeb_Card_Game
{
    class Team
    {
        public int teamScore;
        public string playerName;
        public int teamBid;
        public int getTeamScore()
        {
            return teamScore;
        }

        public void setTeamScore(int teamScore)
        {
            this.teamScore = teamScore;
        }

        public void setTeamBid(int teamBid)
        {
            this.teamBid = teamBid;
        }

        public int getTeamBid()
        {
            return this.teamBid;
        }

        public Team(string playerA, string playerB)
        {

            Player player01 = new Player(playerA);
            Player player02 = new Player(playerB);
            setTeamScore(0);
        }

        public void CalculateTeamScore(int playerA_MatchScore, int playerB_MatchScore)
        {
            setTeamScore(playerA_MatchScore + playerB_MatchScore);
        }

    }
}
