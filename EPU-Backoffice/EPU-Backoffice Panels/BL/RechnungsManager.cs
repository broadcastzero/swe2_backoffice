// -----------------------------------------------------------------------
// <copyright file="Rechnungsmanager.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
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
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;
    using EPU_Backoffice_Panels.DatabindingFramework;
    using EPU_Backoffice_Panels.LoggingFramework;

    /// <summary>
    /// This class is responsible for all business layer activities for the rechnungs tab
    /// </summary>
    public class RechnungsManager
    {
        private Logger logger = Logger.Instance;

        public int CreateEingangsrechnung(EingangsrechnungTable table)
        {
            LettersNumbersHyphenSpaceValidator lnhsv = new LettersNumbersHyphenSpaceValidator();
            StringLength150Validator slv = new StringLength150Validator();
            PositiveIntValidator piv = new PositiveIntValidator();
            DateValidator dv = new DateValidator();

            lnhsv.Eval(table.Archivierungspfad);
            slv.Eval(table.Archivierungspfad);
            piv.Eval(table.KontaktID);
            dv.Eval(table.Rechnungsdatum);

            if (lnhsv.HasErrors || slv.HasErrors || piv.HasErrors || dv.HasErrors)
            {
                throw new InvalidInputException("Daten ungültig!");
            }

            // if data is valid, pass table to DAL
            int returnedID;

            try
            {
                returnedID = DALFactory.GetDAL().CreateEingangsrechnung(table);
            }
            catch (SQLiteException)
            {
                throw;
            }

            return returnedID;
        }

        /// <summary>
        /// Load all Eingangsrechnungen
        /// </summary>
        /// <returns>The loaded Eingangsrechnungen</returns>
        public List<EingangsrechnungTable> LoadEingangsrechnungen()
        {
            List<EingangsrechnungTable> results;

            try
            {
                results = DALFactory.GetDAL().LoadEingangsrechnungen();
            }
            catch (SQLiteException)
            {
                throw;
            }

            return results;
        }
    }
}
