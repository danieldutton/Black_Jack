using BlackJack.CardDeck.Model;
using BlackJack.Utility;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack.UnitTests.Utility
{
    [TestFixture]
    public class GuidShuffler_Should
    {
        private Queue<PlayingCard> _orderedCardDeck;

        private GuidShuffler<PlayingCard> _sut;
        
        
        [SetUp]
        public void Init()
        {
            _orderedCardDeck = Mother.GetUnshuffledCardDeck();
            _sut = new GuidShuffler<PlayingCard>();
        }

        [Test]
        public void Shuffle_ReturnExactly52Cards()
        {
            Queue<PlayingCard> shuffledCardDeck = _sut.Shuffle(_orderedCardDeck);

            Assert.AreEqual(52, shuffledCardDeck.Count);
        }

        [Test]
        public void Shuffle_Return52CardsWithNoDuplicates()
        {
            Queue<PlayingCard> shuffledCardDeck = _sut.Shuffle(_orderedCardDeck);

            CollectionAssert.AreEquivalent(shuffledCardDeck, _orderedCardDeck);
        }

        [Test]
        public void Shuffle_Return52CardsInRandomOrder()
        {
            Queue<PlayingCard> shuffledCardDeck = _sut.Shuffle(_orderedCardDeck);

            CollectionAssert.AreNotEqual(shuffledCardDeck, _orderedCardDeck);   
        }

        [Test] //Probability wise this test is not deterministic but odds on unlikely to ever fail
        public void Shuffle_ShuffleTwoCardDecks_InDifferentOrders()
        {
            Queue<PlayingCard> shuffledCardDeck1 = _sut.Shuffle(_orderedCardDeck);
            Queue<PlayingCard> shuffledCardDeck2 = _sut.Shuffle(_orderedCardDeck);

            CollectionAssert.AreEquivalent(shuffledCardDeck1, shuffledCardDeck2);
            CollectionAssert.AreNotEqual(shuffledCardDeck1, shuffledCardDeck2);
        }

        [TearDown]
        public void TearDown()
        {
            _orderedCardDeck = null;
            _sut = null;
        }
    }
}
