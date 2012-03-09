// -----------------------------------------------------------------------
// <copyright file="DataBaseConnector.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
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
            // get connection string out of configuration file
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

            // Connect to the database
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = this.settings.ConnectionString;
                connection.Open();

                // Create tables if they do not exist
                StringBuilder sb = new StringBuilder();
                sb.Append("CREATE TABLE IF NOT EXISTS Kontakt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Vorname VARCHAR(50), Nachname VARCHAR(50) NOT NULL); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Kunde (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Vorname VARCHAR(50), Nachname VARCHAR(50) NOT NULL); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Projekt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, aktiv BOOLEAN DEFAULT 'false' NOT NULL); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Zeitaufzeichnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, Stunden INTEGER NOT NULL, Bezeichnung VARCHAR(100)); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Angebot (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, kundenID INTEGER NOT NULL, Angebotssumme FLOAT, Dauer INTEGER, Datum TIMESTAMP, Umsetzung FLOAT, akzeptiert BOOLEAN DEFAULT 'false' NOT NULL); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Rechnungszeile (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, AngebotsID INTEGER NOT NULL, AusgangsrechnungsID INTEGER NOT NULL, Stunden INTEGER NOT NULL); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Ausgangsrechnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KundenID INTEGER NOT NULL); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Ausgangsbuchung (BuchungszeilenID INTEGER NOT NULL, AusgangsrechnungsID INTEGER NOT NULL, PRIMARY KEY (BuchungszeilenID, AusgangsrechnungsID)); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Eingangsrechnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KontaktID INTEGER NOT NULL, Archivierungspfad VARCHAR(100) NOT NULL, Archivierdatum TIMESTAMP); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Eingangsbuchung (BuchungszeilenID INTEGER NOT NULL, EingangsrechnungsID INTEGER NOT NULL, PRIMARY KEY (BuchungszeilenID, EingangsrechnungsID)); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Buchungszeilen (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KategorieID INTEGER NOT NULL, EingangsbuchungsID INTEGER NOT NULL, BankkontoID INTEGER NOT NULL, BetragUST FLOAT NOT NULL, BetragNetto FLOAT NOT NULL); ");
                sb.Append("CREATE TABLE IF  NOT EXISTS Kategorien (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name VARCHAR(50) NOT NULL); ");
                sb.Append("CREATE TABLE IF NOT EXISTS Bankkonto (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Kontonummer INTEGER NOT NULL, BLZ INTEGER NOT NULL); ");

                command = new SQLiteCommand(connection);
                command.CommandText = sb.ToString();
                command.ExecuteNonQuery();
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
