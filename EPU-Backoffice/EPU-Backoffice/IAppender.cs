// -----------------------------------------------------------------------
// <copyright file="IAppender.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice
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
