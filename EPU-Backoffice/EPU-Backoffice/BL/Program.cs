// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Windows.Forms;
    using EPUBackoffice.Gui;
    using Logger;

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
             * Implements error logging.
             * Configure all appenders.
             * Get logging level out of App.config.
             */
            FileAppender filelogger = new FileAppender();
            filelogger.Configure();

            Logger logger = Logger.Instance;
            AppSettingsReader config = new AppSettingsReader();
            Logger.Loggerlevel = (int)config.GetValue("LoggerLevel", typeof(int));

            logger.Log(Logger.Level.Info, "-----------------------------------------------------------");
            logger.Log(Logger.Level.Info, "Program is started.");

            logger.Log(Logger.Level.Info, "Logging level: " + Logger.Loggerlevel);

            /***
             * Checks data base existance and creates if needed.
             */
            ConfigFileManager cfm = new ConfigFileManager();
            bool exists = false;

            try
            {
                // Check if mock database shall be used. Result is stored in var ConfigFileManager.mockDB
                cfm.UsingMockDatabase();

                // Save info in logfile
                if (ConfigFileManager.MockDB == true)
                { 
                    logger.Log(0, "Using mock database."); 
                }
                else 
                { 
                    logger.Log(0, "Using SQLite database."); 
                }

                exists = cfm.CheckDataBaseExistance();
            }
            // probably syntax error in config file - see logfile
            catch (System.Configuration.ConfigurationErrorsException)
            {
                Application.Exit();
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