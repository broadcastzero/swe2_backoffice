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

    public class InvalidInputException : Exception
    {
        /// <summary>
        /// This Exception is thrown if the user tries to make an invalid input
        /// </summary>
        public InvalidInputException()
        { }

        /// <summary>
        /// This Exception is thrown if the user tries to make an invalid input
        /// </summary>
        /// <param name="message">The error message which is thrown</param>
        public InvalidInputException(string message) : base(message) { }

        /// <summary>
        /// This Exception is thrown if the user tries to make an invalid input
        /// </summary>
        /// <param name="message">The error message which is thrown</param>
        /// <param name="inner">The base class</param>
        public InvalidInputException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}