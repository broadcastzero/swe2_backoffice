// -----------------------------------------------------------------------
// <copyright file="Ausgangsrechnung.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal.Tables
{
    using System;

    /// <summary>
    /// This class connects an Ausgangsrechnung with one or more Buchungszeile(n)
    /// </summary>
    public class AusgangsbuchungTable
    {
        private int buchungszeilenID;

        /// <summary>
        /// A foreign key to the Buchungszeile
        /// </summary>
        public int BuchungszeilenID
        {
            get { return this.buchungszeilenID; }
            set { if (value >= 0) this.buchungszeilenID = value; }
        }

        private int ausgangsrechnungsID;

        /// <summary>
        /// A foreign key to the Ausgangsrechnung
        /// </summary>
        public int AusgangsrechnungsID
        {
            get { return this.ausgangsrechnungsID; }
            set { if(value >= 0) this.ausgangsrechnungsID = value; }
        }
    }
}