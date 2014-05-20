using BlackJack.CardDeck.Model;
using BlackJack.Players;
using BlackJack.Players.Interfaces;
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

        private readonly Player _player;

        private readonly ICardShoe _cardShoe;
        
        private readonly ICardScorer _cardScorer;

        private int _cardXPos;


        internal BlackJackTable(Dealer dealer, Player player, 
            ICardShoe cardShoe, ICardScorer cardScorer)
        {
            _dealer = dealer;
            _player = player;
            _cardShoe = cardShoe;
            _cardScorer = cardScorer;

            InitializeComponent();
        }

        private void StartGame_Click(object sender, EventArgs e)
        {
            List<PlayingCard> dealersStartingHand = _cardShoe.GetStartingHand();
            List<PlayingCard> playersStartingHand = _cardShoe.GetStartingHand();

            DisplayCardHand(dealersStartingHand, _panelDealersCards);
            DisplayCardHand(playersStartingHand, _panelPlayersCards);

            UpdatePointsScore(_dealer, dealersStartingHand);
            UpdatePointsScore(_player, playersStartingHand);

            _dealer.FinishPlay(_cardShoe, _cardScorer);
        }

        private void DisplayCardHand(IEnumerable<PlayingCard> playingCards, Panel cardPanel)
        {
            _cardXPos = 0;

            foreach (PlayingCard playingCard in playingCards)
            {
                playingCard.Location = new Point(_cardXPos, 0);
                cardPanel.Controls.Add(playingCard);
                cardPanel.Controls.SetChildIndex(playingCard, 0);
                
                _cardXPos += 40;                
            }            
        }

        private void UpdatePointsScore(ICardPlayer player, IEnumerable<PlayingCard> playingCards)
        {
            player.CurrentScore = 0;
            
            foreach (var playingCard in playingCards)
            {
                int cardValue = _cardScorer.GetPlayingCardValue(playingCard);
               
                player.CurrentScore += cardValue;
            }            
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            DealNewCard_Player();
            DisplayCardHand(_player.CurrentHand, _panelPlayersCards);
            UpdatePointsScore(_player, _player.CurrentHand);
            
            Determine_Winner(); //problem here win being calculated when hand not complete
        }

        private void DealNewCard_Player()
        {
            PlayingCard playingCard = _cardShoe.GetNextPlayingCard();
            
            _player.CurrentHand.Add(playingCard);   
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {           
            Determine_Winner();

            DisplayCardHand(_dealer.CurrentHand, _panelDealersCards);
            DisplayCardHand(_player.CurrentHand, _panelPlayersCards);

            _dealer.DisposeOfCurrentHand();
            _player.DisposeOfCurrentHand();
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

        private void ExitApplication_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}