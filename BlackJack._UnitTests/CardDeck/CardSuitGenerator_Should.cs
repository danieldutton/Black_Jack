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
    public class CardSuitGenerator_Should
    {
        private Mock<ICardImageMapper<PlayingCard>>  _fakeImageMapper; 

        private CardSuitGenerator _sut;

        private IEnumerable<CardNumber> _expectedCardValueOrder;

        [SetUp]
        public void Init()
        {
            _fakeImageMapper = new Mock<ICardImageMapper<PlayingCard>>();
            _sut = new CardSuitGenerator();
            _expectedCardValueOrder = Mother.ExpectedSuitOrder();
        }

        [Test]
        public void GetCardDeck_ReturnExactly_52PlayingCards()
        {
            _fakeImageMapper.Setup(x => x.MapCardImages(It.IsAny<List<PlayingCard>>()))
                .Returns(() => new List<PlayingCard>());

            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

            Assert.AreEqual(52, cardDeck.Count());
        }

        [Test]
        public void GetCardDeck_FirstSetOf13Cards_AreofSuit_Club()
        {
            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

            IEnumerable<PlayingCard> firstSet = cardDeck.Take(13);

            Assert.IsTrue(firstSet.All(x => x.Suit == Suit.Club));
        }

        [Test]
        public void GetCardDeck_FirstSetOf13Clubs_AreInNumericOrderAscending()
        {
            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

            IEnumerable<CardNumber> firstSet = cardDeck.Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, firstSet);
        }

        [Test]
        public void GetCardDeck_SecondSetOf13Cards_AreofSuit_Diamond()
        {
            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

            IEnumerable<PlayingCard> secondSet = cardDeck.Skip(13)
                .Take(13);

            Assert.IsTrue(secondSet.All(x => x.Suit == Suit.Diamond));
        }

        [Test]
        public void GetCardDeck_SecondSetOf13Diamonds_AreInNumericOrderAscending()
        {
            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

            IEnumerable<CardNumber> secondSet = cardDeck.Skip(13)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, secondSet);
        }

        [Test]
        public void GetCardDeck_ThirdSetOf13Cards_AreofSuit_Heart()
        {
            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

            IEnumerable<PlayingCard> thirdSet = cardDeck.Skip(26).Take(13);

            Assert.IsTrue(thirdSet.All(x => x.Suit == Suit.Heart));
        }

        [Test]
        public void GetCardDeck_ThirdSetOf13Hearts_AreInNumericOrderAscending()
        {
            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

            IEnumerable<CardNumber> thirdSet = cardDeck.Skip(26)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, thirdSet);
        }

        [Test]
        public void GetCardDeck_FourthSetOf13Cards_AreofSuit_Spade()
        {
            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

            IEnumerable<PlayingCard> fourthSet = cardDeck.Skip(39).Take(13);

            Assert.IsTrue(fourthSet.All(x => x.Suit == Suit.Spade));
        }

        [Test]
        public void GetCardDeck_FourthSetOf13Spades_AreInNumericOrderAscending()
        {
            IEnumerable<PlayingCard> cardDeck = _sut.GenerateCardDeck();

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
