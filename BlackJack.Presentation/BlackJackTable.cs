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
        
        private readonly IBlackJackScorer _cardScorer;

        private CardMat _dealersMat;

        private CardMat _playersMat;


        internal BlackJackTable(Dealer dealer, CardPlayer player, 
            ICardShoe cardShoe, IBlackJackScorer cardScorer)
        {
            _dealer = dealer;
            _player = player;
            _cardShoe = cardShoe;
            _cardScorer = cardScorer;

            InitializeComponent();
            InitialiseAndDisplayCardMats();
            DisableHitAndStickButtons();
        }

        private void InitialiseAndDisplayCardMats()
        {
            _dealersMat = new CardMat(matLocation:new Point(5, 80));
            _playersMat = new CardMat(matLocation:new Point(5, 190));

            Controls.Add(_dealersMat);
            Controls.Add(_playersMat);
        }

        private void DisableHitAndStickButtons()
        {
            _btnHit.Enabled = false;
            _btnStick.Enabled = false;
        }
        
        private void StartNewGame_Click(object sender, EventArgs e)
        {
            RemoveCardsInPlay();
            ResetGameScoreLabels();
            EnableHitAndStickButtons();
            DealStartingHands();

            _dealer.Play(_cardShoe, _cardScorer);            
        }

        private void RemoveCardsInPlay()
        {
            _dealer.DisposeOfHand();
            _player.DisposeOfHand();

            _dealersMat.Clear();
            _playersMat.Clear();
        }

        private void ResetGameScoreLabels()
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

        private void DealStartingHands()
        {
            List<PlayingCard> dealersStartingHand = _cardShoe.GetStartingHand();
            List<PlayingCard> playersStartingHand = _cardShoe.GetStartingHand();

            _dealer.CurrentHand = dealersStartingHand;
            _player.CurrentHand = playersStartingHand;

            AddCardsToMat(_player.CurrentHand, _playersMat);
            AddCardsToMat(_dealer.CurrentHand, _dealersMat);
        }

        private void AddCardsToMat(IEnumerable<PlayingCard> playingCards, CardMat cardMat)
        {               
            foreach (PlayingCard playingCard in playingCards)
                cardMat.PlaceCard(playingCard);              
            
            cardMat.LastCardXPosition = 0;
        }

        private void SumCardScores(CardPlayer player)
        {
            player.CurrentScore = _cardScorer.GetCardHandValue(player.CurrentHand);        
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            DealNewCard_Player();                                              
            SumCardScores(_player);

            if (_player.IsBust())
                Determine_Winner();                             
        }

        private void DealNewCard_Player()
        {
            PlayingCard playingCard = _cardShoe.GetPlayingCard();
            
            _player.CurrentHand.Add(playingCard);
            AddCardsToMat(_player.CurrentHand, _playersMat);
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {     
            SumCardScores(_player);
            Determine_Winner();
            DisableHitAndStickButtons();            
        }

        private void Determine_Winner()
        {
            int dealersScore = _dealer.CurrentScore;
            int playersScore = _player.CurrentScore;

            AddCardsToMat(_dealer.CurrentHand, _dealersMat);
            
            if (_player.IsBust() && _dealer.IsBust())
                DisplayGameResults(dealersScore, playersScore, "Both Bust");

            else if (_dealer.IsBust())
                DisplayGameResults(dealersScore, playersScore, "Player Wins");

            else if (_player.IsBust())
                DisplayGameResults(dealersScore, playersScore, "Dealer Wins");

            else if (_cardScorer.PlayersDrawn(playersScore, dealersScore))
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