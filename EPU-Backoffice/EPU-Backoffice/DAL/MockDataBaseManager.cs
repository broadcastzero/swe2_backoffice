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
    using System.Linq;
    using System.Text;

    /// <summary>
    /// This class manages the mock database.
    /// </summary>
    public class MockDataBaseManager : IDAL
    {
        /// <summary>
        /// This method initializes the classes needed to create a mock database
        /// </summary>
        public void CreateDataBase()
        {
            //TODO: create instance of tables and store some mock data
            throw new NotImplementedException();
        }

        /// <summary>
        /// Saves a new Kunde or Kontakt to the mock database
        /// </summary>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">false...Kunde, true...Kontakt</param>
        public void SaveNewKunde(string lastname, bool type, string firstname)
        {
            throw new NotImplementedException();
        }
    }
}
