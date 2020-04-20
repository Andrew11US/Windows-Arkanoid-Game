using System;
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
    public partial class Form1 : Form
    {
        private Graphics graphics;
        private Bitmap histogramImage;
        private Panel graphicsPanel = new Panel();
        public int x = 10, y = 10;
        public Form1()
        {
            InitializeComponent();

            ClientSize = new Size(276, 276);
            graphicsPanel.Paint += new PaintEventHandler(graphicsPanel_Paint);
            graphicsPanel.Size = new Size(256, 256);
            graphicsPanel.Left = 10;
            graphicsPanel.Top = 10;

            

            histogramImage = new Bitmap(512, 256);
            Graphics graphicsImage = Graphics.FromImage(histogramImage);

            graphicsImage.Clear(Color.Black);
            
            graphicsImage.DrawRectangle(new Pen(Color.Black, 5), new Rectangle(new Point(20, 20), new Size(50, 50)));
            graphics = graphicsPanel.CreateGraphics();
        }

        private void graphicsPanel_Paint(object sender, PaintEventArgs e)
        {
            //graphics.DrawImage(histogramImage, new Point());
            //for (int i = 0; i < 10; i++)
            //{
            //    Rectangle r = new Rectangle(new Point(i, i), new Size(50, 50));
            //    //e.Graphics.DrawRectangle(new Pen(Color.Black, 5), r);
            //    e.Graphics.FillRectangle(new SolidBrush(Color.Red), r);
            //    this.Invalidate(r);
            //}
            
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r1 = new Rectangle(new Point(x, y), new Size(50, 50));
            Rectangle r2 = new Rectangle(new Point(100, 10), new Size(50, 50));
            if (r1.IntersectsWith(r2))
            {
                Console.WriteLine("Intersection");
                r2.Y = 200;
            }
            //e.Graphics.FillRectangle(new SolidBrush(Color.Green), r);
            e.Graphics.FillRectangle(Brushes.Black, r1);
            e.Graphics.FillRectangle(Brushes.Black, r2);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            x += 10;
            Invalidate();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Update();
            
        }
    }
        
    
}
