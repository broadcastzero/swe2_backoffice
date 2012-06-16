// -----------------------------------------------------------------------
// <copyright file="DataBaseCreator.cs" company="Marvin&Felix">
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
    using System.Data.SQLite;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.DatabindingFramework;
    using EPU_Backoffice_Panels.LoggingFramework;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;

    public partial class zeitTab : UserControl
    {
        private Logger logger = Logger.Instance;

        public zeitTab()
        {
            InitializeComponent();
        }

        private void HideMsgLabels()
        {
            this.zeiterfassungMsgLabel.Hide();

            this.zeiterfassungMsgLabel.Text = string.Empty;
        }


        /// <summary>
        /// Get values of GUI elements and send them to the business layer, they shall be stored in the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateZeiterfassung(object sender, EventArgs e) 
        {
            string projektID = null;

            // hide error label
            this.HideMsgLabels();

            ZeitaufzeichnungTable z = new ZeitaufzeichnungTable();
 
            //define rules
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule pdv = new PositiveDoubleValidator();
            IRule piv = new PositiveIntValidator();
            IRule sl150v = new StringLength150Validator();
            
            projektID = this.zeiterfassungCombobox.SelectedItem.ToString();
            projektID = projektID.Substring(0, projektID.IndexOf(':'));

            //Bind data
            z.ProjektID = DataBindingFramework.BindFromInt(projektID, "ProjektID", this.zeiterfassungMsgLabel, false, piv);
            z.Stunden = DataBindingFramework.BindFromInt(zeiterfassungHoursTextbox.Text, "Dauer", this.zeiterfassungMsgLabel, false, piv);
            z.Bezeichnung = DataBindingFramework.BindFromString(zeiterfassungDescriptionTextBox.Text, "Bezeichnung", this.zeiterfassungMsgLabel, false, lnhsv, sl150v);
            z.Stundensatz = DataBindingFramework.BindFromInt(zeiterfassungStundensatzTextBox.Text, "Stundensatz", this.zeiterfassungMsgLabel, false, pdv);

            ZeiterfassungsManager saver = new ZeiterfassungsManager();
            
            // only if binding had no errors
            if (!this.zeiterfassungMsgLabel.Visible)
            {
                try 
                { 
                    saver.SaveZeiterfassung(z, this.zeiterfassungMsgLabel); 
                }
                catch (SQLiteException)
                {
                    this.zeiterfassungMsgLabel.Text = "Aussagekräftiger Fehler";
                    this.zeiterfassungMsgLabel.Show();

                }
                catch (InvalidInputException ex)
                {
                    this.zeiterfassungMsgLabel.Text = ex.Message;
                    this.zeiterfassungMsgLabel.Show();
                }
                GlobalActions.ShowSuccessLabel(this.zeiterfassungMsgLabel);
                ResetZeiterfassung();

            }
        }

        private void zeiterfassungCombobox_DropDown(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingProjekteToComboBox(sender, e);
        }

        /// <summary>
        /// Loads all Zeiterfassungen into datagrid
        /// </summary>
        private void SearchZeiterfassung(object sender, EventArgs e)
        {
            // get kundenID out of ComboBox
            string projektID = this.zeiterfassungCombobox.SelectedItem.ToString();
            int id = -1;

            try
            {
                id = GlobalActions.getIdFromCombobox(projektID, zeiterfassungMsgLabel);
            }
            catch
            (
                InvalidInputException
            )
            {
                logger.Log(Logger.Level.Error, "Unknown Exception while getting ID from Projekte from ZeiterfassungTab!");
            }
            
            ZeiterfassungsManager manager = new ZeiterfassungsManager();
            List<ZeitaufzeichnungTable> results = new List<ZeitaufzeichnungTable>();

            try
            {
                results = manager.LoadZeiterfassung(id, this.zeiterfassungMsgLabel);
            }
            catch (DataBaseException ex)
            {
                this.logger.Log(Logger.Level.Error, "A serious problem with the database has occured. Program will be exited. " + ex.Message + ex.StackTrace);
                Application.Exit();
            }

            this.zeiterfassungBindingSource.DataSource = results;
        }

        /// <summary>
        /// Resets Zeiterfassungs Fields after entry
        /// </summary>
        private void ResetZeiterfassung()
        {
            this.zeiterfassungHoursTextbox.Text = string.Empty;
            this.zeiterfassungStundensatzTextBox.Text = string.Empty;
            this.zeiterfassungDescriptionTextBox.Text = string.Empty;
        }

        private void DisableFields() 
        {
            this.zeiterfassungStundensatzTextBox.ReadOnly = true;
            this.zeiterfassungDescriptionTextBox.ReadOnly = true;
            this.zeiterfassungHoursTextbox.ReadOnly = true;
        }

        private void EnableFields()
        {
            this.zeiterfassungStundensatzTextBox.ReadOnly = false;
            this.zeiterfassungDescriptionTextBox.ReadOnly = false;
            this.zeiterfassungHoursTextbox.ReadOnly = false;
        }
    }
}
