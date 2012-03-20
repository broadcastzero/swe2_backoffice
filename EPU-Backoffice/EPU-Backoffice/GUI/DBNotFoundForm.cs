using EPUBackoffice.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                creator.Create(dialog.FileName);

                //MessageBox.Show(dialog.FileName);
            }
        }
    }
}
