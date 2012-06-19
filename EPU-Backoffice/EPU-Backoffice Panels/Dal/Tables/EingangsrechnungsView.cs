// -----------------------------------------------------------------------
// <copyright file="EingangsrechnungsView.cs" company="Marvin&Felix">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Dal.Tables
{
    using System;

    /// <summary>
    /// This class contains a view to all important Eingangsrechnungs information.
    /// </summary>
    public class EingangsrechnungsView
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

        private double betrag;
        public double Betrag
        {
            get { return betrag; }
            set { betrag = value; }
        }

        private string rechnungsdatum;
        public string Rechnungsdatum
        {
            get { return rechnungsdatum; }
            set { rechnungsdatum = value; }
        }
    }
}
