using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_Game_Csharp
{
    // MARK: Ball class inherited from Block
    public class Ball : Block
    {
        public int xDirection;
        public int yDirection;
        public int size;
        public int speed = Const.BALL_SPEED;
        Random random = new Random();
        public Ball() : base(Const.WINDOW_WIDTH / 2, Const.WINDOW_HEIGHT / 2, Const.BALL_SIZE, Const.BALL_SIZE)
        {
            xDirection = 1;
            yDirection = -1;
            size = width;

            // MARK: generating random ball position on ball creation
            int rightBound = (Const.WINDOW_WIDTH / 2) + Const.PADDLE_WIDTH;
            int leftBound = (Const.WINDOW_WIDTH / 2) - Const.PADDLE_WIDTH;
            int topBound = Const.WINDOW_HEIGHT - 200;
            int bottomBound = Const.WINDOW_HEIGHT - 80;

            // Assigning random x and y to properties inherited from Block
            x = random.Next((rightBound - leftBound)) + leftBound;
            y = random.Next((bottomBound - topBound)) + topBound;
        }
    }
}
