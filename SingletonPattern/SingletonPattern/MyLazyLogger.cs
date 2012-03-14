using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    class MyLazyLogger
    {
        private static MyLazyLogger instance = null;

        protected MyLazyLogger() { }

        public static MyLazyLogger Instance
        {
            get
            {
                if (instance == null) {
                    Console.WriteLine("Instance created\n");
                    return new MyLazyLogger();
                }
                return instance; 
            }
        }

        public void Log(string user)
        {
            Console.WriteLine(DateTime.Today);
            Console.WriteLine(user);
            Console.WriteLine(DateTime.Now.TimeOfDay);
        }
    }
}
