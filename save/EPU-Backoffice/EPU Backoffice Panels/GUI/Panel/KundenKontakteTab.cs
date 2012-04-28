using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EPUBackofficePanels.Dal.Tables;
using DatabindingFramework;
using EPUBackofficePanels.BL;
using EPUBackofficePanels.Rules;

namespace EPUBackofficePanels.Gui.Panel
{
    public partial class KundenKontakteTab : UserControl
    {
        public KundenKontakteTab()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Clear textblocks in which a new Kunde or Kontakt can be created
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">Event args</param>
        private void ResetNewKundeTextBlocks(object sender, EventArgs e)
        {
            this.createKundeVornameTextBlock.Clear();
            this.createKundeNachnameTextBlock.Clear();
        }

        /// <summary>
        /// Get values of GUI elements and send them to the business layer, they shall be stored in the database.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs</param>
        private void CreateKundeOrKontakt(object sender, EventArgs e)
        {
            // hide error label
            this.kundeNeuMsgLabel.Hide();
            this.kundeNeuMsgLabel.Text = string.Empty;

            KundeKontaktTable k = new KundeKontaktTable();

            //create rules object            
            IRule lhv = new LettersHyphenValidator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule slv = new StringLength150Validator();

            // Bind data
            k.Vorname = DataBindingFramework.BindFromString(this.createKundeVornameTextBlock.Text, "Vorname", this.kundeNeuMsgLabel, true, lhv, slv);
            k.NachnameFirmenname = DataBindingFramework.BindFromString(this.createKundeNachnameTextBlock.Text, "Nachname/Firmenname", this.kundeNeuMsgLabel, false,  lnhsv, slv );
            k.Type = this.createKontaktRadioButton.Checked; // false - Kunde, true - Kontakt

            // if no errors, send to business layer and show success message
            if (!this.kundeNeuMsgLabel.Visible)
            {
                KundenKontakteSaver saver = new KundenKontakteSaver();
                saver.SaveNewKundeKontakt(k, this.kundeNeuMsgLabel);

                SharedPanelActions.ShowSuccessLabel(this.kundeNeuMsgLabel);
            }
        }
    }
}
