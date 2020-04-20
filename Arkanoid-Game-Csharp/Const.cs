using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_Game_Csharp
{
    /**
    * SSOT principle - Single Source of Truth
    * Dedicated class to store essential constants:
    * Window size; Ball, Paddle, Brick sizes; move speed, etc.
    */
    public class Const
    {
        // MARK: App constants
        public static readonly int WINDOW_WIDTH = 530;
        public static readonly int WINDOW_HEIGHT = 530;

        // MARK: Game constants
        public static readonly int BALL_SIZE = 20;
        public static readonly int PADDLE_WIDTH = 120;
        public static readonly int PADDLE_HEIGHT = 10;
        public static readonly int BRICK_WIDTH = 50;
        public static readonly int BRICK_HEIGHT = 30;
        public static readonly int GAME_SPEED = 6;
    }
}
