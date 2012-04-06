﻿// -----------------------------------------------------------------------
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
        public static bool ValidateLettersAndHyphen(string input)
        {
            if(!Regex.IsMatch(input, @"^[a-zA-Z-]+$"))
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
        public static bool ValidateLettersNumbersHyphen(string input)
        {
            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9-]+$"))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
