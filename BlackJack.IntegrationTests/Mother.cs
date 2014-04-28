using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.IntegrationTests
{
    public static class Mother
    {
        public static IEnumerable<CardNumber> ExpectedSuitOrder()
        {
            IEnumerable<CardNumber> expected = new List<CardNumber>
            {
                CardNumber.Ace,
                CardNumber.Two,
                CardNumber.Three,
                CardNumber.Four,
                CardNumber.Five,
                CardNumber.Six,
                CardNumber.Seven,
                CardNumber.Eight,
                CardNumber.Nine,
                CardNumber.Ten,
                CardNumber.Jack,
                CardNumber.Queen,
                CardNumber.King
            };

            return expected;
        }

        public static Queue<PlayingCard> GetTestDeckFiveMixedPlayingCards()
        {
            var testDeck = new Queue<PlayingCard>();

            testDeck.Enqueue(new PlayingCard(Suit.Club, CardNumber.Ace));
            testDeck.Enqueue(new PlayingCard(Suit.Heart, CardNumber.Seven));
            testDeck.Enqueue(new PlayingCard(Suit.Club, CardNumber.Nine));
            testDeck.Enqueue(new PlayingCard(Suit.Spade, CardNumber.Four));
            testDeck.Enqueue(new PlayingCard(Suit.Diamond, CardNumber.King));

            return testDeck;
        } 
    }
}
