using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Utility.Interfaces;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BlackJack.UnitTests.CardDeck
{
    [TestFixture]
    public class CardImageMapper_Should
    {
        private Mock<IResourceHandler> _fakeResourceHandler;

        private ICardImageMapper<PlayingCard> _sut;

        [SetUp]
        public void Init()
        {
            _fakeResourceHandler = new Mock<IResourceHandler>();
            _sut = new CardImageMapper(_fakeResourceHandler.Object);
        }

        [Test]
        public void MapCardImages_CallGetResourceManager_GetObject_Exactly52Times()
        {
            Queue<PlayingCard> deck52Cards = Mother.GetIdenticalCards(52);
            
            _fakeResourceHandler.Setup(x => x.GetResourceManager()
                .GetObject(It.IsAny<string>()))
                .Returns(() => new object());

            _sut.MapCardImages(deck52Cards);

            _fakeResourceHandler.Verify(x => x.GetResourceManager().GetObject(It.IsAny<string>()), Times.Exactly(52));
        }

        [Test]
        public void MapCardImages_CallGetResourceManager_GetObject_WithCorrectData()
        {
            Queue<PlayingCard> deck52Cards = Mother.GetIdenticalCards(52);
            
            _fakeResourceHandler.Setup(x => x.GetResourceManager()
                .GetObject("Club_Ace"))
                .Returns(() => new object());

            _sut.MapCardImages(deck52Cards);

            _fakeResourceHandler.Verify(x => x.GetResourceManager().GetObject(It.Is<string>(y => y.Equals("Club_Ace"))));
        }

        [Test]
        public void MapCardImages_SetPlayingCardTagAndImageProperty_IfResourceReturnedIsNotNull()
        {
            Queue<PlayingCard> deck1Card = Mother.GetIdenticalCards(1);

            _fakeResourceHandler.Setup(x => x.GetResourceManager()
                .GetObject(It.IsAny<string>()))
                .Returns(() => new Bitmap(10, 10));

            List<PlayingCard> playingCards = _sut.MapCardImages(deck1Card).ToList();

            Assert.IsNotNull(playingCards.ElementAt(0).Image);
            Assert.AreEqual("Club_Ace", playingCards.ElementAt(0).Tag);
        }

        [Test]
        public void MapCardImages_NeverSetPlayingCardTagAndImageProperty_IfResourceReturnedIsNull()
        {
            Queue<PlayingCard> deck1Card = Mother.GetIdenticalCards(1);

            _fakeResourceHandler.Setup(x => x.GetResourceManager()
                .GetObject(It.IsAny<string>()))
                .Returns(() => null);

            List<PlayingCard> playingCards = _sut.MapCardImages(deck1Card).ToList();

            Assert.IsNull(playingCards.ElementAt(0).Image);
            Assert.IsNull(playingCards.ElementAt(0).Tag);
        }

        [TearDown]
        public void TearDown()
        {
            _fakeResourceHandler = null;
            _sut = null;
        }
    }
}