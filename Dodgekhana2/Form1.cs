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
        Graphics g; // declare the graphics object
        int x = 20, y = 20;// starting position of tire
        Random speed = new Random();
        // Declare the rectangles to display the spaceship and planets in
        Rectangle area, area1, area2, area3, area4, area5, area6, area7;
        int x2 = 50, y2 = 290; // starting position of spaceship

        private void PnlGame_Paint(object sender, PaintEventArgs e)
        {
            //get the methods from the graphic's class to paint on the panel
            g = e.Graphics;
            //use the DrawImage method to draw the spaceship on the panel
            g.DrawImage(Vehicle, area);
            //use the DrawImage method to draw the planet on the panel
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
            area1.Y += speed.Next(5, 11); //move planet1 down the Game panel at a speed between 5 and 10
            area2.X += speed.Next(5, 11);
            area3.Y += speed.Next(5, 11);
            area4.X += speed.Next(5, 11);
            area5.Y += speed.Next(5, 11);
            area6.X += speed.Next(5, 11);
            area7.Y += speed.Next(5, 11);
            PnlGame.Invalidate();//makes the paint event (PnlGame_Paint) fire to draw the panel
            if (area1.X > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area1.X = 20; //place planet back at top of panel
            }
            if (area2.Y > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area2.Y = 20; //place planet back at top of panel
            }
            if (area3.X > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area3.X = 20; //place planet back at top of panel
            }
            if (area4.Y > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area4.Y = 20; //place planet back at top of panel
            }
            if (area5.X > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area5.X = 20; //place planet back at top of panel
            }
            if (area6.Y > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area6.Y = 20; //place planet back at top of panel
            }
            if (area7.X > PnlGame.Height)
            {
                score += 1; // add 1 to score
                LblScore.Text = score.ToString();//display score on the form
                area7.X = 20; //place planet back at top of panel
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        int x3 = 50, y5 = 290; // starting position of spaceship
        int score = 0;
        int lives = 5;

        // load the spaceship and one planet
        Image Vehicle = Image.FromFile(Application.StartupPath + @"\Vehicle.jpg");
        Image Tire = Image.FromFile(Application.StartupPath + @"\Tire.png");
        bool left, right, up, down;
        public FrmDodge()
        {
            InitializeComponent();
            area = new Rectangle(x2, y2, 30, 30);//spaceship's rectangle
            area1 = new Rectangle(x, y, 20, 20);// planet1's rectangle
            area2 = new Rectangle(x + 50, y, 20, 20);// planet2's rectangle
            area3 = new Rectangle(x + 100, y, 20, 20);// planet3's rectangle
            area4 = new Rectangle(x + 150, y, 20, 20);// planet4's rectangle
            area5 = new Rectangle(x + 200, y, 20, 20);// planet5's rectangle
            area6 = new Rectangle(x + 250, y, 20, 20);// planet6's rectangle
            area7 = new Rectangle(x + 300, y, 20, 20);// planet7's rectangle
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
