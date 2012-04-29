// -----------------------------------------------------------------------
// <copyright file="KundenKontakteLoader.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Text;
    using System.Windows.Forms;
    using DatabindingFramework;
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;
    using Logger;

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
            IRule doubv = new PositiveDoubleValidator();
            IRule intv = new PositiveIntValidator();
            IRule datev = new DateValidator();
            IRule lengthv = new StringLength150Validator();
            IRule percv = new PercentValidator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule lhv = new LettersHyphenValidator();

            DataBindingFramework.BindFromString(k.Vorname, "Vorname", errorlabel, true, lhv, lengthv);
            DataBindingFramework.BindFromString(k.NachnameFirmenname, "Nachname", errorlabel, true, lnhsv, lengthv);
            k.ID = -1; // indicates that we don't want to search for an ID

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

        /// <summary>
        /// Gets an Kunden/Kontakt ID and type and loads requested data
        /// </summary>
        /// <param name="id">The requested ID</param>
        /// <param name="type">Kunde (false) or Kontakt (true)?</param>
        /// <returns></returns>
        public List<KundeKontaktTable> LoadKundenKontakte(int id, bool type)
        {
            KundeKontaktTable k = new KundeKontaktTable();
            k.ID = id;
            k.Vorname = string.Empty;
            k.NachnameFirmenname = string.Empty;
            k.Type = type;

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
