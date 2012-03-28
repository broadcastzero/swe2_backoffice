using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ra_kundenNeuKunde_CheckedChanged(object sender, EventArgs e)
        {

        }      
    }
}
