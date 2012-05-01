// -----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Marvin&Felix">
// You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace EPU_Backoffice_Panels.LoggingFramework
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.Text;
    using System.IO;

    /// <summary>
    /// This class serves as a logger, which writes out messages in a textfile
    /// </summary>
    public class Logger
    {
        private static Logger instance;

        /// <summary>
        /// The level that shall be logged (info, warning, error)
        /// </summary>
        public static int Loggerlevel { get; set; }

        /// <summary>
        /// A static list of all appenders of the logger.
        /// </summary>
        public static List<IAppender> Appenders { get; set; }

        /// <summary>
        /// The logging level
        /// </summary>
        public enum Level 
        { 
            /// <summary>
            /// only info messages
            /// </summary>
            Info = 0,

            /// <summary>
            /// Infomessages and Warnings
            /// </summary>
            Warning = 1,

            /// <summary>
            /// Infomessages, Warnings and Errors
            /// </summary>
            Error = 2
        }

        /// <summary>
        /// The instance of the singleton class Logger.
        /// </summary>
        public static Logger Instance
        {
            get { return instance; }
        }

        /// <summary>
        /// Creates an instance of the Logger class if it does not exist yet.
        /// </summary>
        static Logger()
        {
            if (Logger.instance == null)
            {
                instance = new Logger();
            }

            // create new List of appenders
            if (Logger.Appenders == null)
            {
                Logger.Appenders = new List<IAppender>();
            }
        }

        /// <summary>
        /// Constructor of singleton class Logger
        /// </summary>
        protected Logger()
        {
            
        }

        /// <summary>
        /// Log the message.
        /// </summary>
        /// <param name="lev">The warning level: 0...info, 1...warning, 2...error (see enumeration)</param>
        /// <param name="msg">The message which has to be logged.</param>
        public void Log(Level lev, string msg)
        {
            int level = (int)lev;

            // ignore, if level is below minimum logging level
            if (level < Logger.Loggerlevel)
            {
                return;
            }

            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Today.ToShortDateString());
            sb.Append(" - ");
            sb.Append(DateTime.Now.ToShortTimeString());
            
            switch (level)
            {
               case 0: sb.Append(" Info: ");
                   break;
               case 1: sb.Append(" Warning: ");
                   break;
               case 2: sb.Append(" Error: ");
                   break;
               default: sb.Append(" Message: ");
                   break;
            }

            sb.Append(msg);

            // send string to each appender in Appender List
            foreach (IAppender appender in Logger.Appenders)
            {
                appender.Write(sb.ToString());
            }
        }
    }
}
