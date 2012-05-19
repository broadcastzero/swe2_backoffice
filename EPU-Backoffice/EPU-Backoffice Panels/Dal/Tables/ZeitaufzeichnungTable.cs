// -----------------------------------------------------------------------
// <copyright file="ZeitaufzeichnungTable.cs" company="Marvin&Felix">
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
    /// A class for the database table "Zeitaufzeichnung" with its attributes
    /// </summary>
    public class ZeitaufzeichnungTable
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
        /// Gets or sets foreign key to table Projekt
        /// </summary>
        public int ProjektID
        {
            get { return projektID; }
            set { if (value >= 0) { projektID = value; } }
        }

        private int stunden;
        /// <summary>
        /// Gets or sets the number of hours that shall be booked
        /// </summary>
        public int Stunden
        {
            get { return stunden; }
            set { if (value >= 0) { stunden = value; } }
        }

        private string bezeichnung;
        /// <summary>
        /// Gets or sets the description of what has been done
        /// </summary>
        public string Bezeichnung
        {
            get { return bezeichnung; }
            set { { bezeichnung = value; } }
        }

        private int stundensatz;
        /// <summary>
        /// Gets or sets the costs per hour
        /// </summary>
        public int Stundensatz
        {
            get { return stundensatz; }
            set { { stundensatz = value; } }
        }
    }
}
