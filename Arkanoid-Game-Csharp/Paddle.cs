﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_Game_Csharp
{
    // MARK: Paddle class inherited from Block
    public class Paddle : Block
    {
        // Generation Paddle x position in the middle regardless the Window_Size
        public Paddle() : base((Const.WINDOW_WIDTH / 2) - (Const.PADDLE_WIDTH / 2),
                                Const.WINDOW_HEIGHT - 50,
                                Const.PADDLE_WIDTH,
                                Const.PADDLE_HEIGHT)
        { 

        }
    }
}
