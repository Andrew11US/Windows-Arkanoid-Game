using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arkanoid_Game_Csharp
{
    public abstract class Block
    {
        public int x;
        public int y;
        public int width;
        public int height;
        public Block(int x, int y, int width, int height)
        {
            this.width = width;
            this.height = height;
            this.x = x;
            this.y = y;
        }

        // MARK: Converts object instance to Rectangle object
        public Rectangle ToRectangle()
        {
            return new Rectangle(new Point(x, y), new Size(width, height));
        }
    }
}
