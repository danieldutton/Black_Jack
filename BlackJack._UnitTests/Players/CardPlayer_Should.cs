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

        #region Ace Of Clubs Combination

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

        #region Ace Of Hearts Combination

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

        #region Ace Of Spades Combination

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

        #region Ace Of Diamonds Combination

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

        //
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

        //
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

            Assert.IsTrue(sut.HasTwoCards());
        }

        [Test]
        public void HasTwoCardsInHand_ReturnFalse_IfLessThanTwoCardsInHand()
        {
            var testHand = new List<PlayingCard>
            {
                new PlayingCard(Suit.Club, CardNumber.Ace),
            };

            var sut = new CardPlayer { CurrentHand = testHand };

            Assert.IsFalse(sut.HasTwoCards());    
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

            Assert.IsFalse(sut.HasTwoCards());    
        }

        

        [Test]
        public void ScoresAreDrawn_ReturnTrue_IfScoresAreEqual()
        {
            var sut = new CardPlayer {CurrentScore = 20 };

            Assert.IsTrue(sut.ScoresTied(20));
        }

        [Test]
        public void ScoresAreDrawn_ReturnFalseIfScores_NotEqual()
        {
            var sut = new CardPlayer { CurrentScore = 14 };

            Assert.IsFalse(sut.ScoresTied(20));    
        }

        [Test]
        public void DisposeOfHand_ResetCurrentScoreToZero()
        {
            var sut = new CardPlayer { CurrentScore = 10};

            sut.DisposeHand();

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

            sut.DisposeHand();

            Assert.AreEqual(0, sut.CurrentHand.Count);
        }
    }
}
