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
        private readonly IAutomatedCardPlayer _dealer;

        private readonly ICardPlayer _player;

        private readonly ICardShoe _cardShoe;
        
        private readonly ICardScorer _cardScorer;

        private CardMat _dealersCardMat;

        private CardMat _playersCardMat;


        internal BlackJackTable(IAutomatedCardPlayer dealer, ICardPlayer player, 
            ICardShoe cardShoe, ICardScorer cardScorer)
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
            _dealersCardMat = new CardMat(location:new Point(5, 80));
            _playersCardMat = new CardMat(location:new Point(5, 190));

            Controls.Add(_dealersCardMat);
            Controls.Add(_playersCardMat);
        }

        private void DisableHitAndStickButtons()
        {
            _btnHit.Enabled = false;
            _btnStick.Enabled = false;
        }
        
        private void StartNewGame_Click(object sender, EventArgs e)
        {
            ResetToNewGame();
            ResetGameScoreLabels();
            EnableHitAndStickButtons();
            DealStartingHands();

            _dealer.FinishPlay(_cardShoe, _cardScorer);            
        }

        private void ResetToNewGame()
        {
            _dealer.DisposeOfCurrentHand();
            _player.DisposeOfCurrentHand();

            _dealersCardMat.Clear();
            _playersCardMat.Clear();
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

            AddCardsToMat(_player.CurrentHand, _playersCardMat);
            AddCardsToMat(_dealer.CurrentHand, _dealersCardMat);
        }

        private void AddCardsToMat(IEnumerable<PlayingCard> playingCards, CardMat cardMat)
        {               
            foreach (PlayingCard playingCard in playingCards)
                cardMat.AddPlayingCard(playingCard);              
            
            cardMat.LastCardPositionX = 0;
        }

        private void SumCardScores(ICardPlayer player)
        {
            player.CurrentScore = _cardScorer.GetCardHandValue(player.CurrentHand);        
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            DealNewCard_Player();                                              
            SumCardScores(_player);

            if (_cardScorer.IsBust(_player.CurrentScore))
                Determine_Winner();                             
        }

        private void DealNewCard_Player()
        {
            PlayingCard playingCard = _cardShoe.TakeSinglePlayingCard();
            
            _player.CurrentHand.Add(playingCard);
            AddCardsToMat(_player.CurrentHand, _playersCardMat);
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

            AddCardsToMat(_dealer.CurrentHand, _dealersCardMat);
            
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