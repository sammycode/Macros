using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VF.Macros.Client
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


            //Application.Run(new Forms.MainForm());

            //MacrosAppContext context = new MacrosAppContext(new Forms.MainForm());
            using (var appContext = new MacrosAppContext())
            {
                Application.Run(appContext);
            }


        }
    }
}
