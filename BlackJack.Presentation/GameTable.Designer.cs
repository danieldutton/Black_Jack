namespace BlackJack.Presentation
{
    partial class GameTable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._btnHit = new System.Windows.Forms.Button();
            this._panelPlayersHand = new System.Windows.Forms.Panel();
            this._panelDealersHand = new System.Windows.Forms.Panel();
            this._btnStartGame = new System.Windows.Forms.Button();
            this._btnStick = new System.Windows.Forms.Button();
            this._lblDealerScore = new System.Windows.Forms.Label();
            this._lblPlayerScore = new System.Windows.Forms.Label();
            this._lblWinner = new System.Windows.Forms.Label();
            this._lblStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _btnHit
            // 
            this._btnHit.Location = new System.Drawing.Point(12, 268);
            this._btnHit.Name = "_btnHit";
            this._btnHit.Size = new System.Drawing.Size(75, 23);
            this._btnHit.TabIndex = 0;
            this._btnHit.Text = "Hit";
            this._btnHit.UseVisualStyleBackColor = true;
            this._btnHit.Click += new System.EventHandler(this.PlayerHits_Click);
            // 
            // _panelPlayersHand
            // 
            this._panelPlayersHand.Location = new System.Drawing.Point(12, 160);
            this._panelPlayersHand.Name = "_panelPlayersHand";
            this._panelPlayersHand.Size = new System.Drawing.Size(467, 100);
            this._panelPlayersHand.TabIndex = 1;
            this._panelPlayersHand.Tag = "PLayer";
            // 
            // _panelDealersHand
            // 
            this._panelDealersHand.Location = new System.Drawing.Point(13, 13);
            this._panelDealersHand.Name = "_panelDealersHand";
            this._panelDealersHand.Size = new System.Drawing.Size(466, 100);
            this._panelDealersHand.TabIndex = 2;
            this._panelDealersHand.Tag = "Dealer";
            // 
            // _btnStartGame
            // 
            this._btnStartGame.Location = new System.Drawing.Point(327, 268);
            this._btnStartGame.Name = "_btnStartGame";
            this._btnStartGame.Size = new System.Drawing.Size(75, 23);
            this._btnStartGame.TabIndex = 3;
            this._btnStartGame.Text = "Start";
            this._btnStartGame.UseVisualStyleBackColor = true;
            this._btnStartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // _btnStick
            // 
            this._btnStick.Location = new System.Drawing.Point(94, 268);
            this._btnStick.Name = "_btnStick";
            this._btnStick.Size = new System.Drawing.Size(75, 23);
            this._btnStick.TabIndex = 4;
            this._btnStick.Text = "Stick";
            this._btnStick.UseVisualStyleBackColor = true;
            this._btnStick.Click += new System.EventHandler(this.PlayerSticks_Click);
            // 
            // _lblDealerScore
            // 
            this._lblDealerScore.AutoSize = true;
            this._lblDealerScore.ForeColor = System.Drawing.Color.White;
            this._lblDealerScore.Location = new System.Drawing.Point(13, 120);
            this._lblDealerScore.Name = "_lblDealerScore";
            this._lblDealerScore.Size = new System.Drawing.Size(35, 13);
            this._lblDealerScore.TabIndex = 5;
            this._lblDealerScore.Text = "label1";
            // 
            // _lblPlayerScore
            // 
            this._lblPlayerScore.AutoSize = true;
            this._lblPlayerScore.ForeColor = System.Drawing.Color.White;
            this._lblPlayerScore.Location = new System.Drawing.Point(13, 144);
            this._lblPlayerScore.Name = "_lblPlayerScore";
            this._lblPlayerScore.Size = new System.Drawing.Size(35, 13);
            this._lblPlayerScore.TabIndex = 5;
            this._lblPlayerScore.Text = "label1";
            // 
            // _lblWinner
            // 
            this._lblWinner.AutoSize = true;
            this._lblWinner.ForeColor = System.Drawing.Color.White;
            this._lblWinner.Location = new System.Drawing.Point(197, 120);
            this._lblWinner.Name = "_lblWinner";
            this._lblWinner.Size = new System.Drawing.Size(35, 13);
            this._lblWinner.TabIndex = 6;
            this._lblWinner.Text = "label1";
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.ForeColor = System.Drawing.Color.White;
            this._lblStatus.Location = new System.Drawing.Point(327, 120);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(35, 13);
            this._lblStatus.TabIndex = 7;
            this._lblStatus.Text = "label1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(418, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Restart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RestartApplication_Click);
            // 
            // GameTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(491, 303);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this._lblWinner);
            this.Controls.Add(this._lblPlayerScore);
            this.Controls.Add(this._lblDealerScore);
            this.Controls.Add(this._btnStick);
            this.Controls.Add(this._btnStartGame);
            this.Controls.Add(this._panelDealersHand);
            this.Controls.Add(this._panelPlayersHand);
            this.Controls.Add(this._btnHit);
            this.Name = "GameTable";
            this.Text = "Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnHit;
        private System.Windows.Forms.Panel _panelPlayersHand;
        private System.Windows.Forms.Panel _panelDealersHand;
        private System.Windows.Forms.Button _btnStartGame;
        private System.Windows.Forms.Button _btnStick;
        private System.Windows.Forms.Label _lblDealerScore;
        private System.Windows.Forms.Label _lblPlayerScore;
        private System.Windows.Forms.Label _lblWinner;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Button button1;
    }
}