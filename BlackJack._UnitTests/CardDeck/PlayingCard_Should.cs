using BlackJack.CardDeck;
using NUnit.Framework;

namespace BlackJack.UnitTests.CardDeck
{
    [TestFixture]
    public class PlayingCard_Should
    {
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
