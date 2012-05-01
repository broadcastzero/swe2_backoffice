using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPU_Backoffice_Panels
{
    public partial class angeboteTab : UserControl
    {
        public angeboteTab()
        {
            InitializeComponent();
        }

        // Bind to drop down combobox
        private void createAngebotExistingKundeComboBox_DropDown(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingKundenToComboBox(sender, e);
        }

        /// <summary>
        /// Switch between new Kunde and existing Kunde within create Angebot
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void angebotErstellenNKundeButton_Click(object sender, EventArgs e)
        {
            if (this.angebotErstellenSubTab.SelectedTab == this.angebotErstellenNKTab)
            {
                this.angebotErstellenSwitchKundeButton.Text = "Bestehender Kunde";
                this.angebotErstellenSubTab.SelectedTab = this.angebotErstellenBKTab;
            }
            else
            {
                this.angebotErstellenSwitchKundeButton.Text = "Neuer Kunde";
                this.angebotErstellenSubTab.SelectedTab = this.angebotErstellenNKTab;
            }
        }


    }
}
