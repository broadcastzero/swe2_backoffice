using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EPU_Backoffice_Panels.BL;

namespace EPU_Backoffice_Panels
{
    public partial class homeTab : UserControl
    {
        public homeTab()
        {
            InitializeComponent();
            this.SetOpenedDbText();
        }

        /// <summary>
        /// Sets win title and label within "Home" subwindow to the currently opened database
        /// </summary>
        public void SetOpenedDbText()
        {
            ConfigFileManager cfm = new ConfigFileManager();
            this.homeCurrentDBLabel.Text = ConfigFileManager.DbName;
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
            db_opener.OpenExistingDatabase(sender, e, null, null);

            // Update title bar and text within "Home" subwindow
            this.Text = "EPU Backoffice 1.0 - ";
            this.Text += ConfigFileManager.DbName;
            this.homeCurrentDBLabel.Text = ConfigFileManager.DbName;
        }
    }
}
