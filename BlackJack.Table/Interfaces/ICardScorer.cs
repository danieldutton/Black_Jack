using BlackJack.CardDeck.Model;

namespace BlackJack.Table.Interfaces
{
    public interface ICardScorer
    {
        int StickThreshold { get; }

        int WinningScore { get; }

        int GetPlayingCardValue(PlayingCard playingCard);
    }
}
