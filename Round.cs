using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using Cards;
namespace Tarneeb_Card_Game
{
    class Round
    {
        public const int roundScore = 1;
        //List<Cards> RoundLCards = new List<Cards>();
        /*public Player RoundWinner()
        {

        }*/
        public List<Card> roundCards = new List<Card>();

        public int RoundWinner()
        {
            Card greaterCard = roundCards[0];
            for (int i=0;i<3;i++)
            {
               
                if (roundCards[i+1] >= greaterCard) 
                { 
                    greaterCard = roundCards[i+1];
                }
            }

            //return (roundCards.IndexOf( greaterCard ) +1);
            return greaterCard.cardOwner;
        }
    }
}
