using BlackJack.CardDeck.Model;
using BlackJack.Presentation.Components;
using NUnit.Framework;
using System;

namespace BlackJack.UnitTests.Presentation
{
    [TestFixture]
    public class CardMat_Should
    {
        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddPlayingCard_ThrowAnArgumentNullException_IfPlayingCardParamIsNull()
        {
            var sut = new CardMat();
            sut.AddPlayingCard(null);
        }

        [Test]
        public void AddPlayingCard_SetProperty_CardXPositionTo40_If1CardAdded()
        {
            var sut = new CardMat();

            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            
            Assert.AreEqual(40, sut.LastCardPositionX);
        }

        [Test]
        public void AddPlayingCard_SetProperty_CardXPositionTo80_If2CardsAdded()
        {
            var sut = new CardMat();

            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Two));

            Assert.AreEqual(80, sut.LastCardPositionX);
        }

        [Test]
        public void AddPlayingCard_SetProperty_CardXPosition120_If3CardsAdded()
        {
            var sut = new CardMat();

            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Two));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Three));

            Assert.AreEqual(120, sut.LastCardPositionX);
        }

        [Test]
        public void AddPlayingCard_SetProperty_CardXPosition160_If4CardsAdded()
        {
            var sut = new CardMat();

            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Two));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Three));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Four));

            Assert.AreEqual(160, sut.LastCardPositionX);
        }

        [Test]
        public void AddPlayingCard_SetProperty_CardXPosition200_If5CardsAdded()
        {
            var sut = new CardMat();

            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Two));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Three));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Four));
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Five));

            Assert.AreEqual(200, sut.LastCardPositionX);
        }

        [Test]
        public void Reset_ClearAllCardMatControls()
        {
            var sut = new CardMat { LastCardPositionX = 40 };
            sut.AddPlayingCard(new PlayingCard(Suit.Club, CardNumber.Ace));

            sut.Clear();

            Assert.AreEqual(0, sut.Controls.Count);
        }

        [Test]
        public void Reset_DefaultProperty_CardXPosition_ToZero()
        {
            var sut = new CardMat {LastCardPositionX = 40};

            sut.Clear();

            Assert.AreEqual(0, sut.LastCardPositionX);
        }

        [Test]
        public void ToString_ReturnTheCorrectValue()
        {
            var sut = new CardMat();

            Assert.AreEqual("[CardMat] Width:200 Height:100", sut.ToString());
        }
    }
}
