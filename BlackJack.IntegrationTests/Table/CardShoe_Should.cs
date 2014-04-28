using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Utility;
using BlackJack.Utility.Interfaces;
using NUnit.Framework;

namespace BlackJack.IntegrationTests.Table
{
    [TestFixture]
    public class CardShoe_Should
    {
        private ICardSuitBuilder _cardSuitBuilder;

        private IShuffler<PlayingCard> _shuffler;

        private CardShoe _sut;

        [SetUp]
        public void Init()
        {
            _cardSuitBuilder = new CardSuitBuilder();
            _shuffler = new GuidShuffler<PlayingCard>();
            _sut = new CardShoe(_cardSuitBuilder, _shuffler);
        }

        [Test]
        public void InitNewDeck_ProvideADeckWith52Cards()
        {
            
        }

        [TearDown]
        public void TearDown()
        {
            _cardSuitBuilder = null;
            _shuffler = null;
            _sut = null;
        }
    }
}
