using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    public interface ICardShoe
    {
        Queue<PlayingCard> CurrentDeckInPlay { get; }

        List<PlayingCard> GetStartingHand();

        void InitialiseNewCardDeck();

        PlayingCard GetNextPlayingCard();
    }
}
