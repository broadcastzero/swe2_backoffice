// -----------------------------------------------------------------------
// <copyright file="GlobalActions.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
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
    using EPU_Backoffice_Panels.DatabindingFramework;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;


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

        /// <summary>
        /// Gets all existing Projekte from the Database and adds them to the existingProjekteComboBox
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        public static void BindFromExistingProjekteToComboBox(object sender, EventArgs e)
        {
            // check sender for null
            if (sender == null)
            {
                return;
            }

            List<ProjektTable> results;

            // add empty element to make empty choices possible
            List<string> listItems = new List<string>();
            listItems.Add("");

            ProjektManager loader = new ProjektManager();

            // Load all existing Projekte to object result list
            results = loader.Load(-1, new DateTime(1900, 1, 1), new DateTime(2100, 1, 1), null);

            // if there are results, add them to string result list
            if (results.Count != 0)
            {
                foreach (ProjektTable projekt in results)
                {
                    string entry = projekt.ID + ": " + projekt.Projektname;
                    listItems.Add(entry);
                }
            }

            // set data source
            (sender as ComboBox).DataSource = listItems;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static int getIdFromCombobox(string data, Label messages)
        {
            int id;   
            // if no Kunde has been chosen, set kundenID to -1, which indicates, that it shall not be searched for a certain Kunde
            if (data != string.Empty)
            {
                data = data.Substring(0, data.IndexOf(':'));

                IRule posintval = new PositiveIntValidator();
                id = DataBindingFramework.BindFromInt(data, "Kunden ID", messages, false, posintval);

                if (posintval.HasErrors)
                {
                    throw new InvalidInputException("Problem with getting KundenID. Unknown hard error.");
                }
            }
            else
            {
                id = -1;
            }
        return id;
           
        }

        /// <summary>
        /// Parses a date string to a SQLite date string (YYYY-MM-DD)
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ParseToSQLiteDateString(string input)
        {
            DateTime date = new DateTime();
            string month;
            string day;

            if (!DateTime.TryParse(input, out date))
            { return string.Empty; }

            string output = date.Year + "-";

            // add zeros at the beginning if necessary (i.e. 03 instead of 3)
            month = date.Month.ToString();
            if (month.Length == 1)
            { month = "0" + month; }

            day = date.Day.ToString();
            if (day.Length == 1)
            { day = "0" + day; }
      
            return date.Year + "-" + month + "-" + day + " 00:00:00";
        }
    }
}
