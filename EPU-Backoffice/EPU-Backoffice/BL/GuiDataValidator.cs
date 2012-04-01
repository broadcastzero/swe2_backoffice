// -----------------------------------------------------------------------
// <copyright file="Program.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EPUBackoffice.Dal;
    using Logger;

    /// <summary>
    /// Checks data from the GUI and forwards it to the database where it is saved.
    /// </summary>
    public class GuiDataValidator
    {
        /// <summary>
        /// Saves a new Kunde or Kontakt to the database.
        /// </summary>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        public void saveNewKunde(string firstname, string lastname, bool type)
        {
            // if invalid chars are found, throw exception
            // else save new Kunde or Kontakt in database
            // first name is optional, if empty, just send lastname and type
            DALFactory.GetDAL().SaveNewKunde(lastname, type, firstname);
        }
    }
}
