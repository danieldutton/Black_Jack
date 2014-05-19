using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;

namespace BlackJack.Table
{
    public class BlackJackScorer : ICardScorer
    {
        private const int _stickThreshold = 15;

        public int StickThreshold{get { return _stickThreshold; }}

        private const int _winningScore = 21;

        public int WinningScore { get { return _winningScore; } }


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
