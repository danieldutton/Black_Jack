using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.CardDeck.Interfaces
{
    public interface ICardSuitBuilder
    {
        IEnumerable<PlayingCard> GetOrderedCardDeck();
    }
}
