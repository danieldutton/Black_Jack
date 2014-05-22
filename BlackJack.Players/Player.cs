using BlackJack.CardDeck.Model;
using BlackJack.Players.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Players
{
    public class Player : ICardPlayer
    {
        public int CurrentScore { get; set; }

        public List<PlayingCard> CurrentHand { get; set; }

        
        public Player()
        {
            CurrentHand = new List<PlayingCard>();   
        }

        public void DisposeOfCurrentHand()
        {
            CurrentScore = 0;
            CurrentHand.Clear();
        }
    }
}
