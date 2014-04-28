using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.CardDeck
{
    public class CardDeckBuilder
    {
        private readonly ICardSuitBuilder _cardSuitBuilder;
        
        private readonly ICardImageMapper<PlayingCard> _cardImageMapper;

        public CardDeckBuilder(ICardSuitBuilder cardSuitBuilder, ICardImageMapper<PlayingCard> cardImageMapper)
        {
            _cardSuitBuilder = cardSuitBuilder;
            _cardImageMapper = cardImageMapper;
        }

        public Queue<PlayingCard> GetCardDeck()
        {
            IEnumerable<PlayingCard> plainDeck = _cardSuitBuilder.GetOrderedCardDeck();
            IEnumerable<PlayingCard> imageDeck = _cardImageMapper.MapCardImages(plainDeck);

            return new Queue<PlayingCard>(imageDeck);
        } 
    }
}
