﻿using System;
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
            Invalidate();
        }

        private void GameForm_Paint(object sender, PaintEventArgs e)
        {
            setUI(e);

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
            if (ball.ToRectangle().IntersectsWith(paddle.ToRectangle()))
            {
                if (ball.x + ball.size < paddle.x + 10)
                {
                    ball.xDirection *= -1;
                    //System.out.println("Left side intersection");
                }
                else if (ball.x > paddle.x + paddle.width - 10)
                {
                    ball.xDirection *= -1;
                    //System.out.println("Right side intersection");
                }

                ball.yDirection *= -1;
            }

            // MARK: Ball crosses bottom edge
            if (ball.y > Const.WINDOW_WIDTH)
            {
                lives -= 1;
                if (lives != 0)
                {
                    resetScene(false);
                }
                else
                {
                    
                    
                    //  call gameOver method
                    
                }
            }

            // MARK: Ball hits one or multiple blocks, handling collision
            bricks.ForEach(brick => {
                if (!brick.destroyed)
                {
                    e.Graphics.FillRectangle(Brushes.White, brick.ToRectangle());
                    e.Graphics.DrawRectangle(Pens.DarkGray, brick.ToRectangle());
                }

                if (!brick.destroyed && ball.ToRectangle().IntersectsWith(brick.ToRectangle()))
                {
                    brick.destroyed = true;
                    if (ball.x + ball.size < brick.x + 5)
                    {
                        ball.xDirection *= -1;
                        //System.out.println("Left side hit");
                    }
                    else if (ball.x > brick.x + brick.width - 5)
                    {
                        ball.xDirection *= -1;
                        //System.out.println("Right side hit");
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

        private void setUI(PaintEventArgs e)
        {
            string levelOutput = string.Format("Level {0}: {1}", level, levelScore);
            e.Graphics.FillRectangle(Brushes.Black, 0, 0, Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
            e.Graphics.DrawString(levelOutput, new Font("Calibri", 16), Brushes.White, 10, 10);
            e.Graphics.DrawString("Score: " + score, new Font("Calibri", 16), Brushes.White, Const.WINDOW_WIDTH / 2 - 30, 10);
            e.Graphics.DrawString("Lives: " + lives, new Font("Calibri", 16), Brushes.White, Const.WINDOW_WIDTH - 80, 10);

            e.Graphics.FillRectangle(Brushes.White, paddle.ToRectangle());
            if (timer.Enabled) e.Graphics.FillEllipse(Brushes.Aqua, ball.ToRectangle());
            else e.Graphics.FillEllipse(Brushes.White, ball.ToRectangle());
        }

        // MARK: Timer tick method repeats every n ms
        private void timer_Tick(object sender, EventArgs e)
        {
            // MARK: Constantly updates ball position in certain direction and speed
            ball.x += ball.xDirection * ball.speed;
            ball.y += ball.yDirection * ball.speed;
            Invalidate();
        }

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

        private void GameForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult result = MessageBox.Show("Do you really want to exit?", "Arkanoid", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    Environment.Exit(0);
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
    }
        
    
}
