using BlackJack.CardDeck.Model;
using NUnit.Framework;

namespace BlackJack.UnitTests.CardDeck.Model
{
    [TestFixture]
    public class PlayingCard_Should
    {
        [Test]
        public void Constructor_SizePlayingCardCorrectly()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Ace);
    
            Assert.AreEqual(71, playingCard.Width);
            Assert.AreEqual(96, playingCard.Height);
        }

        #region Club

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Ace()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Ace);

            const string expected = "Club_Ace";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Two()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Two);

            const string expected = "Club_Two";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Three()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Three);

            const string expected = "Club_Three";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Four()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Four);

            const string expected = "Club_Four";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Five()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Five);

            const string expected = "Club_Five";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Six()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Six);

            const string expected = "Club_Six";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Seven()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Seven);

            const string expected = "Club_Seven";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Eight()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Eight);

            const string expected = "Club_Eight";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Nine()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Nine);

            const string expected = "Club_Nine";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Ten()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Ten);

            const string expected = "Club_Ten";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Jack()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Jack);

            const string expected = "Club_Jack";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_Queen()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Queen);

            const string expected = "Club_Queen";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForClub_King()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.King);

            const string expected = "Club_King";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Diamond

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Ace()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Ace);

            const string expected = "Diamond_Ace";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Two()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Two);

            const string expected = "Diamond_Two";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Three()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Three);

            const string expected = "Diamond_Three";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Four()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Four);

            const string expected = "Diamond_Four";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Five()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Five);

            const string expected = "Diamond_Five";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Six()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Six);

            const string expected = "Diamond_Six";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Seven()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Seven);

            const string expected = "Diamond_Seven";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Eight()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Eight);

            const string expected = "Diamond_Eight";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Nine()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Nine);

            const string expected = "Diamond_Nine";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Ten()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Ten);

            const string expected = "Diamond_Ten";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Jack()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Jack);

            const string expected = "Diamond_Jack";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_Queen()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.Queen);

            const string expected = "Diamond_Queen";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForDiamond_King()
        {
            var playingCard = new PlayingCard(Suit.Diamond, CardNumber.King);

            const string expected = "Diamond_King";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Heart

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Ace()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Ace);

            const string expected = "Heart_Ace";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Two()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Two);

            const string expected = "Heart_Two";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Three()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Three);

            const string expected = "Heart_Three";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Four()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Four);

            const string expected = "Heart_Four";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Five()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Five);

            const string expected = "Heart_Five";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Six()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Six);

            const string expected = "Heart_Six";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Seven()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Seven);

            const string expected = "Heart_Seven";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Eight()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Eight);

            const string expected = "Heart_Eight";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Nine()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Nine);

            const string expected = "Heart_Nine";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Ten()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Ten);

            const string expected = "Heart_Ten";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Jack()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Jack);

            const string expected = "Heart_Jack";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_Queen()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.Queen);

            const string expected = "Heart_Queen";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForHeart_King()
        {
            var playingCard = new PlayingCard(Suit.Heart, CardNumber.King);

            const string expected = "Heart_King";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        #region Spade

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Ace()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Ace);

            const string expected = "Spade_Ace";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Two()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Two);

            const string expected = "Spade_Two";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Three()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Three);

            const string expected = "Spade_Three";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Four()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Four);

            const string expected = "Spade_Four";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Five()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Five);

            const string expected = "Spade_Five";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Six()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Six);

            const string expected = "Spade_Six";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Seven()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Seven);

            const string expected = "Spade_Seven";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Eight()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Eight);

            const string expected = "Spade_Eight";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Nine()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Nine);

            const string expected = "Spade_Nine";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Ten()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Ten);

            const string expected = "Spade_Ten";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Jack()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Jack);

            const string expected = "Spade_Jack";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_Queen()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.Queen);

            const string expected = "Spade_Queen";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void GetResourceImageName_ReturnTheCorrectValue_ForSpade_King()
        {
            var playingCard = new PlayingCard(Suit.Spade, CardNumber.King);

            const string expected = "Spade_King";
            string actual = playingCard.GetResourceImageName();

            Assert.AreEqual(expected, actual);
        }

        #endregion

        [Test]
        public void ToString_ReturnTheCorrectValue()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Ace);

            const string expected = "[PlayingCard] Suit: Club CardNumber: Ace";
            string actual = playingCard.ToString();

            Assert.AreEqual(expected, actual);
        }
    }
}
