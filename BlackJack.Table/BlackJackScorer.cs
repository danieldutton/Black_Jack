using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Table
{
    public class BlackJackScorer : IBlackJackScorer
    {
        public int StickThreshold { get; private set; }

        private const int BlackJackScore = 21;

        public int BlackJack{ get { return BlackJackScore; }}


        public BlackJackScorer(int stickThreshold)
        {
            StickThreshold = stickThreshold;
        }

        public bool IsBlackJack(IEnumerable<PlayingCard> playingCards)
        {
            int score = 0;

            var enumerable = playingCards as IList<PlayingCard> ?? playingCards.ToList();

            if (HasOnlyTwoCards(enumerable))
            {
                foreach (var playingCard in enumerable)
                {
                    switch (playingCard.CardNumber)
                    {
                        case CardNumber.Jack:
                        case CardNumber.Queen:
                        case CardNumber.King:
                        case CardNumber.Ten:
                            score = 10;
                            break;
                        case CardNumber.Ace:
                            score = 11;
                            break;
                    }
                }    
            }
           
            if (score == 21) return true;

            return false;
        }

        public int GetCardHandValue(IEnumerable<PlayingCard> playingCards)
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
                        score += 10;
                        break;
                    case CardNumber.Ace:
                        score += 11;
                        aceCount++;
                        break;
                    default:
                        score += (int) playingCard.CardNumber;
                        break;
                }
            }
            for (int i = 0; i < aceCount; i++)
            {
                if (score > 21)
                {
                    score -= 10;
                }
            }
            return score;
        }

        private bool HasOnlyTwoCards(IEnumerable<PlayingCard> playingCards)
        {
            return playingCards.Count() == 2;
        }

        public bool IsBust(int score)
        {
            return score > BlackJackScore;
        }

        public bool BothPlayersBust(int playersScore, int dealersScore)
        {
            return IsBust(playersScore) && IsBust(dealersScore);
        }

        public bool PlayersDrawn(int playersScore, int dealersScore)
        {
            return playersScore == dealersScore;
        }
    }
}