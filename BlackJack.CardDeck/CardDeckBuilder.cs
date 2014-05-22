using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.CardDeck
{
    public class CardDeckBuilder : ICardDeckBuilder
    {
        private readonly ICardDeckGenerator _cardDeckGenerator;
        
        private readonly ICardImageMapper<PlayingCard> _cardImageMapper;


        public CardDeckBuilder(ICardDeckGenerator cardDeckGenerator, ICardImageMapper<PlayingCard> cardImageMapper)
        {
            _cardDeckGenerator = cardDeckGenerator;
            _cardImageMapper = cardImageMapper;
        }

        public Queue<PlayingCard> GetCardDeck()
        {
            IEnumerable<PlayingCard> plainCardDeck = _cardDeckGenerator.GetPlainCardDeck();
            IEnumerable<PlayingCard> cardDeckWithImages = _cardImageMapper.MapCardImages(plainCardDeck);

            return new Queue<PlayingCard>(cardDeckWithImages);
        } 
    }
}
