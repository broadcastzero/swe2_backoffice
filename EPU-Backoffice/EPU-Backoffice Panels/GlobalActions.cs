// -----------------------------------------------------------------------
// <copyright file="GlobalActions.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;

    /// <summary>
    /// This class contains static global methods, which can be used by any label
    /// </summary>
    public static class GlobalActions
    {
        // Show success messages in an existing label
        public static void ShowSuccessLabel(Label l)
        {
            if (l == null)
            { return; }

            l.Text = "Erfolgreich aktualisiert.";
            l.ForeColor = Color.Green;
            l.Show();
        }
    }
}
