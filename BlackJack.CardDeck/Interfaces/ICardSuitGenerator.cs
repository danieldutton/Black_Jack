using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.CardDeck.Interfaces
{
    public interface ICardSuitGenerator
    {
        IEnumerable<PlayingCard> GenerateCardDeck();
    }
}
