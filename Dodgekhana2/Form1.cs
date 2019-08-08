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
        Rectangle recPoint = new Rectangle(0, 0, 50, 65);
        Image Point = Image.FromFile(Application.StartupPath + @"\Vehicle.jpg");
        Graphics g; // declare the graphics object
        Random rand = new Random();
        Random speed = new Random();
        int X = 20, Y = 20;// starting position of tire
        int x2 = 50, y2 = 290; // starting position of spaceship
        // Declare the rectangles to display the spaceship and planets in
        Rectangle area, area1, area2, area3, area4, area5, area6, area7;
        int score = 0;
        int lives = 5;
        // load the spaceship and one planet
        Image Vehicle = Image.FromFile(Application.StartupPath + @"\Vehicle.jpg");

        private void LblLives_Click(object sender, EventArgs e)
        {

        }

        Image Tire = Image.FromFile(Application.StartupPath + @"\Tire.png");

        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TmrTire.Enabled = false;
            TmrVehicle.Enabled = false;
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           
            LblScore.Text = score.ToString();
            lives = int.Parse(LblLives.Text);//pass lives entered in textbox to lives variable
            TmrTire.Enabled = true;
            TmrVehicle.Enabled = true;
            startToolStripMenuItem.Visible = false;
            area.Y = 290;
            area.X = 50;
            area1.Y = 20; //place planet back at top of panel
            area2.X = 20; //place planet back at top of panel
            area3.Y = 20; //place planet back at top of panel
            area4.X = 20; //place planet back at top of panel
            area5.Y = 20; //place planet back at top of panel
            area6.X = 20; //place planet back at top of panel
            area7.Y = 20; //place planet back at top of panel
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
           
            area1.Y = 20; //place planet back at top of panel
            area2.X = 20; //place planet back at top of panel
            area3.Y = 20; //place planet back at top of panel
            area4.X = 20; //place planet back at top of panel
            area5.Y = 20; //place planet back at top of panel
            area6.X = 20; //place planet back at top of panel
            area7.Y = 20; //place planet back at top of panel


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 1 && e.KeyChar < 222)//A, B, C or D entered
            {

                if (e.KeyChar > 12 && e.KeyChar < 14)//A, B, C or D entered
                {
                    textBox1.Enabled = false;//deny access to textbox when program runs
                    LblLives.Focus();//focus on TxtLives
                   
                }
            }
            else
            {
                MessageBox.Show("Please enter A, B, C or D Only", "Error");
                //event handler is set to true, user input is suppressed and not reflected in the text box
                e.Handled = true;
                LblLives.Focus();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string context = textBox1.Text;
          
            //for loop checks for letters as characters are entered
          

            

            // if not a letter clear the textbox and focus on it
            // to enter name again
            
        }

        private void LblLives_TextChanged(object sender, EventArgs e)
        {

        }

        private void LblLives_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar > 48 && e.KeyChar < 54)// entered 1, 2, 3,4 or 5
            {
                LblLives.Enabled = false;// stop player entering lives after game has started
                startToolStripMenuItem.Enabled = true;//enable player to click Start to strat game
                startToolStripMenuItem.Visible = true;

            }
            else// didn't enter 1, 2, 3, 4 or 5
            {
                MessageBox.Show("Please enter Numbers 1 to 5 only", "Error");
                e.Handled = true;
                LblLives.Focus();
            }
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
            textBox1.Focus();

        }
        private void CheckLives()
        {
            LblLives.Text = lives.ToString();//show lives on form
            if (lives == 0)
            {
                
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
                else
                {
                    // Do somethi
                }

            }
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the methods from the graphic's class to paint on the panel
            g = e.Graphics;
            //use the DrawImage method to draw the spaceship on the panel
            g.DrawImage(Point, recPoint);
            g.DrawImage(Vehicle, area);//use the DrawImage method to draw the planet on the panel
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
            area1.Y += speed.Next(3, 9); //move planet1 down the Game panel at a speed between 5 and 10
            area2.X += speed.Next(3, 9);
            area3.Y += speed.Next(3, 9);
            area4.X += speed.Next(3, 9);
            area5.Y += speed.Next(3, 9);
            area6.X += speed.Next(3, 9);
            area7.Y += speed.Next(3, 9);
            PnlGame.Invalidate();

            if (area1.Y > PnlGame.Height)
            {
                area1.Y = 0; //place planet back at top of panel
            }
            if (area2.X > PnlGame.Width)
            {
                area2.X = 0; //place planet back at top of panel
            }
            if (area3.Y > PnlGame.Height)
            {
                area3.Y = 0; //place planet back at top of panel
            }
            if (area4.X > PnlGame.Width)
            {
                area4.X = 0; //place planet back at top of panel
            }
            if (area5.Y > PnlGame.Height)
            {
                area5.Y = 0; //place planet back at top of panel
            }
            if (area6.X > PnlGame.Width)
            {
                area6.X = 0; //place planet back at top of panel
            }
            if (area7.Y > PnlGame.Height)
            {
                area7.Y = 0; //place planet back at top of panel
            }
            if (score >= 5)
            {
                TmrTire.Interval = 70;
            }
            if (score >= 7)
            {
                TmrTire.Interval = 65;
            }
            if (score >= 10)
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
            if (left) //if left arrow pressed
                if (area.X < -10)//check to see if spaceship is within 10 of left side
                {
                    area.X = 380;//if it is within 10 from side bounce it to 10 away
                }
                else
                {
                    area.X -= 10; //else move 5 to the left

                }
            if (right) //if right arrow pressed
            {
                if (area.X > PnlGame.Width - -10)// is spaceship within 40 of right side of panel
                {
                    area.X = PnlGame.Width - 380;
                }
                else
                {
                    area.X += 10;
                }
            }
            if (up) //if right arrow pressed
            {
                if (area.Y < PnlGame.Height - 380)// is spaceship within 40 of right side of panel
                {
                    area.Y = PnlGame.Height - 10;
                }
                else
                {
                    area.Y -= 10;
                }
            }
            if (down) //if right arrow pressed
            {
                if (area.Y > PnlGame.Height - 10)// is spaceship within 40 of right side of panel
                {
                    area.Y = PnlGame.Height - 380;
                }
                else
                {
                    area.Y += 10;
                }
            }
            //if spaceship collides with any planet lose a life and move plane to the top of the panel
            if (area.IntersectsWith(area1))
            {
                area1.Y = 0; //move planet to top of panel
                lives -= 1; // reduce lives by 1
                CheckLives();
            }
            if (area.IntersectsWith(area2))
            {
                area2.X = 0; //move planet to top of panel
                lives -= 1; // reduce lives by 1
                CheckLives();
            }
            if (area.IntersectsWith(area3))
            {
                area3.Y = 0; //move planet to top of panel
                lives -= 1; // reduce lives by 1
             
                CheckLives();
            }
            if (area.IntersectsWith(area4))
            {
                area4.X = 0; //move planet to top of panel
                lives -= 1; // reduce lives by 1

                CheckLives();
            }
            if (area.IntersectsWith(area5))
            {
                area5.Y = 0; //move planet to top of panel
                lives -= 1; // reduce lives by 1
      
                CheckLives();
            }
            if (area.IntersectsWith(area6))
            {
                lives -= 1; // reduce lives by 1
                area6.X = 0; //move planet to top of panel
                CheckLives();
            }
            if (area.IntersectsWith(area7))
            {
                area7.Y = 0; //move planet to top of panel
                lives -= 1; // reduce lives by 1
                CheckLives();
            }
            if (area.IntersectsWith(recPoint))
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                recPoint.X = rand.Next(240);
                recPoint.Y = rand.Next(240);
            }
        }

    }

}

