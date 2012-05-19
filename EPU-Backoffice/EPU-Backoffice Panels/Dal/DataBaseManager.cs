// -----------------------------------------------------------------------
// <copyright file="DataBaseManager.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.IO;
    using System.Text;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.LoggingFramework;

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
            sb.Append("CREATE TABLE IF NOT EXISTS Projekt (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, AngebotID INTEGER NOT NULL, Projektname VARCHAR(150) NOT NULL, Projektstart DATETIME NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Zeitaufzeichnung (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, Stunden INTEGER NOT NULL, Bezeichnung VARCHAR(150) NOT NULL, Stundensatz INTEGER NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Angebot (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, kundenID INTEGER NOT NULL, Angebotssumme FLOAT NOT NULL, Angebotsdauer DATETIME NOT NULL, Erstellungsdatum VARCHAR(150) NOT NULL, Umsetzung INTEGER NOT NULL, Beschreibung VARCHAR(150) NOT NULL); ");
            sb.Append("CREATE TABLE IF NOT EXISTS Rechnungszeile (ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, ProjektID INTEGER NOT NULL, AusgangsrechnungsID INTEGER NOT NULL,BEzeichnung Varchar(150), Stunden INTEGER NOT NULL, Stundensatz FLOAT NOT NULL); ");
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
                this.logger.Log(Logger.Level.Error, e.Message + e.Source);
                throw; // pass exception to caller
            }
            finally
            {
                // Free allocated resources and close connection
                command.Dispose();
                connection.Dispose();
            }

            this.logger.Log(Logger.Level.Info, "A new database has been created.");
        }

        /// <summary>
        /// Saves a new Kunde or Kontakt to the database
        /// </summary>
        /// <param name="k">The Kunde or Kontakt object that shall be saved</param>
        public int SaveNewKundeKontakt(KundeKontaktTable k)
        {
            int insertedID;
            string s_type = k.Type == false ? "Kunde" : "Kontakt";

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
                p_firstname.Value = k.Vorname;
                cmd.Parameters.Add(p_firstname);
                
                // bind last name
                p_lastname.Value = k.NachnameFirmenname;
                cmd.Parameters.Add(p_lastname);
                
                // execute and commit
                cmd.ExecuteNonQuery();
                tra.Commit();

                // get rowID
                cmd.Parameters.Clear();
                cmd.CommandText = "SELECT last_insert_rowid() AS id FROM " + s_type;
                cmd.ExecuteNonQuery();
                System.Object temp = cmd.ExecuteScalar();
                insertedID = int.Parse(temp.ToString());
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
            string successmessage = "A new " + s_type + " has been saved to the database: " + insertedID + " " + k.Vorname + " " + k.NachnameFirmenname;
            this.logger.Log(Logger.Level.Info, successmessage);

            // return ID of inserted item
            return insertedID;
        }

        /// <summary>
        /// Create SQL-wrapper string for Kunden/Kontakte
        /// </summary>
        /// <param name="k">The to-be-searched Kunde/Kontakt table object</param>
        /// <returns>SQLite prepared statement string</returns>
        public string GetKundenKontakteSQL(KundeKontaktTable k)
        {
            string type = k.Type == false ? "Kunde" : "Kontakt";

            // if it shall be searched for ID, really only search for ID and ignore other fields
            // ID will be -1 if it shall not be searched for ID (set in Business Layer)
            if (k.ID >= 0)
            {
                return "SELECT * FROM " + type + " WHERE ID = ?";
            }
            else if (k.Vorname.Length == 0 && k.NachnameFirmenname.Length == 0)
            {
                return "SELECT * FROM " + type;
            }
            else if (k.Vorname.Length != 0 && k.NachnameFirmenname.Length == 0)
            {
                return "SELECT * FROM " + type + " WHERE Vorname = ?";
            }
            else if (k.Vorname.Length == 0 && k.NachnameFirmenname.Length != 0)
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
        /// <param name="k">The Kunden/Kontakt table object</param>
        /// <returns>A list of all found Kunden or Kontakte</returns>
        public List<KundeKontaktTable> GetKundenKontakte(KundeKontaktTable k)
        {
            string s_type = k.Type == false ? "Kunde" : "Kontakt";
            string sql = GetKundenKontakteSQL(k);
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

                // if it shall be searched for ID, really only search for ID and ignore other fields
                if (k.ID != -1)
                {
                    SQLiteParameter p_ID = new SQLiteParameter();
                    p_ID.Value = k.ID;
                    cmd.Parameters.Add(p_ID);
                }

                // bind first name
                if (k.ID < 0 && k.Vorname.Length != 0)
                {
                    SQLiteParameter p_firstname = new SQLiteParameter();
                    p_firstname.Value = k.Vorname;
                    cmd.Parameters.Add(p_firstname);
                }
                
                // bind last name
                if (k.ID < 0 && k.NachnameFirmenname.Length != 0)
                {
                    SQLiteParameter p_lastname = new SQLiteParameter();
                    p_lastname.Value = k.NachnameFirmenname;
                    cmd.Parameters.Add(p_lastname);
                }
                
                // execute and get results
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    KundeKontaktTable result = new KundeKontaktTable();
                    result.ID = reader.GetInt32(0);
                    result.Vorname = reader.GetString(1);
                    result.NachnameFirmenname = reader.GetString(2);
                    result.Type = k.Type;

                    // if nothing is stored within field "Vorname", just return empty string
                    if (result.Vorname == "<null>")
                    { result.Vorname = string.Empty; }

                    resultlist.Add(result);
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
        /// <param name="k">The to be updated Kunde/Kontakt object</param>
        public void UpdateKundeKontakte(KundeKontaktTable k)
        {
            string s_type = k.Type == false ? "Kunde" : "Kontakt";
            string sql = "UPDATE " + s_type + " SET Vorname = ?, Nachname_Firmenname = ? WHERE ID = ?";

            try
            {
                this.SendStatementToDatabase(sql, k.ID, k.Vorname, k.NachnameFirmenname);
            }
            catch (SQLiteException)
            {
                throw;
            }

            // success logging
            string successmessage = s_type + " has been updated in the SQLite database: ID: " + k.ID + " " + k.Vorname + " " + k.NachnameFirmenname;
            this.logger.Log(Logger.Level.Info, successmessage);
        }

        /// <summary>
        /// Deletes an existing Kunde or Kontakt out of the SQLite database
        /// </summary>
        /// <param name="k">The Kunde/Kontakt object that shall be deleted from the SQLite database</param>
        public void DeleteKundeKontakt(KundeKontaktTable k)
        {
            string s_type = k.Type == false ? "Kunde" : "Kontakt";
            string sql = "DELETE FROM " + s_type + " WHERE ID = ?";

            try
            {
                this.SendStatementToDatabase(sql, k.ID);
            }
            catch (SQLiteException)
            {
                throw;
            }

            // success logging
            string successmessage = s_type + " has been dropped from the SQLite database. ID: " + k.ID;
            this.logger.Log(Logger.Level.Info, successmessage);
        }

        /// <summary>
        /// Gets an sql statement and an ID and commits statement
        /// </summary>
        /// <param name="sql">The sql statement</param>
        /// <param name="id">The ID of the table. Is -1, if not needed. Is >=0, if it shall be used (i.e. for WHERE kundenID = ?)</param>
        /// <param name="parameter">A string array of provided optional paramter</param>
        private void SendStatementToDatabase(string sql, int id, params object[] parameter)
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

                // set optional string parameters
                foreach (object p in parameter)
                {
                    SQLiteParameter param = new SQLiteParameter();
                    param.Value = p;
                    cmd.Parameters.Add(param);
                }

                // initialise and bind ID - at the end of the string, mostly in WHERE needed!
                if (id >= 0)
                {
                    SQLiteParameter p_ID = new SQLiteParameter();
                    p_ID.Value = id;
                    cmd.Parameters.Add(p_ID);
                }

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

        /// <summary>
        /// Creates a new Angebot with the provided parameters and saves it in the SQLite-DB
        /// </summary>
        /// <param name="angebot">The business object with all needed data</param>
        public void CreateAngebot(AngebotTable angebot)
        {
            string sql = "INSERT INTO Angebot (kundenID, Angebotssumme, Angebotsdauer, Erstellungsdatum, Umsetzung, Beschreibung) VALUES (?, ?, ?, ?, ?, ?)";

            try
            {
                this.SendStatementToDatabase(sql, -1, angebot.KundenID, angebot.Angebotssumme, angebot.Angebotsdauer, angebot.Erstellungsdatum, angebot.Umsetzungschance, angebot.Beschreibung);
            }
            catch (SQLiteException)
            {
                this.logger.Log(Logger.Level.Error, "An SQLite exception occured while saving a new Angebot within the SQLite database.");
                throw;
            }
            this.logger.Log(Logger.Level.Info, "New Angebot has been stored within the SQLite database.");
        }

        /// <summary>
        /// Receive params and load fitting existing Angebote from the SQLite database
        /// </summary>
        /// <param name="kid">The ID of the Kunde</param>
        /// <param name="from">A date string which indicates the search-begin date</param>
        /// <param name="until">A date string which indicates the search-end date</param>
        /// <returns>A resultlist of all fitting Angebote</returns>
        public List<AngebotTable> LoadAngebote(int kid, string from, string until)
        {
            string sql = "SELECT * FROM Angebot WHERE ";
            sql += kid >= 0 ? "kundenID = ? AND angebotsdauer BETWEEN ? AND ?;" : "angebotsdauer BETWEEN ? AND ?;";

            List<AngebotTable> results = new List<AngebotTable>();

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

                // if it shall be searched for ID, really only search for ID and ignore other fields
                if (kid != -1)
                {
                    SQLiteParameter p_ID = new SQLiteParameter();
                    p_ID.Value = kid;
                    cmd.Parameters.Add(p_ID);
                }

                // bind from
                SQLiteParameter p_from = new SQLiteParameter();
                p_from.Value = from;
                cmd.Parameters.Add(p_from);

                // bind to
                SQLiteParameter p_until = new SQLiteParameter();
                p_until.Value = until;
                cmd.Parameters.Add(p_until);                

                // execute and get results
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    AngebotTable result = new AngebotTable();
                    result.ID = reader.GetInt32(0);
                    result.KundenID = reader.GetInt32(1);
                    result.Angebotssumme = reader.GetFloat(2);
                    result.Angebotsdauer = reader.GetString(3);
                    result.Erstellungsdatum = reader.GetString(4);
                    result.Umsetzungschance = reader.GetInt32(5);
                    result.Beschreibung = reader.GetString(6);

                    results.Add(result);
                }

                return results;
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
        /// Creates a new Projekt with the provided parameters and stores it in the SQLite database
        /// </summary>
        /// <param name="projektname">The projekt which shall be saved</param>
        public void CreateProjekt(ProjektTable pj)
        {
            string sql = "INSERT INTO Projekt (AngebotID, Projektname, Projektstart) VALUES (?, ?, ?)";

            try
            {
                this.SendStatementToDatabase(sql, -1, pj.AngebotID, pj.Projektname, pj.Projektstart);
                logger.Log(Logger.Level.Info, pj.AngebotID + " " + pj.Projektname + " " + pj.Projektstart);
            }
            catch (SQLiteException)
            {
                throw;
            }

            // success logging
            this.logger.Log(Logger.Level.Info, "New Projekt " +pj.Projektname+ " has been stored in the SQLite database.");
        }

        /// <summary>
        /// Loads existing Projekte out of the SQLite database
        /// </summary>
        /// <param name="from">Start searching date in format DD.MM.YYYY</param>
        /// <param name="until">End searching date in format DD.MM.YYYY</param>
        /// <param name="kundenID">The ID of the related kundenID. -1, if any.</param>
        /// <returns>A resultlist of the found matching Projekte</returns>
        public List<ProjektTable> LoadProjekte(string from, string until, int kundenID)
        {   
            string sql;
            if (kundenID >= 0)
            {
                sql = "SELECT t0.ID, t0.AngebotID, t0.Projektname, t0.Projektstart FROM Projekt t0 JOIN Angebot t1 on t0.AngebotID = t1.ID WHERE t1.KundenID = ? AND t0.Projektstart BETWEEN ? AND ?";
            }
            else
            {
                sql = "SELECT * FROM Projekt WHERE Projektstart BETWEEN ? AND ?";
            }
            

            List<ProjektTable> results = new List<ProjektTable>();

            // open connection and get requested Projekt(e) out of database
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

                if (kundenID != -1)
                {
                    SQLiteParameter p_ID = new SQLiteParameter();
                    p_ID.Value = kundenID;
                    cmd.Parameters.Add(p_ID);
                }

                // bind from
                SQLiteParameter p_from = new SQLiteParameter();
                p_from.Value = from;
                cmd.Parameters.Add(p_from);

                // bind to
                SQLiteParameter p_until = new SQLiteParameter();
                p_until.Value = until;
                cmd.Parameters.Add(p_until);                

                // execute and get results
                reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    ProjektTable result = new ProjektTable();
                    result.ID = reader.GetInt32(0);
                    result.AngebotID = reader.GetInt32(1);
                    result.Projektname = reader.GetString(2);
                    result.Projektstart = reader.GetString(3);
                    results.Add(result);
                }

                return results;
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