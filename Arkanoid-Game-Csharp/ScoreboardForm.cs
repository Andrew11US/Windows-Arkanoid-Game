using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
            SetUI();
            ShowScores();
        }

        private void SetUI()
        {
            ClientSize = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT);
            flowLayoutPanel1.Size = new Size(Const.WINDOW_WIDTH - 15, Const.WINDOW_HEIGHT);
            closeBtn.Size = new Size(Const.WINDOW_WIDTH, Const.WINDOW_HEIGHT / 15);
            nameLbl.Height = Const.WINDOW_HEIGHT / 4;
            scoreboardTextBox.Height = Const.WINDOW_HEIGHT - ((Const.WINDOW_HEIGHT / 15) + (Const.WINDOW_HEIGHT / 7));

            closeBtn.FlatAppearance.BorderSize = 0;
        }

        private void ShowScores()
        {
            List<string> scores = new List<string>();

            // MARK: Reading scores from scores.txt using StreamReader
            try
            {
                using (StreamReader streamReader = new StreamReader("scores.txt"))
                {
                    string line;
                    while ((line = streamReader.ReadLine()) != null && line.Trim() != String.Empty)
                    {
                        scores.Add(line);
                    }
                }
            } catch (FileNotFoundException e)
            {
                scores.Add("Nothing to show");
            }
            

            // MARK: Using custom comparer to sort scores descending by String score part
            scores.Sort(new ScoresComparer().Compare);
            scores.Reverse();

            foreach (string score in scores)
            {
                scoreboardTextBox.AppendText(score+Environment.NewLine);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            Close();
            Game.menuForm.Show();
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

    // MARK: Custom comparer to sort scores by part of a string
    public class ScoresComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            int space1 = x.ToString().IndexOf(" ");
            int space2 = y.ToString().IndexOf(" ");
            int a, b;
            int.TryParse(x.ToString().Substring(0, space1), out a);
            int.TryParse(y.ToString().Substring(0, space2), out b);
            return a.CompareTo(b);
        }
    }
}
