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
    using System.Text.RegularExpressions;
    using EPUBackoffice.Dal;
    using UserExceptions;
    using Logger;

    /// <summary>
    /// Checks data from the GUI and forwards it to the database where it is saved.
    /// </summary>
    public class GuiDataValidator
    {
        Logger logger = Logger.Instance;

        /// <summary>
        /// Saves a new Kunde or Kontakt to the database.
        /// </summary>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        public void saveNewKunde(string firstname, string lastname, bool type)
        {
            // if invalid chars are found, throw exception, don't check for null (field is not mandatory)
            if (firstname != "" && !Regex.IsMatch(firstname, @"^[a-zA-Z]+$"))
            {
                this.logger.Log(2, "Field 'Vorname' within tab 'Neuer Kunde/Kontakt' contains invalid characters!");
                throw new InvalidInputException("Feld 'Vorname' ist ungültig!");
            }
            // if 'Nachname' is null or invalid sign is found
            else if (!Regex.IsMatch(lastname, @"^[a-zA-Z]+$"))
            {
                this.logger.Log(2, "");
                throw new InvalidInputException("Feld 'Nachname' ist ungültig!");
            }
            // else save new Kunde or Kontakt in database
            // first name is optional, if empty, just send lastname and type
            else if (firstname == null)
            {
                this.logger.Log(0, "Es wird kein Vorname eingetragen.");
                DALFactory.GetDAL().SaveNewKunde(lastname, type);
            }
            else
            {
                DALFactory.GetDAL().SaveNewKunde(lastname, type, firstname);
            }
        }
    }
}
