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
        private int _ID;
        /// <summary>
        /// Unique ID for the table
        /// </summary>
        public int ID 
        { 
            get { return _ID; }
            set { if (value >= 0) { _ID = value; } } 
        }

        private int _ProjektID;
        /// <summary>
        /// Foreign key to table Projekt
        /// </summary>
        public int ProjektID
        {
            get { return _ProjektID; }
            set { if (value >= 0) { _ProjektID = value; } }
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

        private double _Angebotssumme;
        /// <summary>
        /// Sum of an Angebot
        /// </summary>
        public double Angebotssumme
        {
            get { return _KundenID; }
            set { if (value >= 0) { _Angebotssumme = value; } }
        }

        // in hours
        private int _Angebotsdauer;
        /// <summary>
        /// Dauer of an Angebot
        /// </summary>
        public int Angebotsdauer
        {
            get { return _Angebotsdauer; }
            set { if (value >= 0) { _Angebotsdauer = value; } }
        }

        private DateTime _Erstellungsdatum;
        /// <summary>
        /// Datum of creation of an Angebot
        /// </summary>
        public DateTime Erstellungsdatum
        {
            get { return _Erstellungsdatum; }
            set { _Erstellungsdatum = value; }
        }

        // between 0-1 (in %)
        private double _Umsetzungschance;
        /// <summary>
        /// Chance in % of Umsetzung
        /// </summary>
        public double Umsetzungschance
        {
            get { return _Umsetzungschance; }
            set { if (value <= 1 && value >= 0) { _Umsetzungschance = value; } }
        }

        private bool _Akzeptiert;
        /// <summary>
        /// bool-value, which shows if Angebot has been accepted
        /// </summary>
        public bool Akzeptiert
        {
            get { return _Akzeptiert; }
            set { _Akzeptiert = value; }
        }
    }
}
