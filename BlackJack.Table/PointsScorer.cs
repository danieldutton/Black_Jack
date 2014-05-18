using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;

namespace BlackJack.Table
{
    public class PointsScorer : IPointsScorer
    {
        public int GetPlayingCardValue(PlayingCard playingCard)
        {
            switch (playingCard.CardNumber)
            {
                case CardNumber.Jack:
                case CardNumber.Queen:
                case CardNumber.King:
                    return 10;
                default:
                    return (int)playingCard.CardNumber;
            }
            //ToDo - A strategy for scoring an Ace High/Low
        }
    }
}
