using BlackJack.CardDeck.Model;
using BlackJack.Table.EventArgs;
using BlackJack.Table.Interfaces;
using System;
using System.Collections.Generic;

namespace BlackJack.Table
{
    public class Player : IBlackJackPlayer
    {
        public event EventHandler<PlayerSticksEventArg> Stick;

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

        public virtual void OnStick(PlayerSticksEventArg e)
        {
            EventHandler<PlayerSticksEventArg> handler = Stick;
            if (handler != null) handler(this, e);
        }
    }
}
