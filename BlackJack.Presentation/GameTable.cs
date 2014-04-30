﻿using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Table.EventArgs;
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

            _dealer.DealStartingHand_Dealer(dealersCards, cardMatDealer);
            _dealer.DealStartingHand_Player(playersCards, cardMatPlayer, _player);

            _dealer.PlayGame();

            _btnStartGame.Enabled = false;
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            _dealer.Hit(cardMatPlayer);
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {           
            _player.OnStick(new PlayerSticksEventArg(_player, cardMatPlayer, cardMatDealer));
        }

        private void ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}