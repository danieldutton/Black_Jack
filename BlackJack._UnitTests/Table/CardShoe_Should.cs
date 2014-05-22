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
        private Mock<ICardDeckBuilder> _fakeCardDeckGenerator;

        private Mock<IShuffler<PlayingCard>> _fakeShuffler;

        private CardShoe _sut;

        [SetUp]
        public void Init()
        {
            _fakeCardDeckGenerator = new Mock<ICardDeckBuilder>();
            _fakeShuffler = new Mock<IShuffler<PlayingCard>>();
            _sut = new CardShoe(_fakeCardDeckGenerator.Object, _fakeShuffler.Object);
        }

        [Test]
        public void Constructor_CallGetOrderedCardDeck_ExactlyOnce()
        {
            _fakeCardDeckGenerator.Verify(x => x.GetCardDeck(), Times.Once());
        }

        [Test]
        public void Constructor_CallShuffle_ExactlyOnce()
        {
            _fakeShuffler.Verify(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()), Times.Once());
        }

        [Test]
        public void GetStartingHand_ReturnTwoPlayingCards()
        {
            _fakeCardDeckGenerator.Setup(x => x.GetCardDeck())
                .Returns(() => new Queue<PlayingCard>());

            _fakeShuffler.Setup(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()))
                .Returns(Mother.GetTestDeckFiveMixedPlayingCards);

            PlayingCard card = _sut.TakeSinglePlayingCard();

            Assert.AreEqual(Suit.Club, card.Suit);
            Assert.AreEqual(CardNumber.Ace, card.CardNumber);
        }

        [Test]
        public void TakeSinglePlayingCard_ReturnOnePlayingCard()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            _fakeCardDeckGenerator = null;
            _fakeShuffler = null;
            _sut = null;
        }
    }
}