// -----------------------------------------------------------------------
// <copyright file="ZeitaufzeichnungTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackofficePanels.Dal.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class for the database table "Zeitaufzeichnung" with its attributes
    /// </summary>
    public class ZeitaufzeichnungTable
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

        private int stunden;
        /// <summary>
        /// The number of hours that shall be booked
        /// </summary>
        public int Stunden
        {
            get { return stunden; }
            set { if (value >= 0) { stunden = value; } }
        }

        private string bezeichnung;
        /// <summary>
        /// The description of what has been done
        /// </summary>
        public string Bezeichnung
        {
            get { return bezeichnung; }
            set { { bezeichnung = value; } }
        }
    }
}
