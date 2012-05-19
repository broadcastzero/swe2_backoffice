// -----------------------------------------------------------------------
// <copyright file="ProjektManager.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.BL
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Text;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels;
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.LoggingFramework;
    using EPU_Backoffice_Panels.Rules;
    using EPU_Backoffice_Panels.UserExceptions;


    /// <summary>
    /// This class is responsible for checking values provided by the GUI and creating or loading a project into/from the database
    /// </summary>
    public class ProjektManager
    {
        private Logger logger = Logger.Instance;

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
            try
            {
                DALFactory.GetDAL().CreateProjekt(pj);
            }
            catch (SQLiteException ex)
            {
                this.logger.Log(Logger.Level.Error, ex.Message + ex.StackTrace);
                throw new DataBaseException(ex.Message);
            }
        }

        /// <summary>
        /// Checks parameters provided by the GUI and loads existing Projekte according to the provided values
        /// </summary>
        /// <returns>A list of all fitting Projekte</returns>
        public List<ProjektTable> Load(int id, DateTime from, DateTime until, Label message)
        {
            PositiveIntOrMinusOneValidator pimv = new PositiveIntOrMinusOneValidator();
            DateValidator dvf = new DateValidator();
            DateValidator dvu = new DateValidator();
            string dateFrom = from.ToShortDateString();
            string dateUntil = until.ToShortDateString();


            pimv.Eval(id);
            dvf.Eval(dateFrom);
            dvu.Eval(dateUntil);

            if (pimv.HasErrors || dvf.HasErrors || dvu.HasErrors)
            {
                throw new InvalidInputException();
            }

            // parse to date strings
            dateFrom = GlobalActions.ParseToSQLiteDateString(dateFrom);
            dateUntil = GlobalActions.ParseToSQLiteDateString(dateUntil);


            try
            {
                return DALFactory.GetDAL().LoadProjekte(dateFrom, dateUntil, id);
            }
            catch (SQLiteException)
            {
                throw;
            }
        }
    }
}
