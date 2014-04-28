using System;
using System.Collections.Generic;
using BlackJack.CardDeck.Model;
using BlackJack.Table.EventArg;
using BlackJack.Table.Interfaces;

namespace BlackJack.Table
{
    public class Dealer : IBlackJackPlayer
    {
        private readonly ICardShoe _cardShoe;
        //if dealer has 17 or above but less or equal to 21 then stick
        //else hit
        public event EventHandler<EventArgs> Hit;

        public event EventHandler<CardHandStickArgs> Stick;

        public IEnumerable<PlayingCard> CurrentHand { get; set; }

        public int CurrentScore { get; set; }

        public Dealer(ICardShoe cardShoe)
        {
            _cardShoe = cardShoe;
        }

        public List<PlayingCard> DealStartingCards()
        {
            const int startingCardCount = 4;

            var startCards = new List<PlayingCard>();

            for (int i = 0; i < startingCardCount; i++)
            {
                startCards.Add(_cardShoe.ReleasePlayingCard());
            }
            return startCards;
        } 

        public PlayingCard InitialDeal()
        {
            return _cardShoe.ReleasePlayingCard();
        } 


        public bool HasCurrentTurn { get; set; }
    }
}
