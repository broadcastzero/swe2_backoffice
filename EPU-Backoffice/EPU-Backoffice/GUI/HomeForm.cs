// -----------------------------------------------------------------------
// <copyright file="HomeForm.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Gui
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SQLite;
    using System.Drawing;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;
    using DatabindingFramework;
    using EPUBackoffice.BL;
    using EPUBackoffice.Dal.Tables;
    using EPUBackoffice.UserExceptions;
    using Logger;
    using Rulemanager;

    /// <summary>
    /// The standard home screen of the application.
    /// </summary>
    public partial class HomeForm : Form
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Constructor, only calls InitializeComponent()
        /// </summary>
        public HomeForm()
        {
            InitializeComponent();
            // set win title and label within "Home" subwindow to the currently opened database
            this.homeCurrentDBLabel.Text = ConfigFileManager.DbName;
            this.Text += " - ";
            this.Text += ConfigFileManager.DbName;
        }

        /* Event handling for buttons */
        private void SelectHomeTab(object sender, EventArgs e)
        {
            mainTab.SelectTab("homeTab");
        }

        private void SelectKundenKontakteTab(object sender, EventArgs e)
        {
            mainTab.SelectTab("kundenKontakteTab");
            this.kundeNeuMsgLabel.Hide();
        }

        private void SelectRechnungsverwaltungTab(object sender, EventArgs e)
        {
            mainTab.SelectTab("rechnungsTab");  
        }

        private void SelectAngeboteTab(object sender, EventArgs e)
        {
            this.ResetCreateAngebotFields(null, null);
            this.createAngebotMsgLabel.Hide();
            mainTab.SelectTab("angeboteTab");  
        }

        private void SelectProjektverwaltungTab(object sender, EventArgs e)
        {
            this.ResetAllWithinProjects(sender, e);

            mainTab.SelectTab("projektTab");
        }

        private void SelectZeiterfassungTab(object sender, EventArgs e)
        {
            mainTab.SelectTab("zeitTab");  
        }

        private void SelectReportsTab(object sender, EventArgs e)
        {
            mainTab.SelectTab("reportTab");  
        }

        private void ShowExitMessageBox(object sender, EventArgs e)
        {
            string message = "Wollen Sie wirklich beenden?";
            string caption = "Beenden";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }      

        /// <summary>
        /// Catches the event, when the user clicks on the "open existing database"-button.
        /// </summary>
        /// <param name="sender">The calling object</param>
        /// <param name="e">Additional event arguments</param>
        private void ShowOpenNewDbDialogue(object sender, EventArgs e)
        {
            //Same code already written in DBNotFoundForm -> just call this method with HomeScreen as sender
            DataBaseOpener db_opener = new DataBaseOpener();
            db_opener.OpenExistingDatabase(sender, e, this);

            // Update title bar and text within "Home" subwindow
            this.Text = "EPU Backoffice 1.0 - ";
            this.Text += ConfigFileManager.DbName;
            this.homeCurrentDBLabel.Text = ConfigFileManager.DbName;
        }

        private void KillProcess(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        // Show success messages in an existing label
        private void ShowSuccessLabel(Label l)
        {
            l.Text = "Erfolgreich eingetragen.";
            l.ForeColor = Color.Green;
            l.Show();
        }

        /// <summary>
        /// Clear textblocks in which a new Kunde or Kontakt can be created
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">Event args</param>
        private void ResetNewKundeTextBlocks(object sender, EventArgs e)
        {
            this.createKundeVornameTextBlock.Clear();
            this.createKundeNachnameTextBlock.Clear();
        }

        /// <summary>
        /// Get values of GUI elements and send them to the business layer, they shall be stored in the database.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs</param>
        private void CreateKundeOrKontakt(object sender, EventArgs e)
        {
            // hide error label
            this.kundeNeuMsgLabel.Hide();
            this.kundeNeuMsgLabel.Text = string.Empty;

            KundeKontaktTable k = new KundeKontaktTable();
            
            // Bind data
            k.Vorname = DataBindingFramework.BindFromString(this.createKundeVornameTextBlock.Text, "Vorname", this.kundeNeuMsgLabel, Rules.IsAndCanBeNull, Rules.LettersHyphen, Rules.StringLength150);
            k.NachnameFirmenname = DataBindingFramework.BindFromString(this.createKundeNachnameTextBlock.Text, "Nachname/Firmenname", this.kundeNeuMsgLabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);
            k.Type = this.createKontaktRadioButton.Checked; // false - Kunde, true - Kontakt

            // if no errors, send to business layer and show success message
            if (!this.kundeNeuMsgLabel.Visible)
            {
                KundenKontakteSaver saver = new KundenKontakteSaver();
                saver.SaveNewKundeKontakt(k, this.kundeNeuMsgLabel);

                this.ShowSuccessLabel(this.kundeNeuMsgLabel);                
            }
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
        /// Get values of GUI elements and send them to Business Layer to store them in the database.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The EventArgs</param>
        private void SaveNewProject(object sender, EventArgs e)
        {
            this.ResetProjektNeuMessages();

            //TODO: add logic
            ProjektManager creator = new ProjektManager();

            // Get AngebotsID
            string angebotstring = this.projektErstellenAngebotCombobox.SelectedValue.ToString();
            string angebotID = angebotstring.Substring(0, angebotstring.IndexOf(':'));

            // Create Projekt
            creator.Create(this.projektNeuProjekttitelTextbox.Text, angebotID, projektNeuStartdatumDatepicker.Value);

            //success logging
            this.projektNeuSuccessLabel.Show();
            this.ResetNewProjectTextBlocks();
        }

        /// <summary>
        /// Hides error/success labels and resets input fields within Project tab
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The EventArgs</param>
        private void ResetAllWithinProjects(object sender, EventArgs e)
        {
            this.ResetProjektNeuMessages();
            this.ResetNewProjectTextBlocks();
        }

        /// <summary>
        /// Resets input fields within Project tab
        /// </summary>
        private void ResetNewProjectTextBlocks()
        {
            this.projektNeuProjekttitelTextbox.Clear();
            this.projektErstellenAngebotCombobox.ResetText();
            this.projektNeuStartdatumDatepicker.ResetText();
        }

        /// <summary>
        /// Resets error/succes labels within Project tab
        /// </summary>
        private void ResetProjektNeuMessages()
        {
            this.projektNeuErrorLabel.Hide();
            this.projektNeuSuccessLabel.Hide();
        }

        private void LoadHomeForm(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gets Kunden or Kontakte out of the database (over the business layer, which checks for valid input)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchKundenOrKontakte(object sender, EventArgs e)
        {
            // hide error message
            this.searchKundeErrorLabel.Hide();
            this.searchKundeErrorLabel.Text = string.Empty;

            KundeKontaktTable k = new KundeKontaktTable();
            k.Vorname = DataBindingFramework.BindFromString(this.searchKundeVornameTextBlock.Text, "Vorname", this.searchKundeErrorLabel, Rules.IsAndCanBeNull, Rules.LettersHyphen, Rules.StringLength150);
            k.NachnameFirmenname = DataBindingFramework.BindFromString(this.searchKundeNachnameTextBlock.Text, "Nachname", this.searchKundeErrorLabel, Rules.IsAndCanBeNull, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);
            k.Type = this.searchKontaktRadioButton.Checked; // False...Kunde, true...Kontakt

            KundenKontakteLoader loader = new KundenKontakteLoader();

            // only if binding had no errors
            if (!this.searchKundeErrorLabel.Visible)
            {
                List<KundeKontaktTable> results;

                results = loader.LoadKundenKontakte(k, this.searchKundeErrorLabel);
                this.kundenSuchenBindingSource.DataSource = results;
            }

            this.BindToKundenSearchLabels(this.kundenSearchDataGridView, null);
        }

        /// <summary>
        /// when user clicks on a row within the search results, write data to labels, so that user can change the values
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The DataGridViewCellEventArgs</param> 
        private void BindToKundenSearchLabels(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowID = e == null ? 0 : e.RowIndex;

            // if there are results
            if (this.kundenSuchenBindingSource.Count > 0 && selectedRowID >= 0)
            {
                KundeKontaktTable k = (KundeKontaktTable)this.kundenSuchenBindingSource.List[selectedRowID];

                this.searchKundeVornameTextBlock.Text = k.Vorname;
                this.searchKundeNachnameTextBlock.Text = k.NachnameFirmenname;
            }
            // clear textbox if there are no results
            else
            { 
                this.searchKundeVornameTextBlock.Text = string.Empty;
                this.searchKundeNachnameTextBlock.Text = string.Empty;
            }
        }

        /// <summary>
        /// After changing an entry, also display changes within DataGridView
        /// </summary>
        /// <param name="action">Shall row be updated or deleted?</param>
        /// <param name="row">The selected row</param>
        /// <param name="firstname">The new first name</param>
        /// <param name="lastname">The new last name</param>
        private void BindFromKundenSearchTextBlock(string action, int row, string firstname, string lastname)
        {
            if (action == "changeKundeButton")
            {
                this.kundenSearchDataGridView.Rows[row].Cells[1].Value = firstname;
                this.kundenSearchDataGridView.Rows[row].Cells[2].Value = lastname;
            }
            else if (action == "deleteKundeButton")
            {
                // update datagridview - clear textblocks first, so that not only the same results are displayed
                this.searchKundeVornameTextBlock.Clear();
                this.searchKundeNachnameTextBlock.Clear();
                this.SearchKundenOrKontakte(null, null);
            }
        }

        /// <summary>
        /// Changes information of an existing Kunde
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The params</param>
        private void ChangeKundeOrKontakt(object sender, EventArgs e)
        {
            this.searchKundeErrorLabel.Hide();
            this.searchKundeErrorLabel.Text = string.Empty;

            // if there are results
            if (this.kundenSuchenBindingSource.Count > 0)
            {
                int selectedRow = this.kundenSearchDataGridView.SelectedCells[0].RowIndex;                //int selectedRow = kundenSearchDataGridView.SelectedCells[0].OwningRow.Index;
                KundeKontaktTable k = (KundeKontaktTable)this.kundenSuchenBindingSource.List[selectedRow];//this.kundenSearchDataGridView.SelectedRows[0].Index];

                // get firstname and lastname from textbox
                string firstname = DataBindingFramework.BindFromString(this.searchKundeVornameTextBlock.Text, "Vorname", this.searchKundeErrorLabel, Rules.IsAndCanBeNull, Rules.LettersHyphen, Rules.StringLength150);
                string lastname = DataBindingFramework.BindFromString(this.searchKundeNachnameTextBlock.Text, "Nachname", this.searchKundeErrorLabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);

                // in case of errors
                if (this.searchKundeErrorLabel.Visible)
                {
                    return;
                }

                KundenKontakteChanger changer = new KundenKontakteChanger();

                string buttonName="";
                if (sender is Button)
                {
                    buttonName = ((Button)sender).Name;
                }

                try
                {
                    if (buttonName == "changeKundeButton")
                    {
                        // if there are no changes, do nothing
                        if (firstname == k.Vorname && lastname == k.NachnameFirmenname)
                        {
                            this.logger.Log(Logger.Level.Warning, "User requested to change an item which does not need to be changed.");
                            return; 
                        }
                        else
                        {
                            // Change Kunde/Kontakt
                            k.Vorname = firstname;
                            k.NachnameFirmenname = lastname;
                            changer.Change(k, this.searchKundeErrorLabel);

                            // success logging
                            this.logger.Log(Logger.Level.Info, "Kunde/Kontakt with the ID " + k.ID + "has successfully been changed.");
                        }
                    }
                    else if (buttonName == "deleteKundeButton")
                    {
                        changer.Delete(k, this.searchKundeErrorLabel);
                    }
                }
                catch (InvalidInputException ex)
                {
                    this.searchKundeErrorLabel.Text = ex.Message;
                    this.searchKundeErrorLabel.Show();
                }

                // update displayed rows
                this.BindFromKundenSearchTextBlock(buttonName, selectedRow, firstname, lastname);
                this.logger.Log(Logger.Level.Info, "Kunden search datagridview has been updated.");

                // show success messages
                this.ShowSuccessLabel(this.searchKundeErrorLabel);
            }
        }

        // reset everything within Kunden/Kontakte search
        private void ResetSearchKunden(object sender, EventArgs e)
        {
            this.searchKundeVornameTextBlock.Clear();
            this.searchKundeNachnameTextBlock.Clear();
            this.searchKundeErrorLabel.Hide();

            this.SearchKundenOrKontakte(null, null);
        }

        /// <summary>
        /// Gets all existing Kunden from the Database and adds them to the existingKundenComboBox
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void BindFromExistingKunden(object sender, EventArgs e)
        {
            List<KundeKontaktTable> results;
            List<string> listItems = new List<string>();
            KundenKontakteLoader loader = new KundenKontakteLoader();

            // Create empty Kunden object with type "false"
            KundeKontaktTable k = new KundeKontaktTable();
            k.Vorname = string.Empty;
            k.NachnameFirmenname = string.Empty;
            k.Type = false;

            // only get Kunden
            results = loader.LoadKundenKontakte(k, this.searchKundeErrorLabel);

            if(results.Count != 0)
            {
                foreach (KundeKontaktTable kunde in results)
                {
                    string entry = kunde.ID + ": " + kunde.Vorname + " - " + kunde.NachnameFirmenname;
                    listItems.Add(entry);
                }
            }

            (sender as ComboBox).DataSource = listItems;
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
                // no Kunde chosen -> show error label
                if (this.createAngebotExistingKundeComboBox.SelectedIndex < 0)
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

            // Create Angebot
            this.logger.Log(Logger.Level.Info, "Start creating new Angebot...");

            AngebotTable angebot = new AngebotTable();
            angebot.Angebotssumme = DataBindingFramework.BindFromDouble(this.createAngebotAngebotssummeTextBox.Text, "Angebotssumme", this.createAngebotMsgLabel, Rules.PositiveDouble);
            angebot.Umsetzungschance = DataBindingFramework.BindFromInt(this.createAngebotUmsetzungswahrscheinlichkeitTextBox.Text, "Umsetzungschance", this.createAngebotMsgLabel, Rules.PerCent);
            angebot.Angebotsdauer = DataBindingFramework.BindFromString(this.angebotValidUntilDateTimePicker.Value.ToShortDateString(), "GültigBis", this.createAngebotMsgLabel, Rules.Date);
            angebot.Beschreibung = DataBindingFramework.BindFromString(this.createAngebotDescriptionTextBox.Text, "Beschreibung", this.createAngebotMsgLabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);
            angebot.KundenID = DataBindingFramework.BindFromInt(k.ID.ToString(), "kundenID", this.createAngebotMsgLabel, Rules.PositiveInt);
            angebot.Erstellungsdatum = DateTime.Now.ToShortDateString();

            // in case of errors
            if (createAngebotMsgLabel.Visible)
            {
                this.logger.Log(Logger.Level.Error, "No angebot has been saved because of invalid inputs.");
                createAngebotMsgLabel.ForeColor = Color.Red;
                createAngebotMsgLabel.Show();
                return;
            }

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
        /// Start searching for Angebote and pass arguments to business layer
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The params</param>
        private void SearchAngebote(object sender, EventArgs e)
        {
            AngebotManager manager = new AngebotManager();
            List<AngebotTable> results;
            results = manager.Load(this.angebotSuchenVornameTextbox.Text, this.angebotSuchenNachnameTextbox.Text, this.angebotSuchenVonDatepicker.Value, this.angebotSuchenBisDatepicker.Value);
            // TODO: catch InvalidInputException & maybe SQLite-exception

            this.AngeboteSuchenDataGridView.DataSource = results;
        }

        /// <summary>
        /// Get existing Angebote and bind the result to the calling ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BindFromExistingAngebote(object sender, EventArgs e)
        {
            AngebotManager loader = new AngebotManager();
            DateTime from = new DateTime(2012, 1, 1);
            DateTime until = new DateTime(2100, 1, 1);

            List<AngebotTable> results = loader.Load(null, null, from, until);

            // Create result strings which shall be displayed in ComboBox
            List<string> resultStrings = new List<string>();
            foreach(AngebotTable angebot in results)
            {
                resultStrings.Add(angebot.ID + ": " + angebot.Beschreibung);
            }

            if (results.Count > 0)
            {
                (sender as ComboBox).DataSource = resultStrings;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void angebotErstellenTab_Click(object sender, EventArgs e)
        {

        }

        private void kundenSearchDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridViewHeaderClick(object sender, DataGridViewCellMouseEventArgs e)
        {
             //Catch clicks on header of datagridview
        }
    }
}