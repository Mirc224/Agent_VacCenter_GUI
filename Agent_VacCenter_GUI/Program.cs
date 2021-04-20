using simulation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agent_VacCenter_GUI
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
            Application.Run(new AppGUI());
            Console.WriteLine("Simulating...");

/*            var replikacie = 1000;
            var casReplikacie = 540 * 60;
            //var casReplikacie = 540 * 6000;


            new VacCenterSimulation(null).Simulate(replikacie, casReplikacie);

            Console.WriteLine("Finished...");*/

        }
    }
}
