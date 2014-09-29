using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Table.Interfaces;
using BlackJack.Utility;
using BlackJack.Utility.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack.IntegrationTests.Table
{
    [TestFixture]
    public class CardShoe_Should
    {
        private ResourceHandler _resourceHandler;

        private ICardDeckGenerator _cardDeckGenerator;

        private ICardImageMapper<PlayingCard> _cardImageMapper;        

        private ICardDeckBuilder _cardDeckBuilder;

        private IShuffler<PlayingCard> _shuffler;

        private ICardShoe _sut;

        [SetUp]
        public void Init()
        {
            _resourceHandler = new ResourceHandler();
            _cardDeckGenerator = new PlainCardDeckGenerator();
            _cardImageMapper = new CardImageMapper(_resourceHandler);
            _cardDeckBuilder = new CardDeckBuilder(_cardDeckGenerator, _cardImageMapper);
            _shuffler = new GuidShuffler<PlayingCard>();
            _sut = new CardShoe(_cardDeckBuilder, _shuffler);
        }

        [Test]
        public void Constructor_InitialiseProperty_CurrentDeckInPlay_With52PlayingCards()
        {
            Queue<PlayingCard> cardsInPlay = _sut.CardDeck;

            Assert.AreEqual(52, cardsInPlay.Count);
        }

        [Test]
        public void Constructor_InitialiseProperty_CurrentDeckInPlay_With52ShuffledCards()
        {
            Queue<PlayingCard> orderedDeck = _cardDeckBuilder.GetCardDeck();
            Queue<PlayingCard> shuffledDeck = _sut.CardDeck;

            CollectionAssert.AreNotEqual(orderedDeck, shuffledDeck);
            CollectionAssert.AreNotEquivalent(orderedDeck, shuffledDeck);    
        }

        [Test]
        public void GetStartingHand_ReturnTwoPlayingCards()
        {
            List<PlayingCard> startingHand = _sut.GetStartingHand();

            Assert.AreEqual(2, startingHand.Count);
        }

        [Test]
        public void GetStartingHand_ReduceProperty_CurrentDeckInPlayCount_ByTwoPlayingCards()
        {
            _sut.GetStartingHand();

            Assert.AreEqual(50, _sut.CardDeck.Count);
        }

        [Test]
        public void GetPlayingCard_ReturnOnePlayingCard()
        {
            PlayingCard playingCard = _sut.GetPlayingCard();

            Assert.IsInstanceOf<PlayingCard>(playingCard);
        }

        [Test]
        public void GetPlayingCard_ReduceProperty_CurrentDeckInPlayCount_ByOnePlayingCard()
        {
            _sut.GetStartingHand();

            Assert.AreEqual(50, _sut.CardDeck.Count);
        }

        [TearDown]
        public void TearDown()
        {
            _resourceHandler = null;
            _cardDeckGenerator = null;
            _cardImageMapper = null;
            _cardDeckBuilder = null;
            _shuffler = null;
            _sut = null;
        }
    }
}
