using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BlackJack.Presentation
{
    public partial class GameTable : Form
    {
        private readonly Dealer _dealer;

        private readonly Player _player;

        private readonly ICardShoe _cardShoe;


        public GameTable(Dealer dealer, Player player, ICardShoe cardShoe)
        {
            _dealer = dealer;
            _player = player;
            _cardShoe = cardShoe;

            InitializeComponent();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            List<PlayingCard> startingHand = _cardShoe.ReleaseStartingHands();

            List<PlayingCard> dealersCards = startingHand.Take(2).ToList();
            List<PlayingCard> playersCards = startingHand.Skip(2).Take(2).ToList();

            _dealer.DealStartingHand_Dealer(dealersCards, _panelGameMatDealer);
            _dealer.DealStartingHand_Player(playersCards, _panelGameMatPlayer, _player);

            _dealer.CompleteGameHand();
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            PlayingCard newCard = _dealer.GetPlayingCard();            
            _player.Hit(newCard, _panelGameMatPlayer);
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {           
            _player.OnSticks(new PlayerSticksEventArg(_player, _panelGameMatPlayer, _panelGameMatDealer));
        }

        private void ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}