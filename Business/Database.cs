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
using System.IO;

namespace XamarinHangMan2020
{
    public static class Database
    {
        public static SQLiteConnection Con;
        public static string dbFilePath;
        public static string dbName;

        //init db
        static Database()
        {
            dbName = "hangmanleaderboard.sqlite";
            dbFilePath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData), dbName);
            if (dbFilePath != null)
            {
                Con = new SQLiteConnection(dbFilePath);
            }
        }

        //init leaderboard
        public static List<TableLeaderboard> LoadLeaderboard()
        {
            Con.CreateTable<TableLeaderboard>();

            //if there are no data inside the table, generate a fake data
            if(Con.Table<TableLeaderboard>().Count() == 0)
            {
                List<TableLeaderboard> tempList = LoadFakeData();

                foreach (TableLeaderboard player in tempList)
                {
                    Con.Insert(player);
                }
            }

            return Con.Table<TableLeaderboard>().ToList();
        }

        public static void AddPlayerScore(string name, int score)
        {
            try
            {
                var newPlayerScore = new TableLeaderboard() { Name = name, Score = score };
                Con.Insert(newPlayerScore);
            }
            catch (Exception e)
            {
                Console.WriteLine("Database SQLite Error thrown: " + e);
                throw e;
            }
        }


        //load fake data method (This method will only be initiated if there are no data inside)
        private static List<TableLeaderboard> LoadFakeData()
        {
            string[] name = { "Declan", "Winston", "O-10", "Bee Lat", "Mr. Noob" };
            int[] score = { 4, 9, 4, 5, 1 };

            TableLeaderboard[] fakeLeaderboard = new TableLeaderboard[5];

            for(int i = 0; i < 5; i++)
            {
                TableLeaderboard data = new TableLeaderboard();
                data.Name = name[i];
                data.Score = score[i];

                fakeLeaderboard[i] = data;
            }

            return fakeLeaderboard.ToList();
        }
    }
}