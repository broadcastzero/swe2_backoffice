// -----------------------------------------------------------------------
// <copyright file="EingangsrechnungTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class for the database table "Eingangsrechnung" with its attributes
    /// </summary>
    public class EingangsrechnungTable
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

        private int _KontaktID;
        /// <summary>
        /// Foreign key to table Kontakte
        /// </summary>
        public int KontaktID
        {
            get { return _KontaktID; }
            set { if (value >= 0) { _KontaktID = value; } }
        }

        private string _Archivierungspfad;
        /// <summary>
        /// The filepath where this Eingangsrechnung is stored
        /// </summary>
        public string Archivierungspfad
        {
            get { return _Archivierungspfad; }
            set { { _Archivierungspfad = value; } }
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
