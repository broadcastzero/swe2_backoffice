// -----------------------------------------------------------------------
// <copyright file="DataBaseException.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.UserExceptions
{
    using System;

    /// <summary>
    /// This Exception is thrown if the user tries to access an entry of the database which does not exist.
    /// </summary>

    [Serializable]
    public class DataBaseException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the DataBaseException class. This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        public DataBaseException()
        { }

        /// <summary>
        /// Initializes a new instance of the DataBaseException class. This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        /// <param name="message">The error message which is thrown</param>
        public DataBaseException(string message) : base(message) { }

        /// <summary>
        /// Initializes a new instance of the DataBaseException class. This Exception is thrown if the user tries to open or save an invalid file.
        /// </summary>
        /// <param name="message">The error message which is thrown</param>
        /// <param name="inner">The base class</param>
        public DataBaseException(string message, Exception inner)
            : base(message, inner)
        { }
    }
}