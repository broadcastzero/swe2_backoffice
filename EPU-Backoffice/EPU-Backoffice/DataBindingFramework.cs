﻿// -----------------------------------------------------------------------
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
                else if (validInt < 0)
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
        /// <param name="name">The description of the input field, as "Vorname" i.e. Needed for error label</param>
        /// <param name="label">The error/success label</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>String</returns>
        public static string BindFromString(TextBox sender, string name, Label label, params Rules[] rules)
        {
            string input = sender.Text;
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
                    default: valid = false;// no rule
                        break;
                }

                if (isAndCanBeNull)
                {
                    return string.Empty;
                }
                else if (!valid)
                {
                    // show error label
                    label.ForeColor = Color.Red;
                    label.Text = name + " enthält ungültige Zeichen!";
                    label.Show();
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
            string input = sender.Text;

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
                else if (validDouble < 0)
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
