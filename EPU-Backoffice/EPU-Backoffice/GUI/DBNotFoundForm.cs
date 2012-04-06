namespace EPUBackoffice.Gui
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SQLite;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using EPUBackoffice.BL;
    using EPUBackoffice.UserExceptions;

    /// <summary>
    /// This form lets the user create a new database or open an existing one.
    /// It will appear, if no valid database path is stored in the .exe.config-file.
    /// </summary>
    public partial class DBNotFoundForm : Form
    {
        /// <summary>
        /// This window shall be shown at the start-up of the application, 
        /// in case that no valid SQLite-file has been found under the path in the configuration file.
        /// </summary>
        public DBNotFoundForm()
        {
            InitializeComponent();
        }

        private void ShowCreateNewDbDialogue(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Title = "Save file as...";
                dialog.Filter = "SQLite files (*.db)|*.db";
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    DatabaseConnector creator = new DatabaseConnector();

                    try
                    {
                        creator.Create(this, dialog.FileName);
                    }
                    catch (System.Configuration.ConfigurationException)
                    {
                        MessageBox.Show("Bei der Erstellung der Datenbank ist etwas schiefgelaufen. Bitte prüfen Sie, ob Sie Schreibrechte für das Konfigurationsdatei besitzen. Löschen Sie die Konfigurationsdatei gegebenenfalls, sie wird beim nächsten Start neu erzeugt.", "Fehlerhafte Konfigurationsdatei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (SQLiteException ex)
                    {
                        MessageBox.Show(ex.Message, "Datenbank konnte nicht erstellt werden.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Catches the event, when the user clicks on the "open existing database"-button and forwards to DBNotFoundForm.OpenExistingDatabase()
        /// </summary>
        /// <param name="sender">The calling object</param>
        /// <param name="e">Additional event arguments</param>
        private void ShowOpenExistingDbDialogue(Object sender, EventArgs e)
        {
            DataBaseOpener dbOpener = new DataBaseOpener();
            dbOpener.OpenExistingDatabase(sender, e, this);
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
