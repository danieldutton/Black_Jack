using BlackJack.CardDeck.Model;
using BlackJack.Players.Interfaces;
using BlackJack.Table.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Players
{
    public class Dealer : ICardPlayer
    {
        public List<PlayingCard> CurrentHand { get; set; }

        public int CurrentScore { get; set; }


        public Dealer()
        {
            CurrentHand = new List<PlayingCard>();
        }

        public bool IsBust(int score)
        {
            return score > 21;
        }

        public void DisposeOfCurrentHand()
        {
            CurrentScore = 0;
            CurrentHand.Clear();
        }

        public void FinishPlay(ICardShoe cardShoe, ICardScorer cardScorer)
        {
            int stickThreshold = cardScorer.StickThreshold;
            int winningScore = cardScorer.WinningScore;

            if (CurrentScore < stickThreshold)
            {
                while (CurrentScore < winningScore && CurrentScore < stickThreshold)
                {
                    PlayingCard card = cardShoe.GetNextPlayingCard();

                    int score = cardScorer.GetPlayingCardValue(card);
                    CurrentScore += score;

                    CurrentHand.Add(card);

                    if (CurrentScore >= stickThreshold && CurrentScore <= winningScore)
                    {
                        break;
                    }
                }
            }
        }
    }
}