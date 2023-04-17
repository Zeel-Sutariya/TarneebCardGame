using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cards
{
    public static class Enums
    {

        public enum Suit
        {
            Club = 1,
            Diamond = 2,
            Heart = 3,
            Spade = 4,
        }

        public enum CardNumber
        {
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
            Ace = 14,
        }




    }

    public class Card
    {
        
        public Enums.Suit Suit { get; set; }
        public Enums.CardNumber CardNumber { get; set; }

        public Boolean isFaceUp = false;
        public Button ParentButton { get; set; }
        public int cardOwner { get; set; }

        public Card() 
        { 
            cardOwner = 0;
        }
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

        public static void SetTrump(Card trump)
        {
            trump.isTrump = true;
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
                return false;
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
                return true;
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

        public string getImagePath()
        {
            string path = "";
            if (this.isFaceUp)
            { 
                string name = Convert.ToString(this.Suit) + Convert.ToString(this.CardNumber);
                path = "/Images/Cards/" + name + ".png";
            
            }
            else
            {
                path = "/Images/cardBackRed.png";
            }
            return path;
        }
    }

    


}
