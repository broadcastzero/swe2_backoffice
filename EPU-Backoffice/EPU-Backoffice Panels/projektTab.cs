using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EPU_Backoffice_Panels
{
    public partial class projektTab : UserControl
    {
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
    }
}
