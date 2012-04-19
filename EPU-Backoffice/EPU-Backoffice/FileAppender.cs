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

        // The maximum size of the logfile
        private static int maxSize;

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
            FileAppender.maxSize = (int)config.GetValue("maxLogFileSize", typeof(int));
        }

        /// <summary>
        /// Writes the logging message into the text logger.
        /// </summary>
        /// <param name="message">The logging message</param>
        public void Write(string message)
        {
            // check if logfile is too big. if that's the case, rename and create new.
            if(File.Exists(FileAppender.LogFilePath))
            {
                try
                {
                    FileInfo f = new FileInfo(FileAppender.LogFilePath);
                    if (f.Length > FileAppender.maxSize)
                    {
                        // save old logfile name
                        string oldname = Path.GetFileNameWithoutExtension(FileAppender.LogFilePath);
                        string ext = Path.GetExtension(FileAppender.LogFilePath);

                        // delete old backup file if there is one
                        if (File.Exists(oldname + "_backup" + ext))
                        {
                            File.Delete(oldname + "_backup" + ext);
                        }

                        // rename current logfile in backup file
                        File.Move(FileAppender.LogFilePath, oldname + "_backup" + ext);

                        // create new, empty logfile with the old name
                        File.Create(FileAppender.LogFilePath);
                    }
                }
                catch (IOException e)
                {
                    Trace.WriteLine("Logfile too big! Moving and recreating failed!");
                    Trace.WriteLine(e.Message);
                }
            }

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
