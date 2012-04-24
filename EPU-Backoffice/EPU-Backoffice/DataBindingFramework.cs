// -----------------------------------------------------------------------
// <copyright file="DataBindingFramework.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace DatabindingFramework
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using Logger;
    using Rulemanager;

    /// <summary>
    /// Validates user input and binds data
    /// </summary>
    public static class DataBindingFramework
    {
        /// <summary>
        /// Checks input string and returns an integer
        /// </summary>
        /// <param name="input">The sending TextBox' value</param>
        /// <param name="name">The name of the sending text box</param>
        /// <param name="label">The error/success label</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>integer (Format depending on rule)</returns>
        public static int BindFromInt(string input, string name, Label label, params Rules[] rules)
        {
            int validInt = -1;
            bool isAndCanBeNull = false;

            // check value for every requested rule
            foreach (int rule in rules)
            {
                switch (rule)
                {
                    case 0: isAndCanBeNull = RuleManager.IsAndCanBeNull(input);
                        break;
                    case 1: validInt = RuleManager.ValidatePositiveInt(input);
                        break;
                    case 6: validInt = RuleManager.ValidatePerCent(input);
                        break;
                    default: validInt = -1; // no rule - error!
                        break;
                }

                if (isAndCanBeNull)
                {
                    return 0;
                }
                else if (validInt < 0 && label != null)
                {
                    // show error label
                    label.ForeColor = Color.Red;
                    label.Text += "\n" + name + " enthält ungültige Zeichen!";
                    label.Show(); // do this in home form maybe?
                    return -1;
                }
            }

            return validInt;
        }

        /// <summary>
        /// Checks input string and returns an integer
        /// </summary>
        /// <param name="input">The sending TextBox' value</param>
        /// <param name="name">The description of the input field, as "Vorname" i.e. Needed for error label</param>
        /// <param name="label">The error/success label</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>String</returns>
        public static string BindFromString(string input, string name, Label label, params Rules[] rules)
        {
            bool valid = true;
            bool isAndCanBeNull = false;

            // check value for every requested rule
            foreach (int rule in rules)
            {
                switch (rule)
                {
                    case 0: isAndCanBeNull = RuleManager.IsAndCanBeNull(input);
                        break;
                    case 3: valid = RuleManager.ValidateLettersHyphen(input);
                        break;
                    case 4: valid = RuleManager.ValidateLettersNumbersHyphenSpace(input);
                        break;
                    case 5: valid = RuleManager.ValidateStringLength150(input);
                        break;
                    case 7: valid = RuleManager.ValidateDateString(input);
                        break;
                    default: valid = false;// no rule
                        break;
                }

                if (isAndCanBeNull)
                {
                    return string.Empty;
                }
                else if (!valid && label != null)
                {
                    // show error label
                    label.ForeColor = Color.Red;
                    label.Text += "\n" + name + " enthält ungültige Zeichen!";
                    label.Show();
                    return string.Empty;
                }
            }

            return input;
        }

        /// <summary>
        /// Checks input string and returns an integer
        /// </summary>
        /// <param name="input">The sending TextBox' value</param>
        /// <param name="name">The name of the sending text box</param>
        /// <param name="label">The error/success label</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>A double value</returns>
        public static double BindFromDouble(string input, string name, Label label, params Rules[] rules)
        {
            //convert dots in semicolons (4,33 instead of 4.33)
            input = input.Replace('.', ',');

            double validDouble = -1;
            bool isAndCanBeNull = false;

            // check value for every requested rule
            foreach (int rule in rules)
            {
                switch (rule)
                {
                    case 0: isAndCanBeNull = RuleManager.IsAndCanBeNull(input);
                        break;
                    case 2: validDouble = RuleManager.ValidatePositiveDouble(input);
                        break;
                    default: validDouble = -1;
                        break;
                }

                if (isAndCanBeNull)
                {
                    return 0;
                }
                else if (validDouble < 0 && label != null)
                {
                    // show error label
                    label.ForeColor = Color.Red;
                    label.Text += "\n" + name + " enthält ungültige Zeichen!";
                    label.Show(); // do this in home form maybe?
                    return -1;
                }
            }

            return validDouble;
        }
    }
}
