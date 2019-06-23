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
    Graphics g; // declare the graphics object
    int x = 20, y = 20;// starting position of tire
    Random speed = new Random();
    // Declare the rectangles to display the spaceship and planets in
    Rectangle area, area1, area2, area3, area4, area5, area6, area7;
    int x2 = 50, y2 = 290; // starting position of spaceship
    int x3 = 50, y5 = 290; // starting position of spaceship
    int score = 0;
    int lives = 5;
    public partial class FrmDodge : Form
    {
        public FrmDodge()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
