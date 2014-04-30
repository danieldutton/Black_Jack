using System;
using System.Drawing;
using System.Windows.Forms;
using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;
using System.Collections.Generic;

namespace BlackJack.Table
{
    public class Player : ICardPlayer
    {
        public int CurrentScore { get; set; }

        public List<PlayingCard> CurrentHand { get; set; }

        public event EventHandler<PlayerSticksEventArg> Sticks;

        private int _cardXPos;


        public Player()
        {
            CurrentHand = new List<PlayingCard>();   
        }

        public void Hit(PlayingCard card, Panel panel)
        {
            _cardXPos += 80;

            card.Location = new Point(_cardXPos, 0);
            panel.Controls.Add(card);
            _cardXPos += 40;

            int cardValue = CardPointScorer.GetPlayingCardValue(card);
            CurrentScore += cardValue;

            CurrentHand.Add(card);
            //_lblPlayerScore.Text = _player.CurrentScore.ToString();
        }

        public bool IsBust(int score)
        {
            return score > 21;
        }

        public virtual void OnSticks(PlayerSticksEventArg e)
        {
            EventHandler<PlayerSticksEventArg> handler = Sticks;
            if (handler != null) handler(this, e);
        }
    }
}
