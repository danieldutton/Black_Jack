using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Table
{
    public class Dealer : ICardPlayer
    {
        public List<PlayingCard> CurrentHand { get; set; }

        public int CurrentScore { get; set; }


        public Dealer()
        {
            CurrentHand = new List<PlayingCard>();
        } 
    }
}
