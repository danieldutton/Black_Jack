using BlackJack.CardDeck.Model;
using BlackJack.Table;
using NUnit.Framework;

namespace BlackJack.UnitTests.Table
{
    [TestFixture]
    public class CardScoreCalculator_Should
    {
        private BlackJackScorer _sut;

        [SetUp]
        public void Init()
        {
            _sut = new BlackJackScorer();
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAJackOf_Clubs()
        {
            var jackOfClubs = new PlayingCard(Suit.Club, CardNumber.Jack);

            int cardValue = _sut.GetPlayingCardValue(jackOfClubs);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAJackOf_Diamonds()
        {
            var jackOfDiamonds = new PlayingCard(Suit.Diamond, CardNumber.Jack);

            int cardValue = _sut.GetPlayingCardValue(jackOfDiamonds);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAJackOf_Hearts()
        {
            var jackOfHearts = new PlayingCard(Suit.Heart, CardNumber.Jack);

            int cardValue = _sut.GetPlayingCardValue(jackOfHearts);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAJackOf_Spades()
        {
            var jackOfSpades = new PlayingCard(Suit.Spade, CardNumber.Jack);

            int cardValue = _sut.GetPlayingCardValue(jackOfSpades);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAQueenOf_Clubs()
        {
            var queenOfClubs = new PlayingCard(Suit.Club, CardNumber.Queen);

            int cardValue = _sut.GetPlayingCardValue(queenOfClubs);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAQueenOf_Diamonds()
        {
            var queenOfDiamonds = new PlayingCard(Suit.Diamond, CardNumber.Queen);

            int cardValue = _sut.GetPlayingCardValue(queenOfDiamonds);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAQueenOf_Hearts()
        {
            var queenOfHearts = new PlayingCard(Suit.Heart, CardNumber.Queen);

            int cardValue = _sut.GetPlayingCardValue(queenOfHearts);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAQueenOf_Spades()
        {
            var queenOfSpades = new PlayingCard(Suit.Spade, CardNumber.Queen);

            int cardValue = _sut.GetPlayingCardValue(queenOfSpades);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAKingOf_Clubs()
        {
            var kingOfClubs = new PlayingCard(Suit.Club, CardNumber.King);

            int cardValue = _sut.GetPlayingCardValue(kingOfClubs);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAKingOf_Diamonds()
        {
            var kingOfDiamonds = new PlayingCard(Suit.Diamond, CardNumber.King);

            int cardValue = _sut.GetPlayingCardValue(kingOfDiamonds);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAKingOf_Hearts()
        {
            var kingOfHearts = new PlayingCard(Suit.Heart, CardNumber.King);

            int cardValue = _sut.GetPlayingCardValue(kingOfHearts);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfPlayingCardIsAKingOf_Spades()
        {
            var kingOfSpades = new PlayingCard(Suit.Spade, CardNumber.King);

            int cardValue = _sut.GetPlayingCardValue(kingOfSpades);

            Assert.AreEqual(10, cardValue);
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }
    }
}
