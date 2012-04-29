// -----------------------------------------------------------------------
// <copyright file="KategorienTable.cs" company="">
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
    /// A class for the database table "Bankkonto" with its attributes
    /// </summary>
    public class KategorienTable
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

        private string name;
        /// <summary>
        /// Foreign key to table Kunde
        /// </summary>
        public string Name
        {
            get { return name; }
            set { { name = value; } }
        }
    }
}
