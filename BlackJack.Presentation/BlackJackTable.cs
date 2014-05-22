using BlackJack.CardDeck.Model;
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
            DisplayCardMats();
            DisableHitAndStickButtons();
        }

        #endregion

        private void InitCardMats()
        {
            _dealerCardMat = new CardMat(location:new Point(5, 80));
            _playerCardMat = new CardMat(location:new Point(5, 190));            
        }

        private void DisplayCardMats()
        {
            Controls.Add(_dealerCardMat);
            Controls.Add(_playerCardMat);   
        }

        private void DisableHitAndStickButtons()
        {
            _btnHit.Enabled = false;
            _btnStick.Enabled = false;
        }
        
        private void StartNewGame_Click(object sender, EventArgs e)
        {
            ClearPriorGame();
            ClearPriorResultLabels();
            EnablePlayButtons();
            DealStartingHands();

            _dealer.FinishPlay(_cardShoe, _cardScorer);
        }

        private void ClearPriorGame()
        {
            _dealer.DisposeOfCurrentHand();
            _player.DisposeOfCurrentHand();

            _dealerCardMat.Clear();
            _playerCardMat.Clear();
        }

        private void ClearPriorResultLabels()
        {
            const string defaultText = "0";

            _lblDealersScore.Text = defaultText;
            _lblPlayersScore.Text = defaultText;
            
            _lblStatus.Text = "--";
        }

        private void EnablePlayButtons()
        {
            _btnHit.Enabled = true;
            _btnStick.Enabled = true;
        }

        private void DealStartingHands()
        {
            List<PlayingCard> dealersStartingHand = _cardShoe.GetStartingHand();
            List<PlayingCard> playersStartingHand = _cardShoe.GetStartingHand();

            _dealer.CurrentHand = dealersStartingHand;
            _player.CurrentHand = playersStartingHand;

            ScorePlayersCurrentHand(_dealer);

            AddCardsToMat(_dealer.CurrentHand, _dealerCardMat);
            AddCardsToMat(_player.CurrentHand, _playerCardMat);   
        }

        private void AddCardsToMat(IEnumerable<PlayingCard> playingCards, CardMat cardMat)
        {               
            foreach (PlayingCard playingCard in playingCards)
                cardMat.AddPlayingCard(playingCard);              
            
            cardMat.LastCardPositionX = 0;
        }

        private void ScorePlayersCurrentHand(ICardPlayer player)
        {
            player.CurrentScore = _cardScorer.GetCardHandValue(player.CurrentHand);        
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            DealNewCard_Player();            
            
            AddCardsToMat(_player.CurrentHand, _playerCardMat);           
            ScorePlayersCurrentHand(_player);

            if (_cardScorer.IsBust(_player.CurrentScore))
            {
                ScorePlayersCurrentHand(_dealer);
                Determine_Winner();
            }                
        }

        private void DealNewCard_Player()
        {
            PlayingCard playingCard = _cardShoe.TakeSinglePlayingCard();
            
            _player.CurrentHand.Add(playingCard);   
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {     
            ScorePlayersCurrentHand(_player);
            Determine_Winner();

            AddCardsToMat(_dealer.CurrentHand, _dealerCardMat);

            DisableHitAndStickButtons();            
        }

        private void Determine_Winner()
        {
            int dealersScore = _dealer.CurrentScore;
            int playersScore = _player.CurrentScore;
            
            if (_cardScorer.BothPlayersAreBust(playersScore, dealersScore))
                DisplayGameResults(dealersScore, playersScore, "Both Bust");

            else if (_cardScorer.IsBust(dealersScore))
                DisplayGameResults(dealersScore, playersScore, "Player Wins");

            else if (_cardScorer.IsBust(playersScore))
                DisplayGameResults(dealersScore, playersScore, "Dealer Wins");

            else if (_cardScorer.PlayersAreDrawn(playersScore, dealersScore))
                DisplayGameResults(dealersScore, playersScore, "Push");
            else
            {
                string text = playersScore > dealersScore ? "Player Wins: " : "DealerWins: ";
                DisplayGameResults(dealersScore, playersScore, text);
            } 
            DisableHitAndStickButtons();
        }

        private void DisplayGameResults(int dealerScore, int playerScore, string statusMessage)
        {
            _lblDealersScore.Text = dealerScore.ToString();
            _lblPlayersScore.Text = playerScore.ToString();
            
            _lblStatus.Text = statusMessage;
        }        
    }
}