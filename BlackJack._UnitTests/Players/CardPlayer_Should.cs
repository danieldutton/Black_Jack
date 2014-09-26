using BlackJack.CardDeck.Model;
using BlackJack.Players;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack.UnitTests.Players
{
    [TestFixture]
    public class CardPlayer_Should
    {
        [Test]
        public void IsBust_ReturnTrue_IfCurrentScoreGreaterThan21()
        {
            var sut = new CardPlayer {CurrentScore = 22};

            Assert.IsTrue(sut.IsBust());
        }

        [Test]
        public void IsBust_ReturnFalse_IfCurrentScoreEqualTo21()
        {
            var sut = new CardPlayer { CurrentScore = 21 };

            Assert.IsFalse(sut.IsBust());
        }

        [Test]
        public void IsBust_ReturnFalse_IfCurrentScoreLessThan21()
        {
            var sut = new CardPlayer { CurrentScore = 8 };

            Assert.IsFalse(sut.IsBust());
        }

        [Test]
        public void DisposeOfHand_ResetCurrentScoreToZero()
        {
            var sut = new CardPlayer {CurrentScore = 10};

            sut.DisposeOfHand();

            Assert.AreEqual(0, sut.CurrentScore);
        }

        [Test]
        public void DisposeOfHand_EmptyCurrentHandToZeroItems()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Eight),
                new PlayingCard(Suit.Club, CardNumber.Nine)
            };

            var sut = new CardPlayer {CurrentHand = testCards};

            sut.DisposeOfHand();

            Assert.AreEqual(0, sut.CurrentHand.Count);
        }
    }
}
