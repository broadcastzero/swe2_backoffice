﻿// -----------------------------------------------------------------------
// <copyright file="DatabaseConnector.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.UserExceptions;
    using EPU_Backoffice_Panels.LoggingFramework;

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
        public void Create(Form sender, string path, Form newForm)
        {
            this.logger.Log(Logger.Level.Info, "User wants to create new database - filename from userinput: " + path);

            // add .db, if not already done
            if (!path.EndsWith(".db"))
            {
                path += ".db";
                this.logger.Log(Logger.Level.Info, "No extension .db found. Added by application.");
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
            this.ChangeToHomeScreen(sender, newForm);
        }

        /// <summary>
        /// Checks if a database exists at the given path and stores it in the config file.
        /// If everything went fine, this method closes the calling Form and opens the main window.
        /// </summary>
        /// <param name="sender">The caller of this method.</param>
        /// <param name="path">The path of the SQLite file</param>
        /// <param name="sendingForm">The form in which the sending element (button) was placed.</param>
        /// <exception cref="InvalidFileException">Thrown if chosen file is invalid.</exception>
        public void Connect(object sender, string path, Form sendingForm, Form newForm)
        {
            ConfigFileManager cfm = new ConfigFileManager();
            bool exists = cfm.CheckDataBaseExistance(path);

            if (exists == false)
            {
                this.logger.Log(Logger.Level.Error, "Tried to open file " + path + " which does not exist or is not a a valid SQLite file!");
                throw new InvalidFileException("Angegebene Datei existiert nicht oder ist kein gültiges SQLite-File!");
            }
            else
            {
                cfm.SetDatabasePath(path);

                // only when sender was DBNotFoundForm, not when sender is HomeForm!
                if (sendingForm != null && sendingForm.Name == "DBNotFoundForm")
                {
                    // set database description values
                    this.ChangeToHomeScreen(sendingForm, newForm);
                }
            }
        }

        /// <summary>
        /// Closes the calling form and opens the home screen in a new thread.
        /// </summary>
        /// <param name="sender">The calling form</param>
        private void ChangeToHomeScreen(Form sender, Form newForm)
        {
            sender.Hide();
            this.logger.Log(Logger.Level.Info, "Open HomeForm");
            newForm.Show();
            sender.Hide();
        }
    }
}