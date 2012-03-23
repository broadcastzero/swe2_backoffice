// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using EPUBackoffice.Gui;

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
            ConfigFileManager cfm = new ConfigFileManager();
            bool exists = false;

            try
            {
                // Check if mock databse shall be used. Result is stored in var ConfigFileManager.mockDB
                cfm.UsingMockDatabase();

                // Save info in logfile
                if (ConfigFileManager.mockDB == true)
                { Debug.WriteLine("Using mock database"); }
                else { Debug.WriteLine("Using SQLite database"); }

                exists = cfm.CheckDataBaseExistance();
            }
            // probably syntax error in config file - see logfile
            catch (System.Configuration.ConfigurationErrorsException)
            {
                Environment.Exit(1);
            }
            
            // Open window, which one depends on whether the database has been found or not
            if (!exists)
            {
                Application.Run(new DBNotFoundForm());                 
            }
            else // database found. Start with home screen.
            {
                Application.Run(new HomeForm());
            }
        }
    }
}