// -----------------------------------------------------------------------
// <copyright file="FileAppender.cs" company="">
// TODO: Update copyright text.
// </copyright>
// -----------------------------------------------------------------------

namespace EPUBackoffice
{
    using System;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class FileAppender : IAppender
    {
        private static string logFilePath;

        /// <summary>
        /// The path in which the textfile log shall be created
        /// </summary>
        public static string LogFilePath { get { return logFilePath; } }

        /// <summary>
        /// get path of logfile from config file or use standard filename
        /// </summary>
        public void Configure()
        {
            AppSettingsReader config = new AppSettingsReader();
            FileAppender.logFilePath = config.GetValue("LogTextFilePath", typeof(string)).ToString();
        }

        /// <summary>
        /// Writes the logging message into the text logger.
        /// </summary>
        /// <param name="message">The logging message</param>
        public void Write(string message)
        {
            // check if logfile is too big
            // TODO: create new logfile and rename old to backup


            // Write to file
            try
            {
                using (StreamWriter sw = File.AppendText(FileAppender.logFilePath))
                {
                    sw.WriteLine(message);
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
