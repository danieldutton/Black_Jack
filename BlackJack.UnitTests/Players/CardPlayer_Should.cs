using BlackJack.CardDeck.Model;
using BlackJack.Players;
using NUnit.Framework;
using System.Collections.Generic;

namespace BlackJack.UnitTests.Players
{
    [TestFixture]
    public class CardPlayer_Should
    {
        #region IsBust

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

        #endregion

        #region HasBlackJack() - Misc False 

        [Test]
        public void HasBlackJack_ReturnsFalse_IfLessThanTwoCardsInHand()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
            };

            var sut = new CardPlayer { CurrentHand = testCards };

            Assert.IsFalse(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsFalse_IfMoreThanTwoCardsInHand()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.King),
                new PlayingCard(Suit.Club, CardNumber.Two),
            };

            var sut = new CardPlayer {CurrentHand = testCards};

            Assert.IsFalse(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsFalseIfNotBlackJack_TestOne()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Three),
                new PlayingCard(Suit.Club, CardNumber.Seven),
            };

            var sut = new CardPlayer { CurrentHand = testCards };

            Assert.IsFalse(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsFalseIfNotBlackJack_TestTwo()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Nine),
                new PlayingCard(Suit.Diamond, CardNumber.Eight),
            };

            var sut = new CardPlayer { CurrentHand = testCards };

            Assert.IsFalse(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsFalseIfNotBlackJack_TestThree()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.King),
                new PlayingCard(Suit.Heart, CardNumber.Six),
            };

            var sut = new CardPlayer { CurrentHand = testCards };

            Assert.IsFalse(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsFalseIfNotBlackJack_TestFour()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Queen),
                new PlayingCard(Suit.Club, CardNumber.Three),
            };

            var sut = new CardPlayer { CurrentHand = testCards };

            Assert.IsFalse(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsFalseIfNotBlackJack_TestFive()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Two),
            };

            var sut = new CardPlayer { CurrentHand = testCards };

            Assert.IsFalse(sut.HasBlackJack());
        }

        #endregion

        #region HasBlackJack() - Ace of Clubs BlackJack combination

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_KingOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_QueenOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_JackOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_TenOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_KingOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_QueenOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_JackOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_TenOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_KingOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_QueenOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_JackOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_TenOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_KingOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_QueenOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_JackOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfClubs_TenOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        #endregion

        #region HasBlackJack() - Ace Of Diamonds BlackJack combination

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_KingOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_QueenOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_JackOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_TenOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_KingOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_QueenOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_JackOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_TenOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_KingOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_QueenOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_JackOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_TenOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_KingOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_QueenOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_JackOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfDiamonds_TenOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Diamond, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        #endregion

        #region HasBlackJack() - Ace Of Hearts BlackJack combination

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_KingOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_QueenOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_JackOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_TenOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_KingOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_QueenOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_JackOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_TenOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_KingOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_QueenOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_JackOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_TenOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_KingOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_QueenOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_JackOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfHearts_TenOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Heart, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        #endregion

        #region HasBlackJack() - Ace Of Spades BlackJack combination

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_KingOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_QueenOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_JackOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_TenOfClubs()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_KingOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_QueenOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_JackOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_TenOfHearts()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Heart, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_KingOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_QueenOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_JackOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_TenOfSpades()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Spade, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_KingOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.King),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_QueenOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Queen),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_JackOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Jack),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        [Test]
        public void HasBlackJack_ReturnsTrueForCards_AceOfSpades_TenOfDiamonds()
        {
            var blackJack = new List<PlayingCard>
            {
                new PlayingCard(Suit.Spade, CardNumber.Ace),
                new PlayingCard(Suit.Diamond, CardNumber.Ten),
            };

            var sut = new CardPlayer { CurrentHand = blackJack };

            Assert.IsTrue(sut.HasBlackJack());
        }

        #endregion

        #region AcceptNewCard() - Single card scoring, Club

        [Test]
        public void AcceptNewCard_Score11For_AceOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Ace));

            Assert.AreEqual(11, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_KingOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.King));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_QueenOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Queen));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_JackOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Jack));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_TwoOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Two));

            Assert.AreEqual(2, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_ThreeOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Three));

            Assert.AreEqual(3, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_FourOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Four));

            Assert.AreEqual(4, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_FiveOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Five));

            Assert.AreEqual(5, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_SixOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Six));

            Assert.AreEqual(6, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_SevenOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Seven));

            Assert.AreEqual(7, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_EightOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Eight));

            Assert.AreEqual(8, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_NineOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Nine));

            Assert.AreEqual(9, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_TenOfClubs()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Ten));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        #endregion

        #region AcceptNewCard() - Single card scoring, Diamond

        [Test]
        public void AcceptNewCard_Score11For_AceOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Ace));

            Assert.AreEqual(11, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_KingOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.King));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_QueenOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Queen));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_JackOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Jack));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_TwoOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Two));

            Assert.AreEqual(2, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_ThreeOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Three));

            Assert.AreEqual(3, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_FourOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Four));

            Assert.AreEqual(4, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_FiveOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Five));

            Assert.AreEqual(5, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_SixOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Six));

            Assert.AreEqual(6, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_SevenOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Seven));

            Assert.AreEqual(7, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_EightOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Eight));

            Assert.AreEqual(8, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_NineOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Nine));

            Assert.AreEqual(9, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_TenOfDiamonds()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Ten));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        #endregion

        #region AcceptNewCard() - Single card scoring, Heart

        [Test]
        public void AcceptNewCard_Score11For_AceOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Ace));

            Assert.AreEqual(11, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_KingOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.King));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_QueenOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Queen));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_JackOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Jack));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_TwoOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Two));

            Assert.AreEqual(2, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_ThreeOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Three));

            Assert.AreEqual(3, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_FourOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Four));

            Assert.AreEqual(4, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_FiveOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Five));

            Assert.AreEqual(5, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_SixOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Six));

            Assert.AreEqual(6, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_SevenOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Seven));

            Assert.AreEqual(7, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_EightOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Eight));

            Assert.AreEqual(8, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_NineOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Nine));

            Assert.AreEqual(9, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_TenOfHearts()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Ten));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        #endregion

        #region AcceptNewCard() - Single card scoring, Spade

        [Test]
        public void AcceptNewCard_Score11For_AceOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Ace));

            Assert.AreEqual(11, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_KingOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.King));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_QueenOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Queen));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_Score10For_JackOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Jack));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_TwoOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Two));

            Assert.AreEqual(2, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_ThreeOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Three));

            Assert.AreEqual(3, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_FourOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Four));

            Assert.AreEqual(4, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_FiveOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Five));

            Assert.AreEqual(5, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_SixOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Six));

            Assert.AreEqual(6, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_SevenOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Seven));

            Assert.AreEqual(7, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_EightOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Eight));

            Assert.AreEqual(8, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_NineOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Nine));

            Assert.AreEqual(9, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_ScoreCorrectlyFor_TenOfSpades()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Ten));

            Assert.AreEqual(10, sut.CurrentScore);
        }

        #endregion

        #region AcceptNewCard() - Multiple card scoring, Aces only

        [Test]
        public void AcceptNewCard_OneSingleAceScores_11()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Ace));

            Assert.AreEqual(11, sut.CurrentScore); 
        }

        [Test]
        public void AcceptNewCard_TwoAcesScore_12()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Ace));          
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Ace));

            Assert.AreEqual(12, sut.CurrentScore);    
        }

        [Test]
        public void AcceptNewCard_ThreeAcesScore_13()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Ace));

            Assert.AreEqual(13, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_FourAcesScore_14()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Ace));

            Assert.AreEqual(14, sut.CurrentScore);
        }

        #endregion

        #region AcceptNewCard() - Multiple card scoring, Random hands

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test1()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Queen));            

            Assert.AreEqual(12, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test2()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Ten));
            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Queen));

            Assert.AreEqual(20, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test3()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Three));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Four));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Six));

            Assert.AreEqual(13, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test4()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Seven));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Nine));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Three));

            Assert.AreEqual(19, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test5()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Five));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Ace));

            Assert.AreEqual(20, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test6()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Jack));

            Assert.AreEqual(14, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test7()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Five));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Jack));

            Assert.AreEqual(19, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test8()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Spade, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Six));
            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Jack));

            Assert.AreEqual(20, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test9()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Five));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Two));
            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Jack));

            Assert.AreEqual(19, sut.CurrentScore);
        }

        [Test]
        public void AcceptNewCard_HandTotalsCorrectly_Test10()
        {
            var sut = new CardPlayer();

            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.King));
            sut.AcceptNewCard(new PlayingCard(Suit.Heart, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Diamond, CardNumber.Ace));
            sut.AcceptNewCard(new PlayingCard(Suit.Club, CardNumber.Ace));

            Assert.AreEqual(13, sut.CurrentScore);
        }

        #endregion

        #region HasTwoCards()

        [Test]
        public void HasTwoCards_ReturnTrue_IfTwoCardsInHand()
        {
            var testHand = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Two),
            };
            
            var sut = new CardPlayer {CurrentHand = testHand};

            Assert.IsTrue(sut.HasTwoCards());
        }

        [Test]
        public void HasTwoCards_ReturnFalse_IfLessThanTwoCardsInHand()
        {
            var testHand = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
            };

            var sut = new CardPlayer { CurrentHand = testHand };

            Assert.IsFalse(sut.HasTwoCards());    
        }

        [Test]
        public void HasTwoCards_ReturnFalseIfMoreThanTwoCardsInHand()
        {
            var testHand = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
                new PlayingCard(Suit.Club, CardNumber.Two),
                new PlayingCard(Suit.Club, CardNumber.Three),
            };

            var sut = new CardPlayer { CurrentHand = testHand };

            Assert.IsFalse(sut.HasTwoCards());    
        }

        #endregion

        #region ScoresTied()

        [Test]
        public void ScoresTied_ReturnTrue_IfScoresAreEqual()
        {
            var sut = new CardPlayer {CurrentScore = 20 };

            Assert.IsTrue(sut.ScoresTied(20));
        }

        [Test]
        public void ScoresTied_ReturnFalseIfScores_NotEqual()
        {
            var sut = new CardPlayer { CurrentScore = 14 };

            Assert.IsFalse(sut.ScoresTied(20));    
        }

        #endregion

        #region DisposeHand()

        [Test]
        public void DisposeHand_ResetCurrentScoreToZero()
        {
            var sut = new CardPlayer { CurrentScore = 10};

            sut.DisposeHand();

            Assert.AreEqual(0, sut.CurrentScore);
        }

        [Test]
        public void DisposeHand_EmptyCurrentHandToZeroItems()
        {
            var testCards = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Eight),
                new PlayingCard(Suit.Club, CardNumber.Nine)
            };

            var sut = new CardPlayer {CurrentHand = testCards};

            sut.DisposeHand();

            Assert.AreEqual(0, sut.CurrentHand.Count);
        }

        #endregion
    }
}
