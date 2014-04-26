using BlackJack.CardDeck;
using BlackJack.Table;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.UnitTests.Table
{
    [TestFixture]
    public class CardShoe_Should
    {
        private CardShoe _sut;

        private IEnumerable<CardNumber> _expectedCardValueOrder;

  
        [SetUp]
        public void Init()
        {
            _sut = new CardShoe();
            _expectedCardValueOrder = Mother.ExpectedSuitOrder();
        }

        [Test]
        public void GetNewCardDeck_ReturnACompleteDeckOf_52Cards()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

            Assert.AreEqual(52, cardDeck.Count);
        }

        [Test]
        public void GetNewCardDeck_FirstSetOf13Cards_AreofSuit_Club()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

            IEnumerable<PlayingCard> firstSet = cardDeck.Take(13);

            Assert.IsTrue(firstSet.All(x => x.Suit == Suit.Club));
        }

        [Test]
        public void GetNewCardDeck_FirstSetOf13Cards_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

            IEnumerable<CardNumber> firstSet = cardDeck.Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, firstSet);
        }

        [Test]
        public void GetNewCardDeck_SecondSetOf13Cards_AreofSuit_Diamond()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

            IEnumerable<PlayingCard> secondSet = cardDeck.Skip(13)
                .Take(13);

            Assert.IsTrue(secondSet.All(x => x.Suit == Suit.Diamond));
        }

        [Test]
        public void GetNewCardDeck_SecondSetOf13Cards_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

            IEnumerable<CardNumber> secondSet = cardDeck.Skip(13)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, secondSet);
        }

        [Test]
        public void GetNewCardDeck_ThirdSetOf13Cards_AreofSuit_Heart()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

            IEnumerable<PlayingCard> thirdSet = cardDeck.Skip(26).Take(13);

            Assert.IsTrue(thirdSet.All(x => x.Suit == Suit.Heart));
        }

        [Test]
        public void GetNewCardDeck_ThirdSetOf13Cards_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

            IEnumerable<CardNumber> thirdSet = cardDeck.Skip(26)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, thirdSet);
        }

        [Test]
        public void GetNewCardDeck_FourthSetOf13Cards_AreofSuit_Spade()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

            IEnumerable<PlayingCard> fourthSet = cardDeck.Skip(39).Take(13);

            Assert.IsTrue(fourthSet.All(x => x.Suit == Suit.Spade));
        }

        [Test]
        public void GetNewCardDeck_FourthSetOf13Cards_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetNewCardDeck();

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