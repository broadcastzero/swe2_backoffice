// -----------------------------------------------------------------------
// <copyright file="DataBindingFramework.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.DatabindingFramework
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using EPU_Backoffice_Panels.Rules;
    using LoggingFramework;
    using EPU_Backoffice_Panels.UserExceptions;

    /// <summary>
    /// Validates user input and binds data
    /// </summary>
    public static class DataBindingFramework
    {
        /// <summary>
        /// Shows a GUI error label
        /// </summary>
        /// <param name="element">The name of the element which has errors</param>
        /// <param name="label">The errorlabel in which errors will be displayed</param>
        private static void ShowError(string element, Label label)
        {
            // show error label
            label.ForeColor = Color.Red;
            label.Text += "\n" + element + " ungültig!";
            label.Show();
        }

        private static bool CheckRules(object input, string element, Label label, IRule[] rules)
        {
            // check value for every requested rule
            foreach (IRule rule in rules)
            {
                rule.Eval(input);

                // if rule must not be null and validating failed, show error label
                if (rule.HasErrors)
                {
                    return false;
                }
            }

            // all rules passed
            return true;
        }

        /// <summary>
        /// Checks input string and returns an integer
        /// </summary>
        /// <param name="input">The sending TextBox' value</param>
        /// <param name="name">The name of the sending text box</param>
        /// <param name="label">The error/success label</param>
        /// <param name="canBeNull">Indicates if field can be empty</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>integer (Format depending on rule)</returns>
        public static int BindFromInt(string input, string name, Label label, bool canBeNull, params IRule[] rules)
        {
            // check provided values for null
            if (input == null || name == null || label == null)
            {
                throw new InvalidInputException("User passed null values to DataBindingFramework");
            }

            // check if field can be empty
            if (canBeNull && input.Length == 0)
            {
                return 0;
            }

            // Try to convert
            int output;
            bool success = Int32.TryParse(input, out output);

            if (!success)
            {
                DataBindingFramework.ShowError(name, label);
                return -1;
            }

            success = DataBindingFramework.CheckRules(input, name, label, rules);

            if (!success)
            {
                DataBindingFramework.ShowError(name, label);
                return -1;
            }
            else
            {
                return output;
            }
        }

        /// <summary>
        /// Checks input string and returns an integer
        /// </summary>
        /// <param name="input">The sending TextBox' value</param>
        /// <param name="name">The description of the input field, as "Vorname" i.e. Needed for error label</param>
        /// <param name="label">The error/success label</param>
        /// <param name="canBeNull">Indicates if field can be empty</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>String</returns>
        public static string BindFromString(string input, string name, Label label, bool canBeNull, params IRule[] rules)
        {
            // check provided values for null
            if (input == null || name == null || label == null)
            {
                throw new InvalidInputException("User passed null values to DataBindingFramework");
            }

            // check if field can be empty
            if (canBeNull && input.Length == 0)
            {
                return string.Empty;
            }

            bool success = DataBindingFramework.CheckRules(input, name, label, rules);

            if (!success)
            {
                DataBindingFramework.ShowError(name, label);
                return string.Empty;
            }
            else
            {
                return input;
            }            
        }

        /// <summary>
        /// Checks input string and returns an integer
        /// </summary>
        /// <param name="input">The sending TextBox' value</param>
        /// <param name="name">The name of the sending text box</param>
        /// <param name="label">The error/success label</param>
        /// <param name="canBeNull">Indicates if field can be empty</param>
        /// <param name="rules">An array of enum rules which indicates what the string shall checked for.</param>
        /// <returns>A double value</returns>
        public static double BindFromDouble(string input, string name, Label label, bool canBeNull, params IRule[] rules)
        {
            // check provided values for null
            if (input == null || name == null || label == null)
            {
                throw new InvalidInputException("User passed null values to DataBindingFramework");
            }

            // check if field can be empty
            if (canBeNull && input.Length == 0)
            {
                return 0;
            }

            //convert dots in semicolons (4,33 instead of 4.33)
            input = input.Replace('.', ',');
            double output;

            bool canParse = Double.TryParse(input, out output);

            if (!canParse)
            {
                DataBindingFramework.ShowError(name, label);
                return -1;
            }

            bool success = DataBindingFramework.CheckRules(output, name, label, rules);

            if (!success)
            {
                DataBindingFramework.ShowError(name, label);
                return -1;
            }
            else
            {
                return output;
            }
        }
    }
}
