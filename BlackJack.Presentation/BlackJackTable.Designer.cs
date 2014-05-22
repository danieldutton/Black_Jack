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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BlackJackTable));
            this._lblStatus = new System.Windows.Forms.Label();
            this._lblDealersScore = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this._lblPlayersScore = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelButtons = new System.Windows.Forms.Panel();
            this._btnStartGame = new System.Windows.Forms.Button();
            this._btnStick = new System.Windows.Forms.Button();
            this._btnHit = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // _lblStatus
            // 
            this._lblStatus.AutoSize = true;
            this._lblStatus.ForeColor = System.Drawing.Color.White;
            this._lblStatus.Location = new System.Drawing.Point(317, 118);
            this._lblStatus.Name = "_lblStatus";
            this._lblStatus.Size = new System.Drawing.Size(13, 13);
            this._lblStatus.TabIndex = 10;
            this._lblStatus.Text = "--";
            // 
            // _lblDealersScore
            // 
            this._lblDealersScore.AutoSize = true;
            this._lblDealersScore.ForeColor = System.Drawing.Color.White;
            this._lblDealersScore.Location = new System.Drawing.Point(387, 75);
            this._lblDealersScore.Name = "_lblDealersScore";
            this._lblDealersScore.Size = new System.Drawing.Size(13, 13);
            this._lblDealersScore.TabIndex = 10;
            this._lblDealersScore.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(317, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Dealer Score:";
            // 
            // _lblPlayersScore
            // 
            this._lblPlayersScore.AutoSize = true;
            this._lblPlayersScore.ForeColor = System.Drawing.Color.White;
            this._lblPlayersScore.Location = new System.Drawing.Point(387, 96);
            this._lblPlayersScore.Name = "_lblPlayersScore";
            this._lblPlayersScore.Size = new System.Drawing.Size(13, 13);
            this._lblPlayersScore.TabIndex = 11;
            this._lblPlayersScore.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(317, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Player Score:";
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.Brown;
            this.panelButtons.Controls.Add(this._btnStartGame);
            this.panelButtons.Controls.Add(this._btnStick);
            this.panelButtons.Controls.Add(this._btnHit);
            this.panelButtons.Location = new System.Drawing.Point(1, 302);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(411, 31);
            this.panelButtons.TabIndex = 9;
            // 
            // _btnStartGame
            // 
            this._btnStartGame.Location = new System.Drawing.Point(3, 5);
            this._btnStartGame.Name = "_btnStartGame";
            this._btnStartGame.Size = new System.Drawing.Size(75, 23);
            this._btnStartGame.TabIndex = 3;
            this._btnStartGame.Text = "Deal";
            this._btnStartGame.UseVisualStyleBackColor = true;
            this._btnStartGame.Click += new System.EventHandler(this.StartNewGame_Click);
            // 
            // _btnStick
            // 
            this._btnStick.Location = new System.Drawing.Point(333, 5);
            this._btnStick.Name = "_btnStick";
            this._btnStick.Size = new System.Drawing.Size(75, 23);
            this._btnStick.TabIndex = 4;
            this._btnStick.Text = "Stick";
            this._btnStick.UseVisualStyleBackColor = true;
            this._btnStick.Click += new System.EventHandler(this.PlayerSticks_Click);
            // 
            // _btnHit
            // 
            this._btnHit.Location = new System.Drawing.Point(253, 5);
            this._btnHit.Name = "_btnHit";
            this._btnHit.Size = new System.Drawing.Size(75, 23);
            this._btnHit.TabIndex = 0;
            this._btnHit.Text = "Hit";
            this._btnHit.UseVisualStyleBackColor = true;
            this._btnHit.Click += new System.EventHandler(this.PlayerHits_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(413, 73);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // BlackJackTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Firebrick;
            this.ClientSize = new System.Drawing.Size(411, 334);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this._lblPlayersScore);
            this.Controls.Add(this.label2);
            this.Controls.Add(this._lblDealersScore);
            this.Controls.Add(this._lblStatus);
            this.Controls.Add(this.panelButtons);
            this.Name = "BlackJackTable";
            this.Text = "Game";
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label _lblStatus;
        private System.Windows.Forms.Label _lblDealersScore;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblPlayersScore;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelButtons;
        private System.Windows.Forms.Button _btnStartGame;
        private System.Windows.Forms.Button _btnStick;
        private System.Windows.Forms.Button _btnHit;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}