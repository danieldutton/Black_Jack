using System.Collections.Generic;
using BlackJack.CardDeck.Model;

namespace BlackJack.Players.Interfaces
{
    public interface ICardPlayer
    {
        int CurrentScore { get; set; }

        List<PlayingCard> CurrentHand { get; set; }

        void DisposeOfCurrentHand();

        bool IsBust(int score);
    }
}
