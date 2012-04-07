// -----------------------------------------------------------------------
// <copyright file="RuleManager.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.BL
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;    

    /// <summary>
    /// This class checks the user input for invalid characters
    /// </summary>
    public static class RuleManager
    {
        /// <summary>
        /// Checks if input string contains only letters and hyphens
        /// </summary>
        /// <param name="input">The string that shall be checked</param>
        /// <returns>True, if string valid</returns>
        public static bool ValidateLettersHyphen(string input)
        {
            if(!Regex.IsMatch(input, @"^[a-zA-Z-]+$") || input.Length > 150)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Checks if input string contains only letters, numbers and hyphens
        /// </summary>
        /// <param name="input">The string that shall be checked</param>
        /// <returns>True, if string is valid</returns>
        public static bool ValidateLettersNumbersHyphenSpace(string input)
        {
            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9- ]+$") || input.Length > 150)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Check if string does not have more than 150 chars
        /// </summary>
        /// <param name="input">The string that shall be checked</param>
        /// <returns>True, if string is valid</returns>
        public static bool ValidateStringLength150(string input)
        {
            if (input.Length > 150)
            { return false; }
            else { return true; }
        }

        /// <summary>
        /// Checks if string is a positive integer
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The converted integer, -1 in case of error</returns>
        public static int ValidatePositiveInt(string input)
        {
            int output;
            bool success = Int32.TryParse(input, out output);

            if (success && output >= 0)
            {
                return output;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// Checks if given string is an integer between 0 and 100 (%)
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The parsed Int, -1 in case of error</returns>
        public static int ValidatePerCent(string input)
        {
            // TODO: implement rule
            return -1;
        }
    }
}
