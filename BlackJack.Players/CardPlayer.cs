using BlackJack.CardDeck.Model;
using System.Collections.Generic;

namespace BlackJack.Players
{
    public class CardPlayer
    {
        public int CurrentScore { get; set; }

        public List<PlayingCard> CurrentHand { get; set; }


        public CardPlayer()
        {
            CurrentHand = new List<PlayingCard>();
        }

        public bool IsBust()
        {
            return CurrentScore > 21;
        }

        public void DisposeOfHand()
        {
            CurrentScore = 0;
            CurrentHand.Clear();
        }

    }
}
