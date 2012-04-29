// -----------------------------------------------------------------------
// <copyright file="PositiveIntValidator.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Rules
{
    using System;
    using System.Text;

    /// <summary>
    /// A class which checks for positive integer
    /// </summary>
    public class PositiveIntValidator : IRule
    {
        /// <summary>
        /// Indicates if the validation has been successful
        /// </summary>
        public bool HasErrors { get; set; }

        /// <summary>
        /// Checks if given string is a positive integer
        /// </summary>
        /// <param name="input">The input object</param>
        public void Eval(object input)
        {
            int outval;
            this.HasErrors = !Int32.TryParse(input.ToString(), out outval);

            if (this.HasErrors) { return; }

            this.HasErrors = outval >= 0 ? false : true;
        }
    }
}
