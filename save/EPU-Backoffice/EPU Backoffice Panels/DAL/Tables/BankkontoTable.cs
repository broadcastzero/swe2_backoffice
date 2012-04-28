// -----------------------------------------------------------------------
// <copyright file="BankkontoTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackofficePanels.Dal.Tables
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
        /// Unique ID for the table
        /// </summary>
        public int ID
        {
            get { return id; }
            set { if (value >= 0) { id = value; } }
        }

        private int kontonummer;
        /// <summary>
        /// Account number
        /// </summary>
        public int Kontonummer
        {
            get { return kontonummer; }
            set { if (value >= 0) { kontonummer = value; } }
        }

        private int blz;
        /// <summary>
        /// Bank code
        /// </summary>
        public int BLZ
        {
            get { return blz; }
            set { if (value >= 0) { blz = value; } }
        }
    }
}
