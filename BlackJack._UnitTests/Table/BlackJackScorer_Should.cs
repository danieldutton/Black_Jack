using BlackJack.CardDeck.Model;
using BlackJack.Table;
using NUnit.Framework;

namespace BlackJack.UnitTests.Table
{
    [TestFixture]
    public class BlackJackScorer_Should
    {
        private BlackJackScorer _sut;

        [SetUp]
        public void Init()
        {
            _sut = new BlackJackScorer();
        }

        #region Club

        [Test]
        public void GetPlayingCardValue_Return2_IfCardClubAce()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Ace);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return2_IfCardClub2()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Two);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(2, cardValue);    
        }

        [Test]
        public void GetPlayingCardValue_Return3_IfCardClub3()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Three);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(3, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return4_IfCardClub4()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Four);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(4, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return5_IfCardClub5()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Five);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(5, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return6_IfCardClub6()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Six);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(6, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return7_IfCardClub7()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Seven);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(7, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return8_IfCardClub8()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Eight);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(8, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return9_IfCardClub9()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Nine);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(9, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardClub10()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Ten);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardClubJack()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Jack);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardClubQueen()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Queen);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardClubKing()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.King);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        #endregion

        #region Diamond

        [Test]
        public void GetPlayingCardValue_Return2_IfCardDiamondAce()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Ace);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return2_IfCardDiamond2()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Two);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(2, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return3_IfCardDiamond3()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Three);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(3, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return4_IfCardDiamond4()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Four);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(4, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return5_IfCardDiamond5()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Five);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(5, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return6_IfCardDiamond6()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Six);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(6, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return7_IfCardDiamond7()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Seven);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(7, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return8_IfCardDiamond8()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Eight);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(8, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return9_IfCardDiamond9()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Nine);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(9, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardDiamond10()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Ten);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardDiamondJack()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Jack);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardDiamondQueen()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.Queen);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardDiamondKing()
        {
            var card = new PlayingCard(Suit.Diamond, CardNumber.King);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        #endregion

        #region Heart

        [Test]
        public void GetPlayingCardValue_Return2_IfCardHeartAce()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Ace);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return2_IfCardHeart2()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Two);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(2, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return3_IfCardHeart3()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Three);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(3, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return4_IfCardHeart4()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Four);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(4, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return5_IfCardHeart5()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Five);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(5, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return6_IfCardHeart6()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Six);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(6, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return7_IfCardHeart7()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Seven);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(7, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return8_IfCardHeart8()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Eight);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(8, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return9_IfCardHeart9()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Nine);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(9, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardHeart10()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Ten);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardHeartJack()
        {
            var card = new PlayingCard(Suit.Heart, CardNumber.Jack);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardHeartQueen()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Jack);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardHeartKing()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Jack);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        #endregion

        #region Spade

        [Test]
        public void GetPlayingCardValue_Return2_IfCardSpadeAce()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Ace);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return2_IfCardSpade2()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Two);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(2, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return3_IfCardSpade3()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Three);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(3, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return4_IfCardSpade4()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Four);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(4, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return5_IfCardSpade5()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Five);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(5, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return6_IfCardSpade6()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Six);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(6, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return7_IfCardSpade7()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Seven);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(7, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return8_IfCardSpade8()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Eight);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(8, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return9_IfCardSpade9()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Nine);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(9, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardSpade10()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Ten);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardSpadeJack()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Jack);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardSpadeQueen()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.Queen);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        [Test]
        public void GetPlayingCardValue_Return10_IfCardSpadeKing()
        {
            var card = new PlayingCard(Suit.Spade, CardNumber.King);

            int cardValue = _sut.GetCardValue(card);

            Assert.AreEqual(10, cardValue);
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }
    }
}
