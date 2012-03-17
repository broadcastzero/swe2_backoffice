// -----------------------------------------------------------------------
// <copyright file="KategorienTable.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.DAL.Tables
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// A class for the database table "Bankkonto" with its attributes
    /// </summary>
    public class KategorienTable
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

        private string _Name;
        /// <summary>
        /// Foreign key to table Kunde
        /// </summary>
        public string Name
        {
            get { return _Name; }
            set { { _Name = value; } }
        }
    }
}
