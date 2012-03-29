// -----------------------------------------------------------------------
// <copyright file="DataBaseOpener.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Gui
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Forms;
    using EPUBackoffice.BL;
    using EPUBackoffice.UserExceptions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class DataBaseOpener
    {
        /// <summary>
        /// Opens an existing database.
        /// </summary>
        /// <param name="sender">The element (button) which has called this function.</param>
        /// <param name="e">Event arguments</param>
        /// <param name="sendingForm">The form in which the sending element (button) was placed.</param>
        public void OpenExistingDatabase(Object sender, EventArgs e, Form sendingForm)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Title = "Vorhandene Datenbank öffnen";
            openfile.Filter = "SQLite files (*.db)|*.db";
            openfile.RestoreDirectory = true;

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                string path = openfile.FileName.ToString();

                DatabaseConnector creator = new DatabaseConnector();

                try
                {
                    creator.Connect(sender, path, sendingForm);
                }
                catch (InvalidFileException ex)
                {
                    MessageBox.Show(ex.Message, "Datenbank konnte nicht geöffnet werden.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
