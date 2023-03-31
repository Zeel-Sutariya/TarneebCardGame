using Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using static Cards.Enums;

namespace Tarneeb_Card_Game
{
    public class AI
    {
        public static int PlaceBid(List<Card> hand, int currentBid, string gameMode)
        {
            // Count the number of cards in each suit
            Dictionary<Suit, int> suitCounts = new Dictionary<Suit, int>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                suitCounts[suit] = 0;
            }

            foreach (Card card in hand)
            {
                suitCounts[card.Suit]++;
                
            }

            // Find the suit with the maximum number of cards
            Suit maxSuit = Suit.Club;
            int maxCount = 0;
            foreach (KeyValuePair<Suit, int> pair in suitCounts)
            {
                if (pair.Value > maxCount)
                {
                    maxSuit = pair.Key;
                    maxCount = pair.Value;
                }
            }


            





            // Determine the bid based on the game mode and the maximum suit
            int bid = currentBid;
            switch (gameMode)
            {
                case "Easy":
                    bid = Math.Max(bid, maxCount + 6);
                    break;
                case "Medium":
                    bid = Math.Max(bid, maxCount + 7);
                    break;
                case "Hard":
                    bid = Math.Max(bid, maxCount + 8);
                    break;
            }



            // Make sure the bid is between 7 and 13, or return null if not
            if (bid >= 7 && bid <= 13)
            {
                return bid;
            }
            else
            {
                return 14;
            }
        }



    }

}
