using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodgekhana2
{

    public partial class FrmDodge : Form
    {
        Rectangle recPoint = new Rectangle(0, 0, 50, 65);
        Image Point = Image.FromFile(Application.StartupPath + @"\Vehicle.jpg");
        Graphics g; // declare the graphics object
        Random rand = new Random();
        Random speed = new Random();
        int x = 20, y = 20;// starting position of tire
        int x2 = 50, y2 = 290; // starting position of spaceship
        // Declare the rectangles to display the spaceship and planets in
        Rectangle area, area1, area2, area3, area4, area5, area6, area7, point;
        int score = 0;
        int lives = 5;
        // load the spaceship and one planet
        Image Vehicle = Image.FromFile(Application.StartupPath + @"\Vehicle.jpg");

        private void LblLives_Click(object sender, EventArgs e)
        {

        }

        Image Tire = Image.FromFile(Application.StartupPath + @"\Tire.png");
        bool left, right, up, down;
        public FrmDodge()
        {
            InitializeComponent();
            area = new Rectangle(x2, y2, 30, 30);
            area1 = new Rectangle(x, y, 20, 20);
            area2 = new Rectangle(x, y + 30, 20, 20);
            area3 = new Rectangle(x + 100, y, 20, 20);
            area4 = new Rectangle(x, y + 140, 20, 20);
            area5 = new Rectangle(x + 200, y, 20, 20);
            area6 = new Rectangle(x, y + 240, 20, 20);
            area7 = new Rectangle(x + 300, y, 20, 20);
           recPoint = new Rectangle(x + 300, y, 20, 20);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
        private void CheckLives()
        {
            if (lives == 0)
            {
                TmrTire.Enabled = false;
                TmrVehicle.Enabled = false;
                MessageBox.Show("Game Over");

            }
        }

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the methods from the graphic's class to paint on the panel
            g = e.Graphics;
            //use the DrawImage method to draw the spaceship on the panel
            g.DrawImage(Vehicle, area);//use the DrawImage method to draw the planet on the panel
            g.DrawImage(Tire, area1);
            g.DrawImage(Tire, area2);
            g.DrawImage(Tire, area3);
            g.DrawImage(Tire, area4);
            g.DrawImage(Tire, area5);
            g.DrawImage(Tire, area6);
            g.DrawImage(Tire, area7);
            g.DrawImage(Point, recPoint);
         
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
            PnlGame.Invalidate();//makes the paint event (PnlGame_Paint) fire to draw the panel
            
            if (area1.IntersectsWith(area))
            {
                area1.Y = 20;
                lives -= 1; // reduce lives by 1
                            //display the number of lives on the form
                LblLives.Text = lives.ToString();

                CheckLives();
            }

            if (area1.Y > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area1.Y = 20; //place planet back at top of panel
            }
            if (area2.X > PnlGame.Width)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area2.X = 20; //place planet back at top of panel
            }
            if (area3.Y > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area3.Y = 20; //place planet back at top of panel
            }
            if (area4.X > PnlGame.Width)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area4.X = 20; //place planet back at top of panel
            }
            if (area5.Y > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area5.Y = 20; //place planet back at top of panel
            }
            if (area6.X > PnlGame.Width)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area6.X = 20; //place planet back at top of panel
            }
            if (area7.Y > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area7.Y = 20; //place planet back at top of panel
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
                if (area.X < 0)//check to see if spaceship is within 10 of left side
                {
                    area.X = 0;//if it is within 10 from side bounce it to 10 away
                }
                else
                {
                    area.X -= 5; //else move 5 to the left

                }
            if (right) //if right arrow pressed
            {
                if (area.X > PnlGame.Width - 0)// is spaceship within 40 of right side of panel
                {
                    area.X = PnlGame.Width - 0;
                }
                else
                {
                    area.X += 5;
                }
            }
            if (up) //if right arrow pressed
            {
                if (area.X > PnlGame.Height - 0)// is spaceship within 40 of right side of panel
                {
                    area.Y = PnlGame.Height - 0;
                }
                else
                {
                    area.Y -= 5;
                }
            }
            if (down) //if right arrow pressed
            {
                if (area.Y > PnlGame.Height - 0)// is spaceship within 40 of right side of panel
                {
                    area.Y = PnlGame.Height - 0;
                }
                else
                {
                    area.Y += 5;
                }
            }
            //if spaceship collides with any planet lose a life and move plane to the top of the panel
            if (area.IntersectsWith(area1))
            {
                lives -= 1; // reduce lives by 1
                area1.Y = 20; //move planet to top of panel
                CheckLives();
            }
            if (area.IntersectsWith(area2))
            {
                lives -= 1; // reduce lives by 1
                area2.Y = 20; //move planet to top of panel
                CheckLives();
            }
            if (area.IntersectsWith(area3))
            {
                lives -= 1; // reduce lives by 1
                area3.Y = 20; //move planet to top of panel
                CheckLives();
            }
            if (area.IntersectsWith(area4))
            {
                lives -= 1; // reduce lives by 1
                area4.Y = 20; //move planet to top of panel
                CheckLives();
            }
            if (area.IntersectsWith(area5))
            {
                lives -= 1; // reduce lives by 1
                area5.Y = 20; //move planet to top of panel
                CheckLives();
            }
            if (area.IntersectsWith(area6))
            {
                lives -= 1; // reduce lives by 1
                area6.Y = 20; //move planet to top of panel
                CheckLives();
            }
            if (area.IntersectsWith(area7))
            {
                lives -= 1; // reduce lives by 1
                area7.Y = 20; //move planet to top of panel
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

