using BlackJack.CardDeck.Model;

namespace BlackJack.CardDeck
{
    public class CardPointScorer
    {
        public int GetPlayingCardValue(PlayingCard playingCard)
        {
            switch (playingCard.CardNumber)
            {
                case CardNumber.Jack:
                case CardNumber.Queen:
                case CardNumber.King:
                    return 10;
                default:
                    return (int)playingCard.CardNumber;
            }
        }
    }
}
