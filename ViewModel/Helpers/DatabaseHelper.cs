using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace EvernoteClone.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        private static string _databaseFile = Path.Combine(Environment.CurrentDirectory, "notesDatabase.db3");

        public static bool Insert<T>(T item)
        {
            bool result = false;

            using (var connection = new SQLiteConnection(_databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Insert(item);

                if (rows > 0)
                    result = true;
            }

            return result;
        }

        public static bool Update<T>(T item)
        {
            bool result = false;

            using (var connection = new SQLiteConnection(_databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Update(item);

                if (rows > 0)
                    result = true;
            }

            return result;
        }

        public static bool Delete<T>(T item)
        {
            bool result = false;

            using (var connection = new SQLiteConnection(_databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Delete(item);

                if (rows > 0)
                    result = true;
            }

            return result;
        }

        public static List<T> Read<T>() where T : new()
        {
            List<T>? items;

            using (var connection = new SQLiteConnection(_databaseFile))
            {
                connection.CreateTable<T>();
                items = connection.Table<T>().ToList();
            }

            return items;
        }
    }
}
