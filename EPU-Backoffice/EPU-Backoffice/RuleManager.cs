// -----------------------------------------------------------------------
// <copyright file="RuleManager.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace Rulemanager
{
    using System;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// An enum for rules
    /// </summary>
    public enum Rules
    {
        /// <summary>
        /// Checks if string contains chars (MUST BE THE FIRST RULE TO CHECK!! WILL BE IGNORED OTHERWISE!) 
        /// </summary>
        IsAndCanBeNull = 0,
        /// <summary>
        /// A positive integer value is requested.
        /// </summary>
        PositiveInt = 1,
        /// <summary>
        /// A positive double value is requested.
        /// </summary>
        PositiveDouble = 2,
        /// <summary>
        /// A string only containing letters and hyphens is requested.
        /// </summary>
        LettersHyphen = 3,
        /// <summary>
        /// A string only containing letters, numbers, hyphens and spaces is requested.
        /// </summary>
        LettersNumbersHyphenSpace = 4,
        /// <summary>
        /// A string only containing less or = 150 signs is requested.
        /// </summary>
        StringLength150 = 5,
        /// <summary>
        /// An integer between 0-100 is requested (%)
        /// </summary>
        PerCent = 6,
        /// <summary>
        /// A date string in the format 17/07/1987
        /// </summary>
        Date = 7
    };

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
            if (!Regex.IsMatch(input, @"^[a-zA-Z0-9- ]+$"))
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
            { 
                return false; 
            }
            else 
            { 
                return true; 
            }
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
            int val = RuleManager.ValidatePositiveInt(input);

            return val >= 0 && val <= 100 ? val : -1;
        }

        /// <summary>
        /// Checks if given string is a positive double
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>The parsed double, -1 in case of error</returns>
        public static double ValidatePositiveDouble(string input)
        {
            double output;
            bool success = double.TryParse(input, out output);

            if (success && output >= 0)
            { return output; }
            else { return -1; }
        }

        /// <summary>
        /// Checks if given string does contain chars - if not, then string is valid (ignore errors of other checks which occure because of string being empty)
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>false, if empty</returns>
        public static bool IsAndCanBeNull(string input)
        {
            return input.Length == 0 ? true : false;
        }

        /// <summary>
        /// Checks if string is a valid date string with the format 17/07/1987
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool ValidateDateString(string input)
        {
            DateTime result;
            bool couldParse = DateTime.TryParse(input, out result);

            return couldParse;
        }
    }
}
