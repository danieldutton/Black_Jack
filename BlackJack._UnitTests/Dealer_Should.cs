using BlackJack.Model;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack._UnitTests
{
    [TestFixture]
    public class Dealer_Should
    {
        [Test]
        public void ShuffleCardDeck_ReturnFiftyTwoCards()
        {
            var theDealer = new Dealer();
            Stack<PlayingCard> shuffledDeck = theDealer.ShuffleCardDeck();

            Assert.AreEqual(52, shuffledDeck.Count);
        }
    }   
}
