using System.Windows.Forms;

namespace BlackJack.Table.EventArgs
{
    public sealed class PlayerSticksEventArg : System.EventArgs
    {
        public Player Player { get; private set; }

        public Panel CardMatPlayer { get; private set; }

        public Panel CardMatDealer { get; private set; }

        public PlayerSticksEventArg(Player player, Panel cardMatPlayer, Panel cardMatDealer)
        {
            Player = player;
            CardMatPlayer = cardMatPlayer;
            CardMatDealer = cardMatDealer;
        }
    }
}
