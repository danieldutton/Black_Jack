using BlackJack.CardDeck;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlackJack.Table
{
    public class CardShoe
    {
        public event EventHandler<EventArgs> ShoeEmpty;

        public Queue<PlayingCard> CurrentCardDeck { get; set; }


        public Queue<PlayingCard> GetNewCardDeck()
        {
            List<PlayingCard> cards = Enumerable.Range(0, 4)
                .SelectMany(s => Enumerable.Range(1, 13)
                    .Select(c => new PlayingCard((Suit)s, (CardNumber)c)                    
                    )
                )
                .ToList();

            return new Queue<PlayingCard>(cards);
        }

        public Queue<PlayingCard> ShuffleCardDeck(Stack<PlayingCard> cards)
        {
            IOrderedEnumerable<PlayingCard> result = cards
                .OrderBy(a => Guid.NewGuid());

            return new Queue<PlayingCard>(result);
        }

        public PlayingCard TakeACard()
        {
            return CurrentCardDeck.Dequeue();
        }

        protected virtual void OnShoeEmpty()
        {
            EventHandler<EventArgs> handler = ShoeEmpty;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}
