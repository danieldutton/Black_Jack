using BlackJack.CardDeck.Model;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Table
{
    public class CardPlayer
    {
        private int _aceCount;

        public int CurrentScore { get; set; }

        public List<PlayingCard> CurrentHand { get; set; }


        public CardPlayer()
        {
            CurrentHand = new List<PlayingCard>();
        }

        public bool HasBlackJack()
        {
            int score = 0;

            if (HasTwoCards())
            {
                foreach (PlayingCard playingCard in CurrentHand)
                {
                    switch (playingCard.CardNumber)
                    {
                        case CardNumber.Jack:
                        case CardNumber.Queen:
                        case CardNumber.King:
                        case CardNumber.Ten:
                            score += 10;
                            break;
                        case CardNumber.Ace:
                            score += 11;
                            break;
                    }
                }
            }

            return score == 21;
        }

        public void AcceptNewCard(PlayingCard card)
        {
            CurrentHand.Add(card);
            int tempScore = 0;

            switch (card.CardNumber)
            {
                case CardNumber.Jack:
                case CardNumber.Queen:
                case CardNumber.King:
                    tempScore += 10;
                    break;
                case CardNumber.Ace:
                    tempScore += 11;
                    _aceCount++;
                    break;
                default:
                    tempScore += (int) card.CardNumber;
                    break;
            }
            CurrentScore += tempScore;

            AdjustScoreForAces();
        }

        private void AdjustScoreForAces()
        {
            while ((CurrentScore > 21) && (_aceCount > 0))
            {
                CurrentScore -= 10;
                _aceCount--;
            }
        }

        public bool IsBust()
        {
            return CurrentScore > 21;
        }

        public bool HasTwoCards()
        {
            return CurrentHand.Count() == 2;
        }

        public bool ScoresTied(int scoreToCompare)
        {
            return CurrentScore == scoreToCompare;
        }

        public void DisposeHand()
        {
            _aceCount = 0;
            CurrentScore = 0;
            CurrentHand.Clear();
        }
    }
}