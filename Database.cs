using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SQLite;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.Util;

namespace XamarinHangMan2020
{
    class Database
    {
        //define the folder that you are going to store the database inside the phone
        string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

        //initialise database
        public bool CreateDatabase()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Leaderboard.db")))
                {
                    connection.CreateTable<Leaderboard>();
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("SQLite", e.Message.ToString());
                return false;
                throw;
            }
        }

        //Add or Insert Data
        public bool insertIntoTable(Leaderboard data)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Leaderboard.dbb")))
                {
                    connection.Insert(data);
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("SQLite", e.Message.ToString());
                return false;
                throw;
            }
        }

        //selecting table
        public List<Leaderboard> selectTable()
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Leaderboard.db")))
                {
                    return connection.Table<Leaderboard>().ToList();
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("SQLite", e.Message.ToString());
                return null;
                throw;
            }
        }

        //removing data
        public bool removeTable(Leaderboard data)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Leaderboard.db")))
                {
                    connection.Delete(data);
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("SQLite", e.Message.ToString());
                return false;
                throw;
            }
        }

        //select operation
        public bool selectTable(int Id)
        {
            try
            {
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Leaderboard.db")))
                {
                    connection.Query<Leaderboard>("SELECT * FROM Person Where Id=?", Id);
                    return true;
                }
            }
            catch (SQLiteException e)
            {
                Console.WriteLine("SQLite", e.Message.ToString());
                return false;
                throw;
            }
        }
    }
}