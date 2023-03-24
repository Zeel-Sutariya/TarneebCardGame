using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarneeb_Card_Game
{
    class Team
    {
        public int teamScore;

        public int getTeamScore()
        {
            return teamScore;
        }

        public void setTeamScore(int teamScore)
        {
            this.teamScore = teamScore;
        }

        public Team()
        {
            setTeamScore(0);
        }

    }
}
