// -----------------------------------------------------------------------
// <copyright file="DalFactory.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EPUBackoffice.BL;

    /// <summary>
    /// A factory for the data access layer
    /// </summary>
    public static class DALFactory
    {
        /// <summary>
        /// This class gets an instance of the database class or mock-database class, depending on the information stored in the config file.
        /// </summary>
        /// <returns></returns>
        public static IDAL GetDAL()
        {
            if (ConfigFileManager.mockDB == true)
            {
                return new DataBaseManager();
            }
            else
            {
                return null;
            }
        }
    }
}
