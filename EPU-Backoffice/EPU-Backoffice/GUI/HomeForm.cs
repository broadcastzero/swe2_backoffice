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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ra_kundenNeuKunde_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void bu_kundenNeuSave_Click(object sender, EventArgs e)
        {

        }

        private void bu_kundenNeuReset_Click(object sender, EventArgs e)
        {

        }

        private void bu_kundenSearchAendern_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        //Öffnung einer neuen Datenbank .. somehow not working

      /*
        private void bu_homeOpenNewDB_Click(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Vorhandene Datenbank öffnen";
            openfile.Filter = "SQLite files (*.db)|*.db";
            openfile.RestoreDirectory = true;

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string path = openfile.FileName.ToString();

                DatabaseConnector creator = new DatabaseConnector();

                try
                {
                    creator.Connect(this, path);
                }
                catch (InvalidFileException ex)
                {
                    MessageBox.Show(ex.Message, "Datenbank konnte nicht geöffnet werden.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }*/
    }
}
