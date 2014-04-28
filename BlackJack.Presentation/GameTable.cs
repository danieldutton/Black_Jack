using System;
using System.Linq;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack.Presentation
{
    public partial class GameTable : Form
    {
        private readonly Dealer _dealer;

        private int _x;

        private int _y;

        private int _total;

        public GameTable(Dealer dealer)
        {
            _dealer = dealer;
            InitializeComponent();
        }

        private void StartingDeal_Click(object sender, EventArgs e)
        {
            List<PlayingCard> startCards = _dealer.DealStartingCards();

            List<PlayingCard> dealersCards = startCards.Take(2).ToList();
            dealersCards.ForEach(x =>
            {
                int i = 0;
                x.Location= new Point(_x, _y);
                _panelDealersHand.Controls.Add(dealersCards[i]);
                i += 1;
                _x += 50;
            });

            _x = 0;

            List<PlayingCard> playersCards = startCards.Skip(2).Take(2).ToList();
            dealersCards.ForEach(x =>
            {
                int i = 0;
                x.Location = new Point(_x, _y);
                _panelPlayersHand.Controls.Add(playersCards[i]);
                i += 1;
                _x += 50;
            });

        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            PlayingCard result = _dealer.InitialDeal(); //two cards each

            result.Location = new Point(_x, _y);
            result.BringToFront();
            _total += (int)result.CardNumber;
            _panelPlayersHand.Controls.Add(result);
            _x += 50;
            if (_total > 21) MessageBox.Show("Bust");
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {
            //get dealers score

            //get players score

            //compare the two

            //declare who wins
        }

    }
}
