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
    using EPUBackoffice.Dal;
    using EPUBackoffice.Dal.Tables;
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
        public List<KundeTable> LoadKunden(string firstname = null, string lastname = null)
        {
            return DALFactory.GetDAL().GetKunden();
        }

        /// <summary>
        /// Gets requested Kontakte out of the database.
        /// </summary>
        public List<KontaktTable> LoadKontakte(string firstname = null, string lastname = null)
        {
            return DALFactory.GetDAL().GetKontakte();
        }

    }
}
