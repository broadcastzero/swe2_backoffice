// -----------------------------------------------------------------------
// <copyright file="BankkontoTable.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class for the database table "Bankkonto" with its attributes
    /// </summary>
    public class BankkontoTable
    {
        private int id;
        /// <summary>
        /// Gets or sets unique ID for the table
        /// </summary>
        public int ID
        {
            get { return id; }
            set { if (value >= 0) { id = value; } }
        }

        private int kontonummer;
        /// <summary>
        /// Gets or sets account number
        /// </summary>
        public int Kontonummer
        {
            get { return kontonummer; }
            set { if (value >= 0) { kontonummer = value; } }
        }

        private int blz;
        /// <summary>
        /// Gets or sets Bank code
        /// </summary>
        public int BLZ
        {
            get { return blz; }
            set { if (value >= 0) { blz = value; } }
        }
    }
}
