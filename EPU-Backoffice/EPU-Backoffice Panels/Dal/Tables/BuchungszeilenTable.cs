// -----------------------------------------------------------------------
// <copyright file="BuchungszeilenTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal.Tables
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
        private int id;
        /// <summary>
        /// Unique ID for the table
        /// </summary>
        public int ID
        {
            get { return id; }
            set { if (value >= 0) { id = value; } }
        }

        private int kategorieID;
        /// <summary>
        /// Foreign key to table Kategorien
        /// </summary>
        public int KategorieID
        {
            get { return kategorieID; }
            set { if (value >= 0) { kategorieID = value; } }
        }

        private int bankkontoID;
        /// <summary>
        /// Foreign key to table Bankkonto
        /// </summary>
        public int BankkontoID
        {
            get { return bankkontoID; }
            set { if (value >= 0) { bankkontoID = value; } }
        }

        private double betragUST;
        /// <summary>
        /// The taxes that have to be paid
        /// </summary>
        public double BetragUST
        {
            get { return betragUST; }
            set { if (value >= 0) { betragUST = value; } }
        }

        private double betragNetto;
        /// <summary>
        /// The (after taxes) amount of money that shall be booked
        /// </summary>
        public double BetragNetto
        {
            get { return betragNetto; }
            set { if (value >= 0) { betragNetto = value; } }
        }

        private DateTime buchungsdatum;
        /// <summary>
        /// Datum of booking
        /// </summary>
        public DateTime Buchungsdatum
        {
            get { return buchungsdatum; }
            set { buchungsdatum = value; }
        }
    }
}
