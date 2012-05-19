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
    public partial class rechnungsTab : UserControl
    {
        public rechnungsTab()
        {
            InitializeComponent();
        }

        private void ausgangsrechnungComboBox_DropDown(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingProjekteToComboBox(sender, e);
        }

        private void BindFromExistingKontakte(object sender, EventArgs e)
        {
            // set additional param to true, so that it is searched for Kontakte instead of Kunden
            GlobalActions.BindFromExistingKundenToComboBox(sender, e, true);
        }

        private void AddBuchungszeile(object sender, EventArgs e)
        {
            // force Kontakte-Combobox to scroll down, in case that user didn't do this

        }
    }
}
