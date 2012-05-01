// -----------------------------------------------------------------------
// <copyright file="AngebotCreator.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;
    using EPU_Backoffice_Panels.DatabindingFramework;
    using EPU_Backoffice_Panels.LoggingFramework;

    /// <summary>
    /// Contains methods to manipulate, save or load Angebote
    /// </summary>
    public class AngebotManager
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Gets values from the GUI, validates them and then sends them to the database to create a new Angebot
        /// </summary>
        public void Create(AngebotTable angebot, Label errorlabel)
        {
            IRule doubv = new PositiveDoubleValidator();
            IRule intv = new PositiveIntValidator();
            IRule datev = new DateValidator();
            IRule lengthv = new StringLength150Validator();
            IRule percv = new PercentValidator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule lhv = new LettersHyphenValidator();

            DataBindingFramework.BindFromDouble(angebot.Angebotssumme.ToString(), "Angebotssumme", errorlabel, false, doubv);
            DataBindingFramework.BindFromInt(angebot.Umsetzungschance.ToString(), "Umsetzungschance", errorlabel, false, percv);
            DataBindingFramework.BindFromString(angebot.Angebotsdauer, "GültigBis", errorlabel, false, datev);
            DataBindingFramework.BindFromString(angebot.Beschreibung, "Beschreibung", errorlabel, false, lnhsv, lengthv);
            DataBindingFramework.BindFromInt(angebot.KundenID.ToString(), "kundenID", errorlabel, false, intv);
            DataBindingFramework.BindFromString(angebot.Erstellungsdatum, "Erstellungsdatum", errorlabel, false, datev);

            // change date formats
            angebot.Angebotsdauer = GlobalActions.ParseToSQLiteDateString(angebot.Angebotsdauer);

            if (errorlabel.Visible)
            {
                throw new InvalidInputException();
            }

            this.logger.Log(Logger.Level.Info, "A new Angebot will be created");

            // create Angebot
            try
            {
                DALFactory.GetDAL().CreateAngebot(angebot);
            }
            catch (SQLiteException)
            {
                throw;
            }
        }

        /// <summary>
        /// Load an existing Angebot out of the database
        /// </summary>
        /// <param name="kid">The referenced kundenID</param>
        /// <param name="from">From which date shall be searched from</param>
        /// <param name="until">Until which date shall be searched</param>
        /// <param name="msglabel">The label in which error messages can be written</param>
        /// <returns>The requested Angebote</returns>
        public List<AngebotTable> Load(int kid, DateTime from, DateTime until, Label msglabel)
        {
            IRule posintormin1val = new PositiveIntOrMinusOneValidator();
            IRule date1 = new DateValidator();
            IRule date2 = new DateValidator();

            DataBindingFramework.BindFromInt(kid.ToString(), "KundenID", msglabel, false, posintormin1val);

            string from_sds = DataBindingFramework.BindFromString(from.ToShortDateString(), "Von", msglabel, false, date1);
            string until_sds = DataBindingFramework.BindFromString(from.ToShortDateString(), "Bis", msglabel, false, date2);

            // parse to date strings
            from_sds = GlobalActions.ParseToSQLiteDateString(from_sds);
            until_sds = GlobalActions.ParseToSQLiteDateString(until_sds);

            if (posintormin1val.HasErrors)
            {
                this.logger.Log(Logger.Level.Error, "User tried to search Angebot with invalid KundenID!");
                throw new InvalidInputException("Feld 'KundenID' ist ungültig!");
            }
            else
            {
                try
                {
                    return DALFactory.GetDAL().LoadAngebote(kid, from_sds, until_sds);
                }
                catch (SQLiteException ex)
                {
                    this.logger.Log(Logger.Level.Error, "Serious problem with database! " + ex.StackTrace + ex.Message);
                    throw new DataBaseException(ex.Message);
                }
            }
        }
    }
}
