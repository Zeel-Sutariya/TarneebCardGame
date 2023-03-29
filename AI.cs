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
        public static int? PlaceBid(List<Card> hand,int currentBid, String gameMode)
        {
                // Determine the minimum and maximum bids based on the game mode
                int minBid, maxBid;
                switch (gameMode)
                {
                    case "easy":
                        minBid = 7;
                        maxBid = 9;
                        break;
                    case "medium":
                        minBid = 7;
                        maxBid = 11;
                        break;
                    case "hard":
                        minBid = 7;
                        maxBid = 13;
                        break;
                    default:
                        throw new ArgumentException("Invalid game mode", nameof(gameMode));
                }

                // Determine the strength of the player's hand based on the number of high-ranking cards
                int highRankingCards = hand.Count(card => card.CardNumber >= CardNumber.Jack);

                // Determine the minimum bid based on the current bid and the strength of the player's hand
                int minBidForStrength = Math.Max(currentBid + 1, highRankingCards + 6);

                // Determine the final minimum bid based on the game mode and the minimum bid for the hand strength
                int finalMinBid = Math.Max(minBid, minBidForStrength);

                // Determine the maximum bid based on the game mode and the current bid
                int finalMaxBid = Math.Min(maxBid, 13);

                // Generate a random bid between the minimum and maximum bids
                Random rand = new Random();
                int bid = rand.Next(finalMinBid, finalMaxBid + 1);

                // If the bid is less than the current bid, return null to indicate no bid
                if (bid <= currentBid)
                {
                    return null;
                }

                // Otherwise, return the bid
                return bid;
            }
        
            static void Main(string[] args)
            {
                // Create a list of cards to use for testing
                Deck deck = new Deck();
                List<Card> hand = deck.TakeCards(13);

                // Test the function with different game modes and current bids
                int? bid = PlaceBid(hand, 6,"easy");
                Console.WriteLine($"Bid: {bid}");

                bid = PlaceBid(hand, 7, "easy");
                Console.WriteLine($"Bid: {bid}");

                bid = PlaceBid(hand, 10, "medium");
                Console.WriteLine($"Bid: {bid}");

                bid = PlaceBid(hand, 12, "hard");
                Console.WriteLine($"Bid: {bid}");

                // You can add more test cases here to cover other scenarios

                Console.ReadLine();
            }

        }
    

    
}
