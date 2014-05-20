using BlackJack.CardDeck.Model;
using BlackJack.Utility;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack.UnitTests.Utility
{
    [TestFixture]
    public class GuidShuffler_Should
    {
        [Test]
        public void Shuffle_ReturnExactly52Cards()
        {
            Queue<PlayingCard> orderedCardDeck = Mother.GetUnshuffledCardDeck();
            var sut = new GuidShuffler<PlayingCard>();

            Queue<PlayingCard> shuffledCardDeck = sut.Shuffle(orderedCardDeck);

            Assert.AreEqual(52, shuffledCardDeck.Count);
        }

        [Test]
        public void Shuffle_Return52CardsWithNoDuplicates()
        {
            Queue<PlayingCard> orderedCardDeck = Mother.GetUnshuffledCardDeck();
            var sut = new GuidShuffler<PlayingCard>();

            Queue<PlayingCard> shuffledCardDeck = sut.Shuffle(orderedCardDeck);

            CollectionAssert.AreEquivalent(shuffledCardDeck, orderedCardDeck);
        }

        [Test]
        public void Shuffle_Return52CardsInRandomOrder()
        {
            Queue<PlayingCard> orderedCardDeck = Mother.GetUnshuffledCardDeck();
            var sut = new GuidShuffler<PlayingCard>();

            Queue<PlayingCard> shuffledCardDeck = sut.Shuffle(orderedCardDeck);

            CollectionAssert.AreNotEqual(shuffledCardDeck, orderedCardDeck);   
        }

        [Test] //Probability wise this test is not deterministic
        public void Shuffle_TwoDecksShuffled_NotEqual()
        {
            Queue<PlayingCard> orderedCardDeck = Mother.GetUnshuffledCardDeck();
            var sut = new GuidShuffler<PlayingCard>();

            Queue<PlayingCard> shuffledCardDeck1 = sut.Shuffle(orderedCardDeck);
            Queue<PlayingCard> shuffledCardDeck2 = sut.Shuffle(orderedCardDeck);

            CollectionAssert.AreEquivalent(shuffledCardDeck1, shuffledCardDeck2);
            CollectionAssert.AreNotEqual(shuffledCardDeck1, shuffledCardDeck2);
        }
    }
}
