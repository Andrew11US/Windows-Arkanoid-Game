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
        public int level = 1;
        public int lives = 3;
        public int levelScore = 0;
        public int score = 0;

        public int x = 10, y = 10;
        public GameForm()
        {
            InitializeComponent();
            resetScene(true);
            KeyPreview = true;

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


        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 3;
            Invalidate();

        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            // MARK: Constantly updates ball position in certain direction and speed
            ball.x += ball.xDirection * ball.speed;
            ball.y += ball.yDirection * ball.speed;

            e.Graphics.FillEllipse(Brushes.Red, ball.ToRectangle());
            e.Graphics.FillRectangle(Brushes.Red, paddle.ToRectangle());
            bricks.ForEach(brick =>
            {
                if (!brick.destroyed)
                {
                    e.Graphics.FillRectangle(Brushes.BlueViolet, brick.ToRectangle());
                }

                if (brick.ToRectangle().IntersectsWith(ball.ToRectangle()))
                {
                    brick.destroyed = true;
                }

            });
            //Rectangle r1 = new Rectangle(new Point(x, y), new Size(50, 50));
            //Rectangle r2 = new Rectangle(new Point(100, 10), new Size(50, 50));
            //if (r1.IntersectsWith(r2))
            //{
            //    Console.WriteLine("Intersection");
            //    r2.Y = 200;
            //}
            //e.Graphics.FillRectangle(new SolidBrush(Color.Green), r);
            //e.Graphics.FillEllipse(Brushes.Black, r1);
            //e.Graphics.FillRectangle(Brushes.Black, r2);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void GameForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (e. == Keys.Right)
            //{

            //}
        }

        private void GameForm_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.D)
            {
                paddle.x += 20;
                Invalidate();
            }
            else if (e.KeyData == Keys.A)
            {
                paddle.x -= 20;
                Invalidate();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled;
            //Invalidate();
        }
    }
        
    
}
