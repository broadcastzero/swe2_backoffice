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
    using EPU_Backoffice_Panels;
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;

    /// <summary>
    /// This class is responsible for checking values provided by the GUI and creating or loading a project into/from the database
    /// </summary>
    public class ProjektManager
    {
        /// <summary>
        /// Checks parameters provided by the GUI and delegates values to database which saves them.
        /// </summary>
        public void Create(ProjektTable pj)
        {
            // check data once again
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule posintv = new PositiveIntValidator();
            IRule slv = new StringLength150Validator();
            IRule dv = new DateValidator();
            
            // call eval methods
            lnhsv.Eval(pj.Projektname);
            slv.Eval(pj.Projektname);
            posintv.Eval(pj.AngebotID);
            dv.Eval(pj.Projektstart);

            // check for errors
            if (lnhsv.HasErrors || slv.HasErrors || posintv.HasErrors || dv.HasErrors)
            { 
                throw new InvalidInputException("Invalid values provided by GUI");
            }
            
            // send values to database
            DALFactory.GetDAL().CreateProjekt(pj);
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
