// -----------------------------------------------------------------------
// <copyright file="IDAL.cs" company="Marvin&Felix">
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
        /// <param name="type">false...Kunde, true...Kontakt</param>
        /// <param name="firstname">First name of the to-be-searched Kontakt (optional)</param>
        /// <param name="lastname">Last name of the to-be-searched Kontakt (optional)</param>
        /// <returns>A list of the requested Kontakte</returns>
        List<KundeKontaktTable> GetKundenKontakte(bool type, string firstname = null, string lastname = null);

        /// <summary>
        /// Saves a new Kunde or Kontakt to the database.
        /// </summary>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        void SaveNewKundeKontakt(string lastname, bool type, string firstname = "<null>");

        /// <summary>
        /// Deletes an existing Kunde or Kontakt out of the database
        /// </summary>
        /// <param name="id">The ID of the to-be-deleted Kunde or Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        void DeleteKundeKontakt(int id, bool type);
    }
}
