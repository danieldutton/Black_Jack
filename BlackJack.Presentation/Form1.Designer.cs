namespace BlackJack.Presentation
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this._btnAddCardLeft = new System.Windows.Forms.Button();
            this._panelCardHand1 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this._btnStand = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(230, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(76, 112);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // _btnAddCardLeft
            // 
            this._btnAddCardLeft.Location = new System.Drawing.Point(12, 12);
            this._btnAddCardLeft.Name = "_btnAddCardLeft";
            this._btnAddCardLeft.Size = new System.Drawing.Size(75, 23);
            this._btnAddCardLeft.TabIndex = 1;
            this._btnAddCardLeft.Text = "Add Card Left";
            this._btnAddCardLeft.UseVisualStyleBackColor = true;
            this._btnAddCardLeft.Click += new System.EventHandler(this._btnAddCardLeft_Click);
            // 
            // _panelCardHand1
            // 
            this._panelCardHand1.Location = new System.Drawing.Point(12, 196);
            this._panelCardHand1.Name = "_panelCardHand1";
            this._panelCardHand1.Size = new System.Drawing.Size(527, 115);
            this._panelCardHand1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this._btnStand);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(4, 323);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(175, 48);
            this.panel1.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(349, 323);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(190, 48);
            this.panel2.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Hit";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // _btnStand
            // 
            this._btnStand.Location = new System.Drawing.Point(89, 20);
            this._btnStand.Name = "_btnStand";
            this._btnStand.Size = new System.Drawing.Size(75, 23);
            this._btnStand.TabIndex = 1;
            this._btnStand.Text = "Stand";
            this._btnStand.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.ForestGreen;
            this.ClientSize = new System.Drawing.Size(551, 378);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this._panelCardHand1);
            this.Controls.Add(this._btnAddCardLeft);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button _btnAddCardLeft;
        private System.Windows.Forms.Panel _panelCardHand1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button _btnStand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel2;
    }
}

