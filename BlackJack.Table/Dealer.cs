using BlackJack.Table.Interfaces;

namespace BlackJack.Table
{
    public class Dealer
    {
        //if dealer has 17 or above but less or equal to 21 then stick
        //else hit
        private ICardShoe _cardShoe;

        public Dealer(ICardShoe cardShoe)
        {
            _cardShoe = cardShoe;
        }
    }
}
