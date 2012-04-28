using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace EPUBackofficePanels
{
    public static class SharedPanelActions
    {
        // Show success messages in an existing label
        public static void ShowSuccessLabel(Label l)
        {
            l.Text = "Erfolgreich eingetragen.";
            l.ForeColor = Color.Green;
            l.Show();
        }
    }
}
