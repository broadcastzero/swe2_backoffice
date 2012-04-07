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
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Connects to the database and creates its tables if they do not exist yet.
        /// </summary>
        public void CreateDataBase()
        {
            SQLiteConnection connection = null;
            SQLiteCommand command = null;

            // save CREATE-statements
            StringBuilder sb = new StringBuilder();
            sb.Append("CREATE TABLE IF NOT EXISTS Kontakt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Vorname VARCHAR(150), Nachname_Firmenname VARCHAR(150) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Kunde (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Vorname VARCHAR(150), Nachname_Firmenname VARCHAR(150) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Projekt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, AngebotID INTEGER NOT NULL, Projektname VARCHAR(150) NOT NULL, Projektstart TIMESTAMP); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Zeitaufzeichnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, Stunden INTEGER NOT NULL, Bezeichnung VARCHAR(150) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Angebot (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, kundenID INTEGER NOT NULL, Angebotssumme FLOAT NOT NULL, Angebotsdauer INTEGER NOT NULL, Erstellungsdatum TIMESTAMP NOT NULL, Umsetzung FLOAT NOT NULL, akzeptiert BOOLEAN DEFAULT 'false' NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Rechnungszeile (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, AngebotsID INTEGER NOT NULL, AusgangsrechnungsID INTEGER NOT NULL,BEzeichnung Varchar(150), Stunden INTEGER NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Ausgangsrechnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KundenID INTEGER NOT NULL, Rechnungsdatum TIMESTAMP NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Ausgangsbuchung (BuchungszeilenID INTEGER NOT NULL, AusgangsrechnungsID INTEGER NOT NULL, PRIMARY KEY (BuchungszeilenID, AusgangsrechnungsID)); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Eingangsrechnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KontaktID INTEGER NOT NULL, Rechnungsdatum TIMESTAMP NOT NULL, Archivierungspfad VARCHAR(150) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Eingangsbuchung (BuchungszeilenID INTEGER NOT NULL, EingangsrechnungsID INTEGER NOT NULL, PRIMARY KEY (BuchungszeilenID, EingangsrechnungsID)); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Buchungszeilen (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, KategorieID INTEGER NOT NULL, BankkontoID INTEGER NOT NULL, BetragUST FLOAT NOT NULL, BetragNetto FLOAT NOT NULL, Buchungsdatum TIMESTAMP NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Kategorien (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Name VARCHAR(150) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Bankkonto (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Kontonummer INTEGER NOT NULL, BLZ INTEGER NOT NULL); ");

            // Connect to the database
            try
            {
                connection = new SQLiteConnection();
                connection.ConnectionString = ConfigFileManager.ConnectionString;
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
                connection.Dispose();
            }

            this.logger.Log(0, "A new database has been created.");
        }

        /// <summary>
        /// Saves a new Kunde or Kontakt to the database
        /// </summary>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        /// <param name="type">false...Kunde, true...Kontakt</param>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        public void SaveNewKundeKontakt(string lastname, bool type, string firstname = null)
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
                con = new SQLiteConnection(ConfigFileManager.ConnectionString);
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
            string successmessage = "A new " + s_type + " has been saved to the database: " + firstname + " " + lastname;
            this.logger.Log(0, successmessage);
        }

        /// <summary>
        /// Create SQL-wrapper string for Kunden/Kontakte
        /// </summary>
        /// <param name="type">"Kunde" or "Kontakt"</param>
        /// <param name="firstname">The first name</param>
        /// <param name="lastname">The last name</param>
        /// <returns>SQLite prepared statement string</returns>
        public string GetKundenKontakteSQL(string type, string firstname, string lastname)
        {
            if (firstname == null && lastname == null)
            {
                return "SELECT * FROM " + type;
            }
            else if (firstname != null && lastname == null)
            {
                return "SELECT * FROM " + type + " WHERE Vorname = ?";
            }
            else if (firstname == null && lastname != null)
            {
                return "SELECT * FROM " + type + " WHERE Nachname_Firmenname = ?";
            }
            else
            {
                return "SELECT * FROM " + type + " WHERE Vorname = ? AND Nachname_Firmenname = ?";
            }
        }
        /// <summary>
        /// This function gets (a) certain Kontakt(e) from the saved objects in the database.
        /// If firstname and lastname should be empty, display all
        /// </summary>
        /// <param name="firstname">First name of the to-be-searched Kontakt (optional)</param>
        /// <param name="lastname">Last name of the to-be-searched Kontakt (optional)</param>
        /// <param name="type">false...Kunde, true...Kontakt</param>
        public List<KundeKontaktTable> GetKundenKontakte(bool type, string firstname = null, string lastname = null)
        {
            string s_type = type == false ? "Kunde" : "Kontakt";
            string sql = GetKundenKontakteSQL(s_type, firstname, lastname);
            List<KundeKontaktTable> resultlist = new List<KundeKontaktTable>();

            // open connection and get requested Kontakt(e) out of database
            SQLiteConnection con = null;
            SQLiteTransaction tra = null;
            SQLiteCommand cmd = null;
            SQLiteDataReader reader = null;
            try
            {
                // initialise connection
                con = new SQLiteConnection(ConfigFileManager.ConnectionString);
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
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KundeKontaktTable k = new KundeKontaktTable();
                    k.ID = reader.GetInt32(0);
                    k.Vorname = reader.GetString(1);
                    k.NachnameFirmenname = reader.GetString(2);

                    if (k.Vorname == "<null>")
                    { k.Vorname = string.Empty; }

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
        /// Updates an existing Kunde or Kontakt in the SQLite database
        /// </summary>
        /// <param name="id">The ID of the to-be-deleted Kunde or Kontakt</param>
        /// <param name="firstname">The new first name</param>
        /// <param name="lastname">The new last name</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        public void UpdateKundeKontakte(int id, string firstname, string lastname, bool type)
        {
            string s_type = type == false ? "Kunde" : "Kontakt";
            string sql = "UPDATE " + s_type + " SET Vorname = ?, Nachname_Firmenname = ? WHERE ID = ?";

            try
            {
                this.SendStatementToDatabase(sql, id, firstname, lastname);
            }
            catch (SQLiteException)
            {
                throw;
            }

            // success logging
            string successmessage = s_type + " has been updated in the SQLite database: ID: " + id + " " + firstname + " " + lastname;
            this.logger.Log(0, successmessage);
        }

        /// <summary>
        /// Deletes an existing Kunde or Kontakt out of the SQLite database
        /// </summary>
        /// <param name="id">The ID of the to-be-deleted Kunde or Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        public void DeleteKundeKontakt(int id, bool type)
        {
            string s_type = type == false ? "Kunde" : "Kontakt";
            string sql = "DELETE FROM " + s_type + " WHERE ID = ?";

            try
            {
                this.SendStatementToDatabase(sql, id);
            }
            catch (SQLiteException)
            {
                throw;
            }

            // success logging
            string successmessage = s_type + " has been dropped from the SQLite database. ID: " + id;
            this.logger.Log(0, successmessage);
        }

        /// <summary>
        /// Gets an sql statement and an ID and commits statement
        /// </summary>
        /// <param name="sql">The sql statement</param>
        /// <param name="id">The ID - used for binding</param>
        /// <param name="param1">Optional string parameter 1</param>
        /// <param name="param2">Optional string parameter 2</param>
        private void SendStatementToDatabase(string sql, int id, string param1 = null, string param2 = null)
        {
            SQLiteConnection con = null;
            SQLiteTransaction tra = null;
            SQLiteCommand cmd = null;
            try
            {
                // initialise connection
                con = new SQLiteConnection(ConfigFileManager.ConnectionString);
                con.Open();

                // initialise transaction
                tra = con.BeginTransaction();
                cmd = new SQLiteCommand(sql, con);

                // Set optional parameter 1
                if (param1 != null)
                {
                    SQLiteParameter p_1 = new SQLiteParameter();
                    p_1.Value = param1;
                    cmd.Parameters.Add(p_1);
                }

                // Set optional parameter 2
                if (param2 != null)
                {
                    SQLiteParameter p_2 = new SQLiteParameter();
                    p_2.Value = param2;
                    cmd.Parameters.Add(p_2);
                }

                // initialise and bind ID - at the end of the string, mostly in WHERE needed!
                SQLiteParameter p_ID = new SQLiteParameter();
                p_ID.Value = id;
                cmd.Parameters.Add(p_ID);

                // execute and commit
                cmd.ExecuteNonQuery();
                tra.Commit();
            }
            catch (SQLiteException)
            {
                throw;
            }
            finally
            {
                if (tra != null) { tra.Dispose(); }
                if (cmd != null) { cmd.Dispose(); }
                if (con != null) { con.Dispose(); }
            }
        }
    }
}