using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    public interface ICardShoe
    {
        Queue<PlayingCard> CurrentDeckInPlay { get; }

        void PlaceNewDeck();

        PlayingCard ReleasePlayingCard();
    }
}
