using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool flag2 = true;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if(flag2)
                Application.Run(new Form1());
            else
                Application.Run(new Form2(true, "admin"));
        }
    }
}
