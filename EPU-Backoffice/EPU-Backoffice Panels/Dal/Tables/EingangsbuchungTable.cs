// -----------------------------------------------------------------------
// <copyright file="EingangsbuchungTable.cs" company="Marvin&Felix">
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
    /// A class for Eingangsbuchungen
    /// </summary>
    public class EingangsbuchungTable
    {
        private int buchungszeilenID;
        /// <summary>
        /// A foreign key to the Buchungszeile
        /// </summary>
        public int BuchungszeilenID
        {
            get { return buchungszeilenID; }
            set { if(value >= 0) { buchungszeilenID = value; } }
        }

        private int eingangsrechungsID;
        /// <summary>
        /// A foreign key to the Eingangsrechnung
        /// </summary>
        public int EingangsrechungsID
        {
            get { return eingangsrechungsID; }
            set { if (value >= 0) { eingangsrechungsID = value; } }
        }
    }
}
