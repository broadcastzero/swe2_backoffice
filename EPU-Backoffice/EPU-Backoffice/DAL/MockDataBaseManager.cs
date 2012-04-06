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

        // Private fields for saved Kunden/Kontakte (ILists)
        private static List<KundeKontaktTable> savedKunden;
        private static List<KundeKontaktTable> savedKontakte;

        /// <summary>
        /// A continuing, unique ID for the table "Kunden"
        /// </summary>
        public static int KundenID { get { return kundenID++; } }

        /// <summary>
        /// A continuing, unique ID for the table "Kontakte"
        /// </summary>
        public static int KontaktID { get { return kontaktID++; } }

        /// <summary>
        /// Static list in which created Kunden are stored
        /// </summary>
        public static List<KundeKontaktTable> SavedKunden { get { return savedKunden; } }

        /// <summary>
        /// Static list in which created Kontakt are stored
        /// </summary>
        public static List<KundeKontaktTable> SavedKontakte { get { return savedKontakte; } }

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
            }
        }

        /// <summary>
        /// Saves a new Kunde or Kontakt to the mock database (IList)
        /// </summary>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">false...Kunde, true...Kontakt</param>
        public void SaveNewKundeKontakt(string lastname, bool type, string firstname = null)
        {
            if (type == false)
            {
                KundeKontaktTable kunde = new KundeKontaktTable();
                kunde.ID = MockDataBaseManager.KundenID;
                kunde.Vorname = firstname;
                kunde.NachnameFirmenname = lastname;
                kunde.Type = false;

                // save to list
                MockDataBaseManager.SavedKunden.Add(kunde);
                this.logger.Log(0, "A new Kunde has been saved in the mockDB.");
            }
            else
            {
                KundeKontaktTable kontakt = new KundeKontaktTable();
                kontakt.ID = MockDataBaseManager.KontaktID;
                kontakt.Vorname = firstname;
                kontakt.NachnameFirmenname = lastname;
                kontakt.Type = true;

                // save to list
                MockDataBaseManager.SavedKontakte.Add(kontakt);
                this.logger.Log(0, "A new Kontakt has been saved in the mockDB.");
            }
        }

        /// <summary>
        /// This function gets (a) certain Kontakt(e) from the mock database.
        /// If firstname and lastname should be empty, display all
        /// </summary>
        /// <param name="type">false...Kunde, true...Kontakt</param>
        /// <param name="firstname">First name of the to-be-searched Kontakt (optional)</param>
        /// <param name="lastname">Last name of the to-be-searched Kontakt (optional)</param>
        /// <returns>A list of the requested Kontakte</returns>
        public List<KundeKontaktTable> GetKundenKontakte(bool type, string firstname = null, string lastname = null)
        {
            List<KundeKontaktTable> resultlist = new List<KundeKontaktTable>();

            // get Kunden
            if (type == false)
            {
                this.logger.Log(0, "Starts getting Kunden out of database...");

                foreach (KundeKontaktTable k in MockDataBaseManager.SavedKunden)
                {
                    if (firstname == null && lastname == null)
                    { resultlist.Add(k); }
                    else if (firstname != null && lastname == null)
                    {
                        if(k.Vorname == firstname)
                        resultlist.Add(k);
                    }
                    else if (lastname != null && firstname == null)
                    {
                        if (k.NachnameFirmenname == lastname)
                        { resultlist.Add(k); }
                    }
                    else
                    {
                        if (k.NachnameFirmenname == lastname && k.Vorname == firstname)
                        { resultlist.Add(k); }
                    }
                }
            }
            // get Kontakt
            else if (type == true)
            {
                this.logger.Log(0, "Starts getting Kontakte out of database...");

                foreach (KundeKontaktTable k in MockDataBaseManager.SavedKontakte)
                {
                    if (firstname == null && lastname == null)
                    { resultlist.Add(k); }
                    else if (firstname != null && lastname == null)
                    {
                        if (k.Vorname == firstname)
                            resultlist.Add(k);
                    }
                    else if (lastname != null && firstname == null)
                    {
                        if (k.NachnameFirmenname == lastname)
                        { resultlist.Add(k); }
                    }
                    else
                    {
                        if (k.NachnameFirmenname == lastname && k.Vorname == firstname)
                        { resultlist.Add(k); }
                    }
                }
            }

            return resultlist;
        }

        /// <summary>
        /// Deletes an existing Kunde or Kontakt out of the mock database
        /// </summary>
        /// <param name="id">The ID of the to-be-deleted Kunde or Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        public void DeleteKundeKontakt(int id, bool type)
        {
            int removed = 0;

            // delete Kunde
            if (type == false)
            {
                foreach (KundeKontaktTable k in MockDataBaseManager.SavedKunden)
                {
                    if(k.ID == id)
                    {
                        MockDataBaseManager.savedKunden.Remove(k);
                        removed++;
                        logger.Log(0, "Kunde has been removed out of mockDB: " + k.ID + " " + k.Vorname + " " + k.NachnameFirmenname);
                        break;
                    }
                }
            }
            // delete Kontakt
            else if (type == true)
            {
                foreach (KundeKontaktTable k in MockDataBaseManager.SavedKontakte)
                {
                    if (k.ID == id)
                    {
                        MockDataBaseManager.savedKontakte.Remove(k);
                        removed++;
                        logger.Log(0, "Kontakt has been removed out of mockDB: " + k.ID + " " + k.Vorname + " " + k.NachnameFirmenname);
                        break;
                    }
                }
            }

            // no entry found
            if (removed != 1)
            {
                this.logger.Log(2, "There is no entry in the mockDB with the ID " + id);
                throw new EntryNotFoundException("There is no entry in the mockDB with the ID " + id);
            }
        }
    }
}
