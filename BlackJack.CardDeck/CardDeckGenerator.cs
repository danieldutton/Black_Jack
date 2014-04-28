using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.CardDeck
{
    public class CardDeckGenerator
    {
        private readonly ICardSuitGenerator _cardSuitGenerator;
        
        private readonly ICardImageMapper<PlayingCard> _cardImageMapper;

        public CardDeckGenerator(ICardSuitGenerator cardSuitGenerator, ICardImageMapper<PlayingCard> cardImageMapper)
        {
            _cardSuitGenerator = cardSuitGenerator;
            _cardImageMapper = cardImageMapper;
        }

        public Queue<PlayingCard> GetCardDeck()
        {
            IEnumerable<PlayingCard> plainCardDeck = _cardSuitGenerator.GenerateCardDeck();
            IEnumerable<PlayingCard> cardDeckWithImages = _cardImageMapper.MapCardImages(plainCardDeck);

            return new Queue<PlayingCard>(cardDeckWithImages);
        } 
    }
}
