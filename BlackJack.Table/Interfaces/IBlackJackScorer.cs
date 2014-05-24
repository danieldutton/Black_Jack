using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    public interface IBlackJackScorer : ICardScorer
    {
        int BlackJack { get; }

        int StickThreshold { get; }

        bool IsBlackJack(IEnumerable<PlayingCard> playingCards);

        bool IsBust(int score);

        bool BothPlayersBust(int playersScore, int dealersScore);
    }
}
