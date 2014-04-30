﻿using BlackJack.CardDeck;
using BlackJack.CardDeck.Model;
using BlackJack.Table.EventArgs;
using BlackJack.Table.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace BlackJack.Table
{
    //This class is a bit of a mess - refactor
    public class Dealer : IBlackJackPlayer
    {
        #region Instance Vars

        public event EventHandler<PlayerSticksEventArg> Stick;

        private const int StickThreshold = 15;
        
        private const int WinningScore = 21;
        
        private int _cardXPos;
        
        private readonly ICardShoe _cardShoe;

        public List<PlayingCard> CurrentHand { get; set; }
        
        public int CurrentScore { get; set; }

        #endregion

        #region Constructor(s)

        public Dealer(ICardShoe cardShoe)
        {
            _cardShoe = cardShoe;
            CurrentHand = new List<PlayingCard>();
        }

        #endregion

        #region Method(s)

        public void RegisterNewPlayer(Player player)
        {
            player.Stick += Determine_Winner;
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
            }
            _cardXPos = 0;
        }

        public void DealStartingHand_Player(IEnumerable<PlayingCard> cards, Panel panel, ICardPlayer cardPlayer)
        {
            foreach (PlayingCard playingCard in cards)
            {
                playingCard.Location = new Point(_cardXPos, 0);
                panel.Controls.Add(playingCard);
                _cardXPos += 40;

                cardPlayer.CurrentHand.Add(playingCard);

                int cardValue = CardPointScorer.GetPlayingCardValue(playingCard);
                cardPlayer.CurrentScore += cardValue;
            }
            _cardXPos = 80;
        }

        public void PlayGame()
        {
            if (CurrentScore < StickThreshold)
            {
                while (CurrentScore < WinningScore && CurrentScore < StickThreshold)
                {
                    PlayingCard card = _cardShoe.GetNextPlayingCard();

                    int score = CardPointScorer.GetPlayingCardValue(card);
                    CurrentScore += score;

                    CurrentHand.Add(card);

                    if (CurrentScore >= StickThreshold && CurrentScore <= WinningScore)
                    {
                        break;
                    }
                }
            }
        }

        public void RevealFinalHand(Panel panel)
        {
            _cardXPos = 0;
            foreach (PlayingCard playingCard in CurrentHand)
            {                
                playingCard.Location = new Point(_cardXPos, 0);
                panel.Controls.Add(playingCard);
                _cardXPos += 40;
            }
        }

        public void Hit(Panel panel, IBlackJackPlayer player)
        {
            //test if player is bust

            var playingCard = GetPlayingCard();

            playingCard.Location = new Point(_cardXPos, 0);
            panel.Controls.Add(playingCard);
            _cardXPos += 40;

            int cardValue = CardPointScorer.GetPlayingCardValue(playingCard);
            player.CurrentScore += cardValue;

            player.CurrentHand.Add(playingCard);
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

            if (PlayerAndDealerBust(e))
                MessageBox.Show("Push" + " Dealer:" + dealersScore + "Player:" + playersScore);

            else if (IsBust(dealersScore))
                MessageBox.Show("Dealer Bust, You win:" + "Player:" + playersScore);

            else if (e.Player.IsBust(playersScore))
                MessageBox.Show("Player Bust, Dealer wins:" + dealersScore);
            
            else if (ScoreTied(e))
                MessageBox.Show("Game Tied- Dealer:" + dealersScore + " Player:" + playersScore);
            else
            {
                //compare the final scores
                string text = playersScore > dealersScore ? "Player Wins:" + playersScore : "DealerWins:" + dealersScore;
                MessageBox.Show(text);   
            }

            RevealFinalHand(e.CardMatDealer);            
        }

        private bool PlayerAndDealerBust(PlayerSticksEventArg e)
        {
            return e.Player.IsBust(e.Player.CurrentScore) && IsBust(CurrentScore);
        }

        private bool ScoreTied(PlayerSticksEventArg e)
        {
            return e.Player.CurrentScore == CurrentScore;
        }

        protected virtual void OnStick(PlayerSticksEventArg e)
        {
            EventHandler<PlayerSticksEventArg> handler = Stick;
            if (handler != null) handler(this, e);
        }

        #endregion
    }
}