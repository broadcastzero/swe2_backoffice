using System;
using System.Collections.Generic;
using System.Configuration;
using System.Windows.Forms;
using EPU_Backoffice_Panels;
using EPU_Backoffice_Panels.BL;
using EPU_Backoffice_Panels.Logger;
using EPU_Backoffice_Panels.UserExceptions;

namespace EPU_Backoffice
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

            /***
             * Implements error logging.
             * Configure all appenders.
             * Get logging level out of App.config.
             */
            Logger logger = Logger.Instance;

            // Create file appender for logging
            FileAppender filelogger = new FileAppender();
            filelogger.Configure();

            // Add all logger appenders to static list
            Logger.Appenders.Add(filelogger);

            // Get logging level out of config file
            AppSettingsReader config = new AppSettingsReader(); // Settings.Default.
            Logger.Loggerlevel = (int)config.GetValue("LoggerLevel", typeof(int));

            // Program startup logging
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
                    logger.Log(Logger.Level.Info, "Using mock database.");
                }
                else
                {
                    logger.Log(Logger.Level.Info, "Using SQLite database.");
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
