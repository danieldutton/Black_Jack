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
            InitialiseNewCardDeck();
        }

        public void InitialiseNewCardDeck()
        {
            Queue<PlayingCard> orderedCardDeck = _cardDeckGenerator.GetCardDeck();

            CurrentDeckInPlay = _cardShuffler.Shuffle(orderedCardDeck);
        }

        public List<PlayingCard> ReleaseStartingHands()
        {
            const int startingCardCount = 4;

            var startCards = new List<PlayingCard>();

            for (int i = 0; i < startingCardCount; i++)
            {
                startCards.Add(GetNextPlayingCard());
            }
            return startCards;
        }
        
        public PlayingCard GetNextPlayingCard()
        {
            if (CurrentDeckInPlay.Count == 0)
                InitialiseNewCardDeck();

            var card = CurrentDeckInPlay.Dequeue();

            return card;
        }
    }   
}
