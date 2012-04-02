using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using EPUBackoffice.BL;
using EPUBackoffice.UserExceptions;

namespace EPUBackoffice.Gui
{
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

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

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
        }

        /// <summary>
        /// Get values of GUI elements and send them to the business layer, they shall be stored in the database.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs</param>
        private void createKundeButton_Click(object sender, EventArgs e)
        {
            GuiDataValidator validator = new GuiDataValidator();
            // bool type: false -> Kunde, true -> Kontakt
            bool type = this.createKontaktRadioButton.Checked;
            try
            {
                validator.saveNewKunde(this.createKundeVornameTextBlock.Text, this.createKundeNachnameTextBlock.Text, type);
                // show user that everything went fine
            }
            catch(Exception ex) // TODO: add own exception here
            {
                // show user that something went wrong
            }
        }

        private void angebotErstellenBProjektButton_Click(object sender, EventArgs e)
        {
            angebotErstellenBProjektButton.Hide();
            angebotErstellenNProjektButton.Show();
            if (angebotErstellenBKundeButton.Visible == true)
            {
                angebotErstellenSubTab.SelectTab("angebotErstellenNKBPTab");
            }
            else 
            {
                angebotErstellenSubTab.SelectTab("angebotErstellenBKBPTab");
            }
        }

        private void angebotErstellenBKundeButton_Click(object sender, EventArgs e)
        {
            angebotErstellenBKundeButton.Hide();
            angebotErstellenNKundeButton.Show();
            if (angebotErstellenBProjektButton.Visible == true)
            {
                angebotErstellenSubTab.SelectTab("angebotErstellenBKNPTab");
            }
            else
            {
                angebotErstellenSubTab.SelectTab("angebotErstellenNKBPTab");
            }
        }

        private void angebotErstellenNKundeButton_Click(object sender, EventArgs e)
        {
            angebotErstellenNKundeButton.Hide();
            angebotErstellenBKundeButton.Show();

            if (angebotErstellenBProjektButton.Visible == true)
            {
                angebotErstellenSubTab.SelectTab("angebotErstellenNKNPTab");
            }
            else
            {
                angebotErstellenSubTab.SelectTab("angebotErstellenNKBPTab");
            }

        }

        private void angebotErstellenNProjektButton_Click(object sender, EventArgs e)
        {
            angebotErstellenNProjektButton.Hide();
            angebotErstellenBProjektButton.Show();

            if (angebotErstellenBKundeButton.Visible == true)
            {
                angebotErstellenSubTab.SelectTab("angebotErstellenNKNPTab");
            }
            else
            {
                angebotErstellenSubTab.SelectTab("angebotErstellenBKNPTab");
            }
        }
    }
}
