using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid_Game_Csharp
{
    public partial class GameForm : Form
    {
        private Ball ball;
        private Paddle paddle;
        private List<Brick> bricks = new List<Brick>();
        //private Image image;
        //private Thread thread;
        // Pauses the game, changing the ball.speed to 0, (recoverable action)
        //private boolean isPaused = true;
        // Stops the game breaking while loop, not recoverable!
        //private boolean isRunning = true;
        private int bricksCount = 0;
        public int level = 10;
        public int lives = 3;
        public int levelScore = 0;
        public int score = 0;

        public int x = 10, y = 10;
        public GameForm()
        {
            InitializeComponent();
            resetScene(true);


        }

        private void resetScene(bool isNewLevel)
        {
            ball = new Ball();
            paddle = new Paddle();

            if (isNewLevel)
            {
                levelScore = 0;
                bricksCount = 0;
                //*/
                for (int i = 1; i < 8; ++i)
                {
                    for (int j = 1; j < 2 + ((level - 1) % 10); ++j)
                    {
                        bricks.Add(new Brick(i * (Const.BRICK_WIDTH + 10), j * (Const.BRICK_HEIGHT + 10)));
                        bricksCount++;
                    }
                }
                /*/
                for(int i = 2; i < 3; ++i) {
                    for(int j = 2; j < 3; ++j) {
                        bricks.Add(new Brick(i*120,j*40));
                        bricksCount++;
                    }
                }
                //*/
            }
        }

        // MARK: corresponds to Java : updateUI 
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            List<Rectangle> br = new List<Rectangle>();

            bricks.ForEach(brick => br.Add(new Rectangle(new Point(brick.x, brick.y), new Size(brick.width, brick.height))));
            Rectangle r1 = new Rectangle(new Point(x, y), new Size(50, 50));
            Rectangle r2 = new Rectangle(new Point(100, 10), new Size(50, 50));
            if (r1.IntersectsWith(r2))
            {
                Console.WriteLine("Intersection");
                r2.Y = 200;
            }
            //e.Graphics.FillRectangle(new SolidBrush(Color.Green), r);
            e.Graphics.FillEllipse(Brushes.Black, r1);
            e.Graphics.FillRectangle(Brushes.Black, r2);
            br.ForEach(b => e.Graphics.FillRectangle(Brushes.Blue, b));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 3;
            Invalidate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Enabled = !timer1.Enabled;
        }
    }
        
    
}
