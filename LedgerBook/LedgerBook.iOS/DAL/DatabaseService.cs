using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LedgerBook.Interfaces;
using LedgerBook.iOS.DAL;

using Foundation;
using UIKit;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(DatabaseService))]
namespace LedgerBook.iOS.DAL
{
    public class DatabaseService : IDBInterface
    {
        public DatabaseService()
        {
        }
        public SQLite.Net.SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "LedgerBookDB.db3";

            string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

            if (!Directory.Exists(libFolder))
            {
                Directory.CreateDirectory(libFolder);
            }
            string path = Path.Combine(libFolder, sqliteFilename);

            // This is where we copy in the pre-created database
            if (!File.Exists(path))
            {
                var existingDb = NSBundle.MainBundle.PathForResource("Employee", "db");
                File.Copy(existingDb, path);
            }

            var iOSPlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(iOSPlatform, path);

            // Return the database connection 
            return connection;
        }
    }
}