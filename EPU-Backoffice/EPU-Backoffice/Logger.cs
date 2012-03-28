// -----------------------------------------------------------------------
// <copyright file="Logger.cs" company="Marvin&Felix">
// TODO: You can use the source code just as you wish. Exception: do not copy the whole or parts of this file, 
// if you also have to submit this homework.
// </copyright>
// -----------------------------------------------------------------------

namespace Logger
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.IO;

    /// <summary>
    /// This class serves as a logger, which writes out messages in a textfile
    /// </summary>
    public class Logger
    {
        private static Logger _instance;
        private static string logFilePath = "logs.txt";

        /// <summary>
        /// The instance of the singleton class Logger.
        /// </summary>
        public static Logger Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Creates an instance of the Logger class.
        /// </summary>
        static Logger()
        {
            _instance = new Logger();
        }

        /// <summary>
        /// Constructor of singleton class Logger.
        /// </summary>
        protected Logger()
        { 
            // get path of logfile from config file or use standard filename
        }

        /// <summary>
        /// Log the message.
        /// </summary>
        /// <param name="level">The warning level: 0...info, 1...warning, 2...error</param>
        /// <param name="msg">The message which has to be logged.</param>
        public void Log(int level, string msg)
        {
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

            // Write to file
            try
            {
                using (StreamWriter sw = File.AppendText(Logger.logFilePath))
                {
                    sw.WriteLine(sb);
                }
            }
            catch (IOException e)
            {
                Trace.WriteLine("Cannot write into logfile.");
                Trace.WriteLine(e.Message);
                Trace.WriteLine(e.StackTrace);
            }
            catch (UnauthorizedAccessException e)
            {
                Trace.WriteLine("Access to logfile denied.");
                Trace.WriteLine(e.Message);
            }
        }
    }
}
