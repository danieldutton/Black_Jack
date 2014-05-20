using System.Collections.Generic;
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

        public int TotalScores(IEnumerable<PlayingCard> playingCards)
        {
            int score = 0;
            int aceCount = 0;

            foreach (var playingCard in playingCards)
            {
                switch (playingCard.CardNumber)
                {
                    case CardNumber.Jack:
                    case CardNumber.Queen:
                    case CardNumber.King:
                        score = 10;
                        break;
                    case CardNumber.Ace:
                        score = 11;
                        aceCount++;
                        break;
                    default:
                        return (int)playingCard.CardNumber;
                }   
            }

            //if the hand total is greater than 21 then subtract 10 for every ace found until the hand value is less
            //than 21
            for (int i = 0; i < aceCount; i++)
            {
                if (score > 21)
                {
                    score -= 10;
                }
            }

            return score;
        }
    }
}
