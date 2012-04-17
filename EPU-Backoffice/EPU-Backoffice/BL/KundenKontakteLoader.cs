// -----------------------------------------------------------------------
// <copyright file="KundenKontakteLoader.cs" company="Marvin&Felix">
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
    using EPUBackoffice.UserExceptions;
    using Logger;
    using Rulemanager;

    /// <summary>
    /// This class' methods load data out of the database and returns a list of requested data.
    /// </summary>
    public class KundenKontakteLoader
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Gets requested Kontakte out of the database.
        /// </summary>
        /// <param name="k">The Kunde/Kontakt object that shall be searched for</param>
        /// <param name="errorlabel">A label in the homeform in which errormessages can be displayed</param>
        /// <returns>List of matching Kontakt</returns>
        public List<KundeKontaktTable> LoadKundenKontakte(KundeKontaktTable k, Label errorlabel)
        {
            DataBindingFramework.BindFromString(k.Vorname, "Vorname", errorlabel, Rules.IsAndCanBeNull, Rules.LettersHyphen, Rules.StringLength150);
            DataBindingFramework.BindFromString(k.Vorname, "Nachname", errorlabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);

            if (errorlabel.Visible)
            {
                throw new InvalidInputException();
            }

            try
            {
                return DALFactory.GetDAL().GetKundenKontakte(k);
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
    }
}
