using System.Drawing;
using System.Windows.Forms;

namespace BlackJack.Presentation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            pictureBox1.Image = Properties.Resources.b1fv;
        }

        private void _btnAddCardLeft_Click(object sender, System.EventArgs e)
        {
            int cardCount = 0;

            //is there any control in place already
            if (_panelCardHand1.Controls.Count == 0)
            {
                var pictureBox = new PictureBox
                    {
                        Width = 150,
                        Height = 150,
                        Image = Properties.Resources.c1
                    };

                _panelCardHand1.Controls.Add(pictureBox);

                cardCount++;
            }
            else
            {
                //get width of last card
                int width = _panelCardHand1.Controls[cardCount].Location.X;

                var pictureBox = new PictureBox
                    {
                        Width = 150,
                        Height = 150,
                        Image = Properties.Resources.c2,
                        Location = new Point(200, 0),
                    };

                _panelCardHand1.Controls.Add(pictureBox);

                cardCount++;

            }
             
        }
    }
}
