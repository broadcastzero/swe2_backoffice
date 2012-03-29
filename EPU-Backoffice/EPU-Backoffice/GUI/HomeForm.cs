using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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

        private void ra_kundenNeuKunde_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

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
            DBNotFoundForm dbForm = new DBNotFoundForm();
            dbForm.OpenExistingDatabase(sender, e, this);
        }
    }
}
