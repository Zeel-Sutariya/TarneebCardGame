using Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
namespace Tarneeb_Card_Game
{
    class Match
    {
        public int matchScore;
        public List<Card> player1 = new List<Card>();
        public List<Card> player2 = new List<Card>();
        public List<Card> player3 = new List<Card>();
        public List<Card> player4 = new List<Card>();
        public int highestBid;
        public int getMatchScore()
        {
            return matchScore;
        }

        public void setMatchScore(int matchScore)
        {
            this.matchScore = matchScore;
        }
        public int getHighestBid()
        {
            return highestBid;
        }

        public void setHighestBid(int highestBid)
        {
            this.highestBid = highestBid;
        }

        public Match()
        {
            setMatchScore(0);
        }

        public void CalculateMatchScore()
        {
            
        }
    }
}
