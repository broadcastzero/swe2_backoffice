﻿// -----------------------------------------------------------------------
// <copyright file="KundeTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class for the database table "Kunde" with its attributes
    /// </summary>
    public class KundeTable
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

        private string _Vorname;
        /// <summary>
        /// Foreign key to table Kunde
        /// </summary>
        public string Vorname
        {
            get { return _Vorname; }
            set { { _Vorname = value; } }
        }

        private string _NachnameFirmenname;
        /// <summary>
        /// Foreign key to table Kunde
        /// </summary>
        public string NachnameFirmenname
        {
            get { return _NachnameFirmenname; }
            set { { _NachnameFirmenname = value; } }
        }
    }
}
