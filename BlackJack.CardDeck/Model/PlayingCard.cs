﻿using System.Windows.Forms;

namespace BlackJack.CardDeck.Model
{
    public class PlayingCard : PictureBox
    {
        public Suit Suit { get; private set; }

        public CardNumber CardNumber { get; private set; }


        public PlayingCard(Suit suit, CardNumber cardNumber)
        {
            Suit = suit;
            CardNumber = cardNumber;
            InitCardSize();
        }

        private void InitCardSize()
        {
            Width = 71;
            Height = 96;
        }
        
        public string GetResourceImageName()
        {
            return string.Format("{0}_{1}", 
                Suit, CardNumber);
        }

        public override string ToString()
        {
            return string.Format("[{0}] Suit: {1} CardNumber: {2}",
                GetType().Name, Suit, CardNumber);
        }
    }
}
