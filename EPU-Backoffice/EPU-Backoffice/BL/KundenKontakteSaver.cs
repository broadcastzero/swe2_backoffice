// -----------------------------------------------------------------------
// <copyright file="KundenKontakteSaver.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Text;
    using EPUBackoffice.Dal;
    using Logger;
    using UserExceptions;
    
    /// <summary>
    /// Checks data from the GUI and forwards it to the database where it is saved.
    /// </summary>
    public class KundenKontakteSaver
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Saves a new Kunde or Kontakt to the database.
        /// </summary>
        /// <param name="firstname">The first name of the Kunde/Kontakt</param>
        /// <param name="lastname">The last name of the Kunde/Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        public void SaveNewKundeKontakt(string firstname, string lastname, bool type)
        {
            // if invalid chars are found, throw exception, don't check for null (field is not mandatory)
            if (firstname.Length != 0 && (RuleManager.ValidateLettersHyphen(firstname) == false || RuleManager.CheckStringLength150(firstname) == false))
            {
                this.logger.Log(2, "Field 'Vorname' within tab 'Neuer Kunde/Kontakt' contains invalid characters!");
                throw new InvalidInputException("Feld 'Vorname' ist ungültig!");
            }
            // if 'Nachname' is null or invalid sign is found or length is more than 150 chars
            else if (lastname == null || lastname.Length == 0 || RuleManager.ValidateLettersNumbersHyphenSpace(lastname) == false || RuleManager.CheckStringLength150(lastname) == false)
            {
                this.logger.Log(2, "Field 'Nachname' within tab 'Neuer Kunde/Kontakt' contains invalid characters!");
                throw new InvalidInputException("Feld 'Nachname/Firma' ist ungültig!");                
            }
            // else save new Kunde or Kontakt in database
            // first name is optional, if empty, just send lastname and type
            else if (firstname.Length == 0)
            {
                this.logger.Log(0, "Es wird kein Vorname eingetragen.");

                try
                {
                    DALFactory.GetDAL().SaveNewKundeKontakt(lastname, type);
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
            else
            {
                try
                {
                    DALFactory.GetDAL().SaveNewKundeKontakt(lastname, type, firstname);
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
        }
    }
}
