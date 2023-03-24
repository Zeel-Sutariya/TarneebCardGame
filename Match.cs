using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarneeb_Card_Game
{
    class Match
    {
        public int matchScore;

        public int getMatchScore()
        {
            return matchScore;
        }

        public void setMatchScore(int matchScore)
        {
            this.matchScore = matchScore;
        }

        public Match()
        {
            setMatchScore(0);
        }

        /*public int CalculateMatchScore()
        {

        }*/
    }
}
