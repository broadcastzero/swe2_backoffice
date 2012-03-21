namespace EPUBackoffice.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.Text;
    using EPUBackoffice.Dal;

    /// <summary>
    /// Creates a new SQLite ".db" file with its needed tables.
    /// </summary>
    public class DatabaseCreator
    {
        /// <summary>
        /// Saves the given filepath in the configuration file and creates new database.
        /// </summary>
        /// <param name="path">The name of the to-be-created database file.</param>
        public void Create(string path)
        {
            Debug.WriteLine("Filename from userinput: " + path);

            // add .db, if not already done
            if (!path.EndsWith(".db"))
            {
                path += ".db";
            }

            DataBaseConnector dbc = new DataBaseConnector();

            try
            {
                dbc.SetDatabasePath(path);
                dbc.createDataBase();
            }
            // probably no write access to config file or syntax error in config file
            catch (System.Configuration.ConfigurationException)
            {
                throw;
            }
            // database could not be created for some reason - see logfile
            catch (SQLiteException)
            {
                throw;
            }            
        }
    }
}


/*

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
*/