using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;

namespace BlackJack.Players
{
    public class Dealer : CardPlayer
    {
        private const int stickThreshold = 14;
        
        private const int BlackJackScore = 21;

        
        public void Play(ICardShoe cardShoe)
        {
            if (!StickThresholdReached())
            {
                while (CanStillHit())
                {
                    PlayingCard card = cardShoe.GetPlayingCard();
                    AddCardToHand(card);                  

                    if (StickThresholdReached())
                        break;
                }
            }
        }

        private bool CanStillHit()
        {
            return !IsBust() && CurrentScore < stickThreshold;
        }

        private bool StickThresholdReached()
        {
            return CurrentScore >= stickThreshold && CurrentScore <= BlackJackScore;
        }
    }
}
