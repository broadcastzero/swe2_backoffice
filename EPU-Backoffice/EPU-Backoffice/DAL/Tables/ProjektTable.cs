// -----------------------------------------------------------------------
// <copyright file="ProjektTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal.Tables
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
        private int _ID;
        /// <summary>
        /// Unique ID for the table
        /// </summary>
        public int ID
        {
            get { return _ID; }
            set { if (value >= 0) { _ID = value; } }
        }

        private string _Projektname;
        /// <summary>
        /// The name of the project
        /// </summary>
        public string Projektname
        {
            get { return _Projektname; }
            set { { _Projektname = value; } }
        }

        private DateTime _Projektstart;
        /// <summary>
        /// Datum of creation of an Angebot
        /// </summary>
        public DateTime Projektstart
        {
            get { return _Projektstart; }
            set { _Projektstart = value; }
        }
    }
}
