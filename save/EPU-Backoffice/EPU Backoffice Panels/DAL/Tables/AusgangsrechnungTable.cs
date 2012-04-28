// -----------------------------------------------------------------------
// <copyright file="Ausgangsrechnung.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackofficePanels.Dal.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class for the database table "Ausgangsrechnung" with its attributes
    /// </summary>
    public class AusgangsrechnungTable
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

        private int kundenID;
        /// <summary>
        /// Foreign key to table Kunde
        /// </summary>
        public int KundenID
        {
            get { return kundenID; }
            set { if (value >= 0) { kundenID = value; } }
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
