using System.Drawing;
using BlackJack.CardDeck.Model;
using BlackJack.Players.EventArg;
using BlackJack.Players.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BlackJack.Table.Interfaces;

namespace BlackJack.Players
{
    //This class is a bit of a mess - refactor
    public class Dealer : ICardPlayer
    {
        public event EventHandler<GameOverEventArgs> GameOver;

        private const int StickThreshold = 15;

        private const int WinningScore = 21;

        private int _cardXPos;

        private readonly ICardShoe _cardShoe;

        private readonly IPointsScorer _scoreCalculator;

        public List<PlayingCard> CurrentHand { get; set; }

        public int CurrentScore { get; set; }


        public Dealer(ICardShoe cardShoe, IPointsScorer scoreCalculator)
        {
            _cardShoe = cardShoe;
            _scoreCalculator = scoreCalculator;
            CurrentHand = new List<PlayingCard>();
        }

        public void RegisterNewPlayer(Player player)
        {
            player.Stick += Determine_Winner;
            player.Hit += DealNewCard_Player;
        }

        //kepp in cardshoe
        public void DealStartingHand_Player(IEnumerable<PlayingCard> cards, Panel panel, ICardPlayer cardPlayer)
        {
            List<PlayingCard> playingCards = cards as List<PlayingCard> ?? cards.ToList();

            for (int i = 0; i < playingCards.Count(); i++)
            {
                playingCards[i].Location = new Point(_cardXPos, 0);

                panel.Controls.Add(playingCards[i]);
                panel.Controls.SetChildIndex(playingCards[i], 0);
                _cardXPos += 40;

                cardPlayer.CurrentHand.Add(playingCards[i]);

                int cardValue = _scoreCalculator.GetPlayingCardValue(playingCards[i]);
                cardPlayer.CurrentScore += cardValue;
            }
            _cardXPos = 80;
        }
        
        //kepp in cardshoe
        public void DealStartingHand_Dealer(IEnumerable<PlayingCard> cards, Panel panel)
        {
            List<PlayingCard> playingCards = cards as List<PlayingCard> ?? cards.ToList();

            for (int i = 0; i < playingCards.Count(); i++)
            {
                playingCards[i].Location = new Point(_cardXPos, 0);
                panel.Controls.Add(playingCards[i]);
                panel.Controls.SetChildIndex(playingCards[i], 0);
                _cardXPos += 40;

                CurrentHand.Add(playingCards[i]);

                int cardValue = _scoreCalculator.GetPlayingCardValue(playingCards[i]);
                CurrentScore += cardValue;
            }
            _cardXPos = 0;
        }

        //keep in cardshoe
        private void DealNewCard_Player(object sender, PlayerTakesMoveArgs e)
        {
            PlayingCard playingCard = GetPlayingCard();

            playingCard.Location = new Point(_cardXPos, 0);
            e.CardMatPlayer.Controls.Add(playingCard);
            e.CardMatPlayer.Controls.SetChildIndex(playingCard, 0);
            _cardXPos += 40;

            int cardValue = _scoreCalculator.GetPlayingCardValue(playingCard);
            e.Player.CurrentScore += cardValue;

            e.Player.CurrentHand.Add(playingCard);

            if (e.Player.IsBust(e.Player.CurrentScore))
            {
                OnGameOver(new GameOverEventArgs(CurrentScore, e.Player.CurrentScore, "Player Bust"));
                RevealHand_Dealer(e.CardMatDealer);
            }           
        }

        public void CompleteBlackJackHand_Dealer()
        {
            if (CurrentScore < StickThreshold)
            {
                while (CurrentScore < WinningScore && CurrentScore < StickThreshold)
                {
                    PlayingCard card = _cardShoe.GetNextPlayingCard();

                    int score = _scoreCalculator.GetPlayingCardValue(card);
                    CurrentScore += score;

                    CurrentHand.Add(card);

                    if (CurrentScore >= StickThreshold && CurrentScore <= WinningScore)
                    {
                        break;
                    }
                }
            }
        }

        //feature envy just use card shoe
        public PlayingCard GetPlayingCard()
        {
            PlayingCard playingCard = _cardShoe.GetNextPlayingCard();

            return playingCard;
        }

        //this should be in interaface and implemented in both dealer and player
        public void RevealHand_Dealer(Panel panel)
        {
            _cardXPos = 0;
            foreach (PlayingCard playingCard in CurrentHand)
            {
                playingCard.Location = new Point(_cardXPos, 0);
                panel.Controls.Add(playingCard);
                panel.Controls.SetChildIndex(playingCard, 0);
                _cardXPos += 40;
            }
        }
        
        public bool IsBust(int score)
        {
            return score > 21;
        }

        private void Determine_Winner(object sender, PlayerTakesMoveArgs e)
        {
            int dealersScore = CurrentScore;
            int playersScore = e.Player.CurrentScore;

            if (PlayerAndDealerAreBust(e))
                OnGameOver(new GameOverEventArgs(dealersScore, playersScore, "Both Bust!"));

            else if (IsBust(dealersScore))
                OnGameOver(new GameOverEventArgs(dealersScore, playersScore, "Dealer Bust! Player Wins.")); //check if player wins

            else if (e.Player.IsBust(playersScore))
                OnGameOver(new GameOverEventArgs(dealersScore, playersScore, "Player Bust! Dealer Wins."));

            else if (PlayerAndDealerAreDrawn(e))
                OnGameOver(new GameOverEventArgs(dealersScore, playersScore, "Dealer and Player draw!"));
            else
            {
                //compare the final scores
                string text = playersScore > dealersScore ? "Player Wins:" + playersScore : "DealerWins:" + dealersScore;
                OnGameOver(new GameOverEventArgs(dealersScore, playersScore, text));
            }

            RevealHand_Dealer(e.CardMatDealer);
            //DisposeOfCurrentHand();
            //e.Player.DisposeOfCurrentHand();
        }

        public void DisposeOfCurrentHand()
        {
            CurrentScore = 0;
            CurrentHand.Clear();
        }

        private bool PlayerAndDealerAreBust(PlayerTakesMoveArgs e)
        {
            return e.Player.IsBust(e.Player.CurrentScore) && IsBust(CurrentScore);
        }

        private bool PlayerAndDealerAreDrawn(PlayerTakesMoveArgs e)
        {
            return e.Player.CurrentScore == CurrentScore;
        }

        protected virtual void OnGameOver(GameOverEventArgs e)
        {
            EventHandler<GameOverEventArgs> handler = GameOver;
            if (handler != null) handler(this, e);
        }
    }
}