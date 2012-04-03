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
        // Private fields for tables Kunden/Kontakte
        private static int kunden_id = 0;
        private static int kontakt_id = 0;
        private static List<KundeTable> savedKunden;
        private static List<KontaktTable> savedKontakte;

        /// <summary>
        /// This method initializes the classes needed to create a mock database
        /// </summary>
        public void CreateDataBase()
        {
            MockDataBaseManager.savedKunden = new List<KundeTable>();
            MockDataBaseManager.savedKontakte = new List<KontaktTable>();
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
                kunde.ID = MockDataBaseManager.kunden_id++;
                kunde.Vorname = firstname;
                kunde.NachnameFirmenname = lastname;

                // save to list
                MockDataBaseManager.savedKunden.Add(kunde);
            }
            else
            {
                KontaktTable kontakt = new KontaktTable();
                kontakt.ID = MockDataBaseManager.kontakt_id++;
                kontakt.Vorname = firstname;
                kontakt.NachnameFirmenname = lastname;

                // save to list
                MockDataBaseManager.savedKontakte.Add(kontakt);
            }
        }
    }
}
