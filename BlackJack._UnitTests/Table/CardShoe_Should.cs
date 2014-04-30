﻿using BlackJack.CardDeck;
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
        private Mock<CardDeckGenerator> _fakeCardDeckGenerator;

        private Mock<IShuffler<PlayingCard>> _fakeShuffler;

        private CardShoe _sut;

        [SetUp]
        public void Init()
        {
            _fakeCardDeckGenerator = new Mock<CardDeckGenerator>();
            _fakeShuffler = new Mock<IShuffler<PlayingCard>>();
            _sut = new CardShoe(_fakeCardDeckGenerator.Object, _fakeShuffler.Object);
        }

        [Test]
        public void InitialiseNewCardDeck_CallGetOrderedCardDeck_ExactlyOnce_FromConstructor()
        {
            _fakeCardDeckGenerator.Verify(x => x.GetCardDeck(), Times.Once());
        }

        [Test]
        public void InitialiseNewCardDeck_CallShuffle_ExactlyOnce()
        {
            _fakeShuffler.Verify(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()), Times.Once());
        }

        [Test]
        public void InitialiseNewCardDeck_CallShuffle_WithCorrectData()
        {
            var cardDeckStub = new Queue<PlayingCard>();
            _fakeCardDeckGenerator.Setup(x => x.GetCardDeck())
                .Returns(() => cardDeckStub);

            _sut.InitialiseNewCardDeck();

            _fakeShuffler.Verify(x => x.Shuffle(It.Is<IEnumerable<PlayingCard>>(y => y.Equals(cardDeckStub))));
        }

        [Test]
        public void InitialiseNewCardDeck_SetCurrentCardDeck()
        {
            var cardQueue = new Queue<PlayingCard>();
            _fakeShuffler.Setup(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()))
                .Returns(() => cardQueue);

            _sut.InitialiseNewCardDeck();
            Queue<PlayingCard> actual = _sut.CurrentDeckInPlay;

            Assert.AreEqual(cardQueue, actual);

        }

        [Test]
        public void TakePlayingCard_ReturnTheFirstItemInTheQueue()
        {
            _fakeCardDeckGenerator.Setup(x => x.GetCardDeck())
                .Returns(() => new Queue<PlayingCard>());

            _fakeShuffler.Setup(x => x.Shuffle(It.IsAny<IEnumerable<PlayingCard>>()))
                .Returns(Mother.GetTestDeckFiveMixedPlayingCards);

            PlayingCard card = _sut.GetNextPlayingCard();

            Assert.AreEqual(Suit.Club, card.Suit);
            Assert.AreEqual(CardNumber.Ace, card.CardNumber);
        }

        [Test]
        public void ReleaseStartingHands_Foo()
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