using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EPU_Backoffice_Panels.BL;
using EPU_Backoffice_Panels.Dal.Tables;
using EPU_Backoffice_Panels.DatabindingFramework;
using EPU_Backoffice_Panels.LoggingFramework;
using EPU_Backoffice_Panels.Rules;
using EPU_Backoffice_Panels.UserExceptions;

namespace EPU_Backoffice_Panels
{
    public partial class kundenKontakteTab : UserControl
    {
        private Logger logger = Logger.Instance;

        public kundenKontakteTab()
        {
            InitializeComponent();
        }

        public void HideMsgLabels()
        {
            this.kundeNeuMsgLabel.Hide();
            this.searchKundeMsgLabel.Hide();

            this.kundeNeuMsgLabel.Text = string.Empty;
            this.searchKundeMsgLabel.Text = string.Empty;
        }

        /// <summary>
        /// resets entry fields
        /// </summary>
        public void ResetFields() 
        {
            this.createKundeNachnameTextBlock.Text = string.Empty;
            this.createKundeVornameTextBlock.Text = string.Empty;
        }

        /// <summary>
        /// Get values of GUI elements and send them to the business layer, they shall be stored in the database.
        /// </summary>
        /// <param name="sender">object sender</param>
        /// <param name="e">EventArgs</param>
        private void CreateKundeOrKontakt(object sender, EventArgs e)
        {
            // hide error label
            this.HideMsgLabels();

            KundeKontaktTable k = new KundeKontaktTable();

            // define rules
            IRule lhv = new LettersHyphenValidator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule slv = new StringLength150Validator();

            // Bind data
            k.Vorname = DataBindingFramework.BindFromString(this.createKundeVornameTextBlock.Text, "Vorname", this.kundeNeuMsgLabel, true, lhv, slv);
            k.NachnameFirmenname = DataBindingFramework.BindFromString(this.createKundeNachnameTextBlock.Text, "Nachname/Firmenname", this.kundeNeuMsgLabel, false, lnhsv, slv);
            k.Type = this.createKontaktRadioButton.Checked; // false - Kunde, true - Kontakt

            // if no errors, send to business layer and show success message
            if (!this.kundeNeuMsgLabel.Visible)
            {
                KundenKontakteSaver saver = new KundenKontakteSaver();
                saver.SaveNewKundeKontakt(k, this.kundeNeuMsgLabel);
                
                GlobalActions.ShowSuccessLabel(this.kundeNeuMsgLabel);
                ResetFields();
            }
        }

        /// <summary>
        /// Gets Kunden or Kontakte out of the database (over the business layer, which checks for valid input)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchKundenOrKontakte(object sender, EventArgs e)
        {
            // hide error message
            this.HideMsgLabels();

            // define rules
            IRule lhv = new LettersHyphenValidator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule slv = new StringLength150Validator();

            KundeKontaktTable k = new KundeKontaktTable();
            k.Vorname = DataBindingFramework.BindFromString(this.searchKundeVornameTextBlock.Text, "Vorname", this.searchKundeMsgLabel, true, lhv, slv);
            k.NachnameFirmenname = DataBindingFramework.BindFromString(this.searchKundeNachnameTextBlock.Text, "Nachname", this.searchKundeMsgLabel, true, lnhsv, slv);
            k.Type = this.searchKontaktRadioButton.Checked; // False...Kunde, true...Kontakt

            KundenKontakteLoader loader = new KundenKontakteLoader();

            // only if binding had no errors
            if (!this.searchKundeMsgLabel.Visible)
            {
                List<KundeKontaktTable> results;

                results = loader.LoadKundenKontakte(k, this.searchKundeMsgLabel);
                this.kundenSuchenBindingSource.DataSource = results;
            }

            this.BindToKundenSearchLabels(this.kundenSearchDataGridView, null);
        }

        /// <summary>
        /// When user clicks on a row within the search results, write data to labels, so that user can change the values
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The DataGridViewCellEventArgs</param> 
        private void BindToKundenSearchLabels(object sender, DataGridViewCellEventArgs e)
        {
            int selectedRowID = e == null ? 0 : e.RowIndex;

            // if there are results
            if (this.kundenSuchenBindingSource.Count > 0 && selectedRowID >= 0)
            {
                KundeKontaktTable k = (KundeKontaktTable)this.kundenSuchenBindingSource.List[selectedRowID];

                this.searchKundeVornameTextBlock.Text = k.Vorname;
                this.searchKundeNachnameTextBlock.Text = k.NachnameFirmenname;
            }
            // clear textbox if there are no results
            else
            {
                this.searchKundeVornameTextBlock.Text = string.Empty;
                this.searchKundeNachnameTextBlock.Text = string.Empty;
            }
        }

