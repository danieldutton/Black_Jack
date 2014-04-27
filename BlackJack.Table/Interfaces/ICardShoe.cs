using BlackJack.CardDeck;
using System.Collections.Generic;
using BlackJack.CardDeck.Model;

namespace BlackJack.Table.Interfaces
{
    public interface ICardShoe
    {
        Queue<PlayingCard> CurrentCardDeck { get; }

        void InitNewDeck();

        PlayingCard TakePlayingCard();
    }
}
