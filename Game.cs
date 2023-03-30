using UsingCards;

namespace Tarneeb_Card_Game
{
    class Game
    {
        public const int winningScore = 31;

        //public int currentScore;
        //public int matchScore;
        //public int roundScore;
        public int gameScore;

        public Game()
        {
            setGameScore(0);
            Team team01 = new Team("Player 1", "Player3");
            Team team02 = new Team("player 2", "Player4");
            while (gameScore < winningScore)
            {
                Match match = new Match();
            }
           
        }


        public int getGameScore()
        {
            return gameScore;
        }

        public void setGameScore(int gameScore)
        {
            this.gameScore = gameScore;
        }


    }
}
