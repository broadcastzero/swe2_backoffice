using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EPUBackofficePanels.BL;
using EPUBackoffice.Gui;

namespace EPUBackofficePanels.Gui.Panel
{
    /// <summary>
    /// The standard home screen of the application.
    /// </summary>
    public partial class HomeTab : UserControl
    {
        /// <summary>
        /// Constructor, only calls InitializeComponent()
        /// </summary>
        public HomeTab()
        {
            InitializeComponent();
            // set win title and label within "Home" subwindow to the currently opened database
            this.homeCurrentDBLabel.Text = ConfigFileManager.DbName;
            this.Text += " - ";
            this.Text += ConfigFileManager.DbName;
        }

        /// <summary>
        /// Catches the event, when the user clicks on the "open existing database"-button.
        /// </summary>
        /// <param name="sender">The calling object</param>
        /// <param name="e">Additional event arguments</param>
        private void homeOpenNewDbButton_Click(object sender, EventArgs e)
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
