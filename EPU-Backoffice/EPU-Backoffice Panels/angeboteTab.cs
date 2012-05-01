// -----------------------------------------------------------------------
// <copyright file="angeboteTab.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Data.SQLite;
    using System.Text;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.DatabindingFramework;
    using EPU_Backoffice_Panels.LoggingFramework;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;

    public partial class angeboteTab : UserControl
    {
        private Logger logger = Logger.Instance;

        public angeboteTab()
        {
            InitializeComponent();
        }

        // Bind to drop down combobox
        private void createAngebotExistingKundeComboBox_DropDown(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingKundenToComboBox(sender, e);
        }

        /// <summary>
        /// Switch between new Kunde and existing Kunde within create Angebot
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void SwitchSelectKundenTabs(object sender, EventArgs e)
        {
            if (this.angebotErstellenSubTab.SelectedTab == this.angebotErstellenNKTab)
            {
                this.angebotErstellenSwitchKundeButton.Text = "Bestehender Kunde";
                this.angebotErstellenSubTab.SelectedTab = this.angebotErstellenBKTab;
            }
            else
            {
                this.angebotErstellenSwitchKundeButton.Text = "Neuer Kunde";
                this.angebotErstellenSubTab.SelectedTab = this.angebotErstellenNKTab;
            }
        }

        /// <summary>
        /// Clears input fields in createAngebot
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void ResetCreateAngebotFields(object sender, EventArgs e)
        {
            this.createAngebotNewKundeVnTextBox.Clear();
            this.createAngebotNewKundeNnTextBox.Clear();
            this.createAngebotAngebotssummeTextBox.Clear();
            this.createAngebotUmsetzungswahrscheinlichkeitTextBox.Clear();
            this.createAngebotDescriptionTextBox.Clear();

            this.createAngebotMsgLabel.Hide();
        }

        /// <summary>
        /// Reads values of concerning fields and asks business layer to create a new Angebot with the provided parameters
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event params</param>
        private void CreateNewAngebot(object sender, EventArgs e)
        {
            // reset error/success labels
            this.createAngebotMsgLabel.Hide();
            this.createAngebotMsgLabel.Text = string.Empty;

            // existing or newly to-be-created
            bool createKunde = false;
            string kundenID = null;

            // Table for the Kontakt
            KundeKontaktTable k = new KundeKontaktTable();

            // new Kunde
            if (this.angebotErstellenSubTab.SelectedTab == this.angebotErstellenSubTab.TabPages[0])
            {
                createKunde = true;
            }
            // existing Kunde
            else
            {
                // no Kunde chosen or first element chosen (which is empty) -> show error label
                if (this.createAngebotExistingKundeComboBox.SelectedIndex <= 0)
                {
                    this.createAngebotMsgLabel.Text = "Error: kein Kunde ausgewählt";
                    this.createAngebotMsgLabel.ForeColor = Color.Red;
                    this.createAngebotMsgLabel.Show();
                    return; // skip rest of function
                }
                // Kunde chosen - get ID out of ComboBox
                else
                {
                    kundenID = this.createAngebotExistingKundeComboBox.SelectedItem.ToString();
                    kundenID = kundenID.Substring(0, kundenID.IndexOf(':'));

                    IRule posint = new PositiveIntValidator();
                    k.ID = DataBindingFramework.BindFromInt(kundenID, "KundenID", this.createAngebotMsgLabel, false, posint);

                    // Check for errors while databinding
                    if (posint.HasErrors)
                    {
                        this.logger.Log(Logger.Level.Error, k.ID + " is an invalid Kunden ID");
                        return; 
                    }

                    // get Kunde table out of Database
                    KundenKontakteLoader loader = new KundenKontakteLoader();
                    List<KundeKontaktTable> results = loader.LoadKundenKontakte(k.ID, false);

                    // there must be exactly one result, for ID is unique!
                    if (results.Count != 1)
                    {
                        this.logger.Log(Logger.Level.Error, "More than one Kunde returned - impossible, because ID is unique!");
                        this.createAngebotMsgLabel.Text = "Error: Datenbank inkonsistent!";
                        this.createAngebotMsgLabel.Visible = true;
                        return; // skip rest of function
                    }

                    // everything went fine
                    k = results[0];
                }
            }

            // Create new Kunde, if requested
            if (createKunde)
            {
                // define Rules
                IRule lhv = new LettersHyphenValidator();
                IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
                IRule slv = new StringLength150Validator();

                // validate data
                k.Vorname = DataBindingFramework.BindFromString(this.createAngebotNewKundeVnTextBox.Text, "Vorname", this.createAngebotMsgLabel, true, lhv, slv);
                k.NachnameFirmenname = DataBindingFramework.BindFromString(this.createAngebotNewKundeNnTextBox.Text, "Nachname", this.createAngebotMsgLabel, false, lnhsv, slv);
                k.Type = false; // Kunde

                if (lhv.HasErrors || lnhsv.HasErrors || slv.HasErrors)
                {
                    this.logger.Log(Logger.Level.Error, "Invalid signs within create Angebot / create Kunde");
                    return; 
                }

                KundenKontakteSaver saver = new KundenKontakteSaver();

                try
                {
                    k.ID = saver.SaveNewKundeKontakt(k, this.createAngebotMsgLabel);
                }
                catch (InvalidInputException ex)
                {
                    this.logger.Log(Logger.Level.Error, ex.Message + ex.StackTrace);
                    this.createAngebotMsgLabel.Text = "Error: Kundenfelder ungültig!";
                    this.createAngebotMsgLabel.Visible = true;
                    return;
                }
                catch (SQLiteException ex)
                {
                    this.logger.Log(Logger.Level.Error, ex.Message + ex.StackTrace);
                    this.createAngebotMsgLabel.Text = "Error: Datenbankproblem!";
                    this.createAngebotMsgLabel.Visible = true;
                    return;
                }

                this.createAngebotMsgLabel.Text = "Kunde wurde gespeichert.";
            }

            // Create Angebot business object
            this.logger.Log(Logger.Level.Info, "Start creating new Angebot...");

            // define Rules
            IRule pdv2 = new PositiveDoubleValidator();
            IRule pcv2 = new PercentValidator();
            IRule dv2 = new DateValidator();
            IRule lnhsv2 = new LettersHyphenValidator();
            IRule slv2 = new StringLength150Validator();
            IRule piv2 = new PositiveIntValidator();

            AngebotTable angebot = new AngebotTable();
            angebot.Angebotssumme = DataBindingFramework.BindFromDouble(this.createAngebotAngebotssummeTextBox.Text, "Angebotssumme", this.createAngebotMsgLabel, false, pdv2);
            angebot.Umsetzungschance = DataBindingFramework.BindFromInt(this.createAngebotUmsetzungswahrscheinlichkeitTextBox.Text, "Umsetzungschance", this.createAngebotMsgLabel, false, pcv2);
            angebot.Angebotsdauer = DataBindingFramework.BindFromString(this.angebotValidUntilDateTimePicker.Value.ToShortDateString(), "GültigBis", this.createAngebotMsgLabel, false, dv2);
            angebot.Beschreibung = DataBindingFramework.BindFromString(this.createAngebotDescriptionTextBox.Text, "Beschreibung", this.createAngebotMsgLabel, false, lnhsv2, slv2);
            angebot.KundenID = DataBindingFramework.BindFromInt(k.ID.ToString(), "kundenID", this.createAngebotMsgLabel, false, piv2);
            angebot.Erstellungsdatum = DateTime.Now.ToShortDateString();

            // in case of errors in Databinding
            if (createAngebotMsgLabel.Visible)
            {
                this.logger.Log(Logger.Level.Error, "No angebot has been saved because of invalid inputs.");
                //createAngebotMsgLabel.ForeColor = Color.Red;
                //createAngebotMsgLabel.Show();
                return;
            }

            // send Angebot object to database
            try
            {
                AngebotManager manager = new AngebotManager();
                manager.Create(angebot, createAngebotMsgLabel);
            }
            catch (InvalidInputException ex)
            {
                this.logger.Log(Logger.Level.Error, ex.Message + ex.StackTrace);
                this.createAngebotMsgLabel.Text += "\nError: " + ex.Message;
                this.createAngebotMsgLabel.Show();
            }
            catch (SQLiteException ex)
            {
                this.logger.Log(Logger.Level.Error, ex.Message + ex.StackTrace);
                this.createAngebotMsgLabel.Text += "\nError: " + ex.Message;
                this.createAngebotMsgLabel.Show();
            }

            // show success message, if no error has been thrown
            if (!createAngebotMsgLabel.Visible)
            {
                this.createAngebotMsgLabel.Text += "\nAngebot wurde gespeichert.";
                this.createAngebotMsgLabel.ForeColor = Color.Green;
                this.createAngebotMsgLabel.Show();
            }
        }

        /// <summary>
        /// Start searching for Angebote and pass arguments to business layer
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The params</param>
        private void SearchAngebote(object sender, EventArgs e)
        {
            // hide Messagelabel
            this.angebotSuchenMsgLabel.Hide();

            // get selected KundenID
            // force searching for existing Kunden, if Kunde has not dropped down the ComboBox (would throw Exception otherwise)
            if (this.angebotSuchenKundeComboBox.SelectedIndex < 0)
            {
                GlobalActions.BindFromExistingKundenToComboBox(this.angebotSuchenKundeComboBox, null);
            }

            // get kundenID out of ComboBox
            string kundenID = this.angebotSuchenKundeComboBox.SelectedItem.ToString();
            int id = -1;

            // if no Kunde has been chosen, set kundenID to -1, which indicates, that it shall not be searched for a certain Kunde
            if (kundenID != string.Empty)
            {
                kundenID = kundenID.Substring(0, kundenID.IndexOf(':'));

                IRule posintval = new PositiveIntValidator();
                id = DataBindingFramework.BindFromInt(kundenID, "Kunden ID", this.angebotSuchenMsgLabel, false, posintval);

                if (posintval.HasErrors)
                {
                    throw new InvalidInputException("Problem with getting KundenID. Unknown hard error.");
                }
            }

            // get Angebot in SDS format: 6/1/2009
            DateTime from = this.angebotSuchenVonDatepicker.Value;
            DateTime until = this.angebotSuchenBisDatepicker.Value;

            AngebotManager manager = new AngebotManager();
            List<AngebotTable> results = new List<AngebotTable>();
            
            try
            {
                 results = manager.Load(id, from, until, this.angebotSuchenMsgLabel);
            }
            catch (DataBaseException ex)
            {
                this.logger.Log(Logger.Level.Error, "A serious problem with the database occured. Program will be exited. " + ex.Message + ex.StackTrace);
                Application.Exit();
            }

            // add results to binding source
            this.angebotSuchenBindingSource.DataSource = results;
        }
    }
}
