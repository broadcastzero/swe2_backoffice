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
    using System.Windows.Forms;
    using DatabindingFramework;
    using EPUBackoffice.Dal;
    using EPUBackoffice.Dal.Tables;
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
        /// <param name="k">The to-be-changed Kunde/Kontakt</param>
        /// <param name="errorlabel">The label in which errormessages may be written</param>
        public void Change(KundeKontaktTable k, Label errorlabel)
        {
            DataBindingFramework.BindFromString(k.Vorname, "Vorname", errorlabel, Rules.IsAndCanBeNull, Rules.LettersHyphen, Rules.StringLength150);
            DataBindingFramework.BindFromString(k.Vorname, "Nachname", errorlabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);

            if (errorlabel.Visible)
            {
                throw new InvalidInputException();
            }

            // else save new Kunde or Kontakt in database
            if (k.Vorname.Length == 0)
            {
                this.logger.Log(Logger.Level.Info, "Es wird kein Vorname eingetragen.");
            }

            // Update data
            try
            {
                DALFactory.GetDAL().UpdateKundeKontakte(k);
            }
            catch (SQLiteException)
            {
                throw;
            }

            
        }

        /// <summary>
        /// Deletes an existing Kunde/Kontakt
        /// </summary>
        /// <param name="k">The Kunde/Kontakt object that shall be deleted</param>
        /// <param name="label">The label in which errormessages can be shown</param>
        public void Delete(KundeKontaktTable k, Label label)
        {
            if (DataBindingFramework.BindFromInt(k.ID.ToString(), "ID", label, Rules.PositiveInt) < 0)
            {
                this.logger.Log(Logger.Level.Error, "No valid ID provided from GUI layer!");
                throw new InvalidInputException("Es wurde keine gültige ID übergeben!");
            }

            this.logger.Log(Logger.Level.Info, "User requested to delete " + (k.Type == false ? "Kunde" : "Kontakt") + " with ID " + k.ID);

            try
            {
                DALFactory.GetDAL().DeleteKundeKontakt(k);
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
    }
}
