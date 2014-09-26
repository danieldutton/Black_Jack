using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;

namespace BlackJack.Players
{
    public class Dealer : CardPlayer
    {
        public void Play(ICardShoe cardShoe, IBlackJackScorer cardScorer)
        {
            int stickThreshold = cardScorer.StickThreshold;
            int winningScore = cardScorer.BlackJack;
            //dealer is not sticking when he should but only after the player hits one or more cards
            if (CurrentScore < stickThreshold)
            {
                while (!IsBust() && CurrentScore < stickThreshold)
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
