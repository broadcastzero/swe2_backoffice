// -----------------------------------------------------------------------
// <copyright file="MockDataBaseManager.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.UserExceptions;
    using LoggingFramework;

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

        // Private fields for Projekt-IDs
        private static int projektID = 0;

        // Private fields for Eingangsrechnungs-IDs
        private static int eingangsrechnungID = 0;

        // Private fields for Ausgangsrechnungs-IDs
        private static int ausgangsrechnungID = 0;

        // Private fields for Buchungszeilen-IDs
        private static int buchungszeilenID = 0;

        // Private fields for Zeiterfassungs-IDs
        private static int zeiterfassungID = 0;

        /// <summary>
        /// Gets or sets a continuing, unique ID for the table "Kunden"
        /// </summary>
        public static int KundenID { get { return kundenID++; } }

        /// <summary>
        /// Gets or sets a continuing, unique ID for the table "Kontakte"
        /// </summary>
        public static int KontaktID { get { return kontaktID++; } }

        /// <summary>
        /// Gets or sets a continuing, unique ID for the table "Angebote"
        /// </summary>
        public static int AngebotID { get { return angebotID++; } }

        /// <summary>
        /// Gets or sets a continuing, unique ID for the table "Projekte"
        /// </summary>
        public static int ProjektID { get { return projektID++; } }

        /// <summary>
        /// Gets or sets a continuing, unique ID for the table "Eingangsrechnung"
        /// </summary>
        public static int EingangsrechnungsID { get { return eingangsrechnungID++; } }

        /// <summary>
        /// Gets or sets a continuing, unique ID for the table "Ausgangsrechnung"
        /// </summary>
        public static int AusgangsrechnungsID { get { return ausgangsrechnungID++; } }

        /// <summary>
        /// Gets or sets a continuing, unique ID for the table "Eingangsrechnung"
        /// </summary>
        public static int BuchungszeilenID { get { return buchungszeilenID++; } }

        /// <summary>
        /// Gets or sets a continuing, unique ID for the table "Eingangsrechnung"
        /// </summary>
        public static int ZeitaufzeichnungID { get { return zeiterfassungID++; } }

        // Gets or sets private fields for saved Kunden/Kontakte (ILists)
        private static List<KundeKontaktTable> savedKunden;
        private static List<KundeKontaktTable> savedKontakte;

        // Gets or sets private fields for saved Angebote (ILists)
        private static List<AngebotTable> savedAngebote;

        // Gets or sets private fields for saved Projekte (ILists)
        private static List<ProjektTable> savedProjekte;

        // Gets or sets private fields for saved Eingangsrechnungen (ILists)
        private static List<EingangsrechnungTable> savedEingangsrechnungen;

        // Gets or sets private fields for saved Ausgangsrechnungen (ILists)
        private static List<AusgangsrechnungTable> savedAusgangsrechnungen;

        // Gets or sets private fields for saved Ausgangsbuchungen (ILists)
        private static List<AusgangsbuchungTable> savedAusgangsbuchungen;

        // Gets or sets private fields for saved Eingangsbuchungen (ILists)
        private static List<EingangsbuchungTable> savedEingangsbuchungen;

        // Gets or sets private fields for saved Buchungszeilen (ILists)
        private static List<BuchungszeilenTable> savedBuchungszeilen;

        // Gets or sets private fields for saved Zeitaufzeichnungen (ILists)
        private static List<ZeitaufzeichnungTable> savedZeitaufzeichnungen;

        /// <summary>
        /// Gets or sets static list in which created Kunden are stored
        /// </summary>
        public static List<KundeKontaktTable> SavedKunden { get { return savedKunden; } }

        /// <summary>
        /// Gets or sets static list in which created Kontakt are stored
        /// </summary>
        public static List<KundeKontaktTable> SavedKontakte { get { return savedKontakte; } }

        /// <summary>
        /// Gets or sets static list in which created Angebot is stored
        /// </summary>
        public static List<AngebotTable> SavedAngebote { get { return savedAngebote; } }

        /// <summary>
        /// Gets or sets static list in which created Angebot is stored
        /// </summary>
        public static List<ProjektTable> SavedProjekte { get { return savedProjekte; } }

        /// <summary>
        /// Gets or sets static list in which created Eingangsrechnung is stored
        /// </summary> 
        private static List<EingangsrechnungTable> SavedEingangsrechnungen { get { return savedEingangsrechnungen; } }

        /// <summary>
        /// Gets or sets static list in which created Ausgangsrechnung is stored
        /// </summary> 
        private static List<AusgangsrechnungTable> SavedAusgangsrechnung { get { return savedAusgangsrechnungen; } }

        /// <summary>
        /// Gets or sets static list in which created Eingangsbuchung is stored
        /// </summary> 
        private static List<EingangsbuchungTable> SavedEingangsbuchungen { get { return savedEingangsbuchungen; } }

        /// <summary>
        /// Gets or sets static list in which created Ausgangsbuchung is stored
        /// </summary> 
        private static List<AusgangsbuchungTable> SavedAusgangsbuchungen { get { return savedAusgangsbuchungen; } }

        /// <summary>
        /// Gets or sets static list in which created Buchungszeile is stored
        /// </summary> 
        private static List<BuchungszeilenTable> SavedBuchungszeilen { get { return savedBuchungszeilen; } }

        /// <summary>
        /// Gets or sets static list in which created Eingangsrechnung is stored
        /// </summary> 
        private static List<ZeitaufzeichnungTable> SavedZeitaufzeichnungen { get { return savedZeitaufzeichnungen; } }

        // A threading lock object
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
                MockDataBaseManager.savedProjekte = new List<ProjektTable>();
                MockDataBaseManager.savedEingangsrechnungen = new List<EingangsrechnungTable>();
                MockDataBaseManager.savedZeitaufzeichnungen = new List<ZeitaufzeichnungTable>();
                MockDataBaseManager.savedEingangsbuchungen = new List<EingangsbuchungTable>();
                MockDataBaseManager.savedAusgangsbuchungen = new List<AusgangsbuchungTable>();
                MockDataBaseManager.savedAusgangsrechnungen = new List<AusgangsrechnungTable>();
                MockDataBaseManager.savedBuchungszeilen = new List<BuchungszeilenTable>();
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
                    // if it shall be searched for ID, really only search for ID and ignore other field values
                    if (k.ID == kunde.ID)
                    {
                        resultlist.Add(kunde);
                        break; // Kunde found, there is no other for ID is unique
                    }
                    else if (k.Vorname.Length == 0 && k.NachnameFirmenname.Length == 0)
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
                    // if it shall be searched for ID, really only search for ID and ignore other field values
                    if (k.ID == kontakt.ID)
                    {
                        resultlist.Add(kontakt);
                        break; // Kontakt found, there is no other for ID is unique
                    }
                    else if (k.Vorname.Length == 0 && k.NachnameFirmenname.Length == 0)
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
        /// Gets an Angebot table with the needed parameters and saves it in the mockDB
        /// </summary>
        /// <param name="angebot">The business object</param>
        public void CreateAngebot(AngebotTable angebot)
        {
            MockDataBaseManager.savedAngebote.Add(angebot);
            this.logger.Log(Logger.Level.Info, "Angebot saved to the mockDB");
        }

        /// <summary>
        /// Receive params and load fitting existing Angebote from the mockDB
        /// </summary>
        /// <param name="kid">The ID of the Kunde</param>
        /// <param name="from">A date string which indicates the search-begin date</param>
        /// <param name="until">A date string which indicates the search-end date</param>
        /// <returns>A resultlist of all fitting Angebote</returns>
        public List<AngebotTable> LoadAngebote(int kid, string from, string until, bool loadwithaid)
        {
            List<AngebotTable> results = new List<AngebotTable>();
            bool couldparse;

            DateTime dfrom = new DateTime();
            DateTime duntil = new DateTime();

            try
            {
                couldparse = DateTime.TryParse(from, out dfrom);
                this.CheckBoolInvalidInput(couldparse);

                couldparse = DateTime.TryParse(until, out duntil);
                this.CheckBoolInvalidInput(couldparse);
            }
            catch(InvalidInputException)
            {
                throw;
            }

            // run through the list
            foreach (AngebotTable angebot in MockDataBaseManager.SavedAngebote)
            { 
                DateTime storedValue = new DateTime();
                couldparse = DateTime.TryParse(angebot.Angebotsdauer, out storedValue);

                try
                {
                    this.CheckBoolInvalidInput(couldparse);
                }
                catch(InvalidInputException)
                {
                    throw;
                }

                // if KundenID is the same as stored or it is -1 (which means that we don't want to search for Kunde and the saved date is between the requested
                if ((angebot.KundenID == kid || kid == -1) && storedValue >= dfrom && storedValue <= duntil)
                {
                    results.Add(angebot);
                }
            }

            return results;
        }

        /// <summary>
        /// Checks a provided bool value. If false, throws InvalidInputException.
        /// </summary>
        /// <param name="input"></param>
        /// <exception cref="InvalidInputException">Throws InvalidInputException</exception>
        private void CheckBoolInvalidInput(bool couldparse)
        {
            if (couldparse == false)
            {
                throw new InvalidInputException("Date string provided is invalid!");
            }
        }

        /// <summary>
        /// Creates a new Projekt with the provided parameters and stores it in the mock database
        /// </summary>
        /// <param name="projektname">The projekt which shall be saved</param>
        public void CreateProjekt(ProjektTable pj)
        {
            pj.ID = MockDataBaseManager.ProjektID;
            MockDataBaseManager.savedProjekte.Add(pj);

            this.logger.Log(Logger.Level.Info, "A new Projekt has been stored within the SQLite database");
        }

        /// <summary>
        /// Loads existing Projekte out of the mock database
        /// </summary>
        /// <param name="from">Start searching date in format DD.MM.YYYY</param>
        /// <param name="until">End searching date in format DD.MM.YYYY</param>

        /// <param name="kundenID">The ID of the related kundenID. -1, if any.</param>
        /// <returns>A resultlist of the found matching Projekte</returns>
        public List<ProjektTable> LoadProjekte(string from, string until, int kundenID = -1)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves a new Eingangsrechnung to the mock database
        /// </summary>
        /// <param name="table">The business object</param>
        /// <returns>The id of the just inserted Eingangsrechnung</returns>
        public int CreateEingangsrechnung(EingangsrechnungTable table)
        {
            table.ID = MockDataBaseManager.EingangsrechnungsID;
            MockDataBaseManager.savedEingangsrechnungen.Add(table);

            return table.ID;
        }

        /// <summary>
        /// Loads all Eingangsrechnungen as Views
        /// </summary>
        /// <returns>The saved Eingangsrechnungen</returns>
        public List<EingangsrechnungsView> LoadEingangsrechnungsView()
        {
            List<EingangsrechnungsView> view = new List<EingangsrechnungsView>();
            int buchungsID = -1;
            BuchungszeilenTable zeile = new BuchungszeilenTable();

            foreach (EingangsrechnungTable table in savedEingangsrechnungen)
            {
                EingangsrechnungsView viewelement = new EingangsrechnungsView();
                viewelement.ID = table.ID;
                viewelement.Bezeichnung = table.Bezeichnung;
                viewelement.Rechnungsdatum = table.Rechnungsdatum;

                // get connected EingangsbuchungsID
                foreach (EingangsbuchungTable b in savedEingangsbuchungen)
                {
                    if (b.EingangsrechungsID == viewelement.ID)
                    {
                        buchungsID = b.BuchungszeilenID;
                        break;
                    }
                }

                // get connected Buchungszeile and Betrag
                foreach (BuchungszeilenTable b in savedBuchungszeilen)
                {
                    if (b.ID == buchungsID)
                    {
                        viewelement.Betrag = b.BetragUST;
                        break;
                    }
                }

                view.Add(viewelement);
            }

            return view;
        }


        public void SaveNewZeiterfassung(ZeitaufzeichnungTable z)
        {
            z.ID = MockDataBaseManager.ZeitaufzeichnungID;
            MockDataBaseManager.savedZeitaufzeichnungen.Add(z);
        }

        public List<ZeitaufzeichnungTable> LoadZeiterfassung(int projektID)
        {
            return MockDataBaseManager.SavedZeitaufzeichnungen;
        }

        /// <summary>
        /// Saves a new Buchungszeile to the mock db
        /// </summary>
        /// <param name="table">The business object</param>
        /// <returns>The ID of the inserted Buchungszeile</returns>
        public int SaveBuchungszeile(BuchungszeilenTable table)
        {
            table.ID = MockDataBaseManager.BuchungszeilenID;
            MockDataBaseManager.savedBuchungszeilen.Add(table);
            return table.ID;
        }

        /// <summary>
        /// Saves a new Eingangsbuchung to the database
        /// </summary>
        /// <param name="table">The Eingangsbuchungstable</param>
        public void SaveEingangsbuchung(EingangsbuchungTable table)
        {
            MockDataBaseManager.savedEingangsbuchungen.Add(table);
        }

        /// <summary>
        /// Saves a new connection between Ausgangsrechnung and Buchungszeile
        /// </summary>
        /// <param name="table">The Ausgangsbuchungs table</param>
        public void SaveAusgangsbuchung(AusgangsbuchungTable table)
        {
            MockDataBaseManager.savedAusgangsbuchungen.Add(table);
        }

        /// <summary>
        /// Saves a new Ausgangsrechnung
        /// </summary>
        /// <param name="table">The Ausgangsrechnung table</param>
        /// <returns>The ID of the just inserted Ausgangsrechnung</returns>
        public int SaveAusgangsrechnung(AusgangsrechnungTable table)
        {
            table.ID = MockDataBaseManager.AusgangsrechnungsID;
            MockDataBaseManager.savedAusgangsrechnungen.Add(table);

            return table.ID;
        }


        public List<AusgangsrechnungsView> LoadAusgangsrechnungsView()
        {
            throw new NotImplementedException();
        }
    }
}
