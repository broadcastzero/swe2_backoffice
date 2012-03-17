// -----------------------------------------------------------------------
// <copyright file="Ausgangsrechnung.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.DAL.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class for the database table "Ausgangsrechnung" with its attributes
    /// </summary>
    public class AusgangsrechnungTable
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

        private int _KundenID;
        /// <summary>
        /// Foreign key to table Kunde
        /// </summary>
        public int KundenID
        {
            get { return _KundenID; }
            set { if (value >= 0) { _KundenID = value; } }
        }

        private DateTime _Rechnungsdatum;
        /// <summary>
        /// Datum of creation of an Rechnung
        /// </summary>
        public DateTime Rechnungsdatum
        {
            get { return _Rechnungsdatum; }
            set { _Rechnungsdatum = value; }
        }
    }
}
