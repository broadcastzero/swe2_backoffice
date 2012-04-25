// -----------------------------------------------------------------------
// <copyright file="StringLength150Validator.cs" company="Marvin&Felix">
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
    public class StringLength150Validator : IRule
    {
        /// <summary>
        /// Indicates if the validation has been successful
        /// </summary>
        public bool HasErrors { get; set; }

        /// <summary>
        /// Check if string does not have more than 150 chars
        /// </summary>
        /// <param name="input">The string that shall be checked</param>
        /// <returns>True, if string is valid</returns>
        public void Eval(object input)
        {
            this.HasErrors = input.ToString().Length > 150 ? true : false;
        }
    }
}
