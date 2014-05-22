using BlackJack.Players;
using NUnit.Framework;

namespace BlackJack.UnitTests.Players
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



        [TearDown]
        public void TearDown()
        {
            _sut = null;
        }
    }
}
