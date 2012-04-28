﻿// -----------------------------------------------------------------------
// <copyright file="DataBaseOpener.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Gui
{
    using System;
    using System.Windows.Forms;
    using EPUBackofficePanels.BL;
    using EPUBackofficePanels.UserExceptions;

    /// <summary>
    /// This class is responsible for showing an opening window, in which an existing SQLite file can be selected.
    /// </summary>
    public class DataBaseOpener
    {
        /// <summary>
        /// Opens an existing database.
        /// </summary>
        /// <param name="sender">The element (button) which has called this function.</param>
        /// <param name="e">Event arguments</param>
        /// <param name="sendingForm">The form in which the sending element (button) was placed.</param>
        public void OpenExistingDatabase(Object sender, EventArgs e, Form sendingForm, Form newForm)
        {
            using (OpenFileDialog openfile = new OpenFileDialog())
            {
                openfile.Title = "Vorhandene Datenbank öffnen";
                openfile.Filter = "SQLite files (*.db)|*.db";
                openfile.RestoreDirectory = true;

                if (openfile.ShowDialog() == DialogResult.OK)
                {
                    string path = openfile.FileName;

                    DatabaseConnector creator = new DatabaseConnector();

                    try
                    {
                        creator.Connect(sender, path, sendingForm, newForm);
                    }
                    catch (InvalidFileException ex)
                    {
                        MessageBox.Show(ex.Message, "Datenbank konnte nicht geöffnet werden.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
