using System;
using System.Windows.Forms;
using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Utility;

namespace BlackJack.Presentation
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Dealer dealer = new Dealer(new CardShoe(new CardSuitBuilder(), new GuidShuffler<PlayingCard>()));
            Application.Run(new GameTable(dealer));
        }
    }
}
