using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    public interface ICardShoe
    {
        Queue<PlayingCard> CurrentDeckInPlay { get; }

        List<PlayingCard> ReleaseStartingHands();

        void InitialiseNewCardDeck();

        PlayingCard GetNextPlayingCard();
    }
}
