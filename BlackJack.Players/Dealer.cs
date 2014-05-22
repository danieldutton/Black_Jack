using BlackJack.CardDeck.Model;
using BlackJack.Players.Interfaces;
using BlackJack.Table.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Players
{
    public class Dealer : IAutomatedCardPlayer
    {//dry principle duplicate code
        public List<PlayingCard> CurrentHand { get; set; }

        public int CurrentScore { get; set; }


        public Dealer()
        {
            CurrentHand = new List<PlayingCard>();
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
                    PlayingCard card = cardShoe.TakeSinglePlayingCard();

                    int score = cardScorer.GetCardValue(card);
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