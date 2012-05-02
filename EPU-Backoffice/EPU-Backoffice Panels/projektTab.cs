// -----------------------------------------------------------------------
// <copyright file="projektTab.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Data;
    using System.Text;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal.Tables;

    public partial class projektTab : UserControl
    {
        public projektTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Add existing Kunden to ComboBox
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void projektSuchenKundeCombobox_DropDown(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingKundenToComboBox(sender, e);
        }

        private void BindFromExistingAngeboteToComboBox(object sender, EventArgs e)
        {
            // add empty element to make empty choices possible
            List<string> listItems = new List<string>();
            listItems.Add("");

            AngebotManager manager = new AngebotManager();

            // load all angebote from list
            List<AngebotTable> angebote = manager.Load(-1, new DateTime(1900, 1, 1), new DateTime(2100, 1, 1), this.projektNeuMsgLabel);

            // if there are results, add them to string result list
            if (angebote.Count != 0)
            {
                foreach (AngebotTable angebot in angebote)
                {
                    string entry = angebot.ID + ": " + angebot.Beschreibung;
                    listItems.Add(entry);
                }
            }

            // set data source
            (sender as ComboBox).DataSource = listItems;
        }
    }
}
