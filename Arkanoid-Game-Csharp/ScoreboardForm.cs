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
            setUI();
        }

        private void setUI()
        {
            ClientSize = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
            flowLayoutPanel1.Size = new Size(Const.WINDOW_WIDTH - 15, Const.WINDOW_HEIGHT);
            closeBtn.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 15);
            nameLbl.Height = Const.WINDOW_HEIGHT / 4;
            scoreboardTextBox.Height = Const.WINDOW_HEIGHT - ((Const.WINDOW_HEIGHT / 15) + (Const.WINDOW_HEIGHT / 7));

            closeBtn.FlatAppearance.BorderSize = 0;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.DarkGray;
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.Transparent;
        }
    }
}
