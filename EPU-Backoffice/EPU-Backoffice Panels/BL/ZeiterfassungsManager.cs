// -----------------------------------------------------------------------
// <copyright file="ZeiterfassungsLoader.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.BL
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data.SQLite;
    using System.Windows.Forms;
    using DatabindingFramework;
    using EPU_Backoffice_Panels.Dal;
    using EPU_Backoffice_Panels.Dal.Tables;
    using EPU_Backoffice_Panels.LoggingFramework;
    using EPU_Backoffice_Panels.UserExceptions;
    using EPU_Backoffice_Panels.Rules;

    /// <summary>
    /// This class' methods load data out of the database and returns a list of requested data.
    /// </summary>
    public class ZeiterfassungsManager
    {
        private Logger logger = Logger.Instance;

      /*  
        public List <ZeitaufzeichnungTable> LoadZeiterfassung()
        {
            return ;
        }
        */
       
        public void SaveZeiterfassung(ZeitaufzeichnungTable z, Label label)
        {
            IRule doubv = new PositiveDoubleValidator();
            IRule intv = new PositiveIntValidator();
            IRule datev = new DateValidator();
            IRule lengthv = new StringLength150Validator();
            IRule percv = new PercentValidator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();
            IRule lhv = new LettersHyphenValidator();

            // load elements
            try
            {
                //return DALFactory.GetDAL()
            }
            catch (SQLiteException)
            {
                throw;
            }
        
        }
        
    }
}
