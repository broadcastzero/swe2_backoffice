using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            Form1 startscreen = new Form1();
            /***
             * Inplements error logging.
             * Debug.WriteLines will be stored in logfile only in Debug-Mode.
             * Trace.WriteLines will be stored in logfile in Debug AND Release Mode.
             * see http://support.microsoft.com/kb/815788 for further information.
             */
            TextWriterTraceListener tr1 = new TextWriterTraceListener(System.IO.File.CreateText("Logfile.txt"));
            Trace.Listeners.Add(tr1);
            Trace.AutoFlush = true;

            /***
             * Checks data base existance and creates if needed.
             */
            DataBaseConnector dbc = new DataBaseConnector();
            bool exists = dbc.checkDataBaseExistance();
            if (!exists)
            {
                // show info-form and ask for user input
                // ask user for path
                //while (exists == false)
                {
                    string path = "backoffice_database.db";
                    exists = dbc.checkDataBaseExistance(path);
                    if (exists == true)
                    { dbc.setDatabasePath(path); }
                }
                // give path or create new? -> input window
                // do the following in an eventhandler!!
                //create new database (if user has not given path)
                bool create = false;
                if (create)
                {
                    dbc.createDataBase();
                }
                Application.Run(startscreen);  
            }
            else // database found. Start with home screen.
            {
                Application.Run(startscreen);
            }
        }
    }
}
