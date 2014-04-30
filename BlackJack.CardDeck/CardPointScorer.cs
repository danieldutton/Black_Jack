using BlackJack.CardDeck.Model;

namespace BlackJack.CardDeck
{
    public static class CardPointScorer
    {
        public static int GetPlayingCardValue(PlayingCard playingCard)
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
