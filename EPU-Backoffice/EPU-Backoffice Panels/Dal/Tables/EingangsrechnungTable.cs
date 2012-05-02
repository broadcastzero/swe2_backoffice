// -----------------------------------------------------------------------
// <copyright file="EingangsrechnungTable.cs" company="Marvin&Felix">
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
    /// A class for the database table "Eingangsrechnung" with its attributes
    /// </summary>
    public class EingangsrechnungTable
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

        private int kontaktID;
        /// <summary>
        /// Gets or sets foreign key to table Kontakte
        /// </summary>
        public int KontaktID
        {
            get { return kontaktID; }
            set { if (value >= 0) { kontaktID = value; } }
        }

        private string archivierungspfad;
        /// <summary>
        /// Gets or sets the filepath where this Eingangsrechnung is stored
        /// </summary>
        public string Archivierungspfad
        {
            get { return archivierungspfad; }
            set { { archivierungspfad = value; } }
        }

        private DateTime rechnungsdatum;
        /// <summary>
        /// Gets or sets Datum of creation of an Rechnung
        /// </summary>
        public DateTime Rechnungsdatum
        {
            get { return rechnungsdatum; }
            set { rechnungsdatum = value; }
        }
    }
}
