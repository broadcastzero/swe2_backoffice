// -----------------------------------------------------------------------
// <copyright file="AngebotCreator.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;
    using EPUBackoffice.Dal;
    using EPUBackoffice.Dal.Tables;
    using EPUBackoffice.UserExceptions;
    using DatabindingFramework;
    using Logger;
    using Rulemanager;

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
            DataBindingFramework.BindFromDouble(angebot.Angebotssumme.ToString(), "Angebotssumme", errorlabel, Rules.PositiveDouble);
            DataBindingFramework.BindFromInt(angebot.Umsetzungschance.ToString(), "Umsetzungschance", errorlabel, Rules.PerCent);
            DataBindingFramework.BindFromString(angebot.Angebotsdauer, "GültigBis", errorlabel, Rules.Date);
            DataBindingFramework.BindFromString(angebot.Beschreibung, "Beschreibung", errorlabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);

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
        /// <returns>The requested Angebote</returns>
        public List<AngebotTable> Load(string firstname, string lastname, DateTime from, DateTime until)
        {
            // check parameter
            if (firstname != null && (firstname.Length != 0 && RuleManager.ValidateLettersHyphen(firstname) == false))
            {
                this.logger.Log(Logger.Level.Error, "User tried to search Angebot with invalid first name!");
                throw new InvalidInputException("Feld 'Vorname' ist ungültig!");
            }
            else if (lastname != null && (lastname.Length != 0 && RuleManager.ValidateLettersNumbersHyphenSpace(lastname) == false))
            {
                this.logger.Log(Logger.Level.Error, "User tried to search Angebot with invalid last name!");
                throw new InvalidInputException("Feld 'Nachname/Firma' ist ungültig!");
            }
            // call GetAngebote function, depending on what parameters have been provided by the GUI
            else if ((firstname == null || firstname.Length == 0) && (lastname == null || lastname.Length == 0))
            {
                try
                {
                    return DALFactory.GetDAL().LoadAngebote(from.ToShortDateString(), until.ToShortDateString());
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
            else if ((firstname != null && firstname.Length != 0) && (lastname == null || lastname.Length == 0))
            {
                try
                {
                    return DALFactory.GetDAL().LoadAngebote(from.ToShortDateString(), until.ToShortDateString(), firstname: firstname);
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
            else if ((firstname == null || firstname.Length == 0) && (lastname != null && lastname.Length != 0))
            {
                try
                {
                    return DALFactory.GetDAL().LoadAngebote(from.ToShortDateString(), until.ToShortDateString(), lastname: lastname);
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
                    return DALFactory.GetDAL().LoadAngebote(from.ToShortDateString(), until.ToShortDateString(), firstname: firstname, lastname: lastname);
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
        }
    }
}
