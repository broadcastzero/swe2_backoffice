// -----------------------------------------------------------------------
// <copyright file="ConfigFileManager.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Text;
    using EPUBackoffice.Dal;
    using Logger;

    /// <summary>
    /// This class reads or writes the config file.
    /// </summary>
    public class ConfigFileManager
    {
        /// <summary>
        /// Sets the connection string. User gives path to .db file.
        /// </summary>
        private ConnectionStringSettings connectSettings;

        /// <summary>
        /// Gets or sets the name of the currently opened database
        /// </summary>
        public static string DbName { get; set; }

        /// <summary>
        /// Gets or sets the connection string needed to create a connection
        /// </summary>
        public static string ConnectionString { get; set; }

        /// <summary>
        /// Gets or sets the value indicating, if a mock database is used. Is true, if the mockDB shall be used. Is false, when real SQLite-DB shall be used (default).
        /// </summary>
        public static bool MockDB { get; set; }

        /// <summary>
        /// A reference to the logger.
        /// </summary>
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Saves path of SQLite database in .config-file.
        /// </summary>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">
        /// Thrown when configuration file could not be edited."
        /// </exception>
        /// <param name="path">File path of the SQLite database.</param>
        public void SetDatabasePath(string path)
        {
            this.connectSettings = new ConnectionStringSettings();
            this.connectSettings.Name = "SQLite";
            this.connectSettings.ConnectionString = "Data Source=" + path;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Remove(this.connectSettings); // clear old path
                config.ConnectionStrings.ConnectionStrings.Add(this.connectSettings);
                config.Save();

                this.logger.Log(0, "Connection string " + this.connectSettings.ConnectionString + " has been stored in config file.");

                // save connection string and database name in static var
                ConfigFileManager.ConnectionString = this.connectSettings.ConnectionString;
                ConfigFileManager.DbName = ConnectionString.Substring(ConnectionString.LastIndexOf('\\') + 1);
            }
            catch (System.Configuration.ConfigurationErrorsException e)
            {
                this.logger.Log(Logger.Level.Warning, e.Message + e.Source);
                throw;
            }
        }

        /// <summary>
        /// Searches the config file for entry "mockDB" and saves value in private var this.mockDB
        /// </summary>
        public void UsingMockDatabase()
        {
            try
            {
                AppSettingsReader config = new AppSettingsReader();
                ConfigFileManager.MockDB = (bool)config.GetValue("mockDB", typeof(bool));
            }
            // no key found in .config-file - don't use mockDB
            catch (InvalidOperationException)
            {
                this.logger.Log(Logger.Level.Warning, "No mockDB key has been found in config file.");
                ConfigFileManager.MockDB = false;
            }
            catch (ConfigurationErrorsException e)
            {
                this.logger.Log(Logger.Level.Error, "Syntax error in config file!" + e.Message);
                throw; 
            }

            // in case that mockDb shall be used, initialise static lists
            if (ConfigFileManager.MockDB == true && (MockDataBaseManager.SavedKontakte == null || MockDataBaseManager.SavedKunden == null))
            {
                MockDataBaseManager mdm = new MockDataBaseManager();
                mdm.CreateDataBase();
            }
        }

        /// <summary>
        /// Gets database path out of config file and checks if the database file exists
        /// </summary>
        /// <returns>
        /// bool. true: file exists, false: file does not exist or invalid path in .exe.config file.
        /// </returns>
        public bool CheckDataBaseExistance()
        {
            // get location of .db file out of configuration file
            this.connectSettings = ConfigurationManager.ConnectionStrings["SQLite"];

            // check if there is an entry "SQLite" in the EPU-Backoffice.exe.config
            if (this.connectSettings == null)
            {
                this.logger.Log(Logger.Level.Warning, "No entry 'SQLite' in config file.");
                return false;
            }

            // get file location out of connection string
            string path = this.connectSettings.ConnectionString;
            int index1, index2;
            index1 = path.IndexOf("Data Source=");
            index2 = path.IndexOf(".db");
            try
            {
                path = path.Substring(index1 + 12, (index2 + 3) - (index1 + 12));
            }
            catch (ArgumentOutOfRangeException)
            {
                this.logger.Log(Logger.Level.Warning, "No (correct) path found in config file.");
                return false;
            }

            this.logger.Log(0, "Saved path of database in config file: " + path);

            // check if path exists in file system
            bool exists = this.CheckDataBaseExistance(path);
            if (exists == true)
            {
                // save connection string and database name in static var
                ConfigFileManager.ConnectionString = this.connectSettings.ConnectionString;
                ConfigFileManager.DbName = ConnectionString.Substring(ConnectionString.LastIndexOf('\\') + 1);

                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Checks if database file exists at given path.
        /// </summary>
        /// <param name="path">The path which shall be checked</param>
        /// <returns>
        /// bool. true: file exists, false: file does not exist.
        /// </returns>
        public bool CheckDataBaseExistance(string path)
        {
            if (File.Exists(path) && path.EndsWith(".db"))
            {
                this.logger.Log(0, "Database path set in config file: " + path);
                return true;
            }
            else
            {
                this.logger.Log(Logger.Level.Warning, "Given file path is wrong. File does not exist: " + path);
                return false;
            }
        }
    }
}
