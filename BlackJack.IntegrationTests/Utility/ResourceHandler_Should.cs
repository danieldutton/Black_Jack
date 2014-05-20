using BlackJack.Utility;
using NUnit.Framework;
using System.Resources;

namespace BlackJack.IntegrationTests.Utility
{
    [TestFixture]
    public class ResourceHandler_Should
    {
        [Test]
        public void GetResourceManager_ReturnAResourceManagerInstance()
        {
            var sut = new ResourceHandler();

            ResourceManager result = sut.GetResourceManager();
            
            Assert.IsInstanceOf<ResourceManager>(result); 
        }

        [Test]
        public void GetResourceManager_LoadTheCorrectResourceRoot()
        {
            var sut = new ResourceHandler();
            
            ResourceManager result = sut.GetResourceManager();
            
            Assert.AreEqual("BlackJack.CardDeck.Properties.Resources", result.BaseName);
        }
    }
}
