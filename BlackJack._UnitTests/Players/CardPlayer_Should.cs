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
            var sut = new CardPlayer { CurrentScore = 22};

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

        //HasBlackJack


        //HandValue

        [Test]
        public void HasTwoCardsInHand_ReturnTrue_IfTwoCardsInHand()
        {
            var testHand = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Two),
            };
            
            var sut = new CardPlayer {CurrentHand = testHand};

            Assert.IsTrue(sut.HasTwoCardsInHand());
        }

        [Test]
        public void HasTwoCardsInHand_ReturnFalse_IfLessThanTwoCardsInHand()
        {
            var testHand = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
            };

            var sut = new CardPlayer { CurrentHand = testHand };

            Assert.IsFalse(sut.HasTwoCardsInHand());    
        }

        [Test]
        public void HasTwoCardsInHand_ReturnFalseIfMoreThanTwoCardsInHand()
        {
            var testHand = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Two),
                new PlayingCard(Suit.Club, CardNumber.Three),
            };

            var sut = new CardPlayer { CurrentHand = testHand };

            Assert.IsFalse(sut.HasTwoCardsInHand());    
        }

        [Test]
        public void ScoresAreDrawn_ReturnTrue_IfScoresAreEqual()
        {
            var sut = new CardPlayer {CurrentScore = 20 };

            Assert.IsTrue(sut.ScoresAreDrawn(20));
        }

        [Test]
        public void ScoresAreDrawn_ReturnFalseIfScores_NotEqual()
        {
            var sut = new CardPlayer { CurrentScore = 14 };

            Assert.IsFalse(sut.ScoresAreDrawn(20));    
        }

        [Test]
        public void DisposeOfHand_ResetCurrentScoreToZero()
        {
            var sut = new CardPlayer { CurrentScore = 10};

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
