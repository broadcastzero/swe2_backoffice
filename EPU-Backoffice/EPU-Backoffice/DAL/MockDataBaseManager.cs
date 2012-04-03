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
    using Logger;

    /// <summary>
    /// This class manages the mock database.
    /// </summary>
    public class MockDataBaseManager : IDAL
    {
        Logger logger = Logger.Instance;

        // Private fields for Kunden/Kontakte-IDs
        private static int _kundenID = 0;
        private static int _kontaktID = 0;

        // Private fields for saved Kunden/Kontakte (ILists)
        private static List<KundeTable> _savedKunden;
        private static List<KontaktTable> _savedKontakte;

        /// <summary>
        /// A continuing, unique ID for the table "Kunden"
        /// </summary>
        public static int kundenID { get { return _kundenID++; } }

        /// <summary>
        /// A continuing, unique ID for the table "Kontakte"
        /// </summary>
        public static int kontaktID { get { return _kontaktID++; } }

        /// <summary>
        /// Static list in which created Kunden are stored
        /// </summary>
        public static List<KundeTable> savedKunden { get { return _savedKunden; } }

        /// <summary>
        /// Static list in which created Kontakt are stored
        /// </summary>
        public static List<KontaktTable> savedKontakte { get { return _savedKontakte; } }

        /// <summary>
        /// This method initializes the classes needed to create a mock database
        /// </summary>
        public void CreateDataBase()
        {
            MockDataBaseManager._savedKunden = new List<KundeTable>();
            MockDataBaseManager._savedKontakte = new List<KontaktTable>();
        }

        /// <summary>
        /// Saves a new Kunde or Kontakt to the mock database (IList)
        /// </summary>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">false...Kunde, true...Kontakt</param>
        public void SaveNewKunde(string lastname, bool type, string firstname = null)
        {
            if (type == false)
            {
                KundeTable kunde = new KundeTable();
                kunde.ID = MockDataBaseManager.kundenID;
                kunde.Vorname = firstname;
                kunde.NachnameFirmenname = lastname;

                // save to list
                MockDataBaseManager.savedKunden.Add(kunde);
                this.logger.Log(0, "A new Kunde has been saved in the mockDB.");
            }
            else
            {
                KontaktTable kontakt = new KontaktTable();
                kontakt.ID = MockDataBaseManager.kontaktID;
                kontakt.Vorname = firstname;
                kontakt.NachnameFirmenname = lastname;

                // save to list
                MockDataBaseManager.savedKontakte.Add(kontakt);
                this.logger.Log(0, "A new Kontakt has been saved in the mockDB.");
            }
        }

        /// <summary>
        /// This function gets (a) certain Kontakt(e) from the mock database.
        /// If firstname and lastname should be empty, display all
        /// </summary>
        /// <param name="firstname">First name of the to-be-searched Kontakt (optional)</param>
        /// <param name="lastname">Last name of the to-be-searched Kontakt (optional)</param>
        /// <returns>A list of the requested Kontakte</returns>
        public List<KontaktTable> GetKontakte(string firstname = null, string lastname = null)
        {
            return new List<KontaktTable>();
        }

        /// <summary>
        /// This function gets (a) certain Kunde(n) from the mockDB.
        /// If firstname and lastname should be empty, display all
        /// </summary>
        /// <param name="firstname">First name of the to-be-searched Kunde (optional)</param>
        /// <param name="lastname">Last name of the to-be-searched Kunde (optional)</param>
        /// <returns>A list of the requested Kunden</returns>
        public List<KundeTable> GetKunden(string firstname = null, string lastname = null)
        {
            return new List<KundeTable>();
        }
    }
}
