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
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            ClientSize = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
            flowLayoutPanel1.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();
            this.Visible = false;
        }

        private void scoreboardBtn_Click(object sender, EventArgs e)
        {
            ScoreboardForm scoreboardForm = new ScoreboardForm();
            scoreboardForm.Show();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
