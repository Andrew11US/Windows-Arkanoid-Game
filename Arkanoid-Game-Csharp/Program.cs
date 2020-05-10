using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arkanoid_Game_Csharp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //MARK: Assigning initial MenuForm to Game singleton to better handle windows changing
            Game.menuForm = new MenuForm();

            Application.Run(Game.menuForm);
        }
    }
}
