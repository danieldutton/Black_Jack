using BlackJack.CardDeck.Model;
using BlackJack.Players.Interfaces;
using BlackJack.Table.Interfaces;

namespace BlackJack.Players
{
    public class AutomatedHand
    {
        private readonly ICardShoe _cardShoe;
        
        private readonly ICardScorer _cardScorer;

        public AutomatedHand(ICardShoe cardShoe, ICardScorer cardScorer)
        {
            _cardShoe = cardShoe;
            _cardScorer = cardScorer;
        }

        //feature envy this should be in the player class
        
    }
}
