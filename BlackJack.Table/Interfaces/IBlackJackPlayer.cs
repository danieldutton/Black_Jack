using System;
using BlackJack.Table.EventArg;

namespace BlackJack.Table.Interfaces
{
    public interface IBlackJackPlayer
    {
        event EventHandler<EventArgs> Hit;

        event EventHandler<CardHandStickArgs> Stick;

        bool HasCurrentTurn { get; set; }

    }
}
