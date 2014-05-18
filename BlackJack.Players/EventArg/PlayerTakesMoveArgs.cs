using System.Windows.Forms;

namespace BlackJack.Players.EventArg
{
    public class PlayerTakesMoveArgs : System.EventArgs
    {
        public Player Player { get; private set; }

        public Panel CardMatPlayer { get; private set; }

        public Panel CardMatDealer { get; private set; }

        public PlayerTakesMoveArgs(Player player, Panel cardMatPlayer, Panel cardMatDealer)
        {
            Player = player;
            CardMatPlayer = cardMatPlayer;
            CardMatDealer = cardMatDealer;
        }
    }
}
