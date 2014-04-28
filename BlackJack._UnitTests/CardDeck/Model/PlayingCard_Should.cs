using BlackJack.CardDeck.Model;
using NUnit.Framework;

namespace BlackJack.UnitTests.CardDeck.Model
{
    [TestFixture]
    public class PlayingCard_Should
    {
        [Test]
        public void GetAssociatedImageName_ReturnTheCorrectValue()
        {
            var playingCard = new PlayingCard(Suit.Club, CardNumber.Ace);

            const string expected = "Club_Ace";
            string actual = playingCard.GetAssociatedImageName();

            Assert.AreEqual(expected, actual);
        }

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
