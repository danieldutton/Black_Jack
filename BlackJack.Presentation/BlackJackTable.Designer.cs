namespace BlackJack.Presentation
{
    partial class BlackJackTable
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
            this._panelPlayersCards = new System.Windows.Forms.Panel();
            this._panelDealersCards = new System.Windows.Forms.Panel();
            this._btnStartGame = new System.Windows.Forms.Button();
            this._btnStick = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
            this._lblStatus = new System.Windows.Forms.Label();
            this._lblDealersScore = new System.Windows.Forms.Label();
            this._lblPlayersScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // _btnHit
            // 
            this._btnHit.Location = new System.Drawing.Point(4, 4);
            this._btnHit.Name = "_btnHit";
            this._btnHit.Size = new System.Drawing.Size(75, 23);
            this._btnHit.TabIndex = 0;
            this._btnHit.Text = "Hit";
            this._btnHit.UseVisualStyleBackColor = true;
            this._btnHit.Click += new System.EventHandler(this.PlayerHits_Click);
            // 
            // _panelPlayersCards
            // 
            this._panelPlayersCards.Location = new System.Drawing.Point(5, 132);
            this._panelPlayersCards.Name = "_panelPlayersCards";
            this._panelPlayersCards.Size = new System.Drawing.Size(467, 100);
            this._panelPlayersCards.TabIndex = 1;
            this._panelPlayersCards.Tag = "PLayer";
            // 
            // _panelDealersCards
            // 
            this._panelDealersCards.Location = new System.Drawing.Point(6, 3);
            this._panelDealersCards.Name = "_panelDealersCards";
            this._panelDealersCards.Size = new System.Drawing.Size(466, 100);
            this._panelDealersCards.TabIndex = 2;
            this._panelDealersCards.Tag = "Dealer";
            // 
            // _btnStartGame
            // 
            this._btnStartGame.Location = new System.Drawing.Point(313, 4);
            this._btnStartGame.Name = "_btnStartGame";
            this._btnStartGame.Size = new System.Drawing.Size(75, 23);
            this._btnStartGame.TabIndex = 3;
            this._btnStartGame.Text = "Start";
            this._btnStartGame.UseVisualStyleBackColor = true;
            this._btnStartGame.Click += new System.EventHandler(this.StartGame_Click);
            // 
            // _btnStick
            // 
            this._btnStick.Location = new System.Drawing.Point(80, 4);
            this._btnStick.Name = "_btnStick";
            this._btnStick.Size = new System.Drawing.Size(75, 23);
            this._btnStick.TabIndex = 4;
            this._btnStick.Text = "Stick";
            this._btnStick.UseVisualStyleBackColor = true;
            this._btnStick.Click += new System.EventHandler(this.PlayerSticks_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(389, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Restart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ExitApplication_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.SlateGray;
            this.panelButtons.Controls.Add(this.button1);
            this.panelButtons.Controls.Add(this._btnStartGame);
            this.panelButtons.Controls.Add(this._btnStick);
            this.panelButtons.Controls.Add(this._btnHit);
            this.panelButtons.Location = new System.Drawing.Point(5, 241);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(467, 31);
            this.panelButtons.TabIndex = 9;
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.ForeColor = System.Drawing.Color.White;
            this._lblStatus.Location = new System.Drawing.Point(6, 111);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(35, 13);
            this._lblStatus.TabIndex = 10;
            this._lblStatus.Text = "label1";
            // 
            // _lblDealersScore
            // 
            this._lblDealersScore.AutoSize = true;
            this._lblDealersScore.ForeColor = System.Drawing.Color.White;
            this._lblDealersScore.Location = new System.Drawing.Point(279, 111);
            this._lblDealersScore.Name = "_lblDealersScore";
            this._lblDealersScore.Size = new System.Drawing.Size(35, 13);
            this._lblDealersScore.TabIndex = 10;
            this._lblDealersScore.Text = "label1";
            // 
            // _lblPlayersScore
            // 
            this._lblPlayersScore.AutoSize = true;
            this._lblPlayersScore.ForeColor = System.Drawing.Color.White;
            this._lblPlayersScore.Location = new System.Drawing.Point(417, 111);
            this._lblPlayersScore.Name = "_lblPlayersScore";
            this._lblPlayersScore.Size = new System.Drawing.Size(35, 13);
            this._lblPlayersScore.TabIndex = 11;
            this._lblPlayersScore.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(377, 111);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Player:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(238, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Dealer:";
            // 
            // BlackJackTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(477, 277);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._lblPlayersScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._lblDealersScore);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this._panelDealersCards);
            this.Controls.Add(this._panelPlayersCards);
            this.Name = "BlackJackTable";
            this.Text = "Game";
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button _btnHit;
        private System.Windows.Forms.Panel _panelPlayersCards;
        private System.Windows.Forms.Panel _panelDealersCards;
        private System.Windows.Forms.Button _btnStartGame;
        private System.Windows.Forms.Button _btnStick;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Label _lblDealersScore;
        private System.Windows.Forms.Label _lblPlayersScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}