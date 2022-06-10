using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.ViewModel.Helpers
{
    public class DatabaseHelper
    {
        private static string _databaseFile = Path.Combine(Environment.CurrentDirectory, "notesDatabase.db3");
        private static string _databasePath = "https://notes-app-wpf-ff8cd-default-rtdb.europe-west1.firebasedatabase.app/";

        public static async Task<bool> InsertAsync<T>(T item)
        {
            /*bool result = false;

            using (var connection = new SQLiteConnection(_databaseFile))
            {
                connection.CreateTable<T>();
                int rows = connection.Insert(item);

                if (rows > 0)
                    result = true;
            }

            return result;*/

            string bodyJson = JsonConvert.SerializeObject(item);
            var content = new StringContent(bodyJson, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                var result = await client.PostAsync($"{_databasePath}{item.GetType().Name.ToLower()}.json", content);

                if (result.IsSuccessStatusCode)
                    return true;
                else
                    return false;
            }
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
