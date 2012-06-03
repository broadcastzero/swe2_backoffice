// -----------------------------------------------------------------------
// <copyright file="rechnungsTab.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Drawing;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using DatabindingFramework;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal.Tables;
    using LoggingFramework;
    using Rules;
    using UserExceptions;

    public partial class rechnungsTab : UserControl
    {
        private Logger logger = Logger.Instance;
        private List<BuchungszeilenTable> collectedBuchungszeilen;
        private EingangsrechnungTable eingangsrechnung;

        public rechnungsTab()
        {
            InitializeComponent();

            // set Kategorie within "Eingangsrechnung" to first item
            this.kategorieComboBox.SelectedItem = this.kategorieComboBox.Items[0];
        }

        private void ausgangsrechnungComboBox_DropDown(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingProjekteToComboBox(sender, e);
        }

        private void BindFromExistingKontakte(object sender, EventArgs e)
        {
            // set additional param to true, so that it is searched for Kontakte instead of Kunden
            GlobalActions.BindFromExistingKundenToComboBox(sender, e, true);
        }

        // If NE tab visible, create Eingangsrechnung AND Buchungszeile. Otherwise, only create Buchungszeile to current Eingangsrechnung
        private void AddBuchungszeile(object sender, EventArgs e)
        {
            this.eingangsrechnungMsgLabel.Text = string.Empty;
            this.eingangsrechnungMsgLabel.Hide();

            // in case of new Eingangsrechnung, the input fields are not locked
            if (!this.eingangsrechnungBezeichnungTextBox.ReadOnly == true)
            {
                this.logger.Log(Logger.Level.Info, "Beginning with new Eingangsrechnung");

                // create new Eingangsrechnung
                this.eingangsrechnung = new EingangsrechnungTable();

                // check Eingangsrechnungs input fields
                if (this.existingKontakteComboBox.SelectedIndex < 1)
                {
                    this.eingangsrechnungMsgLabel.Text = "Keine KundenID gewählt!";
                    this.eingangsrechnungMsgLabel.ForeColor = Color.Red;
                    this.eingangsrechnungMsgLabel.Show();
                    return;
                }

                // get KontaktID out of Combobox
                string kontaktID = this.existingKontakteComboBox.SelectedItem.ToString();
                this.eingangsrechnung.KontaktID = -1;

                try
                {
                    this.eingangsrechnung.KontaktID = GlobalActions.getIdFromCombobox(kontaktID, this.eingangsrechnungMsgLabel);
                }
                catch (InvalidInputException)
                {
                    logger.Log(Logger.Level.Error, "Unknown Exception while getting ID from Projekte from AngeboteTab!");
                }

                // check for valid KontaktID
                IRule posint = new PositiveIntValidator();
                DataBindingFramework.BindFromInt(this.eingangsrechnung.KontaktID.ToString(), "KontaktID", this.eingangsrechnungMsgLabel, false, posint);

                // check other vals
                eingangsrechnung.Rechnungsdatum = this.eingangsrechnungDatePicker.Value.ToShortDateString();
                eingangsrechnung.Bezeichnung = this.eingangsrechnungBezeichnungTextBox.Text;

                // check date
                IRule dateval = new DateValidator();
                DataBindingFramework.BindFromString(eingangsrechnung.Rechnungsdatum, "Datum", this.eingangsrechnungMsgLabel, false, dateval);

                // check description
                IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
                IRule slv = new StringLength150Validator();
                DataBindingFramework.BindFromString(eingangsrechnung.Bezeichnung, "Bez. Eingangsrechnung", this.eingangsrechnungMsgLabel, false, lnhsv, slv);

                // add Archivierungspfad
                eingangsrechnung.Archivierungspfad = DateTime.Now.Year.ToString() + '/' + DateTime.Now.Month.ToString() + '/' + DateTime.Now.ToShortDateString() + '-' + this.eingangsrechnung.KontaktID + '-' + this.eingangsrechnung.Bezeichnung;

                // check for errors
                if (this.eingangsrechnungMsgLabel.Visible)
                { return; }

                // create new collection, if it does not already exist
                if (this.collectedBuchungszeilen == null)
                {
                    this.collectedBuchungszeilen = new List<BuchungszeilenTable>();
                }
                else
                {
                    // if list exists, just clear elements
                    this.collectedBuchungszeilen.Clear();
                }
            }            

            // save Buchungszeile
            this.AddBuchungszeileToDataGridView();

            // lock Eingangsrechnungs elements, if not already done
            if (!this.eingangsrechnungBezeichnungTextBox.ReadOnly == true)
            {
                this.existingKontakteComboBox.Enabled = false;
                this.eingangsrechnungDatePicker.Enabled = false;
                this.eingangsrechnungBezeichnungTextBox.ReadOnly = true;
                this.logger.Log(Logger.Level.Info, "Locked Eingangsrechnungs-elements");
            }
        }

        // save a new Eingangsrechnung
        private int SaveEingangsrechnung()
        {
            // force Kontakte-Combobox to scroll down, in case that user didn't do this
            if (this.existingKontakteComboBox.SelectedIndex < 0)
            {
                GlobalActions.BindFromExistingKundenToComboBox(this.existingKontakteComboBox, null, true);
            }

            RechnungsManager manager = new RechnungsManager();
            int rechnungsid;

            // save Eingangsrechnung in database
            try
            {
                rechnungsid = manager.CreateEingangsrechnung(this.eingangsrechnung);
            }
            catch (InvalidInputException e)
            {
                this.logger.Log(Logger.Level.Error, e.Message);
                this.eingangsrechnungMsgLabel.Text = e.Message;
                this.eingangsrechnungMsgLabel.Show();
                return -1;
            }

            this.eingangsrechnungMsgLabel.Text += "Eingangsrechnung gespeichert.\n";

            return rechnungsid;
        }

        // add Buchungszeile
        private void AddBuchungszeileToDataGridView()
        {   
            string betrag = this.eingangsrechnungBetragTextBox.Text;
            string bezeichnung = this.buchungszeileBezeichnungTextBox.Text;

            IRule pdv = new PositiveDoubleValidator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule slv = new StringLength150Validator();

            // Create Buchungszeilen business object
            BuchungszeilenTable buchungszeile = new BuchungszeilenTable();
            buchungszeile.Beschreibung = DataBindingFramework.BindFromString(bezeichnung, "Bezeichnung", this.eingangsrechnungMsgLabel, false, lnhsv, slv);
            buchungszeile.BetragNetto = DataBindingFramework.BindFromDouble(betrag, "Betrag", this.eingangsrechnungMsgLabel, false, pdv);
            buchungszeile.KategorieID = this.kategorieComboBox.SelectedIndex+1;
            buchungszeile.Buchungsdatum = DateTime.Now.ToShortDateString();

            // in case of errors, do not continue with saving new Eingangsrechnung
            if (this.eingangsrechnungMsgLabel.Visible)
            { return; }

            // add to DataGridView
            this.buchungszeilenBindingSource.Add(buchungszeile);
            GlobalActions.ShowSuccessLabel(this.eingangsrechnungMsgLabel);
        }

        // get all existing Eingangsrechnungen out of Database and bind result list to given combobox
        private void BindFromExistingEingangsrechnungToComboBox(ComboBox combobox)
        { 
            // TODO
        }

        private void BindToExistingKundenComboBox(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingKundenToComboBox(sender, e);
        }

        // load data of an existing Eingangsrechnung
        private void ExistingEingangsrechnungComboBoxLoadData(object sender, EventArgs e)
        {
            List<EingangsrechnungTable> results = new List<EingangsrechnungTable>();
            List<string> listItems = new List<string>();

            RechnungsManager manager = new RechnungsManager();
            results = manager.LoadEingangsrechnungen();
            //this.eingangsrechnungBindingSource.DataSource = results;

            // if there are results, add them to string result list
            if (results.Count != 0)
            {
                foreach (EingangsrechnungTable table in results)
                {
                    string entry = table.ID + ": " + table.Rechnungsdatum;
                    listItems.Add(entry);
                }
            }

            // set data source
            (sender as ComboBox).DataSource = listItems;
        }

        private void BindToEingangsrechnungsDataGridView(object sender, EventArgs e)
        {
            
        }
    }
}
