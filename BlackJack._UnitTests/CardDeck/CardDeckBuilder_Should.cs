using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.UnitTests.CardDeck
{
    [TestFixture]
    public class CardDeckBuilder_Should
    {
        private Mock<IResourceImageMapper<PlayingCard>>  _fakeImageMapper; 

        private CardDeckBuilder _sut;

        private IEnumerable<CardNumber> _expectedCardValueOrder;

        [SetUp]
        public void Init()
        {
            _fakeImageMapper = new Mock<IResourceImageMapper<PlayingCard>>();
            _sut = new CardDeckBuilder();
            _expectedCardValueOrder = Mother.ExpectedSuitOrder();
        }

        [Test]
        public void GetOrderedCardDeck_ReturnExactly_52PlayingCards()
        {
            _fakeImageMapper.Setup(x => x.MapCardImages(It.IsAny<List<PlayingCard>>()))
                .Returns(() => new List<PlayingCard>());

            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            Assert.AreEqual(52, cardDeck.Count);
        }

        [Test]
        public void GetOrderedCardDeck_FirstSetOf13Cards_AreofSuit_Club()
        {
            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            IEnumerable<PlayingCard> firstSet = cardDeck.Take(13);

            Assert.IsTrue(firstSet.All(x => x.Suit == Suit.Club));
        }

        [Test]
        public void GetOrderedCardDeck_FirstSetOf13Clubs_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            IEnumerable<CardNumber> firstSet = cardDeck.Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, firstSet);
        }

        [Test]
        public void GetOrderedCardDeck_SecondSetOf13Cards_AreofSuit_Diamond()
        {
            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            IEnumerable<PlayingCard> secondSet = cardDeck.Skip(13)
                .Take(13);

            Assert.IsTrue(secondSet.All(x => x.Suit == Suit.Diamond));
        }

        [Test]
        public void GetOrderedCardDeck_SecondSetOf13Diamonds_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            IEnumerable<CardNumber> secondSet = cardDeck.Skip(13)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, secondSet);
        }

        [Test]
        public void GetOrderedCardDeck_ThirdSetOf13Cards_AreofSuit_Heart()
        {
            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            IEnumerable<PlayingCard> thirdSet = cardDeck.Skip(26).Take(13);

            Assert.IsTrue(thirdSet.All(x => x.Suit == Suit.Heart));
        }

        [Test]
        public void GetOrderedCardDeck_ThirdSetOf13Hearts_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            IEnumerable<CardNumber> thirdSet = cardDeck.Skip(26)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, thirdSet);
        }

        [Test]
        public void GetOrderedCardDeck_FourthSetOf13Cards_AreofSuit_Spade()
        {
            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            IEnumerable<PlayingCard> fourthSet = cardDeck.Skip(39).Take(13);

            Assert.IsTrue(fourthSet.All(x => x.Suit == Suit.Spade));
        }

        [Test]
        public void GetOrderedCardDeck_FourthSetOf13Spades_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetOrderedCardDeck();

            IEnumerable<CardNumber> fourthSet = cardDeck.Skip(39)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, fourthSet);
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
            _expectedCardValueOrder = null;
        }
    }
}
