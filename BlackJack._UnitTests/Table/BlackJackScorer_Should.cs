using BlackJack.Table;
using NUnit.Framework;

namespace BlackJack.UnitTests.Table
{
    [TestFixture]
    public class BlackJackScorer_Should
    {
        private BlackJackScorer _sut;

        [SetUp]
        public void Init()
        {
            _sut = new BlackJackScorer(stickThreshold:15);
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }
    }
}
