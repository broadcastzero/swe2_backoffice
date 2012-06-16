// -----------------------------------------------------------------------
// <copyright file="AusgangsrechnungTable.cs" company="Marvin&Felix">
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
    /// A class for the database table "Ausgangsrechnung" with its attributes.
    /// </summary>
    public class AusgangsrechnungTable
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
        /// Gets or sets unique ID of the connected project
        /// </summary>
        public int ProjektID
        {
            get { return projektID; }
            set { if (value >= 0) { projektID = value; } }
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

        private DateTime bezeichnung;
        /// <summary>
        /// Gets or sets the title of the Ausgangsrechnung
        /// </summary>
        public DateTime Bezeichnung
        {
            get { return bezeichnung; }
            set { bezeichnung = value; }
        }
    }
}
