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
    using System.Drawing;
    using System.Diagnostics;
    using System.Text;
    using System.Windows.Forms;
    using EPUBackoffice.BL;
    using EPUBackoffice.Dal.Tables;
    using EPUBackoffice.UserExceptions;
    using Logger;

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
            this.HideKundeNeuMessages();
        }

        private void SelectRechnungsverwaltungTab(object sender, EventArgs e)
        {
            mainTab.SelectTab("rechnungsTab");  
        }

        private void SelectAngeboteTab(object sender, EventArgs e)
        {
            this.ResetCreateAngebotFields(null, null);
            this.ResetCreateAngebotLabels(null, null);
            mainTab.SelectTab("angeboteTab");  
        }

        private void SelectProjektverwaltungTab(object sender, EventArgs e)
        {
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

        /// <summary>
        /// Clear textblocks in which a new Kunde or Kontakt can be created
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">Event args</param>
        private void ResetNewKundeTextBlocks(object sender, EventArgs e)
        {
            this.createKundeVornameTextBlock.Clear();
            this.createKundeNachnameTextBlock.Clear();
            this.HideKundeNeuMessages();
        }

        /// <summary>
        /// Removes all success or error messages from panel "add Kunde/Kontakt"
        /// </summary>
        public void HideKundeNeuMessages() 
        {
            this.kundeNeuSuccessLabel.Hide();
            this.kundenNeuErrGeneralLabel.Hide();
            this.searchKundeSuccessLabel.Hide();
            this.searchKundeErrorLabel.Hide();
        }

        /// <summary>
        /// Get values of GUI elements and send them to the business layer, they shall be stored in the database.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs</param>
        private void CreateKundeOrKontakt(object sender, EventArgs e)
        {
            // is set to false in case of error
            bool saved = true;

            KundenKontakteSaver validator = new KundenKontakteSaver();
            // bool type: false -> Kunde, true -> Kontakt
            bool type = this.createKontaktRadioButton.Checked;
            string s_type = type == false ? "Kunde" : "Kontakt";

            try
            {
                validator.SaveNewKundeKontakt(this.createKundeVornameTextBlock.Text, this.createKundeNachnameTextBlock.Text, type);
            }
            catch(InvalidInputException ex)
            {
                saved = false;
                HideKundeNeuMessages();
                this.kundenNeuErrGeneralLabel.Text = "Fehler: " + ex.Message;
                this.kundenNeuErrGeneralLabel.Show();
            }

            // show user that everything went fine
            if (saved)
            {
                this.HideKundeNeuMessages();
                this.kundeNeuSuccessLabel.Show();
                this.createKundeVornameTextBlock.Clear(); // delete input fields
                this.createKundeNachnameTextBlock.Clear();
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
        

        private void SaveNewProject(object sender, EventArgs e)
        {

        }

        private void ResetNewProjectTextBlocks(object sender, EventArgs e)
        {

        }

        private void LoadHomeForm(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>False...Kunde, true...Kontakt</returns>
        private bool GetKundeKontaktType()
        {
            if (this.searchKontaktRadioButton.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
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

            KundenKontakteLoader loader = new KundenKontakteLoader();

            try
            {
                List<KundeKontaktTable> results;
               
                // Kunde (false) or Kontakt (true)?
                bool type = this.GetKundeKontaktType();

                results = loader.LoadKundenKontakte(type, this.searchKundeVornameTextBlock.Text, this.searchKundeNachnameTextBlock.Text);
                this.kundenSearchDataGridView.DataSource = results;
                kundenSearchDataGridView.Columns["type"].Visible = false;
            }
            catch (InvalidInputException ex)
            {
                this.searchKundeErrorLabel.Text = "Error: " + ex.Message;
                this.searchKundeErrorLabel.Show();
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
            if (this.kundenSearchDataGridView.RowCount > 0)
            {
                this.searchKundeVornameTextBlock.Text = this.kundenSearchDataGridView[1, selectedRowID].Value.ToString();
                this.searchKundeNachnameTextBlock.Text = this.kundenSearchDataGridView[2, selectedRowID].Value.ToString();
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
        private void changeKundeOrKontakt(object sender, EventArgs e)
        {
            this.searchKundeErrorLabel.Hide();
            this.searchKundeSuccessLabel.Hide();

            if (kundenSearchDataGridView.SelectedCells.Count > 0)
            {
                bool type = this.GetKundeKontaktType();
                int id = (int)kundenSearchDataGridView.SelectedCells[0].OwningRow.Cells[0].Value;
                string firstname = this.searchKundeVornameTextBlock.Text;
                string lastname = this.searchKundeNachnameTextBlock.Text;

                int selectedRow = kundenSearchDataGridView.SelectedCells[0].OwningRow.Index;

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
                        changer.Change(id, firstname, lastname, type);
                    }
                    else if (buttonName == "deleteKundeButton")
                    {
                        changer.Delete(id, type);
                    }
                }
                catch (InvalidInputException ex)
                {
                    this.searchKundeErrorLabel.Text = ex.Message;
                    this.searchKundeErrorLabel.Show();
                }

                // update displayed rows
                this.BindFromKundenSearchTextBlock(buttonName, selectedRow, firstname, lastname);
                this.searchKundeSuccessLabel.Show();
            }
        }

        // reset everything within Kunden/Kontakte search
        private void ResetSearchKunden(object sender, EventArgs e)
        {
            this.searchKundeVornameTextBlock.Clear();
            this.searchKundeNachnameTextBlock.Clear();
            this.searchKundeErrorLabel.Hide();
            this.searchKundeSuccessLabel.Hide();

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

            results = loader.LoadKundenKontakte(false); // only get Kunden

            if(results.Count != 0)
            {
                foreach (KundeKontaktTable k in results)
                {
                    string entry = k.ID + ": " + k.Vorname + " - " + k.NachnameFirmenname;
                    listItems.Add(entry);
                }
            }
            
            this.createAngebotExistingKundeComboBox.DataSource = listItems;
        }

        /// <summary>
        /// Reads values of concerning fields and asks business layer to create a new Angebot with the provided parameters
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event params</param>
        private void CreateNewAngebot(object sender, EventArgs e)
        {
            // reset error/success labels
            this.ResetCreateAngebotLabels(null, null);

            // existing or newly to-be-created
            bool createKunde = false;
            string kundenID = null;

            // new Kunde
            if (this.angebotErstellenSubTab.SelectedTab == this.angebotErstellenSubTab.TabPages[0])
            {
                createKunde = true;
            }
            // existing Kunde
            else
            {
                // no Kunde ausgewählt -> show error label
                if (this.createAngebotExistingKundeComboBox.SelectedIndex < 0)
                {
                    this.createAngebotErrorLabel.Text = "Error: kein Kunde ausgewählt";
                    this.createAngebotErrorLabel.Show();
                    return; // skip rest of function
                }
                // get ID out of ComboBox
                else
                { 
                    kundenID = this.createAngebotExistingKundeComboBox.SelectedItem.ToString();
                    kundenID = kundenID.Substring(0, kundenID.IndexOf(':'));
                }
            }

            string firstname = this.createAngebotNewKundeVnTextBox.Text;
            string lastname = this.createAngebotNewKundeNnTextBox.Text;

            try
            {
                this.logger.Log(0, "Start creating new Angebot...");
                AngebotManager manager = new AngebotManager();
                manager.Create(kundenID, createKunde, firstname, lastname, this.createAngebotAngebotssummeTextBox.Text, this.createAngebotUmsetzungswahrscheinlichkeitTextBox.Text, this.angebotValidUntilDateTimePicker.Value, this.createAngebotDescriptionTextBox.Text);
            }
            catch (InvalidInputException ex)
            {
                this.createAngebotErrorLabel.Text = "Error: " + ex.Message;
                this.createAngebotErrorLabel.Show();
            }

            // show success message
            if (!createAngebotErrorLabel.Visible)
            {
                this.createAngebotSuccessLabel.Show();
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

            this.ResetCreateAngebotLabels(null, null);
        }

        /// <summary>
        /// Clears error/success labels
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void ResetCreateAngebotLabels(object sender, EventArgs e)
        {
            this.createAngebotErrorLabel.Hide();
            this.createAngebotSuccessLabel.Hide();
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
    }
}
