// -----------------------------------------------------------------------
// <copyright file="IDAL.cs" company="Marvin&Felix">
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

    /// <summary>
    /// An Interface to make the data access layer dynamic. Database class must implement these methods.
    /// </summary>
    public interface IDAL
    {
        /// <summary>
        /// This method is responsible for creating a new (mock) database with all its needed tables
        /// </summary>
        void CreateDataBase();

        /// <summary>
        /// This function gets (a) certain Kontakt(e) from the saved objects.
        /// If firstname and lastname should be empty, display all
        /// </summary>
        /// <param name="k">The object that shall be searched for</param>
        /// <returns>A list of the requested Kontakte</returns>
        List<KundeKontaktTable> GetKundenKontakte(KundeKontaktTable k);

        /// <summary>
        /// Saves a new Kunde or Kontakt to the database.
        /// </summary>
        /// <param name="k">The Kunde/Kontakt object that shall be saved</param>
        int SaveNewKundeKontakt(KundeKontaktTable k);

        /// <summary>
        /// Changes data of an existing Kunde/Kontakt
        /// </summary>
        /// <param name="k">The values of the to-be-changed Kunde</param>
        void UpdateKundeKontakte(KundeKontaktTable k);

        /// <summary>
        /// Deletes an existing Kunde or Kontakt out of the database
        /// </summary>
        /// <param name="k">The Kunde/Kontakt table object that shall be deleted</param>
        void DeleteKundeKontakt(KundeKontaktTable k);

        /// <summary>
        /// Creates a new Angebot with the provided parameters
        /// </summary>
        /// <param name="angebot">The business object</param>
        void CreateAngebot(AngebotTable angebot);

        /// <summary>
        /// Receive params and load fitting existing Angebote
        /// </summary>
        /// <param name="kid">The ID of the Kunde</param>
        /// <param name="from">A date string which indicates the search-begin date</param>
        /// <param name="until">A date string which indicates the search-end date</param>
        /// <returns>A resultlist of all fitting Angebote</returns>
        List<AngebotTable> LoadAngebote(int kid, string from, string until);

        /// <summary>
        /// Creates a new Projekt with the provided parameters and stores it in the SQLite database
        /// </summary>
        /// <param name="´pj">The Projekt which shall be saved</param>
        void CreateProjekt(ProjektTable pj);

        /// <summary>
        /// Loads existing Projekte out of the SQLite database
        /// </summary>
        /// <param name="from">Start searching date in format DD.MM.YYYY</param>
        /// <param name="until">End searching date in format DD.MM.YYYY</param>
        /// <param name="kundenID">The ID of the related kundenID. -1, if any.</param>
        /// <returns>A resultlist of the found matching Projekte</returns>
        List<ProjektTable> LoadProjekte(string from, string until, int kundenID = -1);

        /// <summary>
        /// Saves a new Eingangsrechnung to the database
        /// </summary>
        /// <param name="table">The business object</param>
        /// <returns>The id of the just inserted Eingangsrechnung</returns>
        int CreateEingangsrechnung(EingangsrechnungTable table);

        /// <summary>
        /// Loads all Eingangsrechnungen
        /// </summary>
        /// <returns>The saved Eingangsrechnungen</returns>
        List<EingangsrechnungTable> LoadEingangsrechnungen();


        /// <summary>
        /// Saves all Zeiterfassungs entryx
        /// </summary>
        /// <param name="z">Table name</param>
        void SaveNewZeiterfassung(ZeitaufzeichnungTable z);
    }
}
