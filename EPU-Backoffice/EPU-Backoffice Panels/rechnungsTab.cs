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
    using System.Drawing;
    using System.Windows.Forms;
    using DatabindingFramework;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal.Tables;
    using LoggingFramework;
    using Rules;
    using UserExceptions;
    using System.Data.SQLite;
    using PdfSharp.Pdf;
    using PdfSharp.Drawing;
    using System.Diagnostics;
    


    public partial class rechnungsTab : UserControl
    {
        private Logger logger = Logger.Instance;
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
                    this.eingangsrechnung.KontaktID = GlobalActions.GetIdFromCombobox(kontaktID, this.eingangsrechnungMsgLabel);
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
                // Year/Month/Date/KontaktID/Bezeichnung
                eingangsrechnung.Archivierungspfad = DateTime.Now.Year.ToString() + '/' + DateTime.Now.Month.ToString() + '/' + DateTime.Now.ToShortDateString() + '-' + this.eingangsrechnung.KontaktID + '-' + this.eingangsrechnung.Bezeichnung;

                // check for errors
                if (this.eingangsrechnungMsgLabel.Visible)
                { return; }
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
            buchungszeile.Bezeichnung = DataBindingFramework.BindFromString(bezeichnung, "Bezeichnung", this.eingangsrechnungMsgLabel, false, lnhsv, slv);
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

        private void BindToExistingKundenComboBox(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingKundenToComboBox(sender, e);
        }

        // load data of an existing Eingangsrechnung
        /*private void ExistingEingangsrechnungComboBoxLoadData(object sender, EventArgs e)
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
        }*/

        // Clear everything within Eingangsrechnungstab
        private void ResetEingangsrechnung(object sender, EventArgs e)
        {
            this.buchungszeilenBindingSource.Clear();
            this.eingangsrechnung = null;

            this.existingKontakteComboBox.Enabled = true;
            this.eingangsrechnungDatePicker.Enabled = true;
            this.eingangsrechnungBezeichnungTextBox.ReadOnly = false;

            this.existingKontakteComboBox.ResetText();
            this.eingangsrechnungDatePicker.ResetText();
            this.eingangsrechnungBezeichnungTextBox.ResetText();
            this.buchungszeileBezeichnungTextBox.ResetText();
            this.eingangsrechnungBetragTextBox.ResetText();
            this.kategorieComboBox.ResetText();
            

            this.logger.Log(Logger.Level.Info, "Unocked Eingangsrechnungs-elements. Reset all Eingangsrechnungs-Inputfields.");
        }

        // Save Eingangsrechnung and Buchungszeilen
        private void FinishAccount(object sender, EventArgs e)
        {
            // if there are no elements, return
            if (this.buchungszeilenBindingSource.Count < 1)
            {
                this.eingangsrechnungMsgLabel.Text = "Keine Daten!";
                this.eingangsrechnungMsgLabel.ForeColor = Color.Red;
                this.eingangsrechnungMsgLabel.Show();
                return;
            }

            // save Eingangsrechnung
            int eingangsrechnungsID = this.SaveEingangsrechnung();

            // check for errors while saving Eingangsrechnung to database
            if (eingangsrechnungsID == -1) { return; }

            // get all Buchungszeilen out of BindingSource
            List<BuchungszeilenTable> list = new List<BuchungszeilenTable>();
            for (int i = 0; i < this.buchungszeilenBindingSource.Count; i++)
            {
                list.Add((BuchungszeilenTable)this.buchungszeilenBindingSource.List[i]);
            }

            // save all Buchungszeilen
            RechnungsManager manager = new RechnungsManager();
            foreach (BuchungszeilenTable table in list)
            {
                try
                {
                    manager.SaveBuchungszeile(table, eingangsrechnungsID);
                }
                catch (InvalidInputException ex)
                {
                    this.eingangsrechnungMsgLabel.Text = ex.Message;
                    this.eingangsrechnungMsgLabel.ForeColor = Color.Red;
                    this.eingangsrechnungMsgLabel.Show();
                    return;
                }
                catch (SQLiteException ex)
                {
                    this.eingangsrechnungMsgLabel.Text = ex.Message;
                    this.eingangsrechnungMsgLabel.ForeColor = Color.Red;
                    this.eingangsrechnungMsgLabel.Show();
                    return;
                }
            }

            this.ResetEingangsrechnung(null, null);
        }

        // save a new Eingangsrechnung
        private int SaveEingangsrechnung()
        {
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
                this.eingangsrechnungMsgLabel.ForeColor = Color.Red;
                this.eingangsrechnungMsgLabel.Show();
                return -1;
            }
            catch (SQLiteException e)
            {
                this.logger.Log(Logger.Level.Error, e.Message);
                this.eingangsrechnungMsgLabel.Text = e.Message;
                this.eingangsrechnungMsgLabel.ForeColor = Color.Red;
                this.eingangsrechnungMsgLabel.Show();
                return -1;
            }

            this.eingangsrechnungMsgLabel.Text += "\nEingangsrechnung gespeichert.\n";

            return rechnungsid;
        }

        /// <summary>
        /// Loads Zeitaufzeichnungen to Datagridview and show Sum of remaining bills
        /// </summary>
        /// <param name="sender">The sending ComboBox</param>
        /// <param name="e">The EventArgs</param>
        private void BindFromExistingZeitaufzeichnungen(object sender, EventArgs e)
        {
            // only if a value is selected
            if (this.projekteComboBox.SelectedIndex > 0)
            {
                List<ZeitaufzeichnungTable> results = new List<ZeitaufzeichnungTable>();
                
                // get projectID
                int pID = GlobalActions.GetIdFromCombobox(this.projekteComboBox.SelectedValue.ToString(), this.eingangsrechnungMsgLabel);
                this.logger.Log(Logger.Level.Info, "Starts searching for Zeitauffassungen with project id " + pID);

                ZeiterfassungsManager loader = new ZeiterfassungsManager();

                try
                {
                    results = loader.LoadZeiterfassung(pID, this.eingangsrechnungMsgLabel);
                }
                catch(SQLiteException ex)
                {
                    this.logger.Log(Logger.Level.Error, ex.Message);
                    this.eingangsrechnungMsgLabel.Text = ex.Message;
                    this.eingangsrechnungMsgLabel.ForeColor = Color.Red;
                    this.eingangsrechnungMsgLabel.Show();
                }

                if (results.Count > 0)
                {
                    // bind to datagridview
                    this.ausgangsrechnungBindingSource.DataSource = results;

                    // calculate sum and set result to textbox
                    int sum = 0;
                    foreach (ZeitaufzeichnungTable aufzeichnung in results)
                    {
                        sum += aufzeichnung.Stunden * aufzeichnung.Stundensatz;
                    }

                    this.unpaidBalanceTextBox.Text = sum.ToString();
                }
            }
        }

