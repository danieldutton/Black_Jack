using BlackJack.Players;
using BlackJack.Table;
using NUnit.Framework;

namespace BlackJack.UnitTests.Table
{
    [TestFixture]
    public class Player_Should
    {
        private Player _sut;

        [SetUp]
        public void Init()
        {
            _sut = new Player();    
        }

        [Test]
        public void IsBust_ReturnTrue_IfScoreIsGreaterThan21()
        {
            bool actual = _sut.IsBust(22);

            Assert.IsTrue(actual);
        }

        [Test]
        public void IsBust_ReturnFalse_IfScoreIsExactly21()
        {
            bool actual = _sut.IsBust(21);

            Assert.IsFalse(actual);    
        }

        [Test]
        public void IsBust_ReturnFalse_IfScoreIsLessThan21()
        {
            bool actual = _sut.IsBust(13);

            Assert.IsFalse(actual);    
        }

        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }
    }
}
