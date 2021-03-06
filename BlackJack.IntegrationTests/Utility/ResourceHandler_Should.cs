﻿using BlackJack.Utility;
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

            ResourceManager resourceManager = sut.GetResourceManager();
            
            Assert.IsInstanceOf<ResourceManager>(resourceManager); 
        }

        [Test]
        public void GetResourceManager_LoadTheCorrectResourceRoot()
        {
            var sut = new ResourceHandler();
            
            ResourceManager resourceManager = sut.GetResourceManager();
            
            Assert.AreEqual("BlackJack.CardDeck.Properties.Resources", resourceManager.BaseName);
        }
    }
}
