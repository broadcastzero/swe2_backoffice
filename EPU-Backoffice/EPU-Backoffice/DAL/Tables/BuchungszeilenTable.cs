// -----------------------------------------------------------------------
// <copyright file="BuchungszeilenTable.cs" company="">
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
    /// A class for the database table "Buchungszeilen" with its attributes
    /// </summary>
    public class BuchungszeilenTable
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

        private int _KategorieID;
        /// <summary>
        /// Foreign key to table Kategorien
        /// </summary>
        public int KategorieID
        {
            get { return _KategorieID; }
            set { if (value >= 0) { _KategorieID = value; } }
        }

        private int _BankkontoID;
        /// <summary>
        /// Foreign key to table Bankkonto
        /// </summary>
        public int BankkontoID
        {
            get { return _BankkontoID; }
            set { if (value >= 0) { _BankkontoID = value; } }
        }

        private double _BetragUST;
        /// <summary>
        /// The taxes that have to be paid
        /// </summary>
        public double BetragUST
        {
            get { return _BetragUST; }
            set { if (value >= 0) { _BetragUST = value; } }
        }

        private double _BetragNetto;
        /// <summary>
        /// The (after taxes) amount of money that shall be booked
        /// </summary>
        public double BetragNetto
        {
            get { return _BetragNetto; }
            set { if (value >= 0) { _BetragNetto = value; } }
        }

        private DateTime _Buchungsdatum;
        /// <summary>
        /// Datum of booking
        /// </summary>
        public DateTime Buchungsdatum
        {
            get { return _Buchungsdatum; }
            set { _Buchungsdatum = value; }
        }
    }
}
