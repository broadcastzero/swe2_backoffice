using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SingletonPattern
{
    class MyLogger
    {
        private static MyLogger instance;

        static MyLogger()
        {
            instance = new MyLogger();
            Console.WriteLine("Instance Created\n");
        }

        protected MyLogger() { }

        public static MyLogger Instance
        {
            get { return instance; }
        }

        public void Log(string msg)
        {
            using (StreamWriter sw = File.AppendText("log.txt")) {
                sw.WriteLine(DateTime.Today);
                sw.WriteLine(msg);
                sw.WriteLine(DateTime.Now.TimeOfDay);
            }
        }
    }
}
