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
    using System.Diagnostics;
    using System.Text;
    using EPUBackoffice.Dal;
    using EPUBackoffice.UserExceptions;
    using Logger;

    /// <summary>
    /// Contains methods to manipulate, save or load Angebote
    /// </summary>
    public class AngebotManager
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Gets values from the GUI, validates them and then sends them to the database to create a new Angebot
        /// </summary>
        public void Create(string kundenID, bool createKunde, string firstname, string lastname, string angebotssumme, string umsetzungswahrscheinlichkeit, DateTime validUntil, string description)
        {
            // parse strings
            double angebotssum = RuleManager.ValidatePositiveDouble(angebotssumme);
            int umsetzungswsk = RuleManager.ValidatePerCent(umsetzungswahrscheinlichkeit);
            bool validDescr = RuleManager.ValidateLettersNumbersHyphenSpace(description);

            // additionally check stringlength of description, if first test passed
            if (validDescr)
            {
                validDescr = RuleManager.ValidateStringLength150(description);
            }

            // if no KundenID has been passed, create new Kunde with provided values
            if (createKunde)
            {
                if (firstname != null && firstname.Length != 0 && RuleManager.ValidateLettersHyphen(firstname) == false)
                {
                    this.logger.Log(2, "User tried to create an Angebot with invalid firstname of the newly to be created Kunde.");
                    throw new InvalidInputException("Ungültiger Kunden-Vorname");
                }
                else if (lastname == null || lastname.Length == 0 || RuleManager.ValidateLettersNumbersHyphenSpace(lastname) == false || RuleManager.ValidateStringLength150(lastname) == false)
                {
                    this.logger.Log(2, "User tried to create an Angebot with invalid lastname of the newly to be created Kunde.");
                    throw new InvalidInputException("Feld 'Nachname/Firma' ist ungültig!");
                }
            }

            // check RuleManager return values (returns -1 in case of error)
            if (angebotssum == -1)
            {
                this.logger.Log(2, "User tried to create an Angebot with an invalid Angebotssumme: " + angebotssumme);
                throw new InvalidInputException("Ungültige Angebotssumme");
            }
            else if (umsetzungswsk == -1)
            {
                this.logger.Log(2, "User tried to create an Angebot with an invalid Umsetzungswahrscheinlichkeit: " + umsetzungswahrscheinlichkeit);
                throw new InvalidInputException("Ungültige Angebotswahrscheinlichkeit");
            }
            else if (validDescr == false)
            {
                this.logger.Log(2, "User tried to create an Angebot with an invalid Beschreibung: " + description);
                throw new InvalidInputException("Ungültige Beschreibung");
            }
            else if (validUntil == null)
            {
                this.logger.Log(2, "User tried to create an Angebot with an invalid deadline.");
                throw new InvalidInputException("Ungültige Deadline");
            }

            // save Kunde, if requested
            int kID;
            if (createKunde)
            {
                KundenKontakteSaver saver = new KundenKontakteSaver();
                bool type = false;
                kID = saver.SaveNewKundeKontakt(firstname, lastname, type);
            }
            else
            {
                kID = RuleManager.ValidatePositiveInt(kundenID);
            }

            // create Angebot
            DALFactory.GetDAL().CreateAngebot(kID, angebotssum, umsetzungswsk, validUntil, description);
        }

        /// <summary>
        /// Load an existing Angebot out of the database
        /// </summary>
        public void Load(string firstname, string lastname, DateTime from, DateTime until)
        { 
            // TODO: check parameter and parse dates to strings
            DALFactory.GetDAL().LoadAngebote(firstname, lastname, from.ToShortDateString(), until.ToShortDateString());
        }
    }
}
