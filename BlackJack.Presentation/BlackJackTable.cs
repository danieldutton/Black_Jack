using BlackJack.CardDeck.Model;
using BlackJack.Players;
using BlackJack.Players.EventArg;
using BlackJack.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BlackJack.Presentation
{
    internal partial class BlackJackTable : Form
    {
        private readonly Dealer _dealer;

        private readonly Player _player;

        private readonly ICardShoe _cardShoe;


        internal BlackJackTable(Dealer dealer, Player player, ICardShoe cardShoe)
        {
            _dealer = dealer;
            _player = player;
            _cardShoe = cardShoe;

            InitializeComponent();
            RegisterForGameOverEvent();
        }

        private void RegisterForGameOverEvent()
        {
            _dealer.GameOver += OnGameOver;
        }
        
        private void DealCards_Click(object sender, EventArgs e)
        {
            List<PlayingCard> startingHand = _cardShoe.ReleaseStartingHands();

            List<PlayingCard> dealersCards = startingHand.Take(2).ToList();
            List<PlayingCard> playersCards = startingHand.Skip(2).Take(2).ToList();

            _dealer.DealStartingHand_Dealer(dealersCards, cardMatDealer);
            _dealer.DealStartingHand_Player(playersCards, cardMatPlayer, _player);

            _dealer.CompleteBlackJackHand_Dealer();
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            _player.OnHit(new PlayerTakesMoveArgs(_player, cardMatPlayer, cardMatDealer));
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {           
            _player.OnStick(new PlayerTakesMoveArgs(_player, cardMatPlayer, cardMatDealer));
        }

        private void OnGameOver(object sender, GameOverEventArgs e)
        {
            DisplayGameResults(e);                                   
        }

        private void DisplayGameResults(GameOverEventArgs e)
        {
            _lblDealersScore.Text = e.DealersScore.ToString();
            _lblPlayersScore.Text = e.PlayersScore.ToString();
            _lblStatus.Text = e.StatusMessage;    
        }

        private void ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}