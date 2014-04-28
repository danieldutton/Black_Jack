using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;
using BlackJack.Utility.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Table
{
    public class CardShoe : ICardShoe
    {
        private readonly CardDeckGenerator _cardDeckGenerator;
        
        private readonly IShuffler<PlayingCard> _cardShuffler;
        
        public Queue<PlayingCard> CurrentDeckInPlay { get; private set; }


        public CardShoe(CardDeckGenerator cardDeckGenerator, IShuffler<PlayingCard> cardShuffler)
        {
            _cardDeckGenerator = cardDeckGenerator;
            _cardShuffler = cardShuffler;
            PlaceNewDeck();
        }

        public void PlaceNewDeck()
        {
            Queue<PlayingCard> orderedCardDeck = _cardDeckGenerator.GetCardDeck();

            CurrentDeckInPlay = _cardShuffler.Shuffle(orderedCardDeck);
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
