using System;
using System.Windows.Forms;

namespace BlackJack.Table
{
    public sealed class PlayerSticksEventArg : EventArgs
    {
        public Player Player { get; private set; }

        public Panel GameMatPlayer { get; private set; }

        public Panel GameMatDealer { get; private set; }

        public PlayerSticksEventArg(Player player, Panel gameMatPlayer, Panel gameMatDealer)
        {
            Player = player;
            GameMatPlayer = gameMatPlayer;
            GameMatDealer = gameMatDealer;
        }
    }
}
