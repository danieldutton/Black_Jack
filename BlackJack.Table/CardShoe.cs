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
        
        private readonly IShuffler<PlayingCard> _cardShuffler;
        
        public Queue<PlayingCard> CurrentDeckInPlay { get;  set; }


        public CardShoe(ICardDeckBuilder cardDeckBuilder, IShuffler<PlayingCard> cardShuffler)
        {
            _cardDeckBuilder = cardDeckBuilder;
            _cardShuffler = cardShuffler;
            InitialiseNewCardDeck();
        }

        private void InitialiseNewCardDeck()
        {
            Queue<PlayingCard> orderedCardDeck = _cardDeckBuilder.GetCardDeck();

            CurrentDeckInPlay = _cardShuffler.Shuffle(orderedCardDeck);
        }

        public List<PlayingCard> GetStartingHand()
        {
            const int cardCount = 2;

            var startCards = new List<PlayingCard>();

            for (int i = 0; i < cardCount; i++)
            {
                startCards.Add(TakeSinglePlayingCard());
            }
            return startCards;
        }
        
        public PlayingCard TakeSinglePlayingCard()
        {
            if (CurrentDeckInPlay.Count == 0)
                InitialiseNewCardDeck();

            PlayingCard card = CurrentDeckInPlay.Dequeue();

            return card;
        }
    }   
}
