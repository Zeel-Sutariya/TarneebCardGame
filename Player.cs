using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Diagnostics;
using Cards;

namespace UsingCards
{
    class Player
    {
        public string name { get; set; }
        public List<Card> playersCards = new List<Card>();
        public int bid;
        public Boolean isBidWinner;
        //public String trump { get; set; }
    

        public Player(string name, List<Card> playersCards)
        {
            this.name = name;
            this.playersCards = playersCards;

        }

        public int getBid() { return bid; }
        public void setBid(int bid) { this.bid = bid; }

        public List<Card> getPlayersCards() { return playersCards; }        
        public Boolean getIsBidWinner() { return isBidWinner; }
        public void setIsBidWinner(Boolean isBidWinner) { this.isBidWinner = isBidWinner; }

       



    }
}
