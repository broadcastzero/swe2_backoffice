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
            LettersNumbersHyphenSpaceValidator lnhsv2 = new LettersNumbersHyphenSpaceValidator();
            StringLength150Validator slv = new StringLength150Validator();
            StringLength150Validator slv2 = new StringLength150Validator();
            PositiveIntValidator piv = new PositiveIntValidator();
            DateValidator dv = new DateValidator();

            lnhsv.Eval(table.Archivierungspfad);
            slv.Eval(table.Archivierungspfad);
            piv.Eval(table.KontaktID);
            dv.Eval(table.Rechnungsdatum);
            lnhsv2.Eval(table.Bezeichnung);
            slv2.Eval(table.Bezeichnung);

            if (lnhsv.HasErrors || lnhsv2.HasErrors || slv.HasErrors || slv2.HasErrors || piv.HasErrors || dv.HasErrors)
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
        public List<EingangsrechnungsView> LoadEingangsrechnungsView()
        {
            List<EingangsrechnungsView> results;

            try
            {
                results = DALFactory.GetDAL().LoadEingangsrechnungsView();
            }
            catch (SQLiteException ex)
            {
                throw new DataBaseException(ex.Message + ex.StackTrace, ex);
            }

            return results;
        }

        /// <summary>
        /// Saves a new Buchungszeile to the Database
        /// </summary>
        /// <param name="table">The Buchungszeilentable</param>
        /// <param name="eingangsrechnungsID">The ID of the Eingangsrechnung</param>
        public void SaveBuchungszeile(BuchungszeilenTable table, int eingangsrechnungsID)
        {
            table.BetragUST = table.BetragNetto; // we don't use UST

            // check EingangsrechnungsID
            IRule piv = new PositiveIntValidator();
            piv.Eval(eingangsrechnungsID);

            // check description
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule slv = new StringLength150Validator();
            lnhsv.Eval(table.Bezeichnung);
            slv.Eval(table.Bezeichnung);

            // check Betrag
            IRule pdv = new PositiveDoubleValidator();
            pdv.Eval(table.BetragNetto);

            // check date
            IRule dateval = new DateValidator();
            dateval.Eval(table.Buchungsdatum);

            // check KategorieID for positive int
            IRule piv2 = new PositiveIntValidator();
            piv2.Eval(table.KategorieID);

            if (piv.HasErrors || lnhsv.HasErrors || slv.HasErrors || pdv.HasErrors || dateval.HasErrors || piv2.HasErrors)
            {
                throw new InvalidInputException("Daten ungültig");
            }

            // save Buchungszeile
            int bzID = -1;
            try
            {
                bzID = DALFactory.GetDAL().SaveBuchungszeile(table);
            }
            catch (SQLiteException)
            {
                throw;
            }

            // save Eingangsbuchung
            EingangsbuchungTable eingangsbuchung = new EingangsbuchungTable();
            eingangsbuchung.BuchungszeilenID = bzID;
            eingangsbuchung.EingangsrechungsID = eingangsrechnungsID;

            try
            {
                DALFactory.GetDAL().SaveEingangsbuchung(eingangsbuchung);
            }
            catch (SQLiteException)
            { 
                throw; 
            }
        }

        /// <summary>
        /// Saves a new Ausgangsrechnung within the database
        /// </summary>
        /// <param name="projektID">The connected ProjektID</param>
        /// <param name="unpaidBalance">The amount of money which the Ausgangsrechnung shall include</param>
        /// <param name="rechnungstitelString">The title of the Ausgangsrechnung</param>
        public void CreateAusgangsrechnung(int projektID, double unpaidBalance, string rechnungstitelString)
        {
            // create business objects for Ausgangsrechnung, Ausgangsbuchung & Buchungszeilen
            AusgangsrechnungTable rechnung = new AusgangsrechnungTable();
            AusgangsbuchungTable buchung = new AusgangsbuchungTable();
            BuchungszeilenTable zeile = new BuchungszeilenTable();

            // fill with values and validate
            rechnung.ProjektID = projektID;
            rechnung.Rechnungsdatum = DateTime.Now.ToShortDateString();
            rechnung.Bezeichnung = rechnungstitelString;

            zeile.BetragNetto = unpaidBalance;
            zeile.Bezeichnung = rechnungstitelString;
            zeile.Buchungsdatum = rechnung.Rechnungsdatum;

            // initialise Rule objects
            PositiveIntValidator piv = new PositiveIntValidator();
            PositiveDoubleValidator pdv = new PositiveDoubleValidator();
            LettersNumbersHyphenSpaceValidator lnhsv = new LettersNumbersHyphenSpaceValidator();
            StringLength150Validator slv = new StringLength150Validator();
            
            // evaluate ProjektID
            piv.Eval(rechnung.ProjektID);

            if (piv.HasErrors)
            { throw new InvalidInputException("ProjektID ungültig!"); }

            // evaluate Bezeichnung
            lnhsv.Eval(rechnung.Bezeichnung);
            slv.Eval(rechnung.Bezeichnung);

            if (lnhsv.HasErrors || slv.HasErrors)
            { throw new InvalidInputException("Bezeichnung ungültig!"); }

            // evaluate Betrag
            pdv.Eval(zeile.BetragNetto);

            if (pdv.HasErrors)
            { throw new InvalidInputException("Betrag ungültig"); }

            // SAVE Ausgangsrechnung, Buchungszeile and Ausgangsbuchung
            try
            {
                buchung.AusgangsrechnungsID = DALFactory.GetDAL().SaveAusgangsrechnung(rechnung);
                buchung.BuchungszeilenID = DALFactory.GetDAL().SaveBuchungszeile(zeile);

                // create Ausgangsbuchung with ID values which just returned from database
                DALFactory.GetDAL().SaveAusgangsbuchung(buchung);
            }
            catch (SQLiteException e)
            { 
                this.logger.Log(Logger.Level.Info, "A database exception occured while saving a new Ausgangsrechnung, Buchungszeile or Ausgangsbuchung.");
                throw new DataBaseException(e.Message, e);
            }
        }
    }
}
