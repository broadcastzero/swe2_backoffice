// -----------------------------------------------------------------------
// <copyright file="ConfigFileManager.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using EPUBackoffice.Dal;

    /// <summary>
    /// This class reads or writes the config file.
    /// </summary>
    public class ConfigFileManager
    {
        /// <summary>
        /// Sets the connection string. User gives path to .db file.
        /// </summary>
        private ConnectionStringSettings connect_settings;

        /// <summary>
        /// Is true, if the mockDB shall be used. Is false, when real SQLite-DB shall be used (default).
        /// </summary>
        public static bool mockDB { get; set; }

        /// <summary>
        /// Saves path of SQLite database in .config-file.
        /// </summary>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">
        /// Thrown when configuration file could not be edited."
        /// </exception>
        /// <param name="path">File path of the SQLite database.</param>
        public void SetDatabasePath(string path)
        {
            this.connect_settings = new ConnectionStringSettings();
            this.connect_settings.Name = "SQLite";
            this.connect_settings.ConnectionString = "Data Source=" + path;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Remove(this.connect_settings); // clear old path
                config.ConnectionStrings.ConnectionStrings.Add(this.connect_settings);
                config.Save();

                Debug.WriteLine("Connection string " + this.connect_settings.ConnectionString + " has been stored in config file.");

                // save connection string in static var
                DataBaseCreator.connectionString = this.connect_settings.ConnectionString;
            }
            catch (System.Configuration.ConfigurationErrorsException e)
            {
                Trace.WriteLine(e.Message + e.Source);
                throw;
            }
        }

        /// <summary>
        /// Searches the config file for entry "mockDB" and saves value in private var this.mockDB
        /// </summary>
        /// <returns>true, if mockDB shall be used</returns>
        public void UsingMockDatabase()
        {
            try
            {
                AppSettingsReader config = new AppSettingsReader();
                ConfigFileManager.mockDB = (bool)config.GetValue("mockDB", typeof(bool));
            }
            // no key found in .config-file - don't use mockDB
            catch (InvalidOperationException)
            {
                Trace.WriteLine("No mockDB key has been found in config file.");
                ConfigFileManager.mockDB = false;
            }
            catch (ConfigurationErrorsException e)
            {
                Trace.WriteLine("Syntax error in config file!" + e.Message);
                throw; 
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
            this.connect_settings = ConfigurationManager.ConnectionStrings["SQLite"];

            // check if there is an entry "SQLite" in the EPU-Backoffice.exe.config
            if (this.connect_settings == null)
            {
                Trace.WriteLine("No entry 'SQLite' in config file.");
                return false;
            }

            // get file location out of connection string
            string path = connect_settings.ConnectionString;
            int index1, index2;
            index1 = path.IndexOf("Data Source=");
            index2 = path.IndexOf(".db");
            try
            {
                path = path.Substring(index1 + 12, (index2 + 3) - (index1 + 12));
            }
            catch (ArgumentOutOfRangeException)
            {
                Trace.WriteLine("No (correct) path found in config file.");
                return false;
            }
            Debug.WriteLine("Saved path of database in config file : " + path);

            // check if path exists in file system
            return CheckDataBaseExistance(path) == true ? true : false;
        }

        /// <summary>
        /// Checks if database file exists at given path.
        /// </summary>
        /// <returns>
        /// bool. true: file exists, false: file does not exist.
        /// </returns>
        public bool CheckDataBaseExistance(string path)
        {
            if (File.Exists(path) && path.EndsWith(".db"))
            {
                Debug.WriteLine("Database path set in config file: " + path);
                return true;
            }
            else
            {
                Trace.WriteLine("Given file path is wrong. File does not exist: " + path);
                return false;
            }
        }
    }
}
