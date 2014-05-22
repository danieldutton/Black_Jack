using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Table
{
    public class BlackJackScorer : ICardScorer
    {
        private const int _stickThreshold = 15;

        public int StickThreshold
        {
            get { return _stickThreshold; }
        }

        private const int _winningScore = 21;

        public int WinningScore
        {
            get { return _winningScore; }
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

        public int GetCardValue(PlayingCard playingCard)
        {
            switch (playingCard.CardNumber)
            {
                case CardNumber.Jack:
                case CardNumber.Queen:
                case CardNumber.King:
                    return 10;
                default:
                    return (int) playingCard.CardNumber;
            }
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
            return score > WinningScore;
        }

        public bool BothPlayersAreBust(int playersScore, int dealersScore)
        {
            return IsBust(playersScore) && IsBust(dealersScore);
        }

        public bool PlayersAreDrawn(int playersScore, int dealersScore)
        {
            return playersScore == dealersScore;
        }
    }
}