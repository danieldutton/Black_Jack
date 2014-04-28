using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
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

        public IEnumerable<PlayingCard> MapCardImages(IEnumerable<PlayingCard> cards)
        {
            var mapCardImages = cards as IList<PlayingCard> ?? cards.ToList();
            
            foreach (var playingCard in mapCardImages)
            {
                object o = _resourceHandler.GetResourceManager()
                    .GetObject(playingCard.GetAssociatedImageName());

                if (o != null)
                {
                    playingCard.Image = o as Image;
                    playingCard.Tag = playingCard.GetAssociatedImageName();
                }                    
            }

            return mapCardImages;
        }
    }
}
