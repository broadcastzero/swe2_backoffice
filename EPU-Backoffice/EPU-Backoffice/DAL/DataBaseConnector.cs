// -----------------------------------------------------------------------
// <copyright file="DataBaseConnector.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.DAL
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    /// <summary>
    /// This class provides a connection to the SQLite database-file. Its methods get or save files from/to the DB.
    /// </summary>
    public class DataBaseConnector
    {
        /// <summary>
        /// Sets the connection string. User gives path to .db file.
        /// </summary>
        private ConnectionStringSettings connect_settings;

        /// <summary>
        /// Is true, if the mockDB shall be used. Is false, when real SQLite-DB shall be used (default).
        /// </summary>
        private bool mockDB = false;

        /// <summary>
        /// Gets database path out of config file, checks if the database file exists and if mock database shall be used.
        /// </summary>
        /// <returns>
        /// bool. true: file exists, false: file does not exist or invalid path in .exe.config file.
        /// </returns>
        public bool checkDataBaseExistance()
        {
            // shall mockDB be used instead of real one?
            bool mock;
            try
            {
                mock = usingMockDatabase();
            }
            // error in config file
            catch (System.Configuration.ConfigurationErrorsException)
            {
                throw;
            }

            if(mock == true)
            {
                Debug.WriteLine("Using mock database");
            }
            else { Debug.WriteLine("Using SQLite database"); }

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
            catch (ArgumentOutOfRangeException e)
            {
                Trace.WriteLine(e.Source + "No (correct) path found in config file.");
                return false;
            }
            Debug.WriteLine("Saved path of database in config file : " + path);

            // check if path exists in file system
            return checkDataBaseExistance(path) == true ? true : false;
        }

        /// <summary>
        /// Checks if database file exists at given path.
        /// </summary>
        /// <returns>
        /// bool. true: file exists, false: file does not exist.
        /// </returns>
        public bool checkDataBaseExistance(string path)
        {
            if (File.Exists(path) && path.EndsWith(".db"))
            {
                Debug.WriteLine("Database path set in config file.");
                return true;
            }
            else
            {
                Trace.WriteLine("Given file path is wrong. File does not exist!");
                return false;
            }
        }

        /// <summary>
        /// Saves path of SQLite database in .config-file.
        /// </summary>
        /// <exception cref="System.Configuration.ConfigurationErrorsException">
        /// Thrown when configuration file could not be edited."
        /// </exception>
        /// <param name="path">File path of the SQLite database.</param>
        public void setDatabasePath(string path)
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
        private bool usingMockDatabase()
        {
            try
            {
                AppSettingsReader config = new AppSettingsReader();
                this.mockDB = (bool)config.GetValue("mockDB", typeof(bool));
            }
            // no key found in .config-file - don't use mockDB
            catch (InvalidOperationException)
            {
                this.mockDB = false;
            }
            catch (ConfigurationErrorsException e)
            { 
                Trace.WriteLine("Syntax error in config file!");
                Trace.WriteLine(e.Message);
                throw; 
            }

            return this.mockDB == true ? true : false;            
        }

        /// <summary>
        /// Connects to the database and creates its tables if they do not exist yet.
        /// </summary>
        public void createDataBase()
        {
            // if mock database shall be used, don't do anything
            if (this.mockDB == true)
            { return; }

            SQLiteConnection connection = null;
            SQLiteCommand command = null;

            // save CREATE-statements
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Kontakt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Vorname VARCHAR(50), Nachname_Firmenname VARCHAR(50) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Kunde (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Vorname VARCHAR(50), Nachname_Firmenname VARCHAR(50) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Projekt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Projektname VARCHAR(100) NOT NULL, Projektstart TIMESTAMP); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Zeitaufzeichnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, Stunden INTEGER NOT NULL, Bezeichnung VARCHAR(100) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Angebot (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, kundenID INTEGER NOT NULL, Angebotssumme FLOAT NOT NULL, Angebotsdauer INTEGER NOT NULL, Erstellungsdatum TIMESTAMP NOT NULL, Umsetzung FLOAT NOT NULL, akzeptiert BOOLEAN DEFAULT 'false' NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Rechnungszeile (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, AngebotsID INTEGER NOT NULL, AusgangsrechnungsID INTEGER NOT NULL,BEzeichnung Varchar(200), Stunden INTEGER NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Ausgangsrechnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KundenID INTEGER NOT NULL, Rechnungsdatum TIMESTAMP NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Ausgangsbuchung (BuchungszeilenID INTEGER NOT NULL, AusgangsrechnungsID INTEGER NOT NULL, PRIMARY KEY (BuchungszeilenID, AusgangsrechnungsID)); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Eingangsrechnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KontaktID INTEGER NOT NULL, Rechnungsdatum TIMESTAMP NOT NULL, Archivierungspfad VARCHAR(200) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Eingangsbuchung (BuchungszeilenID INTEGER NOT NULL, EingangsrechnungsID INTEGER NOT NULL, PRIMARY KEY (BuchungszeilenID, EingangsrechnungsID)); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Buchungszeilen (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KategorieID INTEGER NOT NULL, BankkontoID INTEGER NOT NULL, BetragUST FLOAT NOT NULL, BetragNetto FLOAT NOT NULL, Buchungsdatum TIMESTAMP NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Kategorien (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name VARCHAR(50) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Bankkonto (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Kontonummer INTEGER NOT NULL, BLZ INTEGER NOT NULL); ");

            // Connect to the database
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = this.connect_settings.ConnectionString;
                connection.Open();

                // Create tables if they do not exist
                command = new SQLiteCommand(connection);
                command.CommandText = sb.ToString();
                command.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                Trace.WriteLine(e.Message + e.Source);
                throw; // pass exception to caller
            }
            finally
            {
                // Free allocated resources and close connection
                command.Dispose();

                connection.Close();
                connection.Dispose();
            }

            Trace.WriteLine("A new database has been created.");
        }
    }
}