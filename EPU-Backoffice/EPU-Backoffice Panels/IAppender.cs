// -----------------------------------------------------------------------
// <copyright file="IAppender.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels
{
    using System;
    using System.Text;

    /// <summary>
    /// Appender of the Logfile
    /// </summary>
    public interface IAppender
    {
        /// <summary>
        /// Configures the Logfile Appender
        /// </summary>
        void Configure();

        /// <summary>
        /// Writes the message to the logfile
        /// </summary>
        /// <param name="message">The message which shall be logged</param>
        void Write(string message);
    }
}
