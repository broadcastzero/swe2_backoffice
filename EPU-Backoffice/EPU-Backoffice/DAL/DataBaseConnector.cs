// -----------------------------------------------------------------------
// <copyright file="DataBaseConnector.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SQLite;

    /// <summary>
    /// This class provides a connection to the SQLite database-file. Its methods get or save files from/to the DB.
    /// </summary>
    public class DataBaseConnector
    {
        /* Private Vars */
        private ConnectionStringSettings settings = null;

        /// <summary>
        /// Constructor: creates needed tables if they do not exist yet
        /// </summary>
        public DataBaseConnector()
        {
            /***
             * Define the database-file (or get path from configuration-file) and declare variables
             */
            this.settings = ConfigurationManager.ConnectionStrings["SQLite"];

            // check if there is an entry "SQLite" in the EPU-Backoffice.exe.config - if not, create
            if (this.settings == null)
            {
                this.settings = new ConnectionStringSettings();
                this.settings.Name = "SQLite";
                this.settings.ConnectionString = @"Data Source=.\backoffice_data.db";
                try
                {
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.ConnectionStrings.ConnectionStrings.Add(this.settings);
                    config.Save();
                }
                catch (System.Configuration.ConfigurationErrorsException)
                {
                    throw;
                }
            }

            SQLiteConnection connection = null;
            SQLiteCommand command = null;

            /***
             * Connect to the database
             */
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = this.settings.ConnectionString;
                connection.Open();

                /***
                 * Create tables if they do not exist
                 */
                command = new SQLiteCommand(connection);
                command.CommandText = "CREATE TABLE IF NOT EXISTS test (id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL);";
                command.ExecuteNonQuery();
            }
            catch (SQLiteException)
            {
                throw; // pass exception to caller
            }
            finally
            {
                /***
                 * Free allocated resources and lose connection
                 */
                command.Dispose();

                connection.Close();
                connection.Dispose();
            }
        }
    }
}
