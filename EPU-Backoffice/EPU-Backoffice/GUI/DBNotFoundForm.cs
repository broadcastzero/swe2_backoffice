using EPUBackoffice.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EPUBackoffice.GUI
{
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

        private void createButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Title = "Save file as...";
            dialog.Filter = "SQLite files (*.db)|*.db|All files (*.*)|*.*";
            dialog.RestoreDirectory = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                DatabaseCreator creator = new DatabaseCreator();

                try
                {
                    creator.Create(dialog.FileName);
                }
                catch (System.Configuration.ConfigurationException)
                {
                    MessageBox.Show("Bei der Erstellung der Datenbank ist etwas schiefgelaufen. Bitte prüfen Sie, ob Sie Schreibrechte für das Konfigurationsdatei besitzen. Löschen Sie die Konfigurationsdatei gegebenenfalls, sie wird beim nächsten Start neu erzeugt.", "Fehlerhafte Konfigurationsdatei", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (SQLiteException ex)
                {
                    MessageBox.Show(ex.Message, "Datenbank konnte nicht erstellt werden.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //MessageBox.Show(dialog.FileName);
            }
        }
    }
}
