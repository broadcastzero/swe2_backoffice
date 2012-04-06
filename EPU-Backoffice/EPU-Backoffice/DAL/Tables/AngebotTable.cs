// -----------------------------------------------------------------------
// <copyright file="AngebotTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal.Tables
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
        /// Unique ID for the table
        /// </summary>
        public int ID
        { 
            get { return id; }
            set { if (value >= 0) { id = value; } } 
        }

        private int projektID;
        /// <summary>
        /// Foreign key to table Projekt
        /// </summary>
        public int ProjektID
        {
            get { return projektID; }
            set { if (value >= 0) { projektID = value; } }
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

        private double angebotssumme;
        /// <summary>
        /// Sum of an Angebot
        /// </summary>
        public double Angebotssumme
        {
            get { return kundenID; }
            set { if (value >= 0) { angebotssumme = value; } }
        }

        // in hours
        private int angebotsdauer;
        /// <summary>
        /// Dauer of an Angebot
        /// </summary>
        public int Angebotsdauer
        {
            get { return angebotsdauer; }
            set { if (value >= 0) { angebotsdauer = value; } }
        }

        private DateTime erstellungsdatum;
        /// <summary>
        /// Datum of creation of an Angebot
        /// </summary>
        public DateTime Erstellungsdatum
        {
            get { return erstellungsdatum; }
            set { erstellungsdatum = value; }
        }

        // between 0-1 (in %)
        private double umsetzungschance;
        /// <summary>
        /// Chance in % of Umsetzung
        /// </summary>
        public double Umsetzungschance
        {
            get { return umsetzungschance; }
            set { if (value <= 1 && value >= 0) { umsetzungschance = value; } }
        }

        private bool akzeptiert;
        /// <summary>
        /// bool-value, which shows if Angebot has been accepted
        /// </summary>
        public bool Akzeptiert
        {
            get { return akzeptiert; }
            set { akzeptiert = value; }
        }
    }
}
