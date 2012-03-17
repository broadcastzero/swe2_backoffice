// -----------------------------------------------------------------------
// <copyright file="RechnungszeileTable.cs" company="">
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
    /// A class for the database table "Rechnungszeile" with its attributes
    /// </summary>
    public class RechnungszeileTable
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

        private int _AngebotsID;
        /// <summary>
        /// Foreign key to table Angebot
        /// </summary>
        public int AngebotsID
        {
            get { return _AngebotsID; }
            set { if (value >= 0) { _AngebotsID = value; } }
        }

        private int _AusgangsrechnungsID;
        /// <summary>
        /// Foreign key to table Ausgangsrechnung
        /// </summary>
        public int AusgangsrechnungsID
        {
            get { return _AusgangsrechnungsID; }
            set { if (value >= 0) { _AusgangsrechnungsID = value; } }
        }

        private int _Stunden;
        /// <summary>
        /// The number of hours that shall be booked
        /// </summary>
        public int Stunden
        {
            get { return _Stunden; }
            set { if (value >= 0) { _Stunden = value; } }
        }
    }
}
