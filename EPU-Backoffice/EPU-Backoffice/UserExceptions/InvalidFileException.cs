// -----------------------------------------------------------------------
// <copyright file="InvalidFileException.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice.UserExceptions
{
    using System;

    /// <summary>
    /// This Exception is thrown if the user tries to open or save an invalid file.
    /// </summary>

    public class InvalidFileException : Exception
    {
        /// <summary>
        /// This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        public InvalidFileException()
        { }

        /// <summary>
        /// This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        /// <param name="message">The error message which is thrown</param>
        public InvalidFileException(string message) : base(message) { }

        /// <summary>
        /// This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        /// <param name="message">The error message which is thrown</param>
        /// <param name="inner">The base class</param>
        public InvalidFileException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}