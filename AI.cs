using Cards;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Media.Animation;
using static Cards.Enums;

namespace Tarneeb_Card_Game
{
    public class AI
    {
        /// <summary>
        ///  This function place bid in behalf of computer players utilize card strength of players card
        /// </summary>
        /// <param name="hand">List of player card who will place bid</param> 
        /// <param name="currentBid">highest bid that is placed till now</param>
        /// <param name="gameMode">mode of game </param>
        /// <returns>gives bid value in int from  current bid +1 and 14 for passing the bid </returns>
        public static int PlaceBid(List<Card> hand, int currentBid, string gameMode="Easy")
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
            // Define a dictionary that maps each suit to a list of card numbers

            // Count the number of face cards with Ace in each suit except the maxSuit
            int HighValueCard = 0;
            foreach (Card card in hand)
            {
                if ((card.Suit != maxSuit) && (card.CardNumber ==
                    CardNumber.Jack || card.CardNumber == CardNumber.Queen
                    || card.CardNumber == CardNumber.King || card.CardNumber == CardNumber.Ace))
                {
                    HighValueCard++;


                }
            }


            // Determine the bid based on the game mode and the maximum suit
            int bid = 0;
            switch (gameMode)
            {
                case "Easy":

                    Random random = new Random();
                    int randomNumber = random.Next(1, 101);
                    if (randomNumber < 20)
                    {
                        if (maxCount > 5) //best case if 8 or more card from trump suit
                        {
                            bid = random.Next(9, 14);
                        }
                        else
                        if (HighValueCard > 5)
                        {
                            bid = random.Next(8, 11);
                            if (bid == 8)
                                bid = 14;
                        }
                        else
                        if ((maxCount < 6) && (HighValueCard < 6))//best case if 8 or more card from trump suit
                        {
                            bid = random.Next(7, 9);
                            if (bid == 7)
                                bid = 14;
                        }

                    }
                    else
                    {
                        Random randEasyBid = new Random();
                        bid = randEasyBid.Next(currentBid + 1, 14);

                    }
                    break;


                case "Medium":

                    random = new Random();
                    randomNumber = random.Next(1, 101);
                    if (randomNumber < 77)
                    {
                        if (maxCount > 8) //best case if 8 or more card from trump suit
                        {
                            bid = random.Next(9, 14);
                        }
                        else
                        if (HighValueCard > 4) //best case if 8 or more card from trump suit
                        {
                            bid = random.Next(8, 10);
                            if (bid == 8)
                                bid = 14;
                        }
                        else
                        if ((maxCount < 6) && (HighValueCard < 6))//best case if 8 or more card from trump suit
                        {
                            bid = random.Next(7, 9);
                            if (bid == 7)
                                bid = 14;
                        }

                    }
                    else
                    {
                        Random randEasyBid = new Random();
                        bid = randEasyBid.Next(currentBid + 1, 14);

                    }
                    break;




                case "Hard":
                    random = new Random();
                    randomNumber = random.Next(1, 101);
                    if (randomNumber < 98)
                    {
                        if (maxCount > 10) //best case if 8 or more card from trump suit
                        {
                            bid = random.Next(10, 14);
                        }
                        else
                        if (HighValueCard > 7) //best case if 8 or more card from trump suit
                        {
                            bid = random.Next(8, 10);
                            if (bid == 8)
                                bid = 14;
                        }
                        else
                        if ((maxCount < 6) && (HighValueCard < 6))//best case if 8 or more card from trump suit
                        {
                            bid = random.Next(7, 9);
                            if (bid == 7)
                                bid = 14;
                        }

                    }
                    else
                    {
                        Random randEasyBid = new Random();
                        bid = randEasyBid.Next(currentBid + 1, 14);

                    }
                    break;

            }



            if (bid < currentBid + 1)
            {
                return 14;
            }
            return bid;
        }

        public static int selectTrump(List<Card> deck, string gameMode)
        {
            int trump;
            var maxSuit = (from card in deck
                           group card by card.Suit into g
                           orderby g.Count() descending
                           select g.Key).FirstOrDefault();
            if (gameMode == "Easy" || gameMode == "Medium" || gameMode == "Hard")
            {

                if (maxSuit == Suit.Club)
                {
                    trump = 1;
                }
                else if (maxSuit == Suit.Diamond)
                {
                    trump = 2;
                }
                else if (maxSuit == Suit.Heart)
                {
                    trump = 3;
                }
                else
                {
                    trump = 4;
                }
            }
            else
            {
                return 0;
            }
            return trump;
        }

