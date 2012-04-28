using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPUBackofficePanels.Gui.Panel
{
    public partial class AngeboteTab : UserControl
    {
        public AngeboteTab()
        {
            InitializeComponent();
        }

        private void ShowNKundeButton(object sender, EventArgs e)
        {
            angebotErstellenBKundeButton.Hide();
            angebotErstellenNKundeButton.Show();
            angebotErstellenSubTab.SelectTab("angebotErstellenNKTab");
        }

        private void ShowBKundeButton(object sender, EventArgs e)
        {
            angebotErstellenBKundeButton.Show();
            angebotErstellenNKundeButton.Hide();
            angebotErstellenSubTab.SelectTab("angebotErstellenBKTab");
        }

        /// <summary>
        /// Reads values of concerning fields and asks business layer to create a new Angebot with the provided parameters
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event params</param>
        private void CreateNewAngebot(object sender, EventArgs e)
        {
            /*// reset error/success labels
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
                    k.ID = DataBindingFramework.BindFromInt(kundenID, "KundenID", this.createAngebotMsgLabel, Rules.PositiveInt);

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
                k.Vorname = DataBindingFramework.BindFromString(this.createAngebotNewKundeVnTextBox.Text, "Vorname", this.createAngebotMsgLabel, Rules.IsAndCanBeNull, Rules.LettersHyphen, Rules.StringLength150);
                k.NachnameFirmenname = DataBindingFramework.BindFromString(this.createAngebotNewKundeNnTextBox.Text, "Nachname", this.createAngebotMsgLabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);
                k.Type = false; // Kunde

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

            AngebotTable angebot = new AngebotTable();
            angebot.Angebotssumme = DataBindingFramework.BindFromDouble(this.createAngebotAngebotssummeTextBox.Text, "Angebotssumme", this.createAngebotMsgLabel, Rules.PositiveDouble);
            angebot.Umsetzungschance = DataBindingFramework.BindFromInt(this.createAngebotUmsetzungswahrscheinlichkeitTextBox.Text, "Umsetzungschance", this.createAngebotMsgLabel, Rules.PerCent);
            angebot.Angebotsdauer = DataBindingFramework.BindFromString(this.angebotValidUntilDateTimePicker.Value.ToShortDateString(), "GültigBis", this.createAngebotMsgLabel, Rules.Date);
            angebot.Beschreibung = DataBindingFramework.BindFromString(this.createAngebotDescriptionTextBox.Text, "Beschreibung", this.createAngebotMsgLabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);
            angebot.KundenID = DataBindingFramework.BindFromInt(k.ID.ToString(), "kundenID", this.createAngebotMsgLabel, Rules.PositiveInt);
            angebot.Erstellungsdatum = DateTime.Now.ToShortDateString();

            // in case of errors in Databinding
            if (createAngebotMsgLabel.Visible)
            {
                this.logger.Log(Logger.Level.Error, "No angebot has been saved because of invalid inputs.");
                createAngebotMsgLabel.ForeColor = Color.Red;
                createAngebotMsgLabel.Show();
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
            }*/
        }
    }
}
