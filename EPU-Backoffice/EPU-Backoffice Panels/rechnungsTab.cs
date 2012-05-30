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

            // force Eingangsrechnungs-Combobox to scroll down, in case that user didn't do this
            if (this.addToEingangsrechnungCheckBox.Checked && this.existingEingangsrechnungComboBox.SelectedIndex < 0)
            {
                this.BindFromExistingEingangsrechnungToComboBox(this.existingEingangsrechnungComboBox);
            }

            int eingangsrechnungsID = -1;

            // in case of new Eingangsrechnung
            if (!this.addToEingangsrechnungCheckBox.Checked)
            {
                eingangsrechnungsID = this.SaveEingangsrechnung();
            }
            else
            { 
                // get EingangsrechnungsID out of combobox
                eingangsrechnungsID = GlobalActions.getIdFromCombobox(this.existingEingangsrechnungComboBox.SelectedItem.ToString(), this.eingangsrechnungMsgLabel);
                this.logger.Log(Logger.Level.Info, "Chosen EingangsrechnungsID from ComboBox: " + eingangsrechnungsID);
            }

            // in case of error, eingangrechnungsID will be -1
            if (eingangsrechnungsID == -1)
            { return; }

            // save Buchungszeile
            this.RequestBuchungszeileSaving(eingangsrechnungsID);
        }

        // save a new Eingangsrechnung
        private int SaveEingangsrechnung()
        {
            // force Kontakte-Combobox to scroll down, in case that user didn't do this
            if (this.existingKontakteComboBox.SelectedIndex < 0)
            {
                GlobalActions.BindFromExistingKundenToComboBox(this.existingKontakteComboBox, null, true);
            }

            // get KontaktID out of Combobox
            string kontaktID = this.existingKontakteComboBox.SelectedItem.ToString();
            int id = -1;

            try
            {
                id = GlobalActions.getIdFromCombobox(kontaktID, this.eingangsrechnungMsgLabel);
            }
            catch (InvalidInputException)
            {
                logger.Log(Logger.Level.Error, "Unknown Exception while getting ID from Projekte from AngeboteTab!");
            }

            // check for valid KontaktID
            IRule posint = new PositiveIntValidator();
            DataBindingFramework.BindFromInt(id.ToString(), "KontaktID", this.eingangsrechnungMsgLabel, false, posint);

            // check other vals
            string date = this.eingangsrechnungDatePicker.Value.ToShortDateString();
            string description = this.eingangsrechnungBezeichnungTextBox.Text;

            // check date
            IRule dateval = new DateValidator();
            DataBindingFramework.BindFromString(date, "Datum", this.eingangsrechnungMsgLabel, false, dateval);

            // check description
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule slv = new StringLength150Validator();
            DataBindingFramework.BindFromString(description, "Beschreibung", this.eingangsrechnungMsgLabel, false, lnhsv, slv);

            // check for errors
            if (this.eingangsrechnungMsgLabel.Visible)
            { return -1; }

            // TODO: save new Eingangsrechnung and get ID returned
            EingangsrechnungTable table = new EingangsrechnungTable();
            table.KontaktID = id;
            table.Rechnungsdatum = DateTime.Now.ToShortDateString();
            table.Archivierungspfad = "nopath";

            RechnungsManager manager = new RechnungsManager();
            int rechnungsid;

            // save Eingangsrechnung in database
            try
            {
                rechnungsid = manager.CreateEingangsrechnung(table);
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
        private void RequestBuchungszeileSaving(int eingangsrechnungsID)
        {   
            string betrag = this.eingangsrechnungBetragTextBox.Text;
            double p_betrag;
            string kategorie = this.kategorieComboBox.SelectedItem.ToString();

            IRule pdv = new PositiveDoubleValidator();
            p_betrag = DataBindingFramework.BindFromDouble(betrag, "Betrag", this.eingangsrechnungMsgLabel, false, pdv);

            IRule lnhsv1 = new LettersNumbersHyphenSpaceValidator();
            DataBindingFramework.BindFromString(kategorie, "Kategorie", this.eingangsrechnungMsgLabel, false, lnhsv1);

            // in case of errors, do not continue with saving new Eingangsrechnung
            if (this.eingangsrechnungMsgLabel.Visible)
            { return; }

            //TODO: forward to BL

            // Show success label, in case that error label is not visible
            if (!this.eingangsrechnungMsgLabel.Visible)
            {
                GlobalActions.ShowSuccessLabel(this.eingangsrechnungMsgLabel);
            }
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

        private void ChoseExistingEingangsrechnungCheckBox(object sender, EventArgs e)
        {
            if (this.addToEingangsrechnungCheckBox.Checked)
            {
                this.eingangsrechnungErstellenSubTab.SelectedTab = this.eingangsrechnungErstellenBETab;                
            }
            else
            {
                this.eingangsrechnungErstellenSubTab.SelectedTab = this.eingangsrechnungErstellenNETab;
            }
        }

        // load data of an existing Eingangsrechnung
        private void ExistingEingangsrechnungComboBoxLoadData(object sender, EventArgs e)
        {
            List<EingangsrechnungTable> results = new List<EingangsrechnungTable>();
            List<string> listItems = new List<string>();

            RechnungsManager manager = new RechnungsManager();
            results = manager.LoadEingangsrechnungen();
            this.eingangsrechnungBindingSource.DataSource = results;

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
