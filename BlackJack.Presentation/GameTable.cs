using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Table;
using BlackJack.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace BlackJack.Presentation
{
    public partial class GameTable : Form
    {
        #region Instance Vars

        private readonly Dealer _dealer;

        private readonly Player _player;

        private readonly ICardShoe _cardShoe;

        private readonly CardPointScorer _cardPointScorer;

        private int _cardXPos;

        #endregion

        #region Constructor

        public GameTable(Dealer dealer, Player player, ICardShoe cardShoe)
        {
            _dealer = dealer;
            _player = player;
            _cardShoe = cardShoe;

            InitializeComponent();

            _cardPointScorer = new CardPointScorer();
        }

        #endregion

        #region Methods

        private void StartGame_Click(object sender, EventArgs e)
        {
            List<PlayingCard> startingHand = _cardShoe.ReleaseStartingHands();

            List<PlayingCard> dealersCards = startingHand.Take(2).ToList();
            List<PlayingCard> playersCards = startingHand.Skip(2).Take(2).ToList();

            DealStartingHand_Dealer(dealersCards);
            DealStartingHand_Player(playersCards);

            PlayGame_Dealer();
        }

        private void DealStartingHand_Dealer(IEnumerable<PlayingCard> cards)
        {
            foreach (var playingCard in cards)
            {
                playingCard.Location = new Point(_cardXPos, 0);
                _panelDealersHand.Controls.Add(playingCard);
                _cardXPos += 40;

                _dealer.CurrentHand.Add(playingCard);

                int cardValue = _cardPointScorer.GetPlayingCardValue(playingCard);
                _dealer.CurrentScore += cardValue;

                _lblDealerScore.Text = _dealer.CurrentScore.ToString();
            }
            _cardXPos = 0;
        }

        private void DealStartingHand_Player(IEnumerable<PlayingCard> cards)
        {
            foreach (var playingCard in cards)
            {
                playingCard.Location = new Point(_cardXPos, 0);
                _panelPlayersHand.Controls.Add(playingCard);
                _cardXPos += 40;

                _player.CurrentHand.Add(playingCard);

                int cardValue = _cardPointScorer.GetPlayingCardValue(playingCard);
                _player.CurrentScore += cardValue;

                _lblPlayerScore.Text = _player.CurrentScore.ToString();
            }
            _cardXPos = 0;
        }

        private void PlayGame_Dealer()
        {
            //stick if current hand totals 14 or not else
            if (_dealer.CurrentScore < 19)
            {
                //whilst the current hand is less than 21
                while (_dealer.CurrentScore < 21)
                {
                    //we get a playing card
                    PlayingCard card = _cardShoe.GetNextPlayingCard();

                    //we then get the value of that playing card
                    int score = _cardPointScorer.GetPlayingCardValue(card);

                    //we add it to the dealers current score
                    _dealer.CurrentScore += score;

                    //we add the card to the dealers current hand
                    _dealer.CurrentHand.Add(card);

                    //if the score is now in the range of 14-21
                    if (_dealer.CurrentScore >= 19 && _dealer.CurrentScore <= 21 )
                    {
                        //then update the score value
                        _lblDealerScore.Text = score.ToString();

                        //and finish playing/stick
                        break;
                    }
                    //else we start over and play another card
                }
            }
        }

        private void PlayerHits_Click(object sender, EventArgs e)
        {
            _cardXPos += 80;
            PlayingCard result = _cardShoe.GetNextPlayingCard();

            result.Location = new Point(_cardXPos, 0);
            _panelPlayersHand.Controls.Add(result);
            _cardXPos += 40;

            int cardValue = _cardPointScorer.GetPlayingCardValue(result);
            _player.CurrentScore += cardValue;

            _player.CurrentHand.Add(result);
            _lblPlayerScore.Text = _player.CurrentScore.ToString();
        }

        private void PlayerSticks_Click(object sender, EventArgs e)
        {
            _cardXPos = 0;
            DetermineWinner();
        }

        private void DetermineWinner()
        {
            //get dealers score
            int dealersScore = _dealer.CurrentScore;

            //get players score
            int playersScore = _player.CurrentScore;

            //check for bust
            if (IsBust(playersScore) && IsBust(dealersScore))
            {
                _lblStatus.Text = "Push";
                
            }

            if (IsBust(dealersScore))
            {
                _lblStatus.Text = "Dealer Bust";

            }

            if (IsBust(playersScore))
            {
                _lblStatus.Text = "Player Bust";
                
            }
            RevealDealersHand(_dealer.CurrentHand); 
            //compare the two
            _lblWinner.Text = playersScore > dealersScore ? "Player Wins" : "DealerWins";
        }

        public bool IsBust(int score)
        {
            return score > 21;
        }

        private void RevealDealersHand(IEnumerable<PlayingCard> dealersHand)
        {
            //srp put this in dealers class
            foreach (var playingCard in dealersHand)
            {
                playingCard.Location = new Point(_cardXPos, 0);
                _panelDealersHand.Controls.Add(playingCard);
                _cardXPos += 40;
            }
        }

        private void RestartApplication_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        #endregion
    }
}