        /// <summary>
        /// After changing an entry, also display changes within DataGridView
        /// </summary>
        /// <param name="action">Shall row be updated or deleted?</param>
        /// <param name="row">The selected row</param>
        /// <param name="firstname">The new first name</param>
        /// <param name="lastname">The new last name</param>
        private void BindFromKundenSearchTextBlock(string action, int row, string firstname, string lastname)
        {
            if (action == "changeKundeButton")
            {
                this.kundenSearchDataGridView.Rows[row].Cells[1].Value = firstname;
                this.kundenSearchDataGridView.Rows[row].Cells[2].Value = lastname;
            }
            else if (action == "deleteKundeButton")
            {
                // update datagridview - clear textblocks first, so that not only the same results are displayed
                this.searchKundeVornameTextBlock.Clear();
                this.searchKundeNachnameTextBlock.Clear();
                this.SearchKundenOrKontakte(null, null);
            }
        }

        /// <summary>
        /// Changes information of an existing Kunde
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The params</param>
        private void ChangeKundeOrKontakt(object sender, EventArgs e)
        {
            this.searchKundeMsgLabel.Hide();
            this.searchKundeMsgLabel.Text = string.Empty;

            // if there are results
            if (this.kundenSuchenBindingSource.Count > 0)
            {
                int selectedRow = this.kundenSearchDataGridView.SelectedCells[0].RowIndex;                //int selectedRow = kundenSearchDataGridView.SelectedCells[0].OwningRow.Index;
                KundeKontaktTable k = (KundeKontaktTable)this.kundenSuchenBindingSource.List[selectedRow];//this.kundenSearchDataGridView.SelectedRows[0].Index];

                // get firstname and lastname from textbox
                IRule lhv = new LettersHyphenValidator();
                IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
                IRule slv = new StringLength150Validator();

                string firstname = DataBindingFramework.BindFromString(this.searchKundeVornameTextBlock.Text, "Vorname", this.searchKundeMsgLabel, true, lhv, slv);
                string lastname = DataBindingFramework.BindFromString(this.searchKundeNachnameTextBlock.Text, "Nachname", this.searchKundeMsgLabel, false, lnhsv, slv);

                // in case of errors
                if (this.searchKundeMsgLabel.Visible)
                {
                    return;
                }

                KundenKontakteChanger changer = new KundenKontakteChanger();

                // get name of sending button
                string buttonName = "";
                if (sender is Button)
                {
                    buttonName = ((Button)sender).Name;
                }

                // decide action depending on if user wants to change or delete
                try
                {
                    if (buttonName == "changeKundeButton")
                    {
                        // if there are no changes, do nothing
                        if (firstname == k.Vorname && lastname == k.NachnameFirmenname)
                        {
                            this.logger.Log(Logger.Level.Warning, "User requested to change an item which does not need to be changed.");
                            return;
                        }
                        else
                        {
                            // Change Kunde/Kontakt
                            k.Vorname = firstname;
                            k.NachnameFirmenname = lastname;
                            changer.Change(k, this.searchKundeMsgLabel);

                            // success logging
                            this.logger.Log(Logger.Level.Info, "Kunde/Kontakt with the ID " + k.ID + "has successfully been changed.");
                        }
                    }
                    else if (buttonName == "deleteKundeButton")
                    {
                        changer.Delete(k, this.searchKundeMsgLabel);
                    }
                }
                catch (InvalidInputException ex)
                {
                    this.searchKundeMsgLabel.Text = ex.Message;
                    this.searchKundeMsgLabel.Show();
                }

                // update displayed rows
                this.BindFromKundenSearchTextBlock(buttonName, selectedRow, firstname, lastname);
                this.logger.Log(Logger.Level.Info, "Kunden search datagridview has been updated.");

                // show success message
                GlobalActions.ShowSuccessLabel(kundeNeuMsgLabel);
            }
        }

        private void ResetCreateNewKunde(object sender, EventArgs e)
        {
            this.searchKundeVornameTextBlock.Text = string.Empty;
            this.searchKundeNachnameTextBlock.Text = string.Empty;
            this.searchKundeVornameTextBlock.Text = string.Empty;
            this.searchKundeNachnameTextBlock.Text = string.Empty;

            this.HideMsgLabels();
        }
    }
}
