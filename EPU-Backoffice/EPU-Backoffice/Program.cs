using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using EPUBackoffice.Dal;

namespace EPUBackoffice
{
    /// <summary>
    /// The main entry class of the application.
    /// </summary>
    static class Program
    {
        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            DataBaseConnector dbc = new DataBaseConnector();
            Console.ReadLine();
        }
    }
}
