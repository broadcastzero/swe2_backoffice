// -----------------------------------------------------------------------
// <copyright file="AngebotTable.cs" company="Marvin&Felix">
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
    /// A class for the database table "Angebot" with its attributes
    /// </summary>
    public class AngebotTable
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

        private int kundenID;
        /// <summary>
        /// Gets or sets foreign key to table Kunde
        /// </summary>
        public int KundenID
        {
            get { return kundenID; }
            set { if (value >= 0) { kundenID = value; } }
        }

        private double angebotssumme;
        /// <summary>
        /// Gets or sets sum of an Angebot
        /// </summary>
        public double Angebotssumme
        {
            get { return angebotssumme; }
            set { if (value >= 0) { angebotssumme = value; } }
        }

        // in Date (format: 20.12.2012)
        private string angebotsdauer;
        /// <summary>
        /// Gets or sets Dauer of an Angebot
        /// </summary>
        public string Angebotsdauer
        {
            get { return angebotsdauer; }
            set { angebotsdauer = value; }
        }

        private string erstellungsdatum;
        /// <summary>
        /// Gets or sets Datum of creation of an Angebot - in shortDateString-Format
        /// </summary>
        public string Erstellungsdatum
        {
            get { return erstellungsdatum; }
            set { erstellungsdatum = value; }
        }

        // between 0-100 (in %)
        private int umsetzungschance;
        /// <summary>
        /// Gets or sets Chance in % of Umsetzung
        /// </summary>
        public int Umsetzungschance
        {
            get { return umsetzungschance; }
            set { if (value <= 100 && value >= 0) { umsetzungschance = value; } }
        }

        private string beschreibung;
        /// <summary>
        /// Gets or sets a description of the Angebot
        /// </summary>
        public string Beschreibung
        {
            get { return beschreibung; }
            set { { beschreibung = value; } }
        }
    }
}
