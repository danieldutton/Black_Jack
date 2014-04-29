using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Table
{
    public class Player : ICardPlayer
    {
        public int CurrentScore { get; set; }

        public List<PlayingCard> CurrentHand { get; set; }


        public Player()
        {
            CurrentHand = new List<PlayingCard>();   
        }      
    }
}
