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
            
        }

        private void kundenKontakteButton_Click(object sender, EventArgs e)
        {

        }

        private void rechnungsverwaltungButton_Click(object sender, EventArgs e)
        {

        }

        private void angeboteButton_Click(object sender, EventArgs e)
        {

        }

        private void projektverwaltungButton_Click(object sender, EventArgs e)
        {

        }

        private void zeiterfassungButton_Click(object sender, EventArgs e)
        {

        }

        private void reportsButton_Click(object sender, EventArgs e)
        {

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

        private void label1_Click(object sender, EventArgs e)
        {

        }

      
    }
}
