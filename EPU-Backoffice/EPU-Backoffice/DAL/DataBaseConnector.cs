// -----------------------------------------------------------------------
// <copyright file="DataBaseConnector.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal
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
        private ConnectionStringSettings settings;

        /// <summary>
        /// Gets database path out of config file, checks if the database file exists.
        /// </summary>
        /// <returns>
        /// bool. true: file exists, false: file does not exist or invalid path in .exe.config file.
        /// </returns>
        public bool checkDataBaseExistance()
        {
            // get location of .db file out of configuration file
            this.settings = ConfigurationManager.ConnectionStrings["SQLite"];

            // check if there is an entry "SQLite" in the EPU-Backoffice.exe.config
            if (this.settings == null)
            {
                Trace.WriteLine("No entry 'SQLite' in config file.");
                return false;
            }

            // get file location out of connection string
            string path = settings.ConnectionString;
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
            Debug.WriteLine("Path of SQLite file: " + path);

            if (checkDataBaseExistance(path))
            {
                return true;
            }
            else { return false; }
        }

        /// <summary>
        /// Checks if database file exists at given path.
        /// </summary>
        /// <returns>
        /// bool. true: file exists, false: file does not exist.
        /// </returns>
        public bool checkDataBaseExistance(string path)
        {
            string p = System.Environment.CurrentDirectory;
            // check if file exists
            if (File.Exists(path) && path.EndsWith(".db"))
            {
                Debug.WriteLine("Database path set in config file.");
                return true;
            }
            else
            {
                Trace.WriteLine("Given file path in config file is wrong. File does not exist!");
                return false;
            }
        }
        /// <summary>
        /// Initializes a new instance of the DataBaseConnector class. Creates needed database tables if they do not exist yet.
        /// </summary>
        /// <param name="path">File path of the SQLite database.</param>
        public void setDatabasePath(string path)
        {
            this.settings = new ConnectionStringSettings();
            this.settings.Name = "SQLite";
            this.settings.ConnectionString = "Data Source=" + path;
            try
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings.Remove(this.settings); // clear old path
                config.ConnectionStrings.ConnectionStrings.Add(this.settings);
                config.Save();
            }
            catch (System.Configuration.ConfigurationErrorsException e)
            {
                Trace.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// Connect to the database and create its tables if they do not exist yet.
        /// </summary>
        public void createDataBase()
        {
            SQLiteConnection connection = null;
            SQLiteCommand command = null;

            // save CREATE-statements
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Kontakt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Vorname VARCHAR(50), Nachname/Firmenname VARCHAR(50) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Kunde (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Vorname VARCHAR(50), Nachname/Firmenname VARCHAR(50) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Projekt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, aktiv BOOLEAN DEFAULT 'false' NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Zeitaufzeichnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, Stunden INTEGER NOT NULL, Bezeichnung VARCHAR(100) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Angebot (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, kundenID INTEGER NOT NULL, Angebotssumme FLOAT NOT NULL, Dauer INTEGER NOT NULL, Datum TIMESTAMP NOT NULL, Umsetzung FLOAT NOT NULL, akzeptiert BOOLEAN DEFAULT 'false' NOT NULL); ");
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
                connection.ConnectionString = this.settings.ConnectionString;
                connection.Open();

                // Create tables if they do not exist
                command = new SQLiteCommand(connection);
                command.CommandText = sb.ToString();
                command.ExecuteNonQuery();

                command.CommandText = "select * from Bankkonto;";
                SQLiteDataReader sr = command.ExecuteReader();
            }
            catch (SQLiteException)
            {
                throw; // pass exception to caller
            }
            finally
            {
                // Free allocated resources and close connection
                command.Dispose();

                connection.Close();
                connection.Dispose();
            }
        }
    }
}