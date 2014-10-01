using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack.UnitTests.CardDeck
{
    [TestFixture]
    public class CardDeckBuilder_Should
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
        public void GetCardDeck_CallGenerateCardDeck_ExactlyOnce()
        {
            _sut.GetCardDeck();

            _fakeSuitBuilder.Verify(x => x.GetPlainCardDeck(), Times.Once());
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
            var stubDeck = new Queue<PlayingCard>();

            _fakeSuitBuilder.Setup(x => x.GetPlainCardDeck())
                .Returns(() => stubDeck);

            _sut.GetCardDeck();

            _fakeImageMapper.Verify(x => x.MapCardImages(It.Is<IEnumerable<PlayingCard>>(y => Equals(y, stubDeck))));
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
