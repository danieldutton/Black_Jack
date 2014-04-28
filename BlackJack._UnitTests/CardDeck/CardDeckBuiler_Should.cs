using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack.UnitTests.CardDeck
{
    [TestFixture]
    public class CardDeckBuiler_Should
    {
        private Mock<ICardSuitBuilder> _fakeSuitBuilder;

        private Mock<ICardImageMapper<PlayingCard>>  _fakeImageMapper;

        private CardDeckBuilder _sut;

        [SetUp]
        public void Init()
        {
            _fakeSuitBuilder = new Mock<ICardSuitBuilder>();
            _fakeImageMapper = new Mock<ICardImageMapper<PlayingCard>>();
            _sut = new CardDeckBuilder(_fakeSuitBuilder.Object, _fakeImageMapper.Object);
        }

        [Test]
        public void GetCardDeck_CallOrderedCardDeck_ExactlyOnce()
        {
            _sut.GetCardDeck();

            _fakeSuitBuilder.Verify(x => x.GetOrderedCardDeck(), Times.Once());
        }

        [Test]
        public void GetCardDeck_CallMapCardImages_ExactlyOnce()
        {
            _sut.GetCardDeck();

            _fakeImageMapper.Verify(x => x.MapCardImages(It.IsAny<IEnumerable<PlayingCard>>()), Times.Once());
        }

        [Test]
        public void GetCardDeck_CallMapCardImages_WithCorrectData()
        {
            var fakeDeck = new Queue<PlayingCard>();

            _fakeSuitBuilder.Setup(x => x.GetOrderedCardDeck()).Returns(() => fakeDeck);

            _sut.GetCardDeck();

            _fakeImageMapper.Verify(x => x.MapCardImages(It.Is<IEnumerable<PlayingCard>>(y => Equals(y, fakeDeck))));
        }

        [TearDown]
        public void TearDown()
        {
            _fakeSuitBuilder = null;
            _fakeImageMapper = null;
            _sut = null;
        }
    }
}
