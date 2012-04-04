// -----------------------------------------------------------------------
// <copyright file="DataLoader.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;
    using EPUBackoffice.Dal;
    using EPUBackoffice.Dal.Tables;
    using EPUBackoffice.UserExceptions;
    using Logger;

    /// <summary>
    /// This class' methods load data out of the database and returns a list of requested data.
    /// </summary>
    public class DataLoader
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Gets requested Kunden out of the database.
        /// </summary>
        /// <param name="firstname">The first name of the to-be-searched Kunde</param>
        /// <param name="lastname">The last name of the to-be-searched Kunde</param>
        /// <returns>List of matching Kunden</returns>
        public List<KundeTable> LoadKunden(string firstname, string lastname)
        {
            if (firstname != null && !Regex.IsMatch(firstname, @"^[a-zA-Z-]+$"))
            {
                string msg = "User tried to search for invalid first name!";
                logger.Log(2, msg);
                throw new InvalidInputException(msg);
            }
            else if (lastname != null && !Regex.IsMatch(lastname, @"^[a-zA-Z0-9-]+$"))
            {
                string msg = "User tried to search for invalid last name!";
                logger.Log(2, msg);
                throw new InvalidInputException(msg);
            }
            else if(firstname == "" && lastname == "")
            {
                return DALFactory.GetDAL().GetKunden();
            }
            else if (firstname != "" && lastname == "")
            {
                return DALFactory.GetDAL().GetKunden(firstname);
            }
            else if (firstname == "" && lastname != "")
            {
                return DALFactory.GetDAL().GetKunden(lastname);
            }
            else { return DALFactory.GetDAL().GetKunden(firstname, lastname); }
        }

        /// <summary>
        /// Gets requested Kontakte out of the database.
        /// </summary>
        /// <param name="firstname">The first name of the to-be-searched Kontakt</param>
        /// <param name="lastname">The last name of the to-be-searched Kontakt</param>
        /// <returns>List of matching Kontakt</returns>
        public List<KontaktTable> LoadKontakte(string firstname = null, string lastname = null)
        {
            if (firstname != null && !Regex.IsMatch(firstname, @"^[a-zA-Z-]+$"))
            {
                string msg = "User tried to search for invalid first name!";
                logger.Log(2, msg);
                throw new InvalidInputException(msg);
            }
            else if (lastname != null && !Regex.IsMatch(lastname, @"^[a-zA-Z0-9-]+$"))
            {
                string msg = "User tried to search for invalid last name!";
                logger.Log(2, msg);
                throw new InvalidInputException(msg);
            }
            else if (firstname == "" && lastname == "")
            {
                return DALFactory.GetDAL().GetKontakte(firstname, lastname);
            }
            else if (firstname != "" && lastname == "")
            {
                return DALFactory.GetDAL().GetKontakte(firstname, lastname);
            }
            else if (firstname == "" && lastname != "")
            {
                return DALFactory.GetDAL().GetKontakte(firstname, lastname);
            }
            else { return DALFactory.GetDAL().GetKontakte(firstname, lastname); }
        }
    }
}
