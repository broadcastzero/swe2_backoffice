namespace EPUBackoffice.Bl
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using EPUBackoffice.Gui;
    using EPUBackoffice.Dal;

    /// <summary>
    /// Creates a new SQLite ".db" file with its needed tables.
    /// </summary>
    public class DatabaseCreator
    {
        /// <summary>
        /// Saves the given filepath in the configuration file and creates new database.
        /// </summary>
        /// <param name="sender">The caller of this method.</param>
        /// <param name="path">The name of the to-be-created database file.</param>
        public void Create(Form sender, string path)
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
                ConfigFileManager cfm = new ConfigFileManager();
                cfm.SetDatabasePath(path);
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

            // database could be created - change to normal startscreen
            this.ChangeToHomeScreen(sender);
        }

        /// <summary>
        /// Checks if a database exists at the given path and stores it in the config file.
        /// If everything went fine, this method closes the calling Form and opens the main window.
        /// </summary>
        /// <returns>True, if database exists.</returns>
        /// <param name="sender">The caller of this method.</param>
        /// <param name="path">The path of the SQLite file</param>
        /// <exception cref="Exception">Thrown if chosen file is invalid.</exception>
        public void Connect(Form sender, string path)
        {
            ConfigFileManager cfm = new ConfigFileManager();
            bool exists = cfm.CheckDataBaseExistance(path);

            if (exists == false) { throw new Exception(); }
            else
            {
                cfm.SetDatabasePath(path);
                this.ChangeToHomeScreen(sender);
            }
        }

        /// <summary>
        /// Closes the calling form and opens the home screen in a new thread.
        /// </summary>
        /// <param name="sender">The calling form</param>
        private void ChangeToHomeScreen(Form sender)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenHomeScreen));
            sender.Close();
            t.Start();
        }

        /// <summary>
        /// Opens the home screen
        /// </summary>
        private void OpenHomeScreen()
        {
            Application.Run(new HomeForm());
        }

    }
}