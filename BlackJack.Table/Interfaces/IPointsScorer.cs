using BlackJack.CardDeck.Model;

namespace BlackJack.Table.Interfaces
{
    public interface IPointsScorer
    {
        int GetPlayingCardValue(PlayingCard playingCard);
    }
}
