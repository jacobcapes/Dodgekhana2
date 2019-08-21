using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;

namespace Dodgekhana2
{

    public partial class FrmDodge : Form
    {
        Rectangle recPoint = new Rectangle(0, 0, 50, 65);//Rectangle point start point and perameters
        Graphics g; //Graphics declaration
        Random rand = new Random();
        Random speed = new Random();
        int X = 20, Y = 20;//X and Y values
        int x2 = 50, y2 = 290;
        //Declare the rectangles that the point, player and tyres will be
        Rectangle area, area1, area2, area3, area4, area5, area6, area7;
        int score = 0;
        int lives = 5;
        //Images for the tyres, player and point
        Image Point = Image.FromFile(Application.StartupPath + @"\Vehicle.jpg");//Image for point
        Image Vehicle = Image.FromFile(Application.StartupPath + @"\Vehicle.jpg");
        Image Tire = Image.FromFile(Application.StartupPath + @"\Tire.png");

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TmrTire.Enabled = false;
            TmrVehicle.Enabled = false;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)//StartButton
        {

            TmrTire.Interval = 75;
            LblScore.Text = score.ToString();
            lives = int.Parse(LblLives.Text);//pass lives entered in textbox to lives variable
            TmrTire.Enabled = true;
            TmrVehicle.Enabled = true;
            StartButton.Visible = false;
            score = 0;
            LblScore.Text = score.ToString();
            area.Y = 290;
            area.X = 50;
            area1.Y = 20; 
            area2.X = 20; 
            area3.Y = 20;
            area4.X = 20;
            area5.Y = 20;
            area6.X = 20; 
            area7.Y = 20; 
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            score = 0;
            lives = 5;
            LblLives.Text = "5";
            LblScore.Text = score.ToString();
            lives = int.Parse(LblLives.Text);//pass lives entered in textbox to lives variable
            TmrTire.Enabled = true;
            TmrVehicle.Enabled = true;
           
            area1.Y = 20; 
            area2.X = 20;
            area3.Y = 20;
            area4.X = 20; 
            area5.Y = 20; 
            area6.X = 20; 
            area7.Y = 20; 


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 95 && e.KeyChar < 124)
            {
                //only display lowercase letters of the alphabet
            }
            else//entered a number or character that isnt in the alphabet
            {
                MessageBox.Show("Please enter letters only", "Error");
                e.Handled = true;
                TextName.Focus();//Focus on name textbox
            }

            if (e.KeyChar > 12 && e.KeyChar < 14)//Enter key pressed
            {
                MessageBox.Show("Please enter your lives now between 1 and 5");
                TextName.Enabled = false;//deny access to name textbox
                LblLives.Focus();//Focus on lives textbox

            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string context = TextName.Text;
        }

