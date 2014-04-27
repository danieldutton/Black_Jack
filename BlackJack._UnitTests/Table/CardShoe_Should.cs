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
        private Mock<ICardDeckBuilder> _fakeCardDeckBuilder;

        private Mock<IShuffler<PlayingCard>> _fakeShuffler;

        private CardShoe _sut;

        [SetUp]
        public void Init()
        {
            _fakeCardDeckBuilder = new Mock<ICardDeckBuilder>();
            _fakeShuffler = new Mock<IShuffler<PlayingCard>>();
            _sut = new CardShoe(_fakeCardDeckBuilder.Object, _fakeShuffler.Object);
        }

        #region InitNewDeck

        [Test]
        public void InitNewDeck_CallGetOrderedCardDeck_ExactlyOnce()
        {
            _sut.InitNewDeck();

            _fakeCardDeckBuilder.Verify(x => x.GetOrderedCardDeck(), Times.Once());
        }

        [Test]
        public void InitNewDeck_CallShuffle_ExactlyOnce()
        {
            _sut.InitNewDeck();

            _fakeShuffler.Verify(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()), Times.Once());
        }

        [Test]
        public void InitNewDeck_CallShuffle_WithCorrectData()
        {
            var cardQueue = new Queue<PlayingCard>();
            _fakeCardDeckBuilder.Setup(x => x.GetOrderedCardDeck())
                .Returns(() => cardQueue);

            _sut.InitNewDeck();

            _fakeShuffler.Verify(x => x.Shuffle(It.Is<IEnumerable<PlayingCard>>(y => y.Equals(cardQueue))), Times.Once());
        }

        [Test]
        public void InitNewDeck_SetCurrentCardDeck()
        {
            var cardQueue = new Queue<PlayingCard>();
            _fakeShuffler.Setup(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()))
                .Returns(() => cardQueue);

            _sut.InitNewDeck();
            Queue<PlayingCard> actual = _sut.CurrentCardDeck;

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

            PlayingCard card = _sut.TakePlayingCard();

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