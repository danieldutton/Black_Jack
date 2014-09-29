using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Utility;
using BlackJack.Utility.Interfaces;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.IntegrationTests.CardDeck
{
    [TestFixture]
    public class CardDeckBuilder_Should
    {
        private ICardDeckGenerator _cardDeckGenerator;

        private IResourceHandler _resourceHandler;

        private ICardImageMapper<PlayingCard> _cardImageMapper;

        private CardDeckBuilder _sut;

        private IEnumerable<CardNumber> _expectedCardValueOrder;
        
        [SetUp]
        public void Init()
        {
            _cardDeckGenerator = new PlainCardDeckGenerator();
            _resourceHandler = new ResourceHandler();
            _cardImageMapper = new CardImageMapper(_resourceHandler);
           
            _sut = new CardDeckBuilder(_cardDeckGenerator, _cardImageMapper);
            
            _expectedCardValueOrder = Mother.ExpectedSuitOrder();
        }

        [Test]
        public void GetCardDeck_ReturnExactly_52PlayingCards()
        {
            Queue<PlayingCard> cardDeck =  _sut.GetCardDeck();

            Assert.AreEqual(52, cardDeck.Count);    
        }

        [Test]
        public void GetCardDeck_FirstSetOf13Cards_AreofSuit_Club()
        {
            Queue<PlayingCard> cardDeck = _sut.GetCardDeck();

            IEnumerable<PlayingCard> firstSet = cardDeck.Take(13);

            Assert.IsTrue(firstSet.All(x => x.Suit == Suit.Club));
        }

        [Test]
        public void GetCardDeck_FirstSetOf13Clubs_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetCardDeck();

            IEnumerable<CardNumber> firstSet = cardDeck.Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, firstSet);
        }

        [Test]
        public void GetCardDeck_SecondSetOf13Cards_AreofSuit_Diamond()
        {
            Queue<PlayingCard> cardDeck = _sut.GetCardDeck();

            IEnumerable<PlayingCard> secondSet = cardDeck.Skip(13)
                .Take(13);

            Assert.IsTrue(secondSet.All(x => x.Suit == Suit.Diamond));
        }

        [Test]
        public void GetCardDeck_SecondSetOf13Diamonds_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetCardDeck();

            IEnumerable<CardNumber> secondSet = cardDeck.Skip(13)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, secondSet);
        }

        [Test]
        public void GetCardDeck_ThirdSetOf13Cards_AreofSuit_Heart()
        {
            Queue<PlayingCard> cardDeck = _sut.GetCardDeck();

            IEnumerable<PlayingCard> thirdSet = cardDeck.Skip(26).Take(13);

            Assert.IsTrue(thirdSet.All(x => x.Suit == Suit.Heart));
        }

        [Test]
        public void GetCardDeck_ThirdSetOf13Hearts_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetCardDeck();

            IEnumerable<CardNumber> thirdSet = cardDeck.Skip(26)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, thirdSet);
        }

        [Test]
        public void GetCardDeck_FourthSetOf13Cards_AreofSuit_Spade()
        {
            Queue<PlayingCard> cardDeck = _sut.GetCardDeck();

            IEnumerable<PlayingCard> fourthSet = cardDeck.Skip(39).Take(13);

            Assert.IsTrue(fourthSet.All(x => x.Suit == Suit.Spade));
        }

        [Test]
        public void GetCardDeck_FourthSetOf13Spades_AreInNumericOrderAscending()
        {
            Queue<PlayingCard> cardDeck = _sut.GetCardDeck();

            IEnumerable<CardNumber> fourthSet = cardDeck.Skip(39)
                .Take(13)
                .Select(x => x.CardNumber);

            CollectionAssert.AreEqual(_expectedCardValueOrder, fourthSet);
        }

        #region Images Club

        [Test]
        public void GetCardDeck_AceOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(0);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Ace", card.Tag);
        }

        [Test]
        public void GetCardDeck_TwoOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(1);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Two", card.Tag);
        }

        [Test]
        public void GetCardDeck_ThreeOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(2);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Three", card.Tag);
        }

        [Test]
        public void GetCardDeck_FourOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(3);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Four", card.Tag);
        }

        [Test]
        public void GetCardDeck_FiveOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(4);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Five", card.Tag);
        }

        [Test]
        public void GetCardDeck_SixOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(5);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Six", card.Tag);
        }

        [Test]
        public void GetCardDeck_SevenOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(6);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Seven", card.Tag);
        }

        [Test]
        public void GetCardDeck_EightOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(7);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Eight", card.Tag);
        }

        [Test]
        public void GetCardDeck_NineOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(8);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Nine", card.Tag);
        }

        [Test]
        public void GetCardDeck_TenOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(9);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Ten", card.Tag);
        }

        [Test]
        public void GetCardDeck_JackOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(10);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Jack", card.Tag);
        }

        [Test]
        public void GetCardDeck_QueenOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(11);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_Queen", card.Tag);
        }

        [Test]
        public void GetCardDeck_KingOfClubs_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(12);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Club_King", card.Tag);
        }

        #endregion

        #region Images Diamond

        [Test]
        public void GetCardDeck_AceOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(13);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Ace", card.Tag);
        }

        [Test]
        public void GetCardDeck_TwoOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(14);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Two", card.Tag);
        }

        [Test]
        public void GetCardDeck_ThreeOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(15);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Three", card.Tag);
        }

        [Test]
        public void GetCardDeck_FourOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(16);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Four", card.Tag);
        }

        [Test]
        public void GetCardDeck_FiveOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(17);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Five", card.Tag);
        }

        [Test]
        public void GetCardDeck_SixOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(18);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Six", card.Tag);
        }

        [Test]
        public void GetCardDeck_SevenOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(19);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Seven", card.Tag);
        }

        [Test]
        public void GetCardDeck_EightOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(20);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Eight", card.Tag);
        }

        [Test]
        public void GetCardDeck_NineOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(21);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Nine", card.Tag);
        }

        [Test]
        public void GetCardDeck_TenOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(22);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Ten", card.Tag);
        }

        [Test]
        public void GetCardDeck_JackOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(23);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Jack", card.Tag);
        }

        [Test]
        public void GetCardDeck_QueenOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(24);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_Queen", card.Tag);
        }

        [Test]
        public void GetCardDeck_KingOfDiamonds_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(25);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Diamond_King", card.Tag);
        }

        #endregion

        #region Images Heart

        [Test]
        public void GetCardDeck_AceOfHearts_ImageMappedCorrect() //this is not running
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(26);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Ace", card.Tag);
        }

        [Test]
        public void GetCardDeck_TwoOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(27);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Two", card.Tag);
        }

        [Test]
        public void GetCardDeck_ThreeOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(28);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Three", card.Tag);
        }

        [Test]
        public void GetCardDeck_FourOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(29);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Four", card.Tag);
        }

        [Test]
        public void GetCardDeck_FiveOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(30);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Five", card.Tag);
        }

        [Test]
        public void GetCardDeck_SixOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(31);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Six", card.Tag);
        }

        [Test]
        public void GetCardDeck_SevenOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(32);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Seven", card.Tag);
        }

        [Test]
        public void GetCardDeck_EightOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(33);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Eight", card.Tag);
        }

        [Test]
        public void GetCardDeck_NineOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(34);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Nine", card.Tag);
        }

        [Test]
        public void GetCardDeck_TenOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(35);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Ten", card.Tag);
        }

        [Test]
        public void GetCardDeck_JackOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(36);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Jack", card.Tag);
        }

        [Test]
        public void GetCardDeck_QueenOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(37);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_Queen", card.Tag);
        }

        [Test]
        public void GetCardDeck_KingOfHearts_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(38);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Heart_King", card.Tag);
        }

        #endregion

        #region Images Spade

        [Test]
        public void GetCardDeck_AceOfSpades_ImageMappedCorrect() //this is not running
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(39);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Ace", card.Tag);
        }

        [Test]
        public void GetCardDeck_TwoOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(40);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Two", card.Tag);
        }

        [Test]
        public void GetCardDeck_ThreeOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(41);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Three", card.Tag);
        }

        [Test]
        public void GetCardDeck_FourOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(42);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Four", card.Tag);
        }

        [Test]
        public void GetCardDeck_FiveOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(43);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Five", card.Tag);
        }

        [Test]
        public void GetCardDeck_SixOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(44);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Six", card.Tag);
        }

        [Test]
        public void GetCardDeck_SevenOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(45);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Seven", card.Tag);
        }

        [Test]
        public void GetCardDeck_EightOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(46);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Eight", card.Tag);
        }

        [Test]
        public void GetCardDeck_NineOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(47);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Nine", card.Tag);
        }

        [Test]
        public void GetCardDeck_TenOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(48);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Ten", card.Tag);
        }

        [Test]
        public void GetCardDeck_JackOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(49);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Jack", card.Tag);
        }

        [Test]
        public void GetCardDeck_QueenOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(50);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_Queen", card.Tag);
        }

        [Test]
        public void GetCardDeck_KingOfSpades_ImageMappedCorrect()
        {
            PlayingCard card = _sut.GetCardDeck().ElementAt(51);

            Assert.IsNotNull(card.Image);
            Assert.AreEqual("Spade_King", card.Tag);
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
            _cardDeckGenerator = null;
            _resourceHandler = null;
            _cardImageMapper = null;
            _sut = null;
            _expectedCardValueOrder = null;
        }
    }
}
