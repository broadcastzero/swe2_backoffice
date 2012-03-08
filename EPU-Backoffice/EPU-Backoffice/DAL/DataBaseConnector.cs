// -----------------------------------------------------------------------
// <copyright file="DataBaseConnector.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;

    /// <summary>
    /// This class provides a connection to the SQLite database-file. Its methods get or save files from/to the DB.
    /// </summary>
    public class DataBaseConnector
    {
        /// <summary>
        /// Constructor: creates needed tables if they do not exist yet
        /// </summary>
        public DataBaseConnector()
        {
            /***
             * Define the database-file and declare variables
             */
            string dataSource = "backoffice_data.db";
            SQLiteConnection connection = null;
            SQLiteCommand command = null;

            /***
             * Connect to the database
             */
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = "Data Source=" + dataSource;
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
