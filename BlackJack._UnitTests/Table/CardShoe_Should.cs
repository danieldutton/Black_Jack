using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Table.Interfaces;
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

        private ICardShoe _sut;


        [SetUp]
        public void Init()
        {
            _fakeCardDeckBuilder = new Mock<ICardDeckBuilder>();
            _fakeShuffler = new Mock<IShuffler<PlayingCard>>();
            
            _sut = new CardShoe(_fakeCardDeckBuilder.Object, _fakeShuffler.Object);
        }

        [Test]
        public void MountDeck_CallGetCardDeck_ExactlyOnce()
        {
            _fakeCardDeckBuilder.Verify(x => x.GetCardDeck(), Times.Once);
        }

        [Test]
        public void MountDeck_InitialiseCardDeckProperty_WithReturnedCardDeck()
        {
            Queue<PlayingCard> stubDeck = Mother.GetTestDeckFiveMixedPlayingCards();
            
            _fakeCardDeckBuilder.Setup(x => x.GetCardDeck())
                .Returns(()=> stubDeck);
            
            _sut.MountDeck();

            Queue<PlayingCard> actual = _sut.CardDeck;

            CollectionAssert.AreEqual(stubDeck, actual);
        }

        [Test]
        public void ShuffleDeck_CallShuffle_Twice_ConstructorAndMethodCall()
        {
            _sut.ShuffleDeck();

            _fakeShuffler.Verify(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()), 
                Times.Exactly(2));
        }

        [Test]
        public void GetStartingHand_ReturnTwoPlayingCards()
        {
            Queue<PlayingCard> stubDeck = Mother.GetTestDeckFiveMixedPlayingCards();

            _sut.CardDeck = stubDeck;
            
            List<PlayingCard> startHand = _sut.GetStartingHand();

            Assert.AreEqual(2, startHand.Count);
        }

        [Test]
        public void GetStartingHand_ReturnTheCorrectTwoPlayingCards()
        {
            Queue<PlayingCard> stubDeck = Mother.GetTestDeckFiveMixedPlayingCards();

            _sut.CardDeck = stubDeck;

            List<PlayingCard> startHand = _sut.GetStartingHand();

            Assert.AreEqual(Suit.Club, startHand[0].Suit);
            Assert.AreEqual(CardNumber.Ace, startHand[0].CardNumber);

            Assert.AreEqual(Suit.Heart, startHand[1].Suit);
            Assert.AreEqual(CardNumber.Seven, startHand[1].CardNumber);
        }

        [Test]
        public void GetPlayingCard_MountNewShuffledCardDeck_IfNoCardsLeft()
        {
            _fakeCardDeckBuilder.Setup(x => x.GetCardDeck()).Returns(Mother.GetTestDeckFiveMixedPlayingCards);
            _fakeShuffler.Setup(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()))
                .Returns(Mother.GetTestDeckFiveMixedPlayingCards);

            var emptyDeck = new Queue<PlayingCard>();
            _sut.CardDeck = emptyDeck;

            _sut.GetPlayingCard();

            var replacedDeck = _sut.CardDeck;

            CollectionAssert.AreEqual(replacedDeck, Mother.GetTestDeckFiveMixedPlayingCards());
        }

        [Test]
        public void GetPlayingCard_ReturnOneSinglePlayingCard()
        {
            Queue<PlayingCard> stubDeck = Mother.GetTestDeckFiveMixedPlayingCards();

            _sut.CardDeck = stubDeck;

            PlayingCard result = _sut.GetPlayingCard();

            Assert.AreEqual(Suit.Club, result.Suit);
            Assert.AreEqual(CardNumber.Ace, result.CardNumber);
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