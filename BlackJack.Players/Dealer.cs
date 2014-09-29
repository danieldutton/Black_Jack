using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;

namespace BlackJack.Players
{
    public class Dealer : CardPlayer
    {
        private const int StickThreshold = 16;
        
        private const int BlackJackScore = 21;

        
        public void Play(ICardShoe cardShoe)
        {
            if (!StickThresholdReached())
            {
                while (CanStillHit())
                {
                    PlayingCard card = cardShoe.GetPlayingCard();
                    AcceptNewCard(card);                  

                    if (StickThresholdReached())
                        break;
                }
            }
        }

        private bool CanStillHit()
        {
            return !IsBust() && CurrentScore < StickThreshold;
        }

        private bool StickThresholdReached()
        {
            return CurrentScore >= StickThreshold && CurrentScore <= BlackJackScore;
        }
    }
}
