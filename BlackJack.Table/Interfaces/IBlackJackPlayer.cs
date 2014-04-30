using BlackJack.Table.EventArgs;
using System;

namespace BlackJack.Table.Interfaces
{
    public interface IBlackJackPlayer : ICardPlayer
    {
        event EventHandler<PlayerSticksEventArg> Stick; 

        bool IsBust(int score);
    }
}
