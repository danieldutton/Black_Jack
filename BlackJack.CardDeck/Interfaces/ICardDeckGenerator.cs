using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.CardDeck.Interfaces
{
    public interface ICardDeckGenerator
    {
        IEnumerable<PlayingCard> GetPlainCardDeck();
    }
}
