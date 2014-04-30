using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Table.Interfaces;
using BlackJack.Utility;
using BlackJack.Utility.Interfaces;
using System;
using System.Windows.Forms;

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
            
            //ResourceHandler
            IResourceHandler resourceHandler = new ResourceHandler();

            //CardDeckGenerator
            ICardSuitGenerator cardSuitGenerator = new CardSuitGenerator();
            ICardImageMapper<PlayingCard> cardImageMapper = new CardImageMapper(resourceHandler);
            var cardDeckGenerator = new CardDeckGenerator(cardSuitGenerator, cardImageMapper);

            //Shuffle Strategy
            IShuffler<PlayingCard> guidShuffler = new GuidShuffler<PlayingCard>();

            //Card Shoe
            ICardShoe cardShoe = new CardShoe(cardDeckGenerator, guidShuffler);
            cardShoe.InitialiseNewCardDeck();
            
            //Game Players
            var player = new Player();
            var dealer = new Dealer(cardShoe);
            
            dealer.RegisterNewPlayer(player);
               
            //Launch Form
            Application.Run(new GameTable(dealer, player, cardShoe));
        }
    }
}
