using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SQLite;

namespace SingletonPattern
{
    class MyDbManager
    {
        private static MyDbManager instance;

        private static SQLiteConnection conn;

        private static readonly object LOCK = new object();

        static MyDbManager()
        {
            instance = new MyDbManager();

            conn = new SQLiteConnection("Data Source=sqlite.db");
            conn.ConnectionString = "Data Source=sqlite.db";
            conn.Open();

            Console.WriteLine("Connection to DB established");
        }

        protected MyDbManager() { }

        public static MyDbManager Instance
        {
            get { return instance; }
        }

        ~MyDbManager()
        {
            conn.Close();
            conn.Dispose();
            instance = null;
            Console.WriteLine("Connection to DB closed");
        }

        public bool Query(string query)
        {
            lock (LOCK) {
                SQLiteCommand command = null;
                try {
                    command = new SQLiteCommand(conn);
                    command.CommandText = query;
                    command.ExecuteNonQuery();
                    command.Dispose();
                } catch {
                    return false;
                } finally {
                    command.Dispose();
                }
                return true;
            }
        }
    }
}
