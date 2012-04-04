// -----------------------------------------------------------------------
// <copyright file="DataBaseCreator.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using System.Text;
    using EPUBackoffice.BL;
    using EPUBackoffice.Dal.Tables;
    using Logger;

    /// <summary>
    /// This class provides a connection to the SQLite database-file. Its methods get or save files from/to the DB.
    /// </summary>
    public class DataBaseManager : IDAL
    {
        Logger logger = Logger.Instance;

        /// <summary>
        /// Connects to the database and creates its tables if they do not exist yet.
        /// </summary>
        public void CreateDataBase()
        {
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
                connection.ConnectionString = ConfigFileManager.connectionString;
                connection.Open();

                // Create tables if they do not exist
                command = new SQLiteCommand(connection);
                command.CommandText = sb.ToString();
                command.ExecuteNonQuery();
            }
            catch (SQLiteException e)
            {
                this.logger.Log(2, e.Message + e.Source);
                throw; // pass exception to caller
            }
            finally
            {
                // Free allocated resources and close connection
                command.Dispose();

                connection.Close();
                connection.Dispose();
            }

            this.logger.Log(0, "A new database has been created.");
        }

        /// <summary>
        /// Saves a new Kunde or Kontakt to the database
        /// </summary>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">false...Kunde, true...Kontakt</param>
        public void SaveNewKunde(string lastname, bool type, string firstname = null)
        {
            string s_type = type == false ? "Kunde" : "Kontakt";

            string sql = "INSERT INTO " + s_type + " (Vorname, Nachname_Firmenname) VALUES (?, ?)";

            // open connection and save new Kunde/Kontakt in database
            SQLiteConnection con = null;
            SQLiteTransaction tra = null;
            SQLiteCommand cmd = null;
            try
            {
                // initialise connection
                con = new SQLiteConnection(ConfigFileManager.connectionString);
                con.Open();

                // initialise transaction
                tra = con.BeginTransaction();
                cmd = new SQLiteCommand(sql, con);

                // initialise parameter
                SQLiteParameter p_firstname = new SQLiteParameter();
                SQLiteParameter p_lastname = new SQLiteParameter();

                // bind first name
                p_firstname.Value = firstname;
                cmd.Parameters.Add(p_firstname);
                
                // bind last name
                p_lastname.Value = lastname;
                cmd.Parameters.Add(p_lastname);
                
                // execute and commit
                cmd.ExecuteNonQuery();
                tra.Commit();
            }
            catch(SQLiteException)
            {
                throw;
            }
            finally
            {
                if (tra != null) { tra.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
                if (con != null) { con.Dispose(); }
            }

            // success logging
            string successmessage = "A new " + s_type + " has been saved to the database: ";
            if( firstname != null) { successmessage = successmessage + firstname + ' '; }
            successmessage += lastname;

            this.logger.Log(0, successmessage);
        }

        /// <summary>
        /// Create SQL-wrapper string for Kunden/Kontakte
        /// </summary>
        /// <param name="type">"Kunde" or "Kontakt"</param>
        /// <param name="firstname">The first name</param>
        /// <param name="lastname">The last name</param>
        /// <returns>SQLite prepared statement string</returns>
        private string GetKundenKontakteSQL(string type, string firstname, string lastname)
        {
            if (firstname == null && lastname == null)
            {
                return "SELECT * from " + type;
            }
            else if (firstname != null && lastname == null)
            {
                return "SELECT ID, Vorname FROM " + type + " WHERE Vorname = ?";
            }
            else if (firstname == null && lastname != null)
            {
                return "SELECT ID, Nachname_Firmenname FROM " + type + " WHERE Nachname_Firmenname = ?";
            }
            else
            {
                return "SELECT ID, Vorname, Nachname_Firmenname FROM " + type + " WHERE Vorname = ? AND Nachname_Firmenname = ?";
            }
        }
        /// <summary>
        /// This function gets (a) certain Kontakt(e) from the saved objects in the database.
        /// If firstname and lastname should be empty, display all
        /// </summary>
        /// <param name="firstname">First name of the to-be-searched Kontakt (optional)</param>
        /// <param name="lastname">Last name of the to-be-searched Kontakt (optional)</param>
        public List<KontaktTable> GetKontakte(string firstname = null, string lastname = null)
        {
            string sql = GetKundenKontakteSQL("Kontakt", firstname, lastname);

            // open connection and get requested Kontakt(e) out of database
            SQLiteConnection con = null;
            SQLiteTransaction tra = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;
            try
            {
                // initialise connection
                con = new SQLiteConnection(ConfigFileManager.connectionString);
                con.Open();

                // initialise transaction
                tra = con.BeginTransaction();
                cmd = new SQLiteCommand(sql, con);

                // bind first name
                if (firstname != null)
                {
                    SQLiteParameter p_firstname = new SQLiteParameter();
                    p_firstname.Value = firstname;
                    cmd.Parameters.Add(p_firstname);
                }
                
                // bind last name
                if (lastname != null)
                {
                    SQLiteParameter p_lastname = new SQLiteParameter();
                    p_lastname.Value = lastname;
                    cmd.Parameters.Add(p_lastname);
                }
                
                // execute and get results
                List<KontaktTable> resultlist = new List<KontaktTable>();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KontaktTable k = new KontaktTable();
                    k.ID = reader.GetInt32(0);
                    k.Vorname = reader.GetString(1);
                    k.NachnameFirmenname = reader.GetString(2);

                    resultlist.Add(k);
                }

                return resultlist;
            }
            catch (SQLiteException)
            {
                throw;
            }
            finally
            {
                if (reader != null) { reader.Dispose(); }
                if (tra != null) { tra.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
                if (con != null) { con.Dispose(); }
            }
        }

        /// <summary>
        /// This function gets (a) certain Kunde(n) from the saved objects in the database.
        /// If firstname and lastname should be empty, display all
        /// </summary>
        /// <param name="firstname">First name of the to-be-searched Kunde (optional)</param>
        /// <param name="lastname">Last name of the to-be-searched Kunde (optional)</param>
        public List<KundeTable> GetKunden(string firstname = null, string lastname = null)
        {
            string sql = GetKundenKontakteSQL("Kunde", firstname, lastname);

            // open connection and get requested Kunde(n) out of database
            SQLiteConnection con = null;
            SQLiteTransaction tra = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;
            try
            {
                // initialise connection
                con = new SQLiteConnection(ConfigFileManager.connectionString);
                con.Open();

                // initialise transaction
                tra = con.BeginTransaction();
                cmd = new SQLiteCommand(sql, con);

                // bind first name
                if (firstname != null)
                {
                    SQLiteParameter p_firstname = new SQLiteParameter();
                    p_firstname.Value = firstname;
                    cmd.Parameters.Add(p_firstname);
                }

                // bind last name
                if (lastname != null)
                {
                    SQLiteParameter p_lastname = new SQLiteParameter();
                    p_lastname.Value = lastname;
                    cmd.Parameters.Add(p_lastname);
                }

                // execute and get results
                List<KundeTable> resultlist = new List<KundeTable>();

                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KundeTable k = new KundeTable();
                    k.ID = reader.GetInt32(0);
                    k.Vorname = reader.GetString(1);
                    k.NachnameFirmenname = reader.GetString(2);

                    resultlist.Add(k);
                }

                return resultlist;
            }
            catch (SQLiteException)
            {
                throw;
            }
            finally
            {
                if (reader != null) { reader.Dispose(); }
                if (tra != null) { tra.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
                if (con != null) { con.Dispose(); }
            }
        }
    }
}