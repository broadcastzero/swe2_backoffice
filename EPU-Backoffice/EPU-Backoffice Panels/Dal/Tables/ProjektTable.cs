// -----------------------------------------------------------------------
// <copyright file="ProjektTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class for the database table "Projekt" with its attributes
    /// </summary>
    public class ProjektTable
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

        private int angebotID;
        /// <summary>
        /// Unique ID for the related Angebot
        /// </summary>
        public int AngebotID
        {
            get { return angebotID; }
            set { if (value >= 0) { angebotID = value; } }
        }

        private string projektname;
        /// <summary>
        /// The name of the project
        /// </summary>
        public string Projektname
        {
            get { return projektname; }
            set { { projektname = value; } }
        }

        private DateTime projektstart;
        /// <summary>
        /// Datum of creation of an Angebot
        /// </summary>
        public DateTime Projektstart
        {
            get { return projektstart; }
            set { projektstart = value; }
        }
    }
}
