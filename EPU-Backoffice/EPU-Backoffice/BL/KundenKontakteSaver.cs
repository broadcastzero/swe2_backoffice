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
    using System.Windows.Forms;
    using DatabindingFramework;
    using EPUBackoffice.Dal;
    using EPUBackoffice.Dal.Tables;
    using EPUBackoffice.Rules;
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
        /// <param name="k">The Kunden/Kontakt table</param>
        /// <param name="errorlabel">The label in which possible error messages will be displayed</param>
        /// <returns>The ID of the newly inserted Kunde/Kontakt</returns>
        public int SaveNewKundeKontakt(KundeKontaktTable k, Label errorlabel)
        {
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule lhv = new LettersHyphenValidator();
            IRule lengthv = new StringLength150Validator();

            DataBindingFramework.BindFromString(k.Vorname, "Vorname", errorlabel, true, lhv, lengthv);
            DataBindingFramework.BindFromString(k.NachnameFirmenname, "Nachname", errorlabel, false, lnhsv, lengthv);

            if (errorlabel.Visible)
            {
                throw new InvalidInputException();
            }

            this.logger.Log(Logger.Level.Info, "User requested to insert " + (k.Type == false ? "Kunde" : "Kontakt") + " with values " + k.Vorname + " " + k.NachnameFirmenname);

            // else save new Kunde or Kontakt in database
            if (k.Vorname.Length == 0)
            {
                this.logger.Log(Logger.Level.Info, "No first name will be saved.");
            }

            try
            {
                return DALFactory.GetDAL().SaveNewKundeKontakt(k);
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
    }
}
