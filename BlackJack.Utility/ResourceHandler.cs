using BlackJack.Utility.Exceptions;
using BlackJack.Utility.Interfaces;
using System;
using System.Reflection;
using System.Resources;

namespace BlackJack.Utility
{
    public class ResourceHandler : IResourceHandler
    {
        public ResourceManager GetResourceManager()
        {
            ResourceManager resourceManager;

            try
            {
                Assembly localisationAssembly = Assembly.Load("BlackJack.CardDeck");
                
                resourceManager = new ResourceManager("BlackJack.CardDeck.Properties.Resources", localisationAssembly);
            }
            catch (Exception e)
            {
                throw new ResourceHandleException("Failed to load resources", e);
            }
            
            return resourceManager;
        }
    }
}
