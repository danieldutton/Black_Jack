using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Table.Interfaces;

namespace BlackJack.Table
{
    public class Dealer : ICardPlayer
    {
        private const int StickThreshold = 19;
        private const int MaxCards = 21;
        private int _cardXPos;
        
        private readonly ICardShoe _cardShoe;

        public List<PlayingCard> CurrentHand { get; set; }
        public int CurrentScore { get; set; }

        public Dealer(ICardShoe cardShoe)
        {
            _cardShoe = cardShoe;
            CurrentHand = new List<PlayingCard>();
        }

        public void RegisterNewPlayer(Player player)
        {
            player.Sticks += Determine_Winner;
        }

        public void DealStartingHand_Dealer(IEnumerable<PlayingCard> cards, Panel panel)
        {
            foreach (PlayingCard playingCard in cards)
            {
                playingCard.Location = new Point(_cardXPos, 0);
                panel.Controls.Add(playingCard);
                _cardXPos += 40;

                CurrentHand.Add(playingCard);

                int cardValue = CardPointScorer.GetPlayingCardValue(playingCard);
                CurrentScore += cardValue;

                //_lblDealerScore.Text = _dealer.CurrentScore.ToString();
            }
            _cardXPos = 0;
        }

        public void DealStartingHand_Player(IEnumerable<PlayingCard> cards, Panel panel, ICardPlayer cardPlayer)
        {
            //DRY principle - matches code pattern above
            foreach (PlayingCard playingCard in cards)
            {
                playingCard.Location = new Point(_cardXPos, 0);
                panel.Controls.Add(playingCard);
                _cardXPos += 40;

                cardPlayer.CurrentHand.Add(playingCard);

                int cardValue = CardPointScorer.GetPlayingCardValue(playingCard);
                cardPlayer.CurrentScore += cardValue;

                //_lblPlayerScore.Text = _player.CurrentScore.ToString();
            }
            _cardXPos = 0;
        }

        public void CompleteGameHand()
        {
            if (CurrentScore < StickThreshold)
            {
                while (CurrentScore < MaxCards)
                {
                    PlayingCard card = _cardShoe.GetNextPlayingCard();

                    int score = CardPointScorer.GetPlayingCardValue(card);
                    CurrentScore += score;

                    CurrentHand.Add(card);

                    if (CurrentScore >= StickThreshold && CurrentScore <= MaxCards)
                    {
                        break;
                    }
                }
            }
        }

        public void RevealFinalHand(Panel panel)
        {
            foreach (PlayingCard playingCard in CurrentHand)
            {
                _cardXPos = 80;
                playingCard.Location = new Point(_cardXPos, 0);
                panel.Controls.Add(playingCard);
                _cardXPos += 40;
            }
        }

        public PlayingCard GetPlayingCard()
        {
            PlayingCard playingCard = _cardShoe.GetNextPlayingCard();

            return playingCard;
        }

        public bool IsBust(int score)
        {
            return score > 21;
        }

        private void Determine_Winner(object sender, PlayerSticksEventArg e)
        {
            int dealersScore = CurrentScore;
            int playersScore = e.Player.CurrentScore;

            //if both player an dealer bust then
            if (e.Player.IsBust(playersScore) && IsBust(dealersScore))
            {
                //_lblStatus.Text = "Push";
            }

                //if just dealer bust then
            else if (IsBust(dealersScore))
            {
                //_lblStatus.Text = "Dealer Bust";
            }

                //if just player bust then
            else if (e.Player.IsBust(playersScore))
            {
                //_lblStatus.Text = "Player Bust";
            }
            RevealFinalHand(e.GameMatDealer);
            //compare the two
            //_lblWinner.Text = playersScore > dealersScore ? "Player Wins" : "DealerWins";
        }
    }
}