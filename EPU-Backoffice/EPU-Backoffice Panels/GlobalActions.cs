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
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.Dal.Tables;

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

        /// <summary>
        /// Gets all existing Kunden from the Database and adds them to the existingKundenComboBox
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        public static void BindFromExistingKundenToComboBox(object sender, EventArgs e)
        {
            // check sender for null
            if (sender == null)
            {
                return;
            }

            List<KundeKontaktTable> results;

            // add empty element to make empty choices possible
            List<string> listItems = new List<string>();
            listItems.Add("");

            KundenKontakteLoader loader = new KundenKontakteLoader();

            // Create empty Kunden object with type "false"
            KundeKontaktTable k = new KundeKontaktTable();
            k.Vorname = string.Empty;
            k.NachnameFirmenname = string.Empty;
            k.Type = false; // only get Kunden
            
            // Load all existing Kunden to object result list
            results = loader.LoadKundenKontakte(k, null);

            // if there are results, add them to string result list
            if (results.Count != 0)
            {
                foreach (KundeKontaktTable kunde in results)
                {
                    string entry = kunde.ID + ": " + kunde.Vorname + " - " + kunde.NachnameFirmenname;
                    listItems.Add(entry);
                }
            }

            // set data source
            (sender as ComboBox).DataSource = listItems;
        }
    }
}
