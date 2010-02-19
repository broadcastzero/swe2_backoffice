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

       
        public List <ZeitaufzeichnungTable> LoadZeiterfassung(int pID, Label msglabel)
        {
            List<ZeitaufzeichnungTable> results;

            try
            {
                results = DALFactory.GetDAL().LoadZeiterfassung();
            }
            catch (SQLiteException)
            {
                throw;
            }

            return results;
        }
        
       
        public void SaveZeiterfassung(ZeitaufzeichnungTable z, Label label)
        {
            IRule pdv = new PositiveDoubleValidator();
            IRule piv = new PositiveIntValidator();
            IRule piv2 = new PositiveIntValidator();
            IRule sl150v = new StringLength150Validator();
            IRule lnhsv = new LettersNumbersHyphenSpaceValidator();

            
            piv.Eval(z.ProjektID);
            piv2.Eval(z.Stunden);
            sl150v.Eval(z.Bezeichnung);
            lnhsv.Eval(z.Bezeichnung);
            pdv.Eval(z.Stundensatz);

            if (piv.HasErrors || piv2.HasErrors || sl150v.HasErrors || lnhsv.HasErrors || pdv.HasErrors)
            {
                throw new InvalidInputException("Daten ungültig!");
            }

            // load elements
            try
            {
                DALFactory.GetDAL();
            }
            catch (SQLiteException)
            {
                throw;
            }
        
        }
        
    }
}
