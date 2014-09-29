using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Utility;
using System.Collections.Generic;

namespace BlackJack.UnitTests
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

        public static Queue<PlayingCard> GetIdenticalCardDeckAceOfClubs(int cardCount)
        {
            var cardDeck = new Queue<PlayingCard>();

            for (int i = 0; i < cardCount; i++)
            {
                cardDeck.Enqueue(new PlayingCard(Suit.Club, CardNumber.Ace));
            }

            return cardDeck;
        }

        public static Queue<PlayingCard> GetOrderedCardDeck()
        {
            var cardSuitGenerator = new PlainCardDeckGenerator();
            var cardImageMapper = new CardImageMapper(new ResourceHandler());
            var cardDeckGenerator = new CardDeckBuilder(cardSuitGenerator, cardImageMapper);

            var orderedCardDeck = cardDeckGenerator.GetCardDeck();

            return orderedCardDeck;
        } 
    }
}
