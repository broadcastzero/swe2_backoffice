// -----------------------------------------------------------------------
// <copyright file="DatabaseCreator.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using EPUBackoffice.DAL;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Text;

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
            DataBaseConnector dbc = new DataBaseConnector();
            dbc.setDatabasePath(path);
            dbc.createDataBase();
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