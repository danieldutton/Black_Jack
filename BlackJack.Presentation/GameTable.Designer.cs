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
            this.cardMatPlayer = new System.Windows.Forms.Panel();
            this.cardMatDealer = new System.Windows.Forms.Panel();
            this._btnStartGame = new System.Windows.Forms.Button();
            this._btnStick = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panelButtons = new System.Windows.Forms.Panel();
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
            // cardMatPlayer
            // 
            this.cardMatPlayer.Location = new System.Drawing.Point(5, 132);
            this.cardMatPlayer.Name = "cardMatPlayer";
            this.cardMatPlayer.Size = new System.Drawing.Size(467, 100);
            this.cardMatPlayer.TabIndex = 1;
            this.cardMatPlayer.Tag = "PLayer";
            // 
            // cardMatDealer
            // 
            this.cardMatDealer.Location = new System.Drawing.Point(6, 3);
            this.cardMatDealer.Name = "cardMatDealer";
            this.cardMatDealer.Size = new System.Drawing.Size(466, 100);
            this.cardMatDealer.TabIndex = 2;
            this.cardMatDealer.Tag = "Dealer";
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
            this.button1.Text = "Exit";
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
            // GameTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(477, 277);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.cardMatDealer);
            this.Controls.Add(this.cardMatPlayer);
            this.Name = "GameTable";
            this.Text = "Game";
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnHit;
        private System.Windows.Forms.Panel cardMatPlayer;
        private System.Windows.Forms.Panel cardMatDealer;
        private System.Windows.Forms.Button _btnStartGame;
        private System.Windows.Forms.Button _btnStick;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panelButtons;
    }
}