using BlackJack.CardDeck;
using BlackJack.CardDeck.Interfaces;
using BlackJack.CardDeck.Model;
using BlackJack.Players;
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
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            IResourceHandler resourceHandler = new ResourceHandler();

            //Construct the card deck builder
            ICardSuitBuilder cardSuitBuilder = new CardSuitBuilder();
            ICardImageMapper<PlayingCard> cardImageMapper = new CardImageMapper(resourceHandler);
            ICardDeckBuilder cardDeckBuilder = new CardDeckBuilder(cardSuitBuilder, cardImageMapper);

            //Shuffle Strategy
            IShuffler<PlayingCard> guidShuffler = new GuidShuffler<PlayingCard>();

            //Card Shoe
            ICardShoe cardShoe = new CardShoe(cardDeckBuilder, guidShuffler);
            
            //Game Players
            var player = new CardPlayer();
            var dealer = new Dealer();
             
            //Launch Form
            Application.Run(new BlackJackTable(dealer, player, cardShoe));
        }
    }
}
