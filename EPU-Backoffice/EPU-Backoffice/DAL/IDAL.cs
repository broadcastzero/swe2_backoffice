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
        /// Saves a new Kunde or Kontakt to the database.
        /// </summary>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        void SaveNewKunde(string lastname, bool type, string firstname="<null>");
    }
}
