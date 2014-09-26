using BlackJack.CardDeck.Model;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Players
{
    public class CardPlayer
    {
        public int CurrentScore { get; set; }

        public List<PlayingCard> CurrentHand { get; set; }


        public CardPlayer()
        {
            CurrentHand = new List<PlayingCard>();
        }

        public bool IsBust()
        {
            return CurrentScore > 21;
        }

        public bool HasBlackJack()
        {
            int score = 0;

            if (HasTwoCardsInHand())
            {
                foreach (var playingCard in CurrentHand)
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

        public int AddCardToHand(PlayingCard card)
        {
            CurrentHand.Add(card);
            int score = 0;
            int aceCount = 0;

                switch (card.CardNumber)
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
                        score += (int)card.CardNumber;
                        break;
                }
            
            for (int i = 0; i < aceCount; i++)
            {
                if (score > 21)
                {
                    score -= 10;
                }
            }
            CurrentScore += score;
            return score;
        }

        private void UpdateHandValue()
        {
            
        }

        public bool HasTwoCardsInHand()
        {
            return CurrentHand.Count() == 2;
        }

        public bool ScoresAreDrawn(int scoreToCompare)
        {
            return CurrentScore == scoreToCompare;
        }

        public void DisposeOfHand()
        {
            CurrentScore = 0;
            CurrentHand.Clear();
        }

    }
}
