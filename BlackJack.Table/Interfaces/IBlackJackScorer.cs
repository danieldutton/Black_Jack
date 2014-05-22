using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    public interface IBlackJackScorer : ICardScorer
    {
        int StickThreshold { get; }

        int WinningScore { get; }

        bool IsBlackJack(IEnumerable<PlayingCard> playingCards);
        
        bool IsBust(int score);

        bool BothPlayersAreBust(int playersScore, int dealersScore);

        bool PlayersAreDrawn(int playersScore, int dealersScore);
    }
}
