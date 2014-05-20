﻿using BlackJack.CardDeck.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack.Presentation.Components
{
    public sealed class CardMat : Panel
    {
        public int CardXPosition { get; set; }

        public CardMat(){            
        }

        public CardMat(Point location)
        {
            Location = location;
            InitProperties();
        }

        private void InitProperties()
        {
            Width = 493;
            Height = 130;
        }

        public void AddPlayingCard(PlayingCard playingCard)
        {
            if(playingCard == null) throw new ArgumentNullException("playingCard");
            
            playingCard.Location = new Point(CardXPosition, 0);
            
            Controls.Add(playingCard);
            Controls.SetChildIndex(playingCard, 0);
            
            CardXPosition += 40;
        }

        public void Reset()
        {
            CardXPosition = 0;
            Controls.Clear();
        }

        public override string ToString()
        {
            return string.Format("[{0}] Width:{1} Height:{2}",
                GetType().Name, Width, Height);
        }
    }
}