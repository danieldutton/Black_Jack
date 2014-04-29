using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Table.Interfaces
{
    public interface ICardPlayer
    {
        int CurrentScore { get; set; }

        List<PlayingCard> CurrentHand { get; set; } 
    }
}
