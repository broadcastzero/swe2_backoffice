// -----------------------------------------------------------------------
// <copyright file="DataBaseOpener.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels
{
    using System;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.UserExceptions;

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
