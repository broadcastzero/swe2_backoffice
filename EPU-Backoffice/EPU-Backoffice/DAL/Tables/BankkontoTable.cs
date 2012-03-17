// -----------------------------------------------------------------------
// <copyright file="BankkontoTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.DAL.Tables
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
        private int _ID;
        /// <summary>
        /// Unique ID for the table
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { if (value >= 0) { _ID = value; } }
        }

        private int _Kontonummer;
        /// <summary>
        /// Account number
        /// </summary>
        public int Kontonummer
        {
            get { return _Kontonummer; }
            set { if (value >= 0) { _Kontonummer = value; } }
        }

        private int _BLZ;
        /// <summary>
        /// Bank code
        /// </summary>
        public int BLZ
        {
            get { return _BLZ; }
            set { if (value >= 0) { _BLZ = value; } }
        }
    }
}
