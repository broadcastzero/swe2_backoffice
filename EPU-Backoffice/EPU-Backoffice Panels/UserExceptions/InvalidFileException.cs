﻿// -----------------------------------------------------------------------
// <copyright file="InvalidFileException.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.UserExceptions
{
    using System;

    /// <summary>
    /// This Exception is thrown if the user tries to open or save an invalid file.
    /// </summary>

    [Serializable]
    public class InvalidFileException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the InvalidFileException class. This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        public InvalidFileException()
        { }

        /// <summary>
        /// Initializes a new instance of the InvalidFileException class. This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        /// <param name="message">The error message which is thrown</param>
        public InvalidFileException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the InvalidFileException class. This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        /// <param name="message">The error message which is thrown</param>
        /// <param name="inner">The base class</param>
        public InvalidFileException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}