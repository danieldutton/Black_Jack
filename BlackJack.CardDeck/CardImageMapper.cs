using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Utility.Interfaces;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace BlackJack.CardDeck
{
    public class CardImageMapper : ICardImageMapper<PlayingCard>
    {
        private readonly IResourceHandler _resourceHandler;

        public CardImageMapper(IResourceHandler resourceHandler)
        {
            _resourceHandler = resourceHandler;
        }

        public IEnumerable<PlayingCard> MapCardImages(IEnumerable<PlayingCard> plainCards)
        {
            var mapCardImages = plainCards.ToList();
            
            foreach (var playingCard in mapCardImages)
            {
                object o = _resourceHandler.GetResourceManager()
                    .GetObject(playingCard.GetResourceImageName());
                
                if (o != null)
                {
                    playingCard.Image = o as Image;
                    playingCard.Tag = playingCard.GetResourceImageName();
                }                    
            }

            return mapCardImages;
        }
    }
}
