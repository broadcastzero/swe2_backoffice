// -----------------------------------------------------------------------
// <copyright file="AusgangsrechnungsView.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal.Tables
{
    using System;

    /// <summary>
    /// This class represents a View for the tables Ausgangsrechnung, Ausgangsbuchung and Buchungszeilen
    /// </summary>
    public class AusgangsrechnungsView
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string bezeichnung;
        public string Bezeichnung
        {
            get { return bezeichnung; }
            set { bezeichnung = value; }
        }

        private string rechnungsdatum;
        public string Rechnungsdatum
        {
            get { return rechnungsdatum; }
            set { rechnungsdatum = value; }
        }

        private double betragUST;
        public double Betrag
        {
            get { return betragUST; }
            set { betragUST = value; }
        }
    }
}
