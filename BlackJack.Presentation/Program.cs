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
            
            var cdg = new CardDeckGenerator(new CardSuitGenerator(), new CardImageMapper(new ResourceHandler()));
            ICardShoe cardShoe = new CardShoe(cdg, new GuidShuffler<PlayingCard>());
            var player = new Player();
            var dealer = new Dealer(cardShoe);
            dealer.RegisterNewPlayer(player);
                       
            Application.Run(new GameTable(dealer, player, cardShoe));
        }
    }
}
