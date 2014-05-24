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


        public void FinishPlay(ICardShoe cardShoe, IBlackJackScorer cardScorer)
        {            
            int stickThreshold = cardScorer.StickThreshold;
            int winningScore = cardScorer.BlackJack;
            //dealer is not sticking when he should but only after the player hits one or more cards
            if (CurrentScore < stickThreshold)
            {
                while (CurrentScore < winningScore && CurrentScore < stickThreshold)
                {
                    PlayingCard card = cardShoe.GetPlayingCard();
                    CurrentHand.Add(card);
                    
                    int score = cardScorer.GetCardHandValue(CurrentHand);
                    CurrentScore = score;

                    if (CurrentScore >= stickThreshold && CurrentScore <= winningScore)
                    {
                        break;
                    }
                }
            }
        }
    }
}