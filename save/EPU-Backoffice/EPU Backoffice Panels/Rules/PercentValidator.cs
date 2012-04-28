// -----------------------------------------------------------------------
// <copyright file="PercentValidator.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackofficePanels.Rules
{
    using System;
    using System.Text;

    /// <summary>
    /// A class which checks for percent (0-100)
    /// </summary>
    public class PercentValidator : IRule
    {
        /// <summary>
        /// Indicates if the validation has been successful
        /// </summary>
        public bool HasErrors { get; set; }

        /// <summary>
        /// Checks if given string is an integer between 0 and 100 (%)
        /// </summary>
        /// <param name="input">The input string</param>
        public void Eval(object input)
        {
            int outval;
            this.HasErrors = !Int32.TryParse(input.ToString(), out outval);

            if(this.HasErrors)
            {
                return;
            }

            this.HasErrors = outval >= 0 && outval <= 100 ? false : true;
        }
    }
}
