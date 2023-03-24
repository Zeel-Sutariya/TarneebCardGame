using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarneeb_Card_Game
{
    class Game
    {
        public const int winningScore = 31;

        public int currentScore;
        //public int matchScore;
        //public int roundScore;

        public Game()
        {
            setCurrentScore(0);
        }


        public int getCurrentScore()
        {
            return currentScore;
        }

        public void setCurrentScore(int currentScore)
        {
            this.currentScore = currentScore;
        }


    }
}
