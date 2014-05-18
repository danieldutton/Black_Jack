namespace BlackJack.Players.EventArg
{
    public class GameOverEventArgs : System.EventArgs
    {
        public int DealersScore { get; private set; }

        public int PlayersScore { get; private set; }

        public string StatusMessage { get; private set; }

        public GameOverEventArgs(int dealersScore, int playersScore, string statusMessage)
        {
            DealersScore = dealersScore;
            PlayersScore = playersScore;
            StatusMessage = statusMessage;
        }
    }
}
