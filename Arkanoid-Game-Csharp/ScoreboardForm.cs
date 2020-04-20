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
    public partial class ScoreboardForm : Form
    {
        public ScoreboardForm()
        {
            InitializeComponent();
            ClientSize = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
