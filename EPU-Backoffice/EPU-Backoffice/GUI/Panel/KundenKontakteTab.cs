using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EPUBackoffice.Dal.Tables;
using DatabindingFramework;
using EPUBackoffice.BL;

namespace EPUBackoffice.Gui.Panel
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

            // Bind data
            k.Vorname = DataBindingFramework.BindFromString(this.createKundeVornameTextBlock.Text, "Vorname", this.kundeNeuMsgLabel, Rules.IsAndCanBeNull, Rules.LettersHyphen, Rules.StringLength150);
            k.NachnameFirmenname = DataBindingFramework.BindFromString(this.createKundeNachnameTextBlock.Text, "Nachname/Firmenname", this.kundeNeuMsgLabel, Rules.LettersNumbersHyphenSpace, Rules.StringLength150);
            k.Type = this.createKontaktRadioButton.Checked; // false - Kunde, true - Kontakt

            // if no errors, send to business layer and show success message
            if (!this.kundeNeuMsgLabel.Visible)
            {
                KundenKontakteSaver saver = new KundenKontakteSaver();
                saver.SaveNewKundeKontakt(k, this.kundeNeuMsgLabel);

                this.ShowSuccessLabel(this.kundeNeuMsgLabel);
            }
        }

        private void ShowSuccessLabel(Label label)
        {
            throw new NotImplementedException();
        }

        private void ShowNKundeButton(object sender, EventArgs e)
        {
            angebotErstellenBKundeButton.Hide();
            angebotErstellenNKundeButton.Show();
            angebotErstellenSubTab.SelectTab("angebotErstellenNKTab");
        }

        private void ShowBKundeButton(object sender, EventArgs e)
        {
            angebotErstellenBKundeButton.Show();
            angebotErstellenNKundeButton.Hide();
            angebotErstellenSubTab.SelectTab("angebotErstellenBKTab");
        }
    }
}
