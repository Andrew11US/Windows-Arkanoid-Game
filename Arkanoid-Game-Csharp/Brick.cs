using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_Game_Csharp
{
    // MARK: Brick class inherited from Block
    public class Brick : Block
    {
        public bool destroyed = false;
        public Brick(int x, int y) : base(x, y, Const.BRICK_WIDTH, Const.BRICK_HEIGHT) { }
    }
}
