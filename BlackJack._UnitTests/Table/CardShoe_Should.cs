using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Utility.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack.UnitTests.Table
{
    [TestFixture]
    public class CardShoe_Should
    {
        private Mock<ICardSuitBuilder> _fakeCardDeckBuilder;

        private Mock<IShuffler<PlayingCard>> _fakeShuffler;

        private CardShoe _sut;

        [SetUp]
        public void Init()
        {
            _fakeCardDeckBuilder = new Mock<ICardSuitBuilder>();
            _fakeShuffler = new Mock<IShuffler<PlayingCard>>();
            _sut = new CardShoe(_fakeCardDeckBuilder.Object, _fakeShuffler.Object);
        }

        #region PlaceNewDeck

        [Test]
        public void InitNewDeck_CallGetOrderedCardDeck_ExactlyOnce()
        {
            _sut.PlaceNewDeck();

            _fakeCardDeckBuilder.Verify(x => x.GetOrderedCardDeck(), Times.Once());
        }

        [Test]
        public void InitNewDeck_CallShuffle_ExactlyOnce()
        {
            _sut.PlaceNewDeck();

            _fakeShuffler.Verify(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()), Times.Once());
        }

        [Test]
        public void InitNewDeck_CallShuffle_WithCorrectData()
        {
            var cardQueue = new Queue<PlayingCard>();
            _fakeCardDeckBuilder.Setup(x => x.GetOrderedCardDeck())
                .Returns(() => cardQueue);

            _sut.PlaceNewDeck();

            _fakeShuffler.Verify(x => x.Shuffle(It.Is<IEnumerable<PlayingCard>>(y => y.Equals(cardQueue))), Times.Once());
        }

        [Test]
        public void InitNewDeck_SetCurrentCardDeck()
        {
            var cardQueue = new Queue<PlayingCard>();
            _fakeShuffler.Setup(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()))
                .Returns(() => cardQueue);

            _sut.PlaceNewDeck();
            Queue<PlayingCard> actual = _sut.CurrentDeckInPlay;

            Assert.AreEqual(cardQueue, actual);

        }

        #endregion

        [Test]
        public void TakePlayingCard_ReturnTheFirstItemInTheQueue()
        {
            _fakeCardDeckBuilder.Setup(x => x.GetOrderedCardDeck())
                .Returns(() => new Queue<PlayingCard>());

            _fakeShuffler.Setup(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()))
                .Returns(Mother.GetTestDeckFiveMixedPlayingCards);

            PlayingCard card = _sut.ReleasePlayingCard();

            Assert.AreEqual(Suit.Club, card.Suit);
            Assert.AreEqual(CardNumber.Ace, card.CardNumber);
        }

        [TearDown]
        public void TearDown()
        {
            _fakeCardDeckBuilder = null;
            _fakeShuffler = null;
            _sut = null;
        }
    }
}