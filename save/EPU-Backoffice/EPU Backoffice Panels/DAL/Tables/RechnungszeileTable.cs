// -----------------------------------------------------------------------
// <copyright file="RechnungszeileTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackofficePanels.Dal.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class for the database table "Rechnungszeile" with its attributes
    /// </summary>
    public class RechnungszeileTable
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

        private int projektID;
        /// <summary>
        /// Foreign key to table Angebot
        /// </summary>
        public int ProjektID
        {
            get { return projektID; }
            set { if (value >= 0) { projektID = value; } }
        }

        private int ausgangsrechnungsID;
        /// <summary>
        /// Foreign key to table Ausgangsrechnung
        /// </summary>
        public int AusgangsrechnungsID
        {
            get { return ausgangsrechnungsID; }
            set { if (value >= 0) { ausgangsrechnungsID = value; } }
        }

        private int stunden;
        /// <summary>
        /// The number of hours that shall be booked
        /// </summary>
        public int Stunden
        {
            get { return stunden; }
            set { if (value >= 0) { stunden = value; } }
        }

        private double stundenSatz;
        /// <summary>
        /// The number of hours that shall be booked
        /// </summary>
        public double Stundensatz
        {
            get { return stundenSatz; }
            set { if (value >= 0) { stundenSatz = value; } }
        }

    }
}
