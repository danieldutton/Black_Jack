namespace BlackJack.CardDeck
{
    public sealed class PlayingCard
    {
        public Suit Suit { get; private set; }

        public CardNumber CardNumber { get; private set; }


        public PlayingCard(Suit suit, CardNumber cardNumber)
        {
            Suit = suit;
            CardNumber = cardNumber;
        }

        public override string ToString()
        {
            return string.Format("[{0}] Suit: {1} CardNumber: {2}",
                GetType().Name, Suit, CardNumber);
        }
    }
}
