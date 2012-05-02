using System;
using System.Collections.Generic;
using System.ComponentModel;
// -----------------------------------------------------------------------
// <copyright file="HomeForm.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file,
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice
{
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels;
    using EPU_Backoffice_Panels.BL;
    using EPU_Backoffice_Panels.LoggingFramework;

    public partial class HomeForm : Form
    {
        private Logger logger = Logger.Instance;

        /// <summary>
        /// Remember last active control so that we can switch
        /// </summary>
        private UserControl activeControl;

        public HomeForm()
        {
            InitializeComponent();
            this.FormClosing += this.HomeForm_FormClosing;
            this.Text = "EPU Backoffice 1.0";

            this.activeControl = this.homeTabInner;
        }

        /// <summary>
        /// Selects the home tab
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void SelectHomeTab(object sender, EventArgs e)
        {
            this.TableControl.SelectTab("homeTab");
        }

        /// <summary>
        /// Selects the kundenKontakte tab
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>
        private void SelectKundenKontakteTab(object sender, EventArgs e)
        {
            this.TableControl.SelectTab("kundenKontakteTab");

            this.kundenKontakteTabInner.HideMsgLabels();
        }

        private void SelectRechnungsverwaltungTab(object sender, EventArgs e)
        {
            this.TableControl.SelectTab("rechnungsTab");
        }

        private void SelectAngeboteTab(object sender, EventArgs e)
        {
            //this.ResetCreateAngebotFields(null, null);
            //this.createAngebotMsgLabel.Hide();
            this.TableControl.SelectTab("angeboteTab");
        }

        private void SelectProjektverwaltungTab(object sender, EventArgs e)
        {
            this.TableControl.SelectTab("projektTab");

            //this.projektTabInner.ResetAllWithinProjects(sender, e);
        }

        private void SelectZeiterfassungTab(object sender, EventArgs e)
        {
            this.TableControl.SelectTab("zeitTab");
        }
        
        private void SelectReportsTab(object sender, EventArgs e)
        {
            this.TableControl.SelectTab("reportTab");
        }

        private void ShowDatabaseInfo(object sender, EventArgs e)
        {
            this.homeTabInner.SetOpenedDbText();
        }

        private void ShowExitMessageBox(object sender=null, EventArgs e=null)
        {
            string message = "Wollen Sie wirklich beenden?";
            string caption = "Beenden";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
            result = MessageBox.Show(this, message, caption, buttons);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// Workaround - Application does not close completely when it is called
        /// by another Form (i.e. DBNotFoundForm).
        /// Bad designed, the next time: set HomeForm ALWAYS as main form, and hide
        /// temporary if necessary.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
