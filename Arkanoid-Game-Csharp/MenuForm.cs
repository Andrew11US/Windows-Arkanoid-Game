using System;
using System.Drawing;
using System.Windows.Forms;

namespace Arkanoid_Game_Csharp
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
            SetUI();
        }

        // UI setup method
        private void SetUI()
        {
            ClientSize = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
            nameLbl.Text = "Arkanoid v1.0.2";
            flowLayoutPanel1.Size = new Size(Const.WINDOW_WIDTH - 15, Const.WINDOW_HEIGHT);
            nameLbl.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 4);
            newGameBtn.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 4);
            scoreboardBtn.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 4);
            exitBtn.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 4);

            newGameBtn.FlatAppearance.BorderSize = 0;
            scoreboardBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatAppearance.BorderSize = 0;

            newGameBtn.Focus();
        }

        // Button actions
        private void newGameBtn_Click(object sender, EventArgs e)
        {
            // Init new game
            Game.Start();
        }

        private void scoreboardBtn_Click(object sender, EventArgs e)
        {
            // Show scores
            Game.ShowScores();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
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
        // Form close method -> exit with code 0
        private void MenuForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
