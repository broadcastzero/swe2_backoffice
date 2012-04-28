// -----------------------------------------------------------------------
// <copyright file="EingangsrechnungTable.cs" company="">
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
    /// A class for the database table "Eingangsrechnung" with its attributes
    /// </summary>
    public class EingangsrechnungTable
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

        private int kontaktID;
        /// <summary>
        /// Foreign key to table Kontakte
        /// </summary>
        public int KontaktID
        {
            get { return kontaktID; }
            set { if (value >= 0) { kontaktID = value; } }
        }

        private string archivierungspfad;
        /// <summary>
        /// The filepath where this Eingangsrechnung is stored
        /// </summary>
        public string Archivierungspfad
        {
            get { return archivierungspfad; }
            set { { archivierungspfad = value; } }
        }

        private DateTime rechnungsdatum;
        /// <summary>
        /// Datum of creation of an Rechnung
        /// </summary>
        public DateTime Rechnungsdatum
        {
            get { return rechnungsdatum; }
            set { rechnungsdatum = value; }
        }
    }
}
