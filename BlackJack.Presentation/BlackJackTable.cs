﻿using BlackJack.CardDeck.Model;
using BlackJack.Players.Interfaces;
using BlackJack.Presentation.Components;
using BlackJack.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack.Presentation
{
    internal partial class BlackJackTable : Form
    {
        #region Instance vars

        private readonly IAutomatedCardPlayer _dealer;

        private readonly ICardPlayer _player;

        private readonly ICardShoe _cardShoe;
        
        private readonly ICardScorer _cardScorer;

        private CardMat _dealerCardMat;

        private CardMat _playerCardMat;

        #endregion

        #region Constructor

        internal BlackJackTable(IAutomatedCardPlayer dealer, ICardPlayer player, 
            ICardShoe cardShoe, ICardScorer cardScorer)
        {
            _dealer = dealer;
            _player = player;
            _cardShoe = cardShoe;
            _cardScorer = cardScorer;

            InitializeComponent();
            InitCardMats();
            DisablePlayButtons();
        }

        #endregion

        private void InitCardMats()
        {
            _dealerCardMat = new CardMat(location:new Point(6, 3));
            _playerCardMat = new CardMat(location:new Point(5, 132));

            Controls.Add(_dealerCardMat);
            Controls.Add(_playerCardMat);
        }

        private void DisablePlayButtons()
        {
            _btnHit.Enabled = false;
            _btnStick.Enabled = false;
        }
        
        private void StartNewGame_Click(object sender, EventArgs e)
        {
            ResetGame();
            ClearGameLabels();
            EnablePlayButtons();

            List<PlayingCard> dealersStartingHand = _cardShoe.GetStartingHand();
            List<PlayingCard> playersStartingHand = _cardShoe.GetStartingHand();

            DisplayCardHand(dealersStartingHand, _dealerCardMat);
            DisplayCardHand(playersStartingHand, _playerCardMat);

            UpdatePlayerScores(_dealer, dealersStartingHand);
            UpdatePlayerScores(_player, playersStartingHand);

            _dealer.FinishPlay(_cardShoe, _cardScorer);
        }

        private void ResetGame()
        {
            _dealer.DisposeOfCurrentHand();
            _player.DisposeOfCurrentHand();
            
            _dealerCardMat.Reset();
            _playerCardMat.Reset();
        }

        private void ClearGameLabels()
        {
            _lblDealersScore.Text = string.Empty;
            _lblPlayersScore.Text = string.Empty;
            _lblStatus.Text = string.Empty;
        }

        private void EnablePlayButtons()
        {
            _btnHit.Enabled = true;
            _btnStick.Enabled = true;
        }

        private void DisplayCardHand(IEnumerable<PlayingCard> playingCards, CardMat cardMat)
        {            
            foreach (PlayingCard playingCard in playingCards)
            {
                cardMat.AddPlayingCard(playingCard);
            }            
        }

        private void UpdatePlayerScores(ICardPlayer player, IEnumerable<PlayingCard> playingCards)
        {           
            foreach (var playingCard in playingCards)
            {
                int cardValue = _cardScorer.GetPlayingCardValue(playingCard);
               
                player.CurrentScore += cardValue;
            }            
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            DealNewCard_Player();
            DisplayCardHand(_player.CurrentHand, _playerCardMat);
            UpdatePlayerScores(_player, _player.CurrentHand);

            if(_player.IsBust(_player.CurrentScore))
                Determine_Winner();
        }

        private void DealNewCard_Player()
        {
            PlayingCard playingCard = _cardShoe.GetNextPlayingCard();
            
            _player.CurrentHand.Add(playingCard);   
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {           
            Determine_Winner();

            DisplayCardHand(_dealer.CurrentHand, _dealerCardMat);
            DisplayCardHand(_player.CurrentHand, _playerCardMat);

            _dealer.DisposeOfCurrentHand();
            _player.DisposeOfCurrentHand();

            DisablePlayButtons();
        }

        private void Determine_Winner()
        {
            int dealersScore = _dealer.CurrentScore;
            int playersScore = _player.CurrentScore;

            if (PlayerAndDealerAreBust())
                DisplayGameResults(dealersScore, playersScore, "Both Players Bust!");

            else if (_dealer.IsBust(dealersScore))
                DisplayGameResults(dealersScore, playersScore, "Dealer Bust! Player Wins.");

            else if (_player.IsBust(playersScore))
                DisplayGameResults(dealersScore, playersScore, "Player Bust! Dealer Wins.");

            else if (PlayerAndDealerAreDrawn())
                DisplayGameResults(dealersScore, playersScore, "Dealer and Player draw!");
            else
            {
                string text = playersScore > dealersScore ? "Player Wins:" + playersScore : "DealerWins:" + dealersScore;
                DisplayGameResults(dealersScore, playersScore, text);
            }  
        }

        private void DisplayGameResults(int dealerScore, int playerScore, string statusMessage)
        {
            _lblDealersScore.Text = dealerScore.ToString();
            _lblPlayersScore.Text = playerScore.ToString();
            _lblStatus.Text = statusMessage;
        }

        private bool PlayerAndDealerAreBust()
        {
            return _player.IsBust(_player.CurrentScore) && _dealer.IsBust(_dealer.CurrentScore);
        }

        private bool PlayerAndDealerAreDrawn()
        {
            return _player.CurrentScore == _dealer.CurrentScore;
        }
    }
}