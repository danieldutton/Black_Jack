using BlackJack.CardDeck.Model;
using BlackJack.Presentation.Components;
using NUnit.Framework;
using System;

namespace BlackJack.UnitTests.Presentation
{
    [TestFixture]
    public class CardMat_Should
    {
        private CardMat _sut;

        [SetUp]
        public void Init()
        {
            _sut = new CardMat();
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void PlaceCard_ThrowAnArgumentNullException_IfPlayingCardParamIsNull()
        {
            _sut.PlaceCard(null);
        }

        [Test]
        public void PlaceCard_SetCorrectLocationPropertyValues_ForFirstCardAdded()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));

            Assert.AreEqual(0, _sut.Controls[0].Location.X);
            Assert.AreEqual(0, _sut.Controls[0].Location.Y);
        }

        [Test]
        public void PlaceCard_SetCorrectLocationPropertyValues_ForSecondCardAdded()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));

            Assert.AreEqual(40, _sut.Controls[0].Location.X);
            Assert.AreEqual(0, _sut.Controls[0].Location.Y);
        }

        [Test]
        public void PlaceCard_SetCorrectLocationPropertyValues_ForThirdCardAdded()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Three));

            Assert.AreEqual(80, _sut.Controls[0].Location.X);
            Assert.AreEqual(0, _sut.Controls[0].Location.Y);
        }

        [Test]
        public void PlaceCard_SetCorrectLocationPropertyValues_ForFourthCardAdded()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Three));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Four));

            Assert.AreEqual(120, _sut.Controls[0].Location.X);
            Assert.AreEqual(0, _sut.Controls[0].Location.Y);
        }

        [Test]
        public void PlaceCard_AddOnePlayingCardToCardMatControlsProperty()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));

            Assert.AreEqual(1, _sut.Controls.Count);    
        }

        [Test]
        public void PlaceCard_AddTwoPlayingCardsToCardMatControlsProperty()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));

            Assert.AreEqual(2, _sut.Controls.Count);
        }

        [Test]
        public void PlaceCard_AddThreePlayingCardsToCardMatControlsProperty()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Three));

            Assert.AreEqual(3, _sut.Controls.Count);
        }

        [Test]
        public void PlaceCard_AddFourPLayingCardsToCardMatControlsProperty()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Three));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Four));

            Assert.AreEqual(4, _sut.Controls.Count);
        }

        [Test]
        public void PlaceCard_SetChildIndexToZero_ForEveryCardAdded()
        {
            var card = new PlayingCard(Suit.Club, CardNumber.Ace);

            _sut.PlaceCard(card);

            Assert.AreEqual(0, _sut.Controls.GetChildIndex(card));
        }

        [Test]
        public void PlaceCard_SetPropertyLastCardXPosition_To40_If1CardAdded()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            
            Assert.AreEqual(40, _sut.LastCardXPosition);
        }

        [Test]
        public void PlaceCard_SetProperty_LastCardXPositionTo80_If2CardsAdded()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));

            Assert.AreEqual(80, _sut.LastCardXPosition);
        }

        [Test]
        public void PlaceCard_SetProperty_LastCardXPositionTo120_If3CardsAdded()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Three));

            Assert.AreEqual(120, _sut.LastCardXPosition);
        }

        [Test]
        public void PlaceCard_SetProperty_LastCardXPositionTo160_If4CardsAdded()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Three));
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Four));

            Assert.AreEqual(160, _sut.LastCardXPosition);
        }

        [Test]
        public void Reset_ClearAllCardMatControls()
        {
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Ace)); 
            _sut.PlaceCard(new PlayingCard(Suit.Club, CardNumber.Two));

            _sut.Clear();

            Assert.AreEqual(0, _sut.Controls.Count);
        }

        [Test]
        public void ResetSetPropertyLastCardXPosition_ToZero()
        {
            _sut.Clear();

            Assert.AreEqual(0, _sut.LastCardXPosition);
        }

        [Test]
        public void ToString_ReturnTheCorrectValue()
        {
            const string expected = "[CardMat] Width:493 Height:110";

            Assert.AreEqual(expected, _sut.ToString());
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }
    }
}
