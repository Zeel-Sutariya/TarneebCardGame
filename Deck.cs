using Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarneeb_Card_Game
{
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
                .SelectMany(s => Enumerable.Range(2, 13)
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
                OrderByDescending(c => c.Count()).SelectMany(g => g.OrderBy(c => c.CardNumber)).ToList();


            return sorted;

        }
    }
}
