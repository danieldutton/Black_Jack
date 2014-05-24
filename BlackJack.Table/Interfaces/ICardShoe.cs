using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    public interface ICardShoe
    {
        Queue<PlayingCard> CardDeck { get; set; }

        void MountNewCardDeck();

        void ShuffleCardDeck();

        List<PlayingCard> GetStartingHand();

        PlayingCard GetPlayingCard();
    }
}