<<<<<<< HEAD
        private void ShowUmsaetze(object sender, EventArgs e) 
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.AddPage();
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont header = new XFont("Calibri", 20, XFontStyle.Bold);
            XFont columHeader = new XFont("Calibri", 10, XFontStyle.Bold);
            XFont Text = new XFont("Calibri", 10);
            
            gfx.DrawString("Umsätze", header, XBrushes.Black,new XRect(0, 0, page.Width, page.Height),XStringFormat.TopCenter);
            

            string filename = "HelloWorld.pdf";
            document.Save(filename);
            Process.Start(filename);

        }

        private void PrintUmsaetze(object sender, EventArgs e)
        {
            MessageBox.Show("not yet implemented - Print");
        }

        private void ShowKundenRechnung(object sender, EventArgs e) 
        {
            MessageBox.Show("not yet implemented - Show");
        }

        private void PrintKundenRechnung(object sender, EventArgs e)
        {
            MessageBox.Show("not yet implemented - Print");
        }
       
=======
        /// <summary>
        /// Creates a new Ausgangsrechnung with the provided parameters
        /// </summary>
        /// <param name="sender">The sending button</param>
        /// <param name="e">The EventArgs</param>
        private void CreateAusgangsrechnung(object sender, EventArgs e)
        {
            // reset message label
            this.ausgangsrechnungMsgLabel.Visible = false;
            this.ausgangsrechnungMsgLabel.Text = string.Empty;

            // check if a projekt is selected
            if (this.projekteComboBox.SelectedIndex < 1)
            {
                this.ausgangsrechnungMsgLabel.Visible = true;
                this.ausgangsrechnungMsgLabel.Text = "Kein Projekt ausgewählt";
                this.ausgangsrechnungMsgLabel.ForeColor = Color.Red;
                return;
            }
            
            AusgangsrechnungTable table = new AusgangsrechnungTable();

            // Get values
            int projektID = GlobalActions.GetIdFromCombobox(this.projekteComboBox.SelectedValue.ToString(), this.ausgangsrechnungMsgLabel);
            string unpaidBalanceString = this.unpaidBalanceTextBox.Text;
            string rechnungstitelString = this.rechnungstitelTextBox.Text;

            double unpaidBalance;

            // Validate values
            IRule posintval = new PositiveIntValidator();
            IRule posdoubval = new PositiveDoubleValidator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule slv = new StringLength150Validator();

            DataBindingFramework.BindFromInt(projektID.ToString(), "ProjektID", this.ausgangsrechnungMsgLabel, false, posintval);
            unpaidBalance = DataBindingFramework.BindFromDouble(unpaidBalanceString, "Offener Betrag", this.ausgangsrechnungMsgLabel, false, posdoubval);
            DataBindingFramework.BindFromString(rechnungstitelString, "Rechnungstitel", this.ausgangsrechnungMsgLabel, false, lnhsv, slv);

            // return if errors occured
            if (this.ausgangsrechnungMsgLabel.Visible)
            {
                return;
            }

            // no errors, send values to business layer
            RechnungsManager saver = new RechnungsManager();

            try
            {
                saver.CreateAusgangsrechnung(projektID, unpaidBalance, rechnungstitelString);
            }
            catch (InvalidInputException)
            {
                this.logger.Log(Logger.Level.Error, "The business layer returned the provided values for saving a new Ausgangsrechnung with an error.");
            }
            catch (SQLiteException ex)
            {
                this.logger.Log(Logger.Level.Error, "A serious problem with the database occured while trying to save a new Ausgangsrechnung.");
                this.logger.Log(Logger.Level.Error, ex.Message);
                this.ausgangsrechnungMsgLabel.Text = ex.Message;
                this.ausgangsrechnungMsgLabel.ForeColor = Color.Red;
                this.ausgangsrechnungMsgLabel.Show();
            }

            // show success message label (only if saving has been successful)
            if (!this.ausgangsrechnungMsgLabel.Visible)
            {
                GlobalActions.ShowSuccessLabel(this.ausgangsrechnungMsgLabel);
            }
        }
>>>>>>> d0ba2fa98147878c484d759aac9fb4dd93916ca7
    }
}
