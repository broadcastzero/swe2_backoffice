// -----------------------------------------------------------------------
// <copyright file="KontaktTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Dal.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// A class for the database table "Kontakt" with its attributes
    /// </summary>
    public class KundeKontaktTable
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

        // Kunde...false, Kontakt...true
        private bool _type;
        /// <summary>
        /// Is it a Kunde (false) or a Kontakt (true) we are talking about?
        /// </summary>
        public bool type { get { return _type; } set { _type = value; } }
    }
}
