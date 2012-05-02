// -----------------------------------------------------------------------
// <copyright file="KundeKontaktTable.cs" company="Marvin&Felix">
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
    /// A class for the database table "Kontakt" with its attributes
    /// </summary>
    public class KundeKontaktTable
    {
        private int id;
        /// <summary>
        /// Gets or sets unique ID for the table
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string vorname;
        /// <summary>
        /// Gets or sets foreign key to table Kunde
        /// </summary>
        public string Vorname
        {
            get { return vorname; }
            set { { vorname = value; } }
        }

        private string nachnameFirmenname;
        /// <summary>
        /// Gets or sets foreign key to table Kunde
        /// </summary>
        public string NachnameFirmenname
        {
            get { return nachnameFirmenname; }
            set { { nachnameFirmenname = value; } }
        }

        // Kunde...false, Kontakt...true
        private bool type;
        /// <summary>
        /// Is it a Kunde (false) or a Kontakt (true) we are talking about?
        /// </summary>
        public bool Type { get { return type; } set { type = value; } }
    }
}
