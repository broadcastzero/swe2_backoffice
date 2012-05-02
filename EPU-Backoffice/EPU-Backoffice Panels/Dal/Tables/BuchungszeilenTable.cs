// -----------------------------------------------------------------------
// <copyright file="BuchungszeilenTable.cs" company="Marvin&Felix">
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
    /// A class for the database table "Buchungszeilen" with its attributes
    /// </summary>
    public class BuchungszeilenTable
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

        private int kategorieID;
        /// <summary>
        /// Gets or sets foreign key to table Kategorien
        /// </summary>
        public int KategorieID
        {
            get { return kategorieID; }
            set { if (value >= 0) { kategorieID = value; } }
        }

        private int bankkontoID;
        /// <summary>
        /// Gets or sets foreign key to table Bankkonto
        /// </summary>
        public int BankkontoID
        {
            get { return bankkontoID; }
            set { if (value >= 0) { bankkontoID = value; } }
        }

        private double betragUST;
        /// <summary>
        /// Gets or sets the taxes that have to be paid
        /// </summary>
        public double BetragUST
        {
            get { return betragUST; }
            set { if (value >= 0) { betragUST = value; } }
        }

        private double betragNetto;
        /// <summary>
        /// Gets or sets the (after taxes) amount of money that shall be booked
        /// </summary>
        public double BetragNetto
        {
            get { return betragNetto; }
            set { if (value >= 0) { betragNetto = value; } }
        }

        private DateTime buchungsdatum;
        /// <summary>
        /// Gets or sets Datum of booking
        /// </summary>
        public DateTime Buchungsdatum
        {
            get { return buchungsdatum; }
            set { buchungsdatum = value; }
        }
    }
}
