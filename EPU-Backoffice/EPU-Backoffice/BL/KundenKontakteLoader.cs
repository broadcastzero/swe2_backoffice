﻿// -----------------------------------------------------------------------
// <copyright file="DataLoader.cs" company="Marvin&Felix">
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
    using System.Text.RegularExpressions;
    using EPUBackoffice.Dal;
    using EPUBackoffice.Dal.Tables;
    using EPUBackoffice.UserExceptions;
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
        /// <param name="firstname">The first name of the to-be-searched Kontakt</param>
        /// <param name="lastname">The last name of the to-be-searched Kontakt</param>
        /// <param name="type">false...Kunde, true...Kontakt</param>
        /// <returns>List of matching Kontakt</returns>
        public List<KundeKontaktTable> LoadKundenKontakte(bool type, string firstname = null, string lastname = null)
        {
            if (firstname != "" && !Regex.IsMatch(firstname, @"^[a-zA-Z-]+$"))
            {
                logger.Log(2, "User tried to search for invalid first name in Kontakte!");
                throw new InvalidInputException("Feld 'Vorname' ist ungültig!");
            }
            else if (lastname != "" && !Regex.IsMatch(lastname, @"^[a-zA-Z0-9-]+$"))
            {
                logger.Log(2, "User tried to search for invalid last name!");
                throw new InvalidInputException("Feld 'Nachname/Firma' ist ungültig!");
            }
            else if (firstname == "" && lastname == "")
            {
                try
                {
                    return DALFactory.GetDAL().GetKundenKontakte(type);
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
            else if (firstname != "" && lastname == "")
            {
                try
                {
                    return DALFactory.GetDAL().GetKundenKontakte(type, firstname: firstname);
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
            else if (firstname == "" && lastname != "")
            {
                try
                {
                    return DALFactory.GetDAL().GetKundenKontakte(type, lastname: lastname);
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
                    return DALFactory.GetDAL().GetKundenKontakte(type, firstname, lastname);
                }
                catch (SQLiteException)
                {
                    throw;
                }
            }
        }
    }
}