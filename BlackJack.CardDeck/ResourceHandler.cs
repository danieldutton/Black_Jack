using BlackJack.CardDeck.Interfaces;
using System.Resources;

namespace BlackJack.CardDeck
{
    public class ResourceHandler : IResourceHandler
    {
        public ResourceManager GetResourceManager()
        {
            return Properties.Resources.ResourceManager;
        }
    }
}
