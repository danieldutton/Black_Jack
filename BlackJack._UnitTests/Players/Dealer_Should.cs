using BlackJack.CardDeck.Model;
using BlackJack.Players;
using BlackJack.Table.Interfaces;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace BlackJack.UnitTests.Players
{   //See test notes for further details
    [TestFixture]
    public class Dealer_Should
    {
        private Dealer _sut;

        private Mock<ICardShoe> _fakeCardShoe;

        [SetUp]
        public void Init()
        {
            _sut = new Dealer {CurrentHand = Mother.GetTestDeckFiveMixedPlayingCards().ToList()};
            _fakeCardShoe = new Mock<ICardShoe>();
            _fakeCardShoe.Setup(x => x.GetPlayingCard()).Returns(new PlayingCard(Suit.Diamond, CardNumber.Ace));
        }

        [Test]
        public void Play_CallGetPlayingCardZeroTimes_IfStickThresholdIsReached()
        {
            _sut.CurrentScore = 16;
            _sut.Play(_fakeCardShoe.Object);
            
            _fakeCardShoe.Verify(x => x.GetPlayingCard(), Times.Never());
        }

        [Test]
        public void Play_ZeroCardsAddedToHand_IfStickThresholdIsReached()
        {
            _sut.CurrentScore = 16;
            _sut.Play(_fakeCardShoe.Object);

            Assert.AreEqual(5, _sut.CurrentHand.Count);
        }

        [Test]
        public void Play_CallGetPlayingCardOnce_IfBelowStickThreshold_ButWithRoomForOneMoreCard()
        {
            _sut.CurrentScore = 15;
            _sut.Play(_fakeCardShoe.Object);

            _fakeCardShoe.Verify(x => x.GetPlayingCard(), Times.Once());
        }

        [Test]
        public void Play_OneCardAddedToHand_IfBelowStickThreshold_ButWithRoomForOneMoreCard()
        {
            _sut.CurrentScore = 15;
            _sut.Play(_fakeCardShoe.Object);

            Assert.AreEqual(6, _sut.CurrentHand.Count);
        }

        [Test]
        public void Play_CallGetPlayingCardTwice_IfBelowStickThreshold_ButWithRoomForTwoMoreCards()
        {
            _sut.CurrentScore = 14;
            _sut.Play(_fakeCardShoe.Object);

            _fakeCardShoe.Verify(x => x.GetPlayingCard(), Times.Exactly(2));
        }

        [Test]
        public void Play_TwoCardsAddedToHand_IfBelowStickThreshold_ButWithRoomForTwoMoreCards()
        {
            _sut.CurrentScore = 14;
            _sut.Play(_fakeCardShoe.Object);

            Assert.AreEqual(7, _sut.CurrentHand.Count);
        }

        [Test]
        public void Play_CallGetPlayingCardThreeTimes_IfBelowStickThreshold_ButWithRoomForThreeMoreCards()
        {
            _sut.CurrentScore = 13;
            _sut.Play(_fakeCardShoe.Object);

            _fakeCardShoe.Verify(x => x.GetPlayingCard(), Times.Exactly(3));
        }

        [Test]
        public void Play_ThreeCardsAddedToHand_IfBelowStickThreshold_ButWithRoomForThreeMoreCards()
        {
            _sut.CurrentScore = 13;
            _sut.Play(_fakeCardShoe.Object);

            Assert.AreEqual(8, _sut.CurrentHand.Count);
        }

        [Test]
        public void Play_CallGetPlayingCardFourTimes_IfBelowStickThreshold_ButWithRoomForFourMoreCards()
        {
            _sut.CurrentScore = 12;
            _sut.Play(_fakeCardShoe.Object);

            _fakeCardShoe.Verify(x => x.GetPlayingCard(), Times.Exactly(4));
        }

        [Test]
        public void Play_FourCardsAddedToHand_IfBelowStickThreshold_ButWithRoomForFourMoreCards()
        {
            _sut.CurrentScore = 12;
            _sut.Play(_fakeCardShoe.Object);

            Assert.AreEqual(9, _sut.CurrentHand.Count);
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
            _fakeCardShoe = null;
        }
    }
}
