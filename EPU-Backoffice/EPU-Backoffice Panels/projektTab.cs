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
    using EPU_Backoffice_Panels.DatabindingFramework;
    using EPU_Backoffice_Panels.LoggingFramework;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;

    public partial class projektTab : UserControl
    {
        private Logger logger = Logger.Instance;

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

        /// <summary>
        /// Creates a new Projekt
        /// </summary>
        /// <param name="sender">The sending object</param>
        /// <param name="e">The event args</param>
        private void CreateProjekt(object sender, EventArgs e)
        {
            // hide label
            this.projektNeuMsgLabel.Text = string.Empty;
            this.projektNeuMsgLabel.Hide();

            // define Rules
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule slv = new StringLength150Validator();

            ProjektTable projekt = new ProjektTable();

            // bind values
            projekt.Projektname = DataBindingFramework.BindFromString(this.projektNeuProjekttitelTextbox.Text, "Projekttitel", this.projektNeuMsgLabel, false, lnhsv, slv);

            if (lnhsv.HasErrors || slv.HasErrors)
            { this.projektNeuMsgLabel.Text = "Projektname ungültig!"; }

            // no Angebot chosen or first element chosen (which is empty) -> show error label
            if (this.projektErstellenAngebotCombobox.SelectedIndex <= 0)
            {
                this.projektNeuMsgLabel.Text += "\nKein Angebot ausgewählt";
                this.projektNeuMsgLabel.ForeColor = Color.Red;
                this.projektNeuMsgLabel.Show();
                return;
            }
            // Angebot chosen - get ID out of ComboBox
            else
            {
                string s_angebotID = this.projektErstellenAngebotCombobox.SelectedItem.ToString();
                s_angebotID = s_angebotID.Substring(0, s_angebotID.IndexOf(':'));

                IRule posint = new PositiveIntValidator();
                IRule datev = new DateValidator();

                projekt.AngebotID = DataBindingFramework.BindFromInt(s_angebotID, "AngebotID", this.projektNeuMsgLabel, false, posint);
                projekt.Projektstart = DataBindingFramework.BindFromString(this.projektNeuStartdatumDatepicker.Value.ToShortDateString(), "Startdatum", projektNeuMsgLabel, false, datev);

                // Check for errors while databinding
                if (this.projektNeuMsgLabel.Visible)
                {
                    this.logger.Log(Logger.Level.Error, projekt.AngebotID + " is an invalid Angebot ID or invalid date chosen or invalid project name.");
                    return;
                }

                // get Kunde table out of Database
                AngebotManager loader = new AngebotManager();
                List<AngebotTable> results = loader.Load(projekt.AngebotID, new DateTime(1900, 1, 1), new DateTime(2100, 1, 1), this.projektNeuMsgLabel, true);

                // there must be exactly one result, for ID is unique!
                if (results.Count != 1)
                {
                    this.logger.Log(Logger.Level.Error, "More than one Angebot returned - impossible, because ID is unique!");
                    this.projektNeuMsgLabel.Text = "Error: Datenbank inkonsistent!";
                    this.projektNeuMsgLabel.Visible = true;
                    return;
                }

                // everything went fine
                ProjektManager saver = new ProjektManager();

                try
                {
                    saver.Create(projekt);
                    //logger.Log(Logger.Level.Info, "uebergabe von projekttab: " + projekt.AngebotID+ " " + projekt.Projektstart);
                }
                catch (InvalidInputException ex)
                {
                    this.logger.Log(Logger.Level.Error, "Input was invalid, although checked." + ex.Message);
                }
                catch (DataBaseException ex)
                {
                    this.logger.Log(Logger.Level.Error, "Some serious problem with the database occured!" + ex.Message);
                }

                GlobalActions.ShowSuccessLabel(this.projektNeuMsgLabel);
            }
        }

        private void projektSuchenSearchButton_Click(object sender, EventArgs e)
        {
            logger.Log(Logger.Level.Info, "projekt search button pressed");

            // get selected KundenID
            // force searching for existing Kunden, if Kunde has not dropped down the ComboBox (would throw Exception otherwise)
            if (this.projektSuchenKundeCombobox.SelectedIndex < 0)
            {
                GlobalActions.BindFromExistingKundenToComboBox(this.projektSuchenKundeCombobox, null);
            }

            this.projektSuchenMessageLabel.Hide();

            string kundenID = this.projektSuchenKundeCombobox.SelectedItem.ToString();
            int id = -1;
            try
            {
                id = GlobalActions.GetIdFromCombobox(kundenID, projektSuchenMessageLabel);
                logger.Log(Logger.Level.Info, "kundenid in projekt search: " + id);
            }
            catch(InvalidInputException)
            {
                logger.Log(Logger.Level.Error, "Unknown Exception while getting ID from Projekte from AngeboteTab!");
            }
            //logger.Log(Logger.Level.Info, "KundenID:" +id);

            // get Angebot in SDS format: 6/1/2009
            DateTime from = this.projektSuchenVonDatepicker.Value;
            DateTime until = this.projektSuchenBisDatepicker.Value;

            ProjektManager manager = new ProjektManager();
            List<ProjektTable> results = new List<ProjektTable>();

            try
            {
                results = manager.Load(id, from, until, this.projektSuchenMessageLabel);
                logger.Log(Logger.Level.Info,"resultslength: "+results.Count);
            }
            catch (DataBaseException ex)
            {
                this.logger.Log(Logger.Level.Error, "A serious problem with the database has occured. Program will be exited. " + ex.Message + ex.StackTrace);
                Application.Exit();
            }

            this.projektSearchBindingSource.DataSource = results;
        }
    }
}
