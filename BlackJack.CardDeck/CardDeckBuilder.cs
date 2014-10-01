using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.CardDeck
{
    public class CardDeckBuilder : ICardDeckBuilder
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
            IEnumerable<PlayingCard> plainCardDeck = _cardSuitBuilder.GetPlainCardDeck();
            IEnumerable<PlayingCard> cardDeckWithImages = _cardImageMapper.MapCardImages(plainCardDeck);

            return new Queue<PlayingCard>(cardDeckWithImages);
        } 
    }
}
