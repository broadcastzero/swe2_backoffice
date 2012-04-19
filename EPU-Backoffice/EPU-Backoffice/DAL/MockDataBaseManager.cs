// -----------------------------------------------------------------------
// <copyright file="MockDataBaseManager.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EPUBackoffice.Dal.Tables;
    using EPUBackoffice.UserExceptions;
    using Logger;

    /// <summary>
    /// This class manages the mock database.
    /// </summary>
    public class MockDataBaseManager : IDAL
    {
        private Logger logger = Logger.Instance;

        // Private fields for Kunden/Kontakte-IDs
        private static int kundenID = 0;
        private static int kontaktID = 0;

        // Private fields for Angebot-IDs
        private static int angebotID = 0;

        // Private fields for saved Kunden/Kontakte (ILists)
        private static List<KundeKontaktTable> savedKunden;
        private static List<KundeKontaktTable> savedKontakte;

        // Private fields for saved Angebote (ILists)
        private static List<AngebotTable> savedAngebote;

        /// <summary>
        /// A continuing, unique ID for the table "Kunden"
        /// </summary>
        public static int KundenID { get { return kundenID++; } }

        /// <summary>
        /// A continuing, unique ID for the table "Kontakte"
        /// </summary>
        public static int KontaktID { get { return kontaktID++; } }

        /// <summary>
        /// A continuing, unique ID for the table "Angebote"
        /// </summary>
        public static int AngebotID { get { return angebotID++; } }

        /// <summary>
        /// Static list in which created Kunden are stored
        /// </summary>
        public static List<KundeKontaktTable> SavedKunden { get { return savedKunden; } }

        /// <summary>
        /// Static list in which created Kontakt are stored
        /// </summary>
        public static List<KundeKontaktTable> SavedKontakte { get { return savedKontakte; } }

        /// <summary>
        /// Static list in which created Angebot is stored
        /// </summary>
        public static List<AngebotTable> SavedAngebote { get { return savedAngebote; } }

        private static Object lockObject = new Object();

        /// <summary>
        /// This method initializes the classes needed to create a mock database
        /// </summary>
        public void CreateDataBase()
        {
            lock(MockDataBaseManager.lockObject)
            {
                MockDataBaseManager.savedKunden = new List<KundeKontaktTable>();
                MockDataBaseManager.savedKontakte = new List<KundeKontaktTable>();
                MockDataBaseManager.savedAngebote = new List<AngebotTable>();
            }
        }

        /// <summary>
        /// Saves a new Kunde or Kontakt to the mock database (IList)
        /// </summary>
        /// <param name="k">The to-be-inserted Kunde (DAL table)</param>
        /// <returns>The ID of the newly inserted Kunde/Kontakt</returns>
        public int SaveNewKundeKontakt(KundeKontaktTable k)
        {
            if(k.Type == false)
            {
                k.ID = MockDataBaseManager.KundenID;

                // save to list
                MockDataBaseManager.SavedKunden.Add(k);
                this.logger.Log(Logger.Level.Info, "A new Kunde has been saved in the mockDB.");

                return k.ID;
            }
            else
            {
                k.ID = MockDataBaseManager.KontaktID;

                // save to list
                MockDataBaseManager.SavedKontakte.Add(k);
                this.logger.Log(Logger.Level.Info, "A new Kontakt has been saved in the mockDB.");

                return k.ID;
            }
        }

        /// <summary>
        /// This function gets (a) certain Kontakt(e) from the mock database.
        /// If firstname and lastname should be empty, display all
        /// </summary>
        /// <param name="k">The Kunde or Kontakt table object that shall be searched for</param>
        /// <returns>A list of the requested Kontakte</returns>
        public List<KundeKontaktTable> GetKundenKontakte(KundeKontaktTable k)
        {
            List<KundeKontaktTable> resultlist = new List<KundeKontaktTable>();

            // get Kunden
            if (k.Type == false)
            {
                this.logger.Log(Logger.Level.Info, "Starts getting Kunden out of database...");

                foreach (KundeKontaktTable kunde in MockDataBaseManager.SavedKunden)
                {
                    if (k.Vorname.Length == 0 && k.NachnameFirmenname.Length == 0)
                    { resultlist.Add(kunde); }
                    else if (k.Vorname.Length != 0 && k.NachnameFirmenname.Length == 0)
                    {
                        if(kunde.Vorname == k.Vorname)
                        resultlist.Add(kunde);
                    }
                    else if (k.NachnameFirmenname.Length != 0 && k.NachnameFirmenname.Length == 0)
                    {
                        if (kunde.NachnameFirmenname == k.NachnameFirmenname)
                        { resultlist.Add(kunde); }
                    }
                    else
                    {
                        if (kunde.NachnameFirmenname == k.NachnameFirmenname && kunde.Vorname == k.Vorname)
                        { resultlist.Add(kunde); }
                    }
                }
            }
            // get Kontakt
            else if (k.Type == true)
            {
                this.logger.Log(Logger.Level.Info, "Starts getting Kontakte out of database...");

                foreach (KundeKontaktTable kontakt in MockDataBaseManager.SavedKontakte)
                {
                    if (k.Vorname.Length == 0 && k.NachnameFirmenname.Length == 0)
                    { resultlist.Add(kontakt); }
                    else if (k.Vorname.Length != 0 && k.NachnameFirmenname.Length == 0)
                    {
                        if (kontakt.Vorname == k.Vorname)
                            resultlist.Add(kontakt);
                    }
                    else if (k.NachnameFirmenname.Length != 0 && k.Vorname.Length == 0)
                    {
                        if (kontakt.NachnameFirmenname == k.NachnameFirmenname)
                        { resultlist.Add(kontakt); }
                    }
                    else
                    {
                        if (kontakt.NachnameFirmenname == k.NachnameFirmenname && kontakt.Vorname == k.Vorname)
                        { resultlist.Add(kontakt); }
                    }
                }
            }

            return resultlist;
        }

        /// <summary>
        /// Updates information of an existing Kunde or Kontakt
        /// </summary>
        /// <param name="k">The to-be-changed Kunde or Kontakt</param>
        public void UpdateKundeKontakte(KundeKontaktTable k)
        {
            // Kunde
            if(k.Type == false)
            {
                int index = MockDataBaseManager.SavedKunden.IndexOf(k);

                if (index < 0)
                {
                    this.logger.Log(Logger.Level.Error, "Kunde which shall be updated has not been found!");
                }

                MockDataBaseManager.SavedKunden[index].Vorname = k.Vorname;
                MockDataBaseManager.SavedKunden[index].NachnameFirmenname = k.NachnameFirmenname;

                this.logger.Log(Logger.Level.Info, "Kunde has been updated within mockDB.");
            }
            // Kontakt
            else
            {
                int index = MockDataBaseManager.SavedKontakte.IndexOf(k);

                if (index < 0)
                {
                    this.logger.Log(Logger.Level.Error, "Kontakt which shall be updated has not been found!");
                }

                MockDataBaseManager.SavedKontakte[index].Vorname = k.Vorname;
                MockDataBaseManager.SavedKontakte[index].NachnameFirmenname = k.NachnameFirmenname;

                this.logger.Log(Logger.Level.Info, "Kontakt has been updated within mockDB.");
            }
        }

        /// <summary>
        /// Deletes an existing Kunde or Kontakt out of the mock database
        /// </summary>
        /// <param name="k">The Kunde/Kontakt object that shall be deleted</param>
        public void DeleteKundeKontakt(KundeKontaktTable k)
        {
            int removed = 0;

            // delete Kunde
            if (k.Type == false)
            {
                foreach (KundeKontaktTable kunde in MockDataBaseManager.SavedKunden)
                {
                    if(kunde.ID == k.ID)
                    {
                        MockDataBaseManager.savedKunden.Remove(kunde);
                        removed++;
                        logger.Log(Logger.Level.Info, "Kunde has been removed out of mockDB: " + kunde.ID + " " + kunde.Vorname + " " + kunde.NachnameFirmenname);
                        break;
                    }
                }
            }
            // delete Kontakt
            else if (k.Type == true)
            {
                foreach (KundeKontaktTable kontakt in MockDataBaseManager.SavedKontakte)
                {
                    if (kontakt.ID == k.ID)
                    {
                        MockDataBaseManager.savedKontakte.Remove(kontakt);
                        removed++;
                        logger.Log(Logger.Level.Info, "Kontakt has been removed out of mockDB: " + kontakt.ID + " " + kontakt.Vorname + " " + kontakt.NachnameFirmenname);
                        break;
                    }
                }
            }

            // no entry found
            if (removed != 1)
            {
                this.logger.Log(Logger.Level.Error, "There is no entry in the mockDB with the ID " + k.ID);
                throw new EntryNotFoundException("There is no entry in the mockDB with the ID " + k.ID);
            }
        }

        /// <summary>
        /// Creates a new Angebot with the provided parameters and saves it in the mockDB
        /// </summary>
        /// <param name="kundenID">The foreign key to Kunde</param>
        /// <param name="angebotssumme">The amount of money the costumer will have to pay</param>
        /// <param name="umsetzungswahrscheinlichkeit">Chance of realisation (0-100%)</param>
        /// <param name="validUntil">Deadline date</param>
        /// <param name="description">A short description of the Angebot</param>
        public void CreateAngebot(int kundenID, double angebotssumme, int umsetzungswahrscheinlichkeit, string validUntil, string description)
        {
            AngebotTable angebot = new AngebotTable();
            angebot.ID = MockDataBaseManager.AngebotID;
            angebot.KundenID = kundenID;
            angebot.Angebotssumme = angebotssumme;
            angebot.Umsetzungschance = umsetzungswahrscheinlichkeit;
            angebot.Angebotsdauer = validUntil;
            angebot.Beschreibung = description;

            MockDataBaseManager.savedAngebote.Add(angebot);
        }

        /// <summary>
        /// Receive params and load fitting existing Angebote from the mock database
        /// </summary>
        /// <param name="from">A date string which indicates the search-begin date</param>
        /// <param name="until">A date string which indicates the search-end date</param>
        /// <param name="firstname">The first name of the Kunde</param>
        /// <param name="lastname">The last name of the Kunde</param>
        /// <returns>A resultlist of all fitting Angebote</returns>
        public List<AngebotTable> LoadAngebote(string from, string until, string firstname = null, string lastname = null)
        {
            // TODO: Add selective logic
            return MockDataBaseManager.SavedAngebote;
        }

        /// <summary>
        /// Creates a new Projekt with the provided parameters and stores it in the mock database
        /// </summary>
        /// <param name="projektname">The name of the Projekt</param>
        /// <param name="angebotID">The ID of the existing Angebot</param>
        /// <param name="startdate">The start date of the Projekt</param>
        public void CreateProjekt(string projektname, int angebotID, string startdate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Loads existing Projekte out of the mock database
        /// </summary>
        /// <param name="from">Start searching date in format DD.MM.YYYY</param>
        /// <param name="until">End searching date in format DD.MM.YYYY</param>
        /// <param name="projektID">The ID of the to-be-searched projekt. -1, if any.</param>
        /// <param name="kundenID">The ID of the related kundenID. -1, if any.</param>
        /// <returns>A resultlist of the found matching Projekte</returns>
        public List<ProjektTable> LoadProjekte(string from, string until, int projektID = -1, int kundenID = -1)
        {
            throw new NotImplementedException();
        }
    }
}
