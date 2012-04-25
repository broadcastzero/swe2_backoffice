// -----------------------------------------------------------------------
// <copyright file="DateValidator.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.Rules
{
    using System;
    using System.Text;

    /// <summary>
    /// A class which checks for percent (0-100)
    /// </summary>
    public class DateValidator : IRule
    {
        /// <summary>
        /// Indicates if the validation has been successful
        /// </summary>
        public bool HasErrors { get; set; }

        /// <summary>
        /// Checks if string is a valid date string with the format 17/07/1987
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public void Eval(object input)
        {
            input = input.ToString();
            DateTime result;
            bool couldParse = DateTime.TryParse(input.ToString(), out result);

            this.HasErrors = couldParse == false ? true : false;
        }
    }
}
