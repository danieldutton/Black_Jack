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
        
        public Queue<PlayingCard> CardDeck { get; set; }


        public CardShoe(ICardDeckBuilder cardDeckBuilder, IShuffler<PlayingCard> cardShuffler)
        {
            _cardDeckBuilder = cardDeckBuilder;
            _cardShuffler = cardShuffler; 

            MountDeck();
            ShuffleDeck();
        }

        public void MountDeck()
        {
            CardDeck = _cardDeckBuilder.GetCardDeck();
        }

        public void ShuffleDeck()
        {
            CardDeck = _cardShuffler.Shuffle(CardDeck);    
        }

        public List<PlayingCard> GetStartingHand()
        {
            const int cardCount = 2;

            var startCards = new List<PlayingCard>();

            for (int i = 0; i < cardCount; i++)
            {
                startCards.Add(GetPlayingCard());
            }
            return startCards;
        }
        
        public PlayingCard GetPlayingCard()
        {
            if (CardDeck.Count == 0)
            {
                MountDeck();
                ShuffleDeck();    
            }
                
            PlayingCard card = CardDeck.Dequeue();

            return card;
        }
    }   
}
