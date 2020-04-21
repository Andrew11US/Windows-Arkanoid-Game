using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid_Game_Csharp
{
    class Game
    {
        public static MenuForm menuForm;
        private static GameForm gameForm;
        private static ScoreboardForm scoreboardForm;

        // MARK: Starts game directly from Game class
        public static void Start()
        {
            gameForm = new GameForm();
            gameForm.Show();
            menuForm.Hide();
        }

        // MARK: Opens Scoreboard directly from Game class
        public static void ShowScores()
        {
            scoreboardForm = new ScoreboardForm();
            scoreboardForm.Show();
            menuForm.Hide();
        }
        // MARK: Gets score and writes it to scores.txt tile, creates file if it doesn't exist
        public static void End(int score)
        {
            string scoreStr;
            string name = "";
            ShowInputDialog(ref name, score);

            if (name.Trim().Length > 0) scoreStr = score + " " + name;
            else scoreStr = score + " " + "Player X";

            using (StreamWriter streamWriter = File.AppendText("scores.txt"))
            {
                streamWriter.WriteLine(scoreStr);
            }

            menuForm.Show();
            gameForm.Hide();
            gameForm = null;
        }

        // MARK: Custom DialogBox with a input field to provide name 
        private static DialogResult ShowInputDialog(ref string input, int score)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 120);
            Form inputBox = new Form();

            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Arkanoid";

            Label label1 = new Label();
            label1.Size = new System.Drawing.Size(size.Width - 10, 50);
            label1.Location = new System.Drawing.Point(5, 5);
            label1.Text = "Game Over!" + Environment.NewLine + "Your score is: " + score + Environment.NewLine + "Enter your name below";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            inputBox.Controls.Add(label1);

            TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 25);
            textBox.Location = new System.Drawing.Point(5, 55);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 25);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(20, 80);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 25);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 95, 80);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

    }
}
