using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Model
{
    public class Dealer
    {
        private Stack<PlayingCard> _cardDeck;

        public Stack<PlayingCard> ShuffleCardDeck()
        {
            var cards = Enumerable.Range(0, 51);
            
            var shuffledcards = cards.OrderBy(a => Guid.NewGuid());

            var playingCards = new Stack<PlayingCard>();

            for (int i = 0; i < 52; i++)
            {
                playingCards.Push(new PlayingCard());
            }
            return playingCards;
        }
    }
}
