﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_Game_Csharp
{
    public class Ball : Block
    {
        public int xDirection;
        public int yDirection;
        public int speed = 1;
        public int size;
        Random random = new Random();
        public Ball(int x, int y, int width, int height) : base(Const.WINDOW_WIDTH / 2, Const.WINDOW_HEIGHT / 2, Const.BALL_SIZE, Const.BALL_SIZE)
        {
            xDirection = 1;
            yDirection = -1;
            size = width;

            // MARK: generating random ball position
            int rightBound = (Const.WINDOW_WIDTH / 2) + Const.PADDLE_WIDTH;
            int leftBound = (Const.WINDOW_WIDTH / 2) - Const.PADDLE_WIDTH;
            int topBound = Const.WINDOW_HEIGHT - 200;
            int bottomBound = Const.WINDOW_HEIGHT - 80;

            x = random.Next((rightBound - leftBound)) + leftBound;
            y = random.Next((bottomBound - topBound)) + topBound;
        }

        public void Paint(Graphics g)
        {
            if (speed == 0)
            {
                //g.setColor(Color.Gray);
                //g.FillEllipse()
            }
            else
            {
                //g.setColor(Color.GREEN);
            }

            //g.fillOval(x, y, Const.BALL_SIZE, Const.BALL_SIZE);
        }

    }
}