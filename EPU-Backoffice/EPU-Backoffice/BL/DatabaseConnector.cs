// -----------------------------------------------------------------------
// <copyright file="DataBaseConnector.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    using EPUBackoffice.Gui;
    using EPUBackoffice.Dal;
    using EPUBackoffice.UserExceptions;
    using Logger;

    /// <summary>
    /// Creates a new SQLite ".db" file with its needed tables.
    /// </summary>
    public class DatabaseConnector
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Saves the given filepath in the configuration file and creates new database.
        /// </summary>
        /// <param name="sender">The caller of this method.</param>
        /// <param name="path">The name of the to-be-created database file.</param>
        public void Create(Form sender, string path)
        {
            this.logger.Log(0, "User wants to create new database - filename from userinput: " + path);

            // add .db, if not already done
            if (!path.EndsWith(".db"))
            {
                path += ".db";
                this.logger.Log(1, "No extension .db found. Added by application.");
            }

            try
            {
                ConfigFileManager cfm = new ConfigFileManager();
                cfm.SetDatabasePath(path);
                DALFactory.GetDAL().CreateDataBase();
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
        /// <param name="sendingForm">The form in which the sending element (button) was placed.</param>
        /// <exception cref="InvalidFileException">Thrown if chosen file is invalid.</exception>
        public void Connect(Object sender, string path, Form sendingForm)
        {
            ConfigFileManager cfm = new ConfigFileManager();
            bool exists = cfm.CheckDataBaseExistance(path);

            if (exists == false) 
            {
                this.logger.Log(2, "Tried to open file " + path + " which does not exist or is not a a valid SQLite file!");
                throw new InvalidFileException("Angegebene Datei existiert nicht oder ist kein gültiges SQLite-File!");
            }
            else
            {
                cfm.SetDatabasePath(path);

                // only when sender was DBNotFoundForm, not when sender is HomeForm!
                if (sendingForm.Name != "HomeForm")
                {
                    this.ChangeToHomeScreen(sendingForm);
                }
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
            this.logger.Log(0, "Open HomeForm");
            Application.Run(new HomeForm());
        }
    }
}