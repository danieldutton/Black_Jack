using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;
using BlackJack.Utility.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Table
{
    public class CardShoe : ICardShoe
    {
        private readonly ICardDeckBuilder _cardDeckBuilder;
        
        private readonly IShuffler<PlayingCard> _shuffler;
        
        public Queue<PlayingCard> CurrentCardDeck { get; private set; }


        public CardShoe(ICardDeckBuilder cardDeckBuilder, IShuffler<PlayingCard> shuffler)
        {
            _cardDeckBuilder = cardDeckBuilder;
            _shuffler = shuffler;
        }

        public void InitNewDeck()
        {
            Queue<PlayingCard> orderedCardDeck = _cardDeckBuilder.GetOrderedCardDeck();
            CurrentCardDeck = _shuffler.Shuffle(orderedCardDeck);
        }
        
        public PlayingCard TakePlayingCard()
        {
            if (CurrentCardDeck.Count == 0)
                InitNewDeck();

            return CurrentCardDeck.Dequeue();
        }
    }   
}
