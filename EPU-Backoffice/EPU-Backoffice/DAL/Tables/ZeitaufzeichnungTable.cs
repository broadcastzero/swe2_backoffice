// -----------------------------------------------------------------------
// <copyright file="ZeitaufzeichnungTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.DAL.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class for the database table "Zeitaufzeichnung" with its attributes
    /// </summary>
    public class ZeitaufzeichnungTable
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

        private int _Stunden;
        /// <summary>
        /// The number of hours that shall be booked
        /// </summary>
        public int Stunden
        {
            get { return _Stunden; }
            set { if (value >= 0) { _Stunden = value; } }
        }

        private string _Bezeichnung;
        /// <summary>
        /// The description of what has been done
        /// </summary>
        public string Bezeichnung
        {
            get { return _Bezeichnung; }
            set { { _Bezeichnung = value; } }
        }
    }
}
