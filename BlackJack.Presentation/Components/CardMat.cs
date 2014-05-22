using BlackJack.CardDeck.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack.Presentation.Components
{
    public sealed class CardMat : Panel
    {
        public int LastCardPositionX { get; set; }

        public CardMat()
        {
            Width = 493;
            Height = 110;
        }

        public CardMat(Point location)
            :this()
        {
            Location = location;
        }

        public void AddPlayingCard(PlayingCard playingCard)
        {
            if(playingCard == null) throw new ArgumentNullException("playingCard");
            
            playingCard.Location = new Point(LastCardPositionX, 0);
            
            Controls.Add(playingCard);
            Controls.SetChildIndex(playingCard, 0);
            
            LastCardPositionX += 40;
        }

        public void Clear()
        {
            LastCardPositionX = 0;
            Controls.Clear();
        }

        public override string ToString()
        {
            return string.Format("[{0}] Width:{1} Height:{2}",
                GetType().Name, Width, Height);
        }
    }
}
