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
            // 
            // _panelDealersHand
            // 
            this._panelDealersHand.Location = new System.Drawing.Point(13, 13);
            this._panelDealersHand.Name = "_panelDealersHand";
            this._panelDealersHand.Size = new System.Drawing.Size(466, 100);
            this._panelDealersHand.TabIndex = 2;
            // 
            // _btnStartGame
            // 
            this._btnStartGame.Location = new System.Drawing.Point(327, 268);
            this._btnStartGame.Name = "_btnStartGame";
            this._btnStartGame.Size = new System.Drawing.Size(75, 23);
            this._btnStartGame.TabIndex = 3;
            this._btnStartGame.Text = "Start";
            this._btnStartGame.UseVisualStyleBackColor = true;
            this._btnStartGame.Click += new System.EventHandler(this.StartingDeal_Click);
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
            // GameTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(491, 303);
            this.Controls.Add(this._btnStick);
            this.Controls.Add(this._btnStartGame);
            this.Controls.Add(this._panelDealersHand);
            this.Controls.Add(this._panelPlayersHand);
            this.Controls.Add(this._btnHit);
            this.Name = "GameTable";
            this.Text = "Game";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnHit;
        private System.Windows.Forms.Panel _panelPlayersHand;
        private System.Windows.Forms.Panel _panelDealersHand;
        private System.Windows.Forms.Button _btnStartGame;
        private System.Windows.Forms.Button _btnStick;
    }
}