        //public static Card playCard(List<Card> playersCard, string roundSuit, List<Card> roundCard, string trumpSuit, string gameMode)
        //{
        //    use roundsuit to find playable card
        //    List<Card> playableCard = new List<Card>();
        //    foreach (Card card in playersCard)
        //    {
        //        if ((card.Suit).ToString() == roundSuit)
        //        {
        //            playableCard.Add(card);
        //        }
        //    }
        //    Card bestCard = new Card();
        //    int teammate = 0;
        //    if (playableCard.ElementAt(0).cardOwner == 1)
        //        teammate = 3;
        //    if (playableCard.ElementAt(0).cardOwner == 3)
        //        teammate = 1;
        //    if (playableCard.ElementAt(0).cardOwner == 4)
        //        teammate = 2;
        //    if (playableCard.ElementAt(0).cardOwner == 2)
        //        teammate = 4;

        //    teammate -= 1;
        //    foreach (Card card in playableCard)
        //    {
        //        if (teammate >= 0 && teammate < roundCard.Count)
        //        {
        //            Card card1 = roundCard.ElementAt(teammate);
        //            if (card >= card1)
        //            {
        //                bestCard = card;
        //            }
        //        }
        //    }
        //    return bestCard;
        //}


        /// <summary>
        /// Play  card functioon that  use algorithum to selcet best card to win the round 
        /// </summary>
        /// <param name="playersCard"> cards of player in which we want to use AI to selct card</param>
        /// <param name="roundSuit">name of suit for current round </param>
        /// <param name="roundCard">list of card that are played till the round</param>
        /// <param name="trumpSuit">suit that is trump</param>
        /// <param name="gameMode">current game mode</param>
        /// <returns></returns>
        public static string PlayCard(List<Card> playersCard, string roundSuit, List<Card> roundCards, int inttrumpSuit, string gameMode)
        {
            string trumpSuit = "";
            if (inttrumpSuit == 1)
            {
                trumpSuit = "Club";
            }
            else if (inttrumpSuit == 2)
            {
                trumpSuit = "Diamond";
            }
            else if (inttrumpSuit == 3)
            {
                trumpSuit = "Heart";
            }
            else if (inttrumpSuit == 4)
            {
                trumpSuit = "Spade";
            }
            Card chosenCard = null;
            Card highestCard = null;

            Card lowestCard = null;

            Card roundHighestCard = null;
            if (roundCards.Count > 0)
            {
                roundHighestCard = roundCards.OrderByDescending(c => c.CardNumber).First();
            }



            // Count the number of cards in each suit
            Dictionary<Suit, int> suitCounts = new Dictionary<Suit, int>();
            foreach (Suit suit in Enum.GetValues(typeof(Suit)))
            {
                suitCounts[suit] = 0;
            }

            foreach (Card card in playersCard)
            {
                suitCounts[card.Suit]++;

            }

            if (gameMode == "Hard")
            {
                // Check if we have a card in the suit led
                if (!string.IsNullOrEmpty(roundSuit) && (suitCounts[Enum.Parse<Suit>(roundSuit)] > 0))
                {
                    List<Card> suitCards = playersCard.Where(c => c.Suit.ToString() == roundSuit).ToList();
                    if (suitCards.Count > 0)
                    {
                        highestCard = suitCards.OrderByDescending(c => c.CardNumber).First();

                        lowestCard = suitCards.OrderByDescending(c => c.CardNumber).Last();

                        if (highestCard >= roundHighestCard)
                        {

                            chosenCard = highestCard;
                        }

                        chosenCard = lowestCard;
                    }
                }
                else

                // Check if we have a trump card
                if (!string.IsNullOrEmpty(trumpSuit) && (suitCounts[Enum.Parse<Suit>(trumpSuit)] > 0))

                {
                    List<Card> trumpCards = playersCard.Where(c => c.Suit.ToString() == trumpSuit).ToList();
                    if (trumpCards.Count > 0)
                    {
                        highestCard = trumpCards.OrderByDescending(c => c.CardNumber).Last();
                        chosenCard = highestCard;
                    }
                }
                else


                // If we still haven't found a card, play the lowest-ranking card

                {
                    highestCard = playersCard.OrderByDescending(c => c.CardNumber).Last();
                    chosenCard = highestCard;
                }


                // Adjust strategy if necessary based on the highest card played so far
                //if ( roundCard.Count > 0)
                //{
                //    Card highestPlayedCard = roundCard.OrderByDescending(c => c.CardNumber).First();
                //    if (highestPlayedCard.CardNumber < highestCard.CardNumber)
                //    {
                //        chosenCard = playersCard.OrderBy(c => c.CardNumber).First();
                //    }
                //}

                // Remove the chosen card from our hand and return it
                playersCard.Remove(chosenCard);
                string returnCard = chosenCard.Suit.ToString() + chosenCard.CardNumber.ToString();
                return returnCard;
            }else



            if (gameMode == "Medium")
            {
                // Check if we have a card in the suit led
                if (!string.IsNullOrEmpty(roundSuit) && (suitCounts[Enum.Parse<Suit>(roundSuit)] > 0))
                {
                    List<Card> suitCards = playersCard.Where(c => c.Suit.ToString() == roundSuit).ToList();
                    if (suitCards.Count > 0)
                    {
                        highestCard = suitCards.OrderByDescending(c => c.CardNumber).First();

                        lowestCard = suitCards.OrderByDescending(c => c.CardNumber).Last();

                        if (highestCard >= roundHighestCard)
                        {

                            chosenCard = highestCard;
                        }

                        chosenCard = lowestCard;
                    }
                }
                else

                // Check if we have a trump card
                if (!string.IsNullOrEmpty(trumpSuit) && (suitCounts[Enum.Parse<Suit>(trumpSuit)] > 0))

                {
                    List<Card> trumpCards = playersCard.Where(c => c.Suit.ToString() == trumpSuit).ToList();
                    if (trumpCards.Count > 0)
                    {
                        highestCard = trumpCards.OrderByDescending(c => c.CardNumber).Last();
                        chosenCard = highestCard;
                    }
                }
                else


                // If we still haven't found a card, play the lowest-ranking card

                {
                    highestCard = playersCard.OrderByDescending(c => c.CardNumber).Last();
                    chosenCard = highestCard;
                }


                // Adjust strategy if necessary based on the highest card played so far
                //if ( roundCard.Count > 0)
                //{
                //    Card highestPlayedCard = roundCard.OrderByDescending(c => c.CardNumber).First();
                //    if (highestPlayedCard.CardNumber < highestCard.CardNumber)
                //    {
                //        chosenCard = playersCard.OrderBy(c => c.CardNumber).First();
                //    }
                //}

                // Remove the chosen card from our hand and return it
                playersCard.Remove(chosenCard);
                string returnCard = chosenCard.Suit.ToString() + chosenCard.CardNumber.ToString();
                return returnCard;

            }else
            if (gameMode == "Easy")
            {
                // Check if we have a card in the suit led
                if (!string.IsNullOrEmpty(roundSuit) && (suitCounts[Enum.Parse<Suit>(roundSuit)] > 0))
                {
                    List<Card> suitCards = playersCard.Where(c => c.Suit.ToString() == roundSuit).ToList();
                    if (suitCards.Count > 0)
                    {
                        highestCard = suitCards.Last();

                        lowestCard = suitCards.First();

                        if (highestCard >= roundHighestCard)
                        {

                            chosenCard = highestCard;
                        }

                        chosenCard = lowestCard;
                    }
                }
                else

                // Check if we have a trump card
                if (!string.IsNullOrEmpty(trumpSuit) && (suitCounts[Enum.Parse<Suit>(trumpSuit)] > 0))

                {
                    List<Card> trumpCards = playersCard.Where(c => c.Suit.ToString() == trumpSuit).ToList();
                    if (trumpCards.Count > 0)
                    {
                        highestCard = trumpCards.Last();
                        chosenCard = highestCard;
                    }
                }
                else


                // If we still haven't found a card, play the lowest-ranking card

                {
                    highestCard = playersCard.OrderByDescending(c => c.CardNumber).Last();
                    chosenCard = highestCard;
                }


                // Adjust strategy if necessary based on the highest card played so far
                //if ( roundCard.Count > 0)
                //{
                //    Card highestPlayedCard = roundCard.OrderByDescending(c => c.CardNumber).First();
                //    if (highestPlayedCard.CardNumber < highestCard.CardNumber)
                //    {
                //        chosenCard = playersCard.OrderBy(c => c.CardNumber).First();
                //    }
                //}

                // Remove the chosen card from our hand and return it
                playersCard.Remove(chosenCard);
                string returnCard = chosenCard.Suit.ToString() + chosenCard.CardNumber.ToString();
                return returnCard;


            }
            else
            {

                highestCard = playersCard.OrderByDescending(c => c.CardNumber).Last();
                chosenCard = highestCard;
                playersCard.Remove(chosenCard);
                string returnCard = chosenCard.Suit.ToString() + chosenCard.CardNumber.ToString();
                return returnCard;

            }



        }

    }
}
