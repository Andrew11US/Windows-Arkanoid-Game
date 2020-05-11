using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid_Game_Csharp
{
    public partial class GameForm : Form
    {
        // Game objects
        private Ball ball;
        private Paddle paddle;
        private List<Brick> bricks = new List<Brick>();
        // Game metrics
        private int bricksCount = 0;
        public int level = 1;
        public int lives = 3;
        public int levelScore = 0;
        public int score = 0;
        public GameForm()
        {
            InitializeComponent();
            ClientSize = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
            resetScene(true);
        }

        // Resets scene depending on isNewLevel generates new set of bricks or returns one that already exists
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

        // Form Paint method using paint arguments
        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            // Updating metrics labels for scores and lives
            SetUI(e);

            // MARK: Ball hits left or right edge
            if (ball.x < 0 || ball.x + ball.width > Const.WINDOW_WIDTH)
            {
                ball.xDirection *= -1;
            }

            // MARK: Ball hits a top edge
            if (ball.y < 0)
            {
                ball.yDirection *= -1;
            }

            // MARK: Ball hits a paddle on top of the platform or on one of the sides
            if (ball.ToRectangle.IntersectsWith(paddle.ToRectangle))
            {
                if (ball.x + ball.size < paddle.x + 10)
                {
                    ball.xDirection *= -1;
                }
                else if (ball.x > paddle.x + paddle.width - 10)
                {
                    ball.xDirection *= -1;
                }

                ball.yDirection *= -1;
            }

            // MARK: Ball crosses a bottom edge
            if (ball.y > Const.WINDOW_WIDTH)
            {
                lives -= 1;
                if (lives > 0)
                {
                    resetScene(false);
                }
                else
                {
                    timer.Enabled = false;
                    Game.End(score);
                }
            }

            // MARK: Ball hits one or multiple blocks, handling collision
            bricks.ForEach(brick => {
                if (!brick.destroyed)
                {
                    e.Graphics.FillRectangle(Brushes.White, brick.ToRectangle);
                    e.Graphics.DrawRectangle(Pens.DarkGray, brick.ToRectangle);
                }
                // Handling all 4 sides of collisions ball with brick
                if (!brick.destroyed && ball.ToRectangle.IntersectsWith(brick.ToRectangle))
                {
                    brick.destroyed = true;
                    if (ball.x + ball.size < brick.x + 5)
                    {
                        ball.xDirection *= -1;
                    }
                    else if (ball.x > brick.x + brick.width - 5)
                    {
                        ball.xDirection *= -1;
                    }
                    else if (ball.y + ball.size < brick.y + 5)
                    {
                        ball.yDirection *= -1;
                    }
                    else if (ball.y > brick.y + brick.height - 5)
                    {
                        ball.yDirection *= -1;
                    }
                    else
                    {
                        ball.xDirection *= -1;
                        ball.yDirection *= -1;
                    }
                    levelScore++;
                    score++;
                  
                }
            });
            // Level passed handling
            if (levelScore == bricksCount)
            {
                level += 1;
                levelScore = 0;

                if (lives != 5)
                {
                    lives += 1;
                }
     
                resetScene(true);
            }
        }

        // UI setup of metrics info labels using paint arguments and Graphics
        private void SetUI(PaintEventArgs e)
        {
            string levelOutput = string.Format("Level {0}: {1}", level, levelScore);
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
            e.Graphics.DrawString(levelOutput, new Font("Calibri", 16), Brushes.White, 10, 10);
            e.Graphics.DrawString("Score: " + score, new Font("Calibri", 16), Brushes.White, Const.WINDOW_WIDTH / 2 - 30, 10);
            e.Graphics.DrawString("Lives: " + lives, new Font("Calibri", 16), Brushes.White, Const.WINDOW_WIDTH - 80, 10);

            e.Graphics.FillRectangle(Brushes.White, paddle.ToRectangle);
            if (timer.Enabled) e.Graphics.FillEllipse(Brushes.Aqua, ball.ToRectangle);
            else e.Graphics.FillEllipse(Brushes.White, ball.ToRectangle);
        }

        // MARK: Timer tick method repeats every n ms
        private void timer_Tick(object sender, EventArgs e)
        {
            // MARK: Constantly updates ball position in certain direction and speed
            ball.x += ball.xDirection * ball.speed;
            ball.y += ball.yDirection * ball.speed;
            // Cause UI to be repainted
            Invalidate();
        }

        // Key pressed method using event arguments
        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            // MARK: Start game or pause
            if (e.KeyData == Keys.Space)
            {
                timer.Enabled = !timer.Enabled;
                Invalidate();
            }
            // MARK: Paddle left direction
            if (e.KeyData == Keys.A && paddle.x > 0)
            {
                if (timer.Enabled)
                {
                    paddle.x -= 20;
                    Invalidate();
                }
            }
            // MARK: Paddle right direction
            if (e.KeyData == Keys.D && paddle.x + paddle.width < Const.WINDOW_WIDTH)
            {
                if (timer.Enabled)
                {
                    paddle.x += 20;
                    Invalidate();
                }
            }
        }
        // Form closed method -> exit with code 0 on form close
        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
