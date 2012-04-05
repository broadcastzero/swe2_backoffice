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
    /// <summary>
    /// The standard home screen of the application.
    /// </summary>
    public partial class HomeForm : Form
    {
        /// <summary>
        /// Constructor, only calls InitializeComponent()
        /// </summary>
        public HomeForm()
        {
            InitializeComponent();
            // set win title and label within "Home" subwindow to the currently opened database
            this.homeCurrentDBLabel.Text = ConfigFileManager.dbName;
            this.Text += " - ";
            this.Text += ConfigFileManager.dbName;
        }

        /* Event handling for buttons */
        private void homeButton_Click(object sender, EventArgs e)
        {
            mainTab.SelectTab("homeTab");
        }

        private void kundenKontakteButton_Click(object sender, EventArgs e)
        {
            mainTab.SelectTab("kundenKontakteTab");
            this.hideMessagesKundeNeu();
        }

        private void rechnungsverwaltungButton_Click(object sender, EventArgs e)
        {
            mainTab.SelectTab("rechnungsTab");  
        }

        private void angeboteButton_Click(object sender, EventArgs e)
        {
            mainTab.SelectTab("angeboteTab");  
        }

        private void projektverwaltungButton_Click(object sender, EventArgs e)
        {
            mainTab.SelectTab("projektTab");  
        }

        private void zeiterfassungButton_Click(object sender, EventArgs e)
        {
            mainTab.SelectTab("zeitTab");  
        }

        private void reportsButton_Click(object sender, EventArgs e)
        {
            mainTab.SelectTab("reportTab");  
        }

        private void beendenButton_Click(object sender, EventArgs e)
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
        private void bu_homeOpenNewDB_Click(object sender, EventArgs e)
        {
            //Same code already written in DBNotFoundForm -> just call this method with HomeScreen as sender
            DataBaseOpener db_opener = new DataBaseOpener();
            db_opener.OpenExistingDatabase(sender, e, this);

            // Update title bar and text within "Home" subwindow
            this.Text = "EPU Backoffice 1.0 - ";
            this.Text += ConfigFileManager.dbName;
            this.homeCurrentDBLabel.Text = ConfigFileManager.dbName;
        }

        private void HomeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        /// <summary>
        /// Clear textblocks in which a new Kunde or Kontakt can be created
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">Event args</param>
        private void newKundeResetButton_Click(object sender, EventArgs e)
        {
            this.createKundeVornameTextBlock.Clear();
            this.createKundeNachnameTextBlock.Clear();
            this.hideMessagesKundeNeu();
        }

        /// <summary>
        /// Removes all success or error messages from panel "add Kunde/Kontakt"
        /// </summary>
        public void hideMessagesKundeNeu() 
        {
            this.kundeNeuSuccessLabel.Hide();
            this.kundenNeuErrGeneralLabel.Hide();
            this.searchKundeErrorLabel.Hide();
        }

        /// <summary>
        /// Get values of GUI elements and send them to the business layer, they shall be stored in the database.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs</param>
        private void createKundeButton_Click(object sender, EventArgs e)
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
                hideMessagesKundeNeu();
                this.kundenNeuErrGeneralLabel.Text = "Fehler: " + ex.Message;
                this.kundenNeuErrGeneralLabel.Show();
            }

            // show user that everything went fine
            if (saved)
            {
                this.hideMessagesKundeNeu();
                this.kundeNeuSuccessLabel.Show(); // TODO: show what has been saved!
                this.createKundeVornameTextBlock.Clear(); // delete input fields
                this.createKundeNachnameTextBlock.Clear();
            }
        }

        

        private void angebotErstellenBKundeButton_Click(object sender, EventArgs e)
        {
                angebotErstellenBKundeButton.Hide();
                angebotErstellenNKundeButton.Show();
                angebotErstellenSubTab.SelectTab("angebotErstellenBKTab");
        }

        private void angebotErstellenNKundeButton_Click(object sender, EventArgs e)
        {
                angebotErstellenBKundeButton.Show();
                angebotErstellenNKundeButton.Hide();
                angebotErstellenSubTab.SelectTab("angebotErstellenNKTab");
        }
        

        private void projektNeuSpeichernButton_Click(object sender, EventArgs e)
        {

        }

        private void projektNeuResetButton_Click(object sender, EventArgs e)
        {

        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Gets Kunden or Kontakte out of the database (over the business layer, which checks for valid input)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void kundenSearchButton_Click(object sender, EventArgs e)
        {
            // hide error message
            this.searchKundeErrorLabel.Hide();

            KundenKontakteLoader loader = new KundenKontakteLoader();

            try
            {
                List<KundeKontaktTable> results;
               
                // Kunde (false) or Kontakt (true)?
                bool type = false;
                if (this.searchKontaktRadioButton.Checked)
                {
                    type = true;
                }

                results = loader.LoadKundenKontakte(type, this.searchKundeVornameTextBlock.Text, this.searchKundeNachnameTextBlock.Text);
                this.kundenSearchDataGridView.DataSource = results;
                kundenSearchDataGridView.Columns["type"].Visible = false;
            }
            catch (InvalidInputException ex)
            {
                this.searchKundeErrorLabel.Text = "Error: " + ex.Message;
                this.searchKundeErrorLabel.Show();
            }
            

            /* sample code for databinding - get real values out of database!
            KundeKontaktTable k1 = new KundeKontaktTable();
            k1.ID = 0;
            k1.Vorname = "Franz";
            k1.NachnameFirmenname = "Huber";

            KundeKontaktTable k2 = new KundeKontaktTable();
            k2.ID = 1;
            k2.Vorname = "Michael";
            k2.NachnameFirmenname = "Gorbatschow";

            KundeKontaktTable k3 = new KundeKontaktTable();
            k3.ID = 2;
            k3.Vorname = "Martin";
            k3.NachnameFirmenname = "Klein";*/
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }
    }
}
