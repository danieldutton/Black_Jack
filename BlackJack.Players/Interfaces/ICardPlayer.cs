using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Players.Interfaces
{
    public interface ICardPlayer
    {
        int CurrentScore { get; set; }

        List<PlayingCard> CurrentHand { get; set; }

        void DisposeOfCurrentHand();

    }
}
