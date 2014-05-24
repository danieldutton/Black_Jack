using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    public interface ICardScorer
    {       
        int GetCardHandValue(IEnumerable<PlayingCard> playingCards);
        
        bool PlayersDrawn(int playersScore, int dealersScore);
    }
}