        private void LblLives_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblLives_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 48 && e.KeyChar < 54)//if 1,2,3,4,5 pressed
            {
                LblLives.Enabled = false;
                StartButton.Enabled = true;//Start button is enabled
                StartButton.Visible = true;//Start button is visible

            }
            else//Number not 1,2,3,4,5
            {
                MessageBox.Show("Please enter Numbers 1 to 5 only", "Error");
                e.Handled = true;
                LblLives.Focus();
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        bool left, right, up, down;
        public FrmDodge()
        {
            InitializeComponent();
            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic, null, PnlGame, new object[] { true });
            area = new Rectangle(x2, y2, 30, 30);
            area1 = new Rectangle(X, Y, 20, 20);
            area2 = new Rectangle(X, Y + 30, 20, 20);
            area3 = new Rectangle(X + 100, Y, 20, 20);
            area4 = new Rectangle(X, Y + 140, 20, 20);
            area5 = new Rectangle(X + 200, Y, 20, 20);
            area6 = new Rectangle(X, Y + 240, 20, 20);
            area7 = new Rectangle(X + 300, Y, 20, 20);
           recPoint = new Rectangle(X + 300, Y, 20, 20);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Use the arrow keys to move your vehicle. \n Don't get hit by the tyres! \n Every oil can you collect scores a point! \n If a tyre hits your vehicle a life is lost!", "Game Instructions");
            TextName.Focus();

        }
        private void CheckLives()
        {
            LblLives.Text = lives.ToString();//Show lives on form
            if (lives == 0)
            {
                //Stop the game and initiate a restart sequence
                left = false;
                right = false;
                up = false;
                down = false;
                LblLives.Enabled = true;
                TmrTire.Enabled = false;
                TmrVehicle.Enabled = false;
              string message = "Would you like to play again?";
                string title = "Game Over";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result = MessageBox.Show(message, title, buttons);
                if (result == DialogResult.Yes)
                {
                    LblLives.Focus();
                }
            }
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            g = e.Graphics;
            g.DrawImage(Point, recPoint);
            g.DrawImage(Vehicle, area);
            g.DrawImage(Tire, area1);
            g.DrawImage(Tire, area2);
            g.DrawImage(Tire, area3);
            g.DrawImage(Tire, area4);
            g.DrawImage(Tire, area5);
            g.DrawImage(Tire, area6);
            g.DrawImage(Tire, area7);
    

        }

        private void TmrTire_Tick(object sender, EventArgs e)
        {
            area1.Y += speed.Next(3, 9);//move tyre down screen at a random speed between 3 and 9
            area2.X += speed.Next(3, 9);//move tyre across screen at a speed between 3 aqnd 9
            area3.Y += speed.Next(3, 9);
            area4.X += speed.Next(3, 9);
            area5.Y += speed.Next(3, 9);
            area6.X += speed.Next(3, 9);
            area7.Y += speed.Next(3, 9);
            PnlGame.Invalidate();//Forces panel to redraw and update the images in their new position

            if (area1.Y > PnlGame.Height)
            {
                area1.Y = -30;//Place tyre back to original position
            }
            if (area2.X > PnlGame.Width)
            {
                area2.X = -30;
            }
            if (area3.Y > PnlGame.Height)
            {
                area3.Y = -30;
            }
            if (area4.X > PnlGame.Width)
            {
                area4.X = -30;
            }
            if (area5.Y > PnlGame.Height)
            {
                area5.Y = -30;
            }
            if (area6.X > PnlGame.Width)
            {
                area6.X = -30; 
            }
            if (area7.Y > PnlGame.Height)
            {
                area7.Y = -30;
            }
            if (score >= 5)//If score more than 5 increase the timer speed
            {
                TmrTire.Interval = 70;
            }
            if (score >= 7)//If score more than 7 increase the timer speed
            {
                TmrTire.Interval = 65;
            }
            if (score >= 10)//etc
            {
                TmrTire.Interval = 60;
            }
            if (score >= 13)
            {
                TmrTire.Interval = 55;
            }
            if (score >= 15)
            {
                TmrTire.Interval = 50;
            }
            if (score >= 20)
            {
                TmrTire.Interval = 40;
            }
            if (score >= 30)
            {
                TmrTire.Interval = 30;
            }
        }

        private void FrmDodge_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = false; }
            if (e.KeyData == Keys.Right) { right = false; }
            if (e.KeyData == Keys.Up) { up = false; }
            if (e.KeyData == Keys.Down) { down = false; }
        }

        private void FrmDodge_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Left) { left = true; }
            if (e.KeyData == Keys.Right) { right = true; }
            if (e.KeyData == Keys.Up) { up = true; }
            if (e.KeyData == Keys.Down) { down = true; }
        }

        private void TmrVehicle_Tick(object sender, EventArgs e)
        {
            if (left)
                if (area.X < -10)
                {
                    area.X = 380;
                }
                else
                {
                    area.X -= 10;

                }
            if (right)
            {
                if (area.X > PnlGame.Width - -10)
                {
                    area.X = PnlGame.Width - 380;
                }
                else
                {
                    area.X += 10;
                }
            }
            if (up)
            {
                if (area.Y < PnlGame.Height - 380)
                {
                    area.Y = PnlGame.Height - 10;
                }
                else
                {
                    area.Y -= 10;
                }
            }
            if (down)
            {
                if (area.Y > PnlGame.Height - 10)
                {
                    area.Y = PnlGame.Height - 380;
                }
                else
                {
                    area.Y += 10;
                }
            }
            
            if (area.IntersectsWith(area1))//If player hits tyre
            {
                area1.Y = -30;//Redraw tyre in original position
                lives -= 1;//lose a life
                CheckLives();//Run code checklives
            }
            if (area.IntersectsWith(area2))
            {
                area2.X = -30;
                lives -= 1;
                CheckLives();
            }
            if (area.IntersectsWith(area3))
            {
                area3.Y = -30;
                lives -= 1;
             
                CheckLives();
            }
            if (area.IntersectsWith(area4))
            {
                area4.X = -30;
                lives -= 1;

                CheckLives();
            }
            if (area.IntersectsWith(area5))
            {
                area5.Y = -30;
                lives -= 1;
      
                CheckLives();
            }
            if (area.IntersectsWith(area6))
            {
                lives -= 1;
                area6.X = -30;
                CheckLives();
            }
            if (area.IntersectsWith(area7))
            {
                area7.Y = -30;
                lives -= 1;
                CheckLives();
            }
            if (area.IntersectsWith(recPoint))//If player hits point
            {
                score += 1;//Increase score by 1
                LblScore.Text = score.ToString();
                recPoint.X = rand.Next(240);//Move to random X position
                recPoint.Y = rand.Next(240);//Move to random Y position
            }
        }

    }

}

