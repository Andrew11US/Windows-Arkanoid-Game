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
            setUI();
        }

        private void setUI()
        {
            ClientSize = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
            nameLbl.Text = "Arkanoid v0.9";
            flowLayoutPanel1.Size = new Size(Const.WINDOW_WIDTH - 15, Const.WINDOW_HEIGHT);
            nameLbl.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 4);
            newGameBtn.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 4);
            scoreboardBtn.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 4);
            exitBtn.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 4);

            newGameBtn.FlatAppearance.BorderSize = 0;
            scoreboardBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatAppearance.BorderSize = 0;
        }

        private void newGameBtn_Click(object sender, EventArgs e)
        {
            GameForm gameForm = new GameForm();
            gameForm.Show();
            Visible = false;
            Game.endGame(12);
            
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

        // MARK: Mouse hover stub
        private void newGameBtn_MouseEnter(object sender, EventArgs e)
        {
            newGameBtn.BackColor = Color.DarkGray;
        }

        private void newGameBtn_MouseLeave(object sender, EventArgs e)
        {
            newGameBtn.BackColor = Color.Transparent;
        }

        private void scoreboardBtn_MouseEnter(object sender, EventArgs e)
        {
            scoreboardBtn.BackColor = Color.DarkGray;
        }

        private void scoreboardBtn_MouseLeave(object sender, EventArgs e)
        {
            scoreboardBtn.BackColor = Color.Transparent;
        }

        private void exitBtn_MouseEnter(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.DarkGray;
        }

        private void exitBtn_MouseLeave(object sender, EventArgs e)
        {
            exitBtn.BackColor = Color.Transparent;
        }
    }
}
