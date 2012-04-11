// -----------------------------------------------------------------------
// <copyright file="KundenKontakteChanger.cs" company="">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
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
    using EPUBackoffice.UserExceptions;
    using Logger;
    using Rulemanager;

    /// <summary>
    /// Changes or deletes a existing Kunde/Kontakt
    /// </summary>
    public class KundenKontakteChanger
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Changes data of an existing Kunde/Kontakt
        /// </summary>
        /// <param name="id">The ID of the to-be-changed Kunde/Kontakt</param>
        /// <param name="firstname">The firstname of the to-be-changed Kunde/Kontakt</param>
        /// <param name="lastname">The last name of the to-be-changed Kunde/Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        public void Change(int id, string firstname, string lastname, bool type)
        {
            if(firstname != null && firstname.Length != 0 && (RuleManager.ValidateLettersHyphen(firstname) == false || RuleManager.ValidateStringLength150(firstname) == false))
            {
                this.logger.Log(2, "Field 'Vorname' within tab 'Change Kunde/Kontakt' contains invalid characters!");
                throw new InvalidInputException("Feld 'Vorname' ist ungültig!");
            }
            else if (lastname == null || lastname.Length == 0 || RuleManager.ValidateLettersNumbersHyphenSpace(lastname) == false || RuleManager.ValidateStringLength150(lastname) == false)
            {
                this.logger.Log(2, "Field 'Nachname' within tab 'Change Kunde/Kontakt' contains invalid characters!");
                throw new InvalidInputException("Feld 'Nachname/Firma' ist ungültig!");
            }

            // Update data
            DALFactory.GetDAL().UpdateKundeKontakte(id, firstname, lastname, type);
        }

        /// <summary>
        /// Deletes an existing Kunde/Kontakt
        /// </summary>
        /// <param name="id">The ID of the to-be-deleted Kunde/Kontakt</param>
        /// <param name="type">Is it a Kunde (false) or a Kontakt (true)?</param>
        public void Delete(int id, bool type)
        {
            if (id < 0)
            {
                this.logger.Log(2, "No valid ID provided from GUI layer!");
                throw new InvalidInputException("Es wurde keine gültige ID übergeben!");
            }

            string s_type = type == false ? "Kunde" : "Kontakt";
            this.logger.Log(0, "User requested to delete " + s_type + " with ID " + id);

            try
            {
                DALFactory.GetDAL().DeleteKundeKontakt(id, type);
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
    }
}
