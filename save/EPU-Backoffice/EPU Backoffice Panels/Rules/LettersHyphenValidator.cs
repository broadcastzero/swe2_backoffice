// -----------------------------------------------------------------------
// <copyright file="LettersHyphenValidator.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackofficePanels.Rules
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// A class which checks for letters and hyphen within the string
    /// </summary>
    public class LettersHyphenValidator : IRule
    {
        /// <summary>
        /// Indicates if the validation has been successful
        /// </summary>
        public bool HasErrors { get; set; }

        /// <summary>
        /// Checks if input string contains only letters and hyphens
        /// </summary>
        /// <param name="input">The string that shall be checked</param>
        /// <returns>True, if string valid</returns>
        public void Eval(object input)
        {
            if (!Regex.IsMatch(input.ToString(), @"^[a-zA-Z-]+$") || input.ToString().Length > 150)
            {
                this.HasErrors = true;
            }
            else
            {
                this.HasErrors = false;
            }
        }
    }
}
