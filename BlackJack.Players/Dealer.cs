using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;

namespace BlackJack.Players
{
    public class Dealer : CardPlayer
    {
        public void Play(ICardShoe cardShoe)
        {
            const int stickThreshold = 14;
            const int winningScore = 21;

            if (HasTwoCardsInHand() && HasBlackJack()) return;
            if (CurrentScore < stickThreshold)
            {
                while (!IsBust() && CurrentScore < stickThreshold)
                {
                    PlayingCard card = cardShoe.GetPlayingCard();
                    AddCardToHand(card);                  

                    if (CurrentScore >= stickThreshold && CurrentScore <= winningScore)
                    {
                        break;
                    }
                }
            }
        }
    }
}
