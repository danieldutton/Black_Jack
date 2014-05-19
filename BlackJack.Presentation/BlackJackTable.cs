using BlackJack.CardDeck.Model;
using BlackJack.Players;
using BlackJack.Players.Interfaces;
using BlackJack.Table;
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

            DisplayHand(dealersStartingHand, _panelDealersCards);
            DisplayHand(playersStartingHand, _panelPlayersCards);

            UpdateScore(_dealer, dealersStartingHand);
            UpdateScore(_player, playersStartingHand);

            _dealer.FinishPlay(_cardShoe, _cardScorer);
        }

        private void DisplayHand(IEnumerable<PlayingCard> playingCards, Panel cardPanel)
        {
            foreach (PlayingCard playingCard in playingCards)
            {
                playingCard.Location = new Point(_cardXPos, 0);

                cardPanel.Controls.Add(playingCard);
                cardPanel.Controls.SetChildIndex(playingCard, 0);
                _cardXPos += 40;                
            }
            _cardXPos = 0;
        }

        private void UpdateScore(ICardPlayer player, IEnumerable<PlayingCard> playingCards)
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
        }

        private void DealNewCard_Player()
        {
            PlayingCard playingCard = _cardShoe.GetNextPlayingCard();
            var cardList = new List<PlayingCard>{playingCard};
            
            DisplayHand(cardList, _panelPlayersCards);            
            UpdateScore(_player, cardList);
            Determine_Winner();
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {           
            Determine_Winner();
        }
        
        //can this be moved into point scorer
        private void Determine_Winner()
        {
            int dealersScore = _dealer.CurrentScore;
            int playersScore = _player.CurrentScore;

            if (PlayerAndDealerAreBust())
                DisplayGameResults(dealersScore, playersScore, "Both Bust!");

            else if (_dealer.IsBust(dealersScore))
                DisplayGameResults(dealersScore, playersScore, "Dealer Bust! Player Wins."); //check if player wins

            else if (_player.IsBust(playersScore))
                DisplayGameResults(dealersScore, playersScore, "Player Bust! Dealer Wins.");

            else if (PlayerAndDealerAreDrawn())
                DisplayGameResults(dealersScore, playersScore, "Dealer and Player draw!");
            else
            {
                //compare the final scores
                string text = playersScore > dealersScore ? "Player Wins:" + playersScore : "DealerWins:" + dealersScore;
                DisplayGameResults(dealersScore, playersScore, text);
            }

            DisplayHand(_dealer.CurrentHand, _panelDealersCards);
            DisplayHand(_player.CurrentHand, _panelPlayersCards);
            
            _dealer.DisposeOfCurrentHand();
            _player.DisposeOfCurrentHand();
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