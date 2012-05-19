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

        public void HideMsgLabels()
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
            z.Stunden = DataBindingFramework.BindFromInt(zeiterfassungHoursTextbox.Text, "Stunden", this.zeiterfassungMsgLabel, false, piv);
            z.Bezeichnung = DataBindingFramework.BindFromString(zeiterfassungDescriptionTextBox.Text, "Bezeichnung", this.zeiterfassungMsgLabel, false, lnhsv, sl150v);
            // missing stundensatz in database, databasemanager and zeitaufzeichnungtabel
            z.Stundensatz = DataBindingFramework.BindFromInt(zeiterfassungStundensatzTextBox.Text, "Stundensatz", this.zeiterfassungMsgLabel, false, pdv);

            Zeiterfassungsloader loader = new Zeiterfassungsloader();
            
            // only if binding had no errors
            if (!this.zeiterfassungMsgLabel.Visible)
            {
                List<ZeitaufzeichnungTable> results;

                results = loader.LoadZeiterfassung(z, this.zeiterfassungMsgLabel);
                this.zeiterfassungBindingSource.DataSource = results;
            }


        }

        private void zeiterfassungCombobox_DropDown(object sender, EventArgs e)
        {
            GlobalActions.BindFromExistingProjekteToComboBox(sender, e);
        }

        private void zeiterfassungSubmitButton_Click(object sender, EventArgs e)
        {

        }
    }
}
