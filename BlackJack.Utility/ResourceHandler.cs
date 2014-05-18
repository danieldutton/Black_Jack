using BlackJack.Utility.Interfaces;
using System.Reflection;
using System.Resources;

namespace BlackJack.Utility
{
    public class ResourceHandler : IResourceHandler
    {
        public ResourceManager GetResourceManager()
        {
            Assembly localisationAssembly = Assembly.Load("BlackJack.CardDeck");
            var resourceManager = new ResourceManager("BlackJack.CardDeck.Properties.Resources", localisationAssembly);
            
            return resourceManager;
        }
    }
}
