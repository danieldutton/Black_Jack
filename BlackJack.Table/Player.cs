using BlackJack.Table.EventArg;
using BlackJack.Table.Interfaces;
using System;

namespace BlackJack.Table
{
    public class Player : IBlackJackPlayer
    {
        public event EventHandler<EventArgs> Hit;

        public event EventHandler<CardHandStickArgs> Stick;
       
        public bool HasCurrentTurn { get; set; }
        

        protected virtual void OnHit()
        {
            EventHandler<EventArgs> handler = Hit;
            if (handler != null) handler(this, EventArgs.Empty);
        }

        protected virtual void OnStick(CardHandStickArgs e)
        {
            EventHandler<CardHandStickArgs> handler = Stick;
            if (handler != null) handler(this, e);
        }       
    }
}
