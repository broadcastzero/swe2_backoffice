// -----------------------------------------------------------------------
// <copyright file="IRule.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.Rules
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// An Interfaces for a validating class
    /// </summary>
    public interface IRule
    {
        /// <summary>
        /// Indicates if validating failed
        /// </summary>
        bool HasErrors { get; set; }

        /// <summary>
        /// the validating method
        /// </summary>
        /// <param name="input">The object (string, int, double) that shall be checked</param>
        void Eval(object input);
    }
}
