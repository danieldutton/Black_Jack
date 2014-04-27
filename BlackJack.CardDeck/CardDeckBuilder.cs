using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.CardDeck
{
    public class CardDeckBuilder : ICardDeckBuilder
    {
        public Queue<PlayingCard> GetOrderedCardDeck()
        {
            List<PlayingCard> cards = Enumerable.Range(0, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                    .Select(c => new PlayingCard((Suit)s, (CardNumber)c)
                    )
                )
                .ToList();

            return new Queue<PlayingCard>(cards);
        } 
    }
}
