using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid_Game_Csharp
{
    class Game
    {
        // MARK: Gets score and writes it to scores.txt tile, creates file if it doesn't exist
        public static void endGame(int score)
        {
            string str = "GAME OVER!\nYour Score: " + score + "\n Type your name: ";
            string name = "";
            string scoreStr;

            if (name.Trim().Length > 0)
            {
                scoreStr = Environment.NewLine + score + " " + name;
            }
            else
            {
                scoreStr = score + " " + "Player X";
            }

//            using(StreamWriter writetext = new StreamWriter("write.txt"))
//{
//                writetext.WriteLine(scoreStr);
//            }

            using (StreamWriter streamWriter = File.AppendText("scores.txt"))
            {
                streamWriter.WriteLine(scoreStr);
            }
            string exeFolder = System.IO.Path.GetDirectoryName(Application.ExecutablePath);
            //using (StreamReader readtext = new StreamReader("write.txt"))
            //{
            //    string readText = readtext.ReadLine();
            //}

            //FileStream fs = new FileStream(txtSourcePath.Text, FileMode.Open, FileAccess.Read);
            //using (StreamReader sr = new StreamReader(fs))
            //{
            //    using (StreamWriter sw = new StreamWriter(Destination))
            //    {
            //        sw.writeline("Your text");
            //    }
            //}
        }
            
                
            

            //try
            //{
            //    Files.write(Paths.get("scores.txt"), scoreStr.getBytes(), StandardOpenOption.APPEND);
            //}
            //catch (IOException e)
            //{
            //    try
            //    {
            //        FileOutputStream fileOutputStream = new FileOutputStream(new File("scores.txt"));
            //        fileOutputStream.write(scoreStr.getBytes());
            //        fileOutputStream.close();
            //    }
            //    catch (IOException ex)
            //    {
            //        ex.getStackTrace();
            //    }
            //}

            //initMenu();
        

        
    }
}
