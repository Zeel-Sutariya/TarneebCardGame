using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cards
{
    public static class Enums
    {

        public enum Suit
        {
            Club = 1,
            Diamond = 2,
            Heart = 3,
            Spades = 4,
        }

        public enum CardNumber
        {
            Ace = 1,
            Two = 2,
            Three = 3,
            Four = 4,
            Five = 5,
            Six = 6,
            Seven = 7,
            Eight = 8,
            Nine = 9,
            Ten = 10,
            Jack = 11,
            Queen = 12,
            King = 13,
        }




    }

    public class Card
    {
        
        public Enums.Suit Suit { get; set; }
        public Enums.CardNumber CardNumber { get; set; }

        public Boolean isFaceUp = false;


        public Boolean getIsFaceUp()
        {
            return isFaceUp;
        }

        public void setIsFaceUp(Boolean isFaceUp)
        {
            this.isFaceUp = isFaceUp;
        }

        public Boolean isTrump;

        public Boolean getIsTrump()
        {
            return isTrump;
        }

        public void setIsTrump(Boolean isTrump)
        {
            this.isTrump = isTrump;
        }

        public static bool operator >=(Card card1, Card card2)
        {
            //Enums.Suit currentSuit = card1.Suit;
            if (card1.Suit == card2.Suit)
            {
                return card1.CardNumber >= card2.CardNumber;
            }
            else if (card1.isTrump)
            {
                return true;
            }
            else if (card2.isTrump)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool operator <=(Card card1, Card card2)
        {

            if (card1.Suit == card2.Suit)
            {
                return card1.CardNumber <= card2.CardNumber;
            }
            else if (card1.isTrump)
            {
                return false;
            }
            else if (card2.isTrump)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool operator ==(Card card1, Card card2)
        {
            if (card1.Suit == card2.Suit && card1.CardNumber== card2.CardNumber)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public static bool operator !=(Card card1, Card card2)
        {
            if (card1.Suit != card2.Suit && card1.CardNumber != card2.CardNumber)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public override string ToString()
        {

            return "The Suit is: " + this.Suit + " The card number is: " + this.CardNumber;



        }

        public string getImagePath(Card card)
        {
            return "path";
        }
    }

    public class Deck
    {
        public Deck()
        {
            Reset();
        }

        public List<Card> Cards { get; set; }

        public void Reset()
        {
            Cards = Enumerable.Range(1, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                                    .Select(c => new Card()
                                    {
                                        Suit = (Enums.Suit)s,
                                        CardNumber = (Enums.CardNumber)c
                                    }
                                            )
                            )
                   .ToList();
        }

        public void Shuffle()
        {
            Cards = Cards.OrderBy(c => Guid.NewGuid())
                         .ToList();
        }

        public Card TakeCard()
        {
            var card = Cards.FirstOrDefault();
            Cards.Remove(card);
            return card;
        }

        public List<Card> TakeCards(int numberOfCards)
        {
            var cards = Cards.Take(numberOfCards);

            //var takeCards = cards as Card[] ?? cards.ToArray();
            var takeCards = cards as List<Card> ?? cards.ToList();
            Cards.RemoveAll(takeCards.Contains);

            return takeCards;
        }

        public List<Card> Sort(List<Card> listOfCards)
        {
            List<Card> sorted = listOfCards.GroupBy(s => s.Suit).
                OrderByDescending(c => c.Count()).SelectMany(g => g.OrderByDescending(c => c.CardNumber)).ToList();

            
            return sorted;

        }
    }


}
