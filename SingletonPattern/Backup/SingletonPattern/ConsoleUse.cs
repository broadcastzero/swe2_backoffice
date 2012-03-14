using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingletonPattern
{
    class ConsoleUse
    {
        private MyLogger Log;
        private MyDbManager manager;
        //private MyLazyLogger Log;

        public ConsoleUse() 
        {
            Console.WriteLine("Entered Constructor");
            Log = MyLogger.Instance;

            manager = MyDbManager.Instance;
            if (!manager.Query("CREATE TABLE IF NOT EXISTS beispiel ( id INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, name VARCHAR(100) NOT NULL);")) {
                Log.Log("Error creating table");
            }

            if (!manager.Query("INSERT INTO beispiel values (1, 'TEST1')")) {
                Log.Log("Error inserting values");
            }

            if (!manager.Query("DELETE FROM beispiel")) {
                Log.Log("Error deleting values");
            }
        }
    }
}
