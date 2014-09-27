using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    //can we make this header interface a role interface
    public interface ICardShoe
    {
        Queue<PlayingCard> CardDeck { get; set; }

        void MountDeck();

        void ShuffleDeck();

        List<PlayingCard> GetStartingHand();

        PlayingCard GetPlayingCard();
    }
}
