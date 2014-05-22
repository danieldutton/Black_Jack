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
            DisablePlayButtons();
        }

        #endregion

        private void InitCardMats()
        {
            _dealerCardMat = new CardMat(location:new Point(5, 80));
            _playerCardMat = new CardMat(location:new Point(5, 190));

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

            AddCardsToMat(dealersStartingHand, _dealerCardMat);
            AddCardsToMat(playersStartingHand, _playerCardMat);

            _dealer.CurrentHand = dealersStartingHand;
            _player.CurrentHand = playersStartingHand;

            ScoreCurrentlyHeldCards(_dealer, dealersStartingHand);
            ScoreCurrentlyHeldCards(_player, playersStartingHand);

            _dealer.FinishPlay(_cardShoe, _cardScorer);
        }

        private void ResetGame()
        {
            _dealer.DisposeOfCurrentHand();
            _player.DisposeOfCurrentHand();
            
            _dealerCardMat.Clear();
            _playerCardMat.Clear();
        }

        private void ClearGameLabels()
        {
            const string DefaultText = "0";

            _lblDealersScore.Text = DefaultText;
            _lblPlayersScore.Text = DefaultText;
            _lblStatus.Text = "--";
        }

        private void EnablePlayButtons()
        {
            _btnHit.Enabled = true;
            _btnStick.Enabled = true;
        }

        private void AddCardsToMat(IEnumerable<PlayingCard> playingCards, CardMat cardMat)
        {               
            foreach (PlayingCard playingCard in playingCards)
            {
                cardMat.AddPlayingCard(playingCard);              
            }
            cardMat.LastCardPositionX = 0;
        }

        private void ScoreCurrentlyHeldCards(ICardPlayer player, IEnumerable<PlayingCard> playingCards)
        {
            //basically the players hand is updated after the intial deal but after that
            //the initial deal cards vanish and it just counts the last cards dealt on a hit

            int cardValue = _cardScorer.GetCardHandValue(playingCards);
               
            player.CurrentScore = cardValue;
           
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            DealNewCard_Player();
            
            AddCardsToMat(_player.CurrentHand, _playerCardMat);
            
            ScoreCurrentlyHeldCards(_player, _player.CurrentHand);

            if (_cardScorer.IsBust(_player.CurrentScore))
            {
                AddCardsToMat(_dealer.CurrentHand, _dealerCardMat);
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
            Determine_Winner();

            AddCardsToMat(_dealer.CurrentHand, _dealerCardMat);
            AddCardsToMat(_player.CurrentHand, _playerCardMat);

            DisablePlayButtons();
        }

        private void Determine_Winner()
        {
            int dealersScore = _dealer.CurrentScore;
            int playersScore = _player.CurrentScore;
            
            if (_cardScorer.BothPlayersAreBust(playersScore, dealersScore))
                DisplayGameResults(dealersScore, playersScore, "Both Players Bust!");

            else if (_cardScorer.IsBust(dealersScore))
                DisplayGameResults(dealersScore, playersScore, "Dealer Bust! Player Wins.");

            else if (_cardScorer.IsBust(playersScore))
                DisplayGameResults(dealersScore, playersScore, "Player Bust! Dealer Wins.");

            else if (_cardScorer.BothPlayersAreDrawn(playersScore, dealersScore))
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
    }
}