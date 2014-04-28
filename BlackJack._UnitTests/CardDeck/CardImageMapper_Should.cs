using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using Moq;
using NUnit.Framework;

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
            var deck52Cards = Mother.GetIdenticalCards(52);

            _sut.MapCardImages(deck52Cards);

            _fakeResourceHandler.Verify(x => x.GetResourceManager().GetObject(It.IsAny<string>()), Times.Exactly(1));
        }

        [TearDown]
        public void TearDown()
        {
            _fakeResourceHandler = null;
            _sut = null;
        }
    }
}
