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
            DataBaseConnector dbc = new DataBaseConnector();
            bool exists = dbc.checkDataBaseExistance();
            if (!exists)
            {
                // show info-form and ask for user input
                // ask user for path
                // give path or create new? -> input window
                // do the following in an eventhandler!!
                //create new database (if user has not given path)
                bool create = false;
                if (create)
                {
                    dbc.createDataBase();
                    dbc.setDatabasePath();
                }
            }
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
