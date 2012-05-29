// -----------------------------------------------------------------------
// <copyright file="rechnungsTab.cs" company="Marvin&Felix">
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
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using DatabindingFramework;
    using LoggingFramework;
    using Rules;
    using UserExceptions;

    public partial class rechnungsTab : UserControl
    {
        private Logger logger = Logger.Instance;

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

        // If NE tab visible, create Eingangsrechnung AND Buchungszeile. Otherwise, only create Buchungszeile to current Eingangsrechnung
        private void AddBuchungszeile(object sender, EventArgs e)
        {
            this.eingangsrechnungMsgLabel.Text = string.Empty;
            this.eingangsrechnungMsgLabel.Hide();

            // force Eingangsrechnungs-Combobox to scroll down, in case that user didn't do this
            if (this.addToEingangsrechnungCheckBox.Checked && this.existingEingangsrechnungComboBox.SelectedIndex < 0)
            {
                this.BindFromExistingEingangsrechnungToComboBox(this.existingEingangsrechnungComboBox);
            }

            // force Kontakte-Combobox to scroll down, in case that user didn't do this
            if (this.existingKontakteComboBox.SelectedIndex < 0)
            {
                GlobalActions.BindFromExistingKundenToComboBox(this.existingKontakteComboBox, null, true);
            }

            // get KontaktID out of Combobox
            string kontaktID = this.existingKontakteComboBox.SelectedItem.ToString();
            int id = -1;

            try
            {
                id = GlobalActions.getIdFromCombobox(kontaktID, this.eingangsrechnungMsgLabel);
            }
            catch(InvalidInputException)
            {
                logger.Log(Logger.Level.Error, "Unknown Exception while getting ID from Projekte from AngeboteTab!");
            }

            // check for valid KontaktID
            IRule posint = new PositiveIntValidator();
            DataBindingFramework.BindFromInt(id.ToString(), "KontaktID", this.eingangsrechnungMsgLabel, false, posint);

            // show success message
            if (!posint.HasErrors)
            {
                // TODO: forward to BL
                GlobalActions.ShowSuccessLabel(this.eingangsrechnungMsgLabel);
            }
        }

        // get all existing Eingangsrechnungen out of Database and bind result list to given combobox
        private void BindFromExistingEingangsrechnungToComboBox(ComboBox combobox)
        { 
            // TODO
        }

        private void BindToExistingKundenComboBox(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingKundenToComboBox(sender, e);
        }

        private void ChoseExistingEingangsrechnungCheckBox(object sender, EventArgs e)
        {
            if (this.addToEingangsrechnungCheckBox.Checked)
            {
                this.eingangsrechnungErstellenSubTab.SelectedTab = this.eingangsrechnungErstellenBETab;                
            }
            else
            {
                this.eingangsrechnungErstellenSubTab.SelectedTab = this.eingangsrechnungErstellenNETab;
            }
        }
    }
}
