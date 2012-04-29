// -----------------------------------------------------------------------
// <copyright file="ProjektManager.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.BL
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels;

    /// <summary>
    /// This class is responsible for checking values provided by the GUI and creating or loading a project into/from the database
    /// </summary>
    public class ProjektManager
    {
        /// <summary>
        /// Checks parameters provided by the GUI and delegates values to database which saves them.
        /// </summary>
        public void Create(string projekttitel, string angebotID, DateTime startdate)
        {
            throw new NotImplementedException();
            // after creating the angebot, set "angenommen"-attribute in AngebotTable true!
        }

        /// <summary>
        /// Checks parameters provided by the GUI and loads existing Projekte according to the provided values
        /// </summary>
        /// <returns>A list of all fitting Projekte</returns>
        public List<ProjektTable> Load()
        {
            throw new NotImplementedException();
        }
    }
}
