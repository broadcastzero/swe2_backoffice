// -----------------------------------------------------------------------
// <copyright file="RechnungszeileTable.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal.Tables
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
        /// Gets or sets unique ID for the table
        /// </summary>
        public int ID
        {
            get { return id; }
            set { if (value >= 0) { id = value; } }
        }

        private int projektID;
        /// <summary>
        /// Gets or sets foreign key to table Projekt
        /// </summary>
        public int ProjektID
        {
            get { return projektID; }
            set { if (value >= 0) { projektID = value; } }
        }

        private int ausgangsrechnungsID;
        /// <summary>
        /// Gets or sets foreign key to table Ausgangsrechnung
        /// </summary>
        public int AusgangsrechnungsID
        {
            get { return ausgangsrechnungsID; }
            set { if (value >= 0) { ausgangsrechnungsID = value; } }
        }

        private int stunden;
        /// <summary>
        /// Gets or sets the number of hours that shall be booked
        /// </summary>
        public int Stunden
        {
            get { return stunden; }
            set { if (value >= 0) { stunden = value; } }
        }

        private double stundenSatz;
        /// <summary>
        /// Gets or sets the number of hours that shall be booked
        /// </summary>
        public double Stundensatz
        {
            get { return stundenSatz; }
            set { if (value >= 0) { stundenSatz = value; } }
        }

    }
}
