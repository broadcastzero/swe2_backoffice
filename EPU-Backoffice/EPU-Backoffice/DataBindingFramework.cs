// -----------------------------------------------------------------------
// <copyright file="DataBindingFramework.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice
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
        /// <param name="sender">The sending TextBox</param>
        /// <param name="label">The error/success label</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>integer (Format depending on rule)</returns>
        public static int BindFromInt(TextBox sender, Label label, params Rules[] rules)
        {
            int validInt = -1;
            string input = sender.Text;

            // check value for every requested rule
            foreach (int rule in rules)
            {
                switch (rule)
                {
                    case 0: validInt = RuleManager.ValidatePositiveInt(input);
                        break;
                    case 5: validInt = RuleManager.ValidatePerCent(input);
                        break;
                    default: validInt = -1; // no rule - error!
                        break;
                }

                if (validInt < 0)
                {
                    // show error label
                    label.ForeColor = Color.Red;
                    label.Text = sender.Name + " enthält ungültige Zeichen!";
                    label.Show(); // do this in home form maybe?
                    return -1;
                }
            }

            return validInt;
        }

        /// <summary>
        /// Checks input string and returns an integer
        /// </summary>
        /// <param name="sender">The sending TextBox</param>
        /// <param name="label">The error/success label</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>String</returns>
        public static string BindFromString(TextBox sender, Label label, params Rules[] rules)
        {
            string input = sender.Text;
            bool valid = true;

            // check value for every requested rule
            foreach (int rule in rules)
            {
                switch (rule)
                {
                    case 2: valid = RuleManager.ValidateLettersHyphen(input);
                        break;
                    case 3: valid = RuleManager.ValidateLettersNumbersHyphenSpace(input);
                        break;
                    case 4: valid = RuleManager.ValidateStringLength150(input);
                        break;
                    default: // no rule
                        break;
                }

                if (!valid)
                {
                    // show error label
                    label.ForeColor = Color.Red;
                    label.Text = sender.Name + " enthält ungültige Zeichen!";
                    label.Show(); // do this in home form maybe?
                    return string.Empty;
                }
            }

            return input;
        }

        /// <summary>
        /// Checks input string and returns an integer
        /// </summary>
        /// <param name="sender">The sending TextBox</param>
        /// <param name="label">The error/success label</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>A double value</returns>
        public static double BindFromDouble(TextBox sender, Label label, params Rules[] rules)
        {
            string input = sender.ToString();
            double validDouble = -1;

            // check value for every requested rule
            foreach (int rule in rules)
            {
                switch (rule)
                {
                    case 1: validDouble = RuleManager.ValidatePositiveDouble(input);
                        break;
                    default: validDouble = -1;
                        break;
                }

                if (validDouble < 0)
                {
                    // show error label
                    label.ForeColor = Color.Red;
                    label.Text = sender.Name + " enthält ungültige Zeichen!";
                    label.Show(); // do this in home form maybe?
                    return -1;
                }
            }

            return validDouble;
        }
    }
}
