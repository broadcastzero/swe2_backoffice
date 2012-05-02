// -----------------------------------------------------------------------
// <copyright file="ProjektTable.cs" company="Marvin&Felix">
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
    /// A class for the database table "Projekt" with its attributes
    /// </summary>
    public class ProjektTable
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

        private int angebotID;
        /// <summary>
        /// Gets or sets unique ID for the related Angebot
        /// </summary>
        public int AngebotID
        {
            get { return angebotID; }
            set { if (value >= 0) { angebotID = value; } }
        }

        private string projektname;
        /// <summary>
        /// Gets or sets the name of the project
        /// </summary>
        public string Projektname
        {
            get { return projektname; }
            set { { projektname = value; } }
        }

        private string projektstart;
        /// <summary>
        /// Gets or sets Datum of creation of an Angebot in ShortDateString format (16/12/1989)
        /// </summary>
        public string Projektstart
        {
            get { return projektstart; }
            set { projektstart = value; }
        }
    }
}
