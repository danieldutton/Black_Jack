using System;
using System.Windows.Forms;
using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Table.Interfaces;
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
            
            CardDeckGenerator cdg = new CardDeckGenerator(new CardSuitGenerator(), new CardImageMapper(new ResourceHandler()));
            ICardShoe cardShoe = new CardShoe(cdg, new GuidShuffler<PlayingCard>());
            Dealer dealer = new Dealer();
            Player player = new Player();
            Application.Run(new GameTable(dealer, player, cardShoe));
        }
    }
}
