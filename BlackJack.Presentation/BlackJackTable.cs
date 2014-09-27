using BlackJack.CardDeck.Model;
using BlackJack.Players;
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
        private readonly Dealer _dealer;

        private readonly CardPlayer _player;

        private readonly ICardShoe _cardShoe;
        
        private CardMat _dealersMat;

        private CardMat _playersMat;


        internal BlackJackTable(Dealer dealer, CardPlayer player, 
            ICardShoe cardShoe)
        {
            _dealer = dealer;
            _player = player;
            _cardShoe = cardShoe;

            InitializeComponent();
            InitialiseCardMats();
            DisplayCardMats();
            DisableHitAndStickButtons();
        }

        private void InitialiseCardMats()
        {
            _dealersMat = new CardMat(matLocation: new Point(5, 80));
            _playersMat = new CardMat(matLocation: new Point(5, 190));    
        }

        private void DisplayCardMats()
        {
            Controls.Add(_dealersMat);
            Controls.Add(_playersMat);
        }

        private void DisableHitAndStickButtons()
        {
            _btnHit.Enabled = false;
            _btnStick.Enabled = false;
        }
        
        private void DealStartingHands_Click(object sender, EventArgs e)
        {
            RemovePreviousGameCards();
            RemovePreviousGameScores();
            EnableHitAndStickButtons();
            DisplayStartingHands();

            _dealer.Play(_cardShoe);            
        }

        private void RemovePreviousGameCards()
        {
            _dealer.DisposeHand();
            _player.DisposeHand();

            _dealersMat.Clear();
            _playersMat.Clear();
        }

        private void RemovePreviousGameScores()
        {
            const string defaultText = "--";

            _lblDealersScore.Text = defaultText;
            _lblPlayersScore.Text = defaultText;

            _lblStatus.Text = defaultText;
        }

        private void EnableHitAndStickButtons()
        {
            _btnHit.Enabled = true;
            _btnStick.Enabled = true;
        }

        private void DisplayStartingHands()
        {
            List<PlayingCard> dealersStartingHand = _cardShoe.GetStartingHand();
            List<PlayingCard> playersStartingHand = _cardShoe.GetStartingHand();

            _dealer.AddCardToHand(dealersStartingHand[0]);
            _dealer.AddCardToHand(dealersStartingHand[1]);

            _player.AddCardToHand(playersStartingHand[0]);
            _player.AddCardToHand(playersStartingHand[1]);

            AddCardsToMat(_player.CurrentHand, _playersMat);
            AddCardsToMat(_dealer.CurrentHand, _dealersMat);
        }

        private void AddCardsToMat(IEnumerable<PlayingCard> playingCards, CardMat cardMat)
        {               
            foreach (PlayingCard playingCard in playingCards)
                cardMat.PlaceCard(playingCard);              
            
            cardMat.LastCardXPosition = 0;
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            DealNewCard_Player();                                              

            if (_player.IsBust())
                Determine_Winner();                             
        }

        private void DealNewCard_Player()
        {
            PlayingCard playingCard = _cardShoe.GetPlayingCard();
            
            _player.AddCardToHand(playingCard);
            AddCardsToMat(_player.CurrentHand, _playersMat);
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {     
            Determine_Winner();
            DisableHitAndStickButtons();            
        }

        private void Determine_Winner()
        {
            int dealersScore = _dealer.CurrentScore;
            int playersScore = _player.CurrentScore;

            RevealDealersHand();
            
            if (_player.IsBust() && _dealer.IsBust())
                DisplayGameResults(dealersScore, playersScore, "Both Bust");

            else if (_dealer.IsBust())
                DisplayGameResults(dealersScore, playersScore, "Player Wins");

            else if (_player.IsBust())
                DisplayGameResults(dealersScore, playersScore, "Dealer Wins");

            else if(_player.HasBlackJack() && _dealer.CurrentScore == 21)
                DisplayGameResults(dealersScore, playersScore, "BlackJack - Player Wins");

            else if (_dealer.HasBlackJack() && _player.CurrentScore == 21)
                DisplayGameResults(dealersScore, playersScore, "BlackJack - Dealer Wins");

            else if (_player.ScoresTied(dealersScore))
                DisplayGameResults(dealersScore, playersScore, "Push");
            else
            {
                string text = playersScore > dealersScore ? "Player Wins: " : "DealerWins: ";
                DisplayGameResults(dealersScore, playersScore, text);
            } 

            DisableHitAndStickButtons();
        }

        private void RevealDealersHand()
        {
            AddCardsToMat(_dealer.CurrentHand, _dealersMat);    
        }

        private void DisplayGameResults(int dealerScore, int playerScore, string statusMessage)
        {
            _lblDealersScore.Text = dealerScore.ToString();
            _lblPlayersScore.Text = playerScore.ToString();
            
            _lblStatus.Text = statusMessage;
        }        
    }
}