using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;
using BlackJack.Utility.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Table
{
    public class CardShoe : ICardShoe
    {
        private readonly ICardSuitBuilder _cardSuitBuilder;
        
        private readonly IShuffler<PlayingCard> _cardShuffler;
        
        public Queue<PlayingCard> CurrentDeckInPlay { get; private set; }


        public CardShoe(ICardSuitBuilder cardSuitBuilder, IShuffler<PlayingCard> cardShuffler)
        {
            _cardSuitBuilder = cardSuitBuilder;
            _cardShuffler = cardShuffler;
            PlaceNewDeck();
        }

        public void PlaceNewDeck()
        {
            IEnumerable<PlayingCard> orderedCardDeck = _cardSuitBuilder.GetOrderedCardDeck();
            var mapper = new CardImageMapper();
            var result = mapper.MapCardImages(orderedCardDeck);
            CurrentDeckInPlay = _cardShuffler.Shuffle(result);
        }
        
        public PlayingCard ReleasePlayingCard()
        {
            if (CurrentDeckInPlay.Count == 0)
                PlaceNewDeck();

            var card = CurrentDeckInPlay.Dequeue();

            return card;
        }
    }   
}
