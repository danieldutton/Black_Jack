using BlackJack.CardDeck.Model;
using BlackJack.Players.EventArg;
using BlackJack.Players.Interfaces;
using System;
using System.Collections.Generic;

namespace BlackJack.Players
{
    public class Player : ICardPlayer
    {
        public event EventHandler<PlayerTakesMoveArgs> Stick;

        public EventHandler<PlayerTakesMoveArgs> Hit;

        public int CurrentScore { get; set; }

        public List<PlayingCard> CurrentHand { get; set; }

        
        public Player()
        {
            CurrentHand = new List<PlayingCard>();   
        }

        public bool IsBust(int score)
        {
            return score > 21;
        }

        public void DisposeOfCurrentHand()
        {
            CurrentScore = 0;
            CurrentHand.Clear();
        }

        public virtual void OnStick(PlayerTakesMoveArgs e)
        {
            EventHandler<PlayerTakesMoveArgs> handler = Stick;
            if (handler != null) handler(this, e);
        }

        public virtual void OnHit(PlayerTakesMoveArgs e)
        {
            EventHandler<PlayerTakesMoveArgs> handler = Hit;
            if (handler != null) handler(this, e);
        }
    }
}
