using System.Collections.Generic;
using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Table.Interfaces;
using BlackJack.Utility;
using BlackJack.Utility.Interfaces;
using NUnit.Framework;

namespace BlackJack.IntegrationTests.Table
{
    [TestFixture]
    public class CardShoe_Should
    {
        private CardDeckGenerator _cardDeckGenerator;

        private IShuffler<PlayingCard> _shuffler;

        private ICardShoe _sut;

        [SetUp]
        public void Init()
        {
            _cardDeckGenerator = new CardDeckGenerator();
            _shuffler = new GuidShuffler<PlayingCard>();
            _sut = new CardShoe(_cardDeckGenerator, _shuffler);
        }

        [Test]
        public void Constructor_InitialiseProperty_CurrentDeckInPlay_With52PlayingCards()
        {
            Queue<PlayingCard> cardsInPlay = _sut.CurrentDeckInPlay;

            Assert.AreEqual(51, cardsInPlay.Count);
        }

        [TearDown]
        public void TearDown()
        {
            _cardDeckGenerator = null;
            _shuffler = null;
            _sut = null;
        }
    }
}
