// -----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// This class serves as a logger, which writes out messages in a textfile
    /// </summary>
    public class Logger : IDisposable
    {
        private bool disposed = false;

        /// <summary>
        /// Creates an instance of the Logger class.
        /// </summary>
        public Logger()
        { }

        /// <summary>
        /// Writes out info messages to a textfile.
        /// </summary>
        /// <param name="message">The to-be-written string.</param>
        public void Info(string message)
        { }

        /// <summary>
        /// Writes out warning messages to a textfile.
        /// </summary>
        /// <param name="message">The to-be-written string.</param>
        public void Warn(string message)
        { }

        /// <summary>
        /// Writes out error messages to a textfile.
        /// </summary>
        /// <param name="message">The to-be-written string.</param>
        public void Error(string message)
        { }

        /// <summary>
        /// Calls Dispose()-method if not yet disposed
        /// </summary>
        public void Dispose()
        {
            if (!disposed)
            {
                Dispose(true);
                GC.SuppressFinalize(this);
                disposed = true;
            }
        }

         /// <summary>
         /// Cleans up own and foreign ressources
         /// </summary>
         /// <param name="disposing">Decision, if also own objects shall be freed or only foreign ressources</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Clean up of own objects
            }
            // Clean up of other objects
        }

        /// <summary>
        /// Destructor - calls Dispose(false) and frees foreign ressources.
        /// </summary>
        ~Logger()
        {
            Dispose(false);
        }
    }
}
