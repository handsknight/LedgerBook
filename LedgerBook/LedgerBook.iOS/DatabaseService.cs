using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LedgerBook.iOS;
using Xamarin.Forms;
using System.Diagnostics;
using System.IO;

using Foundation;
using UIKit;

[assembly: Dependency(typeof(DatabaseService))]
namespace LedgerBook.iOS
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
                var existingDb = NSBundle.MainBundle.PathForResource("LedgerBookDB", "db3");
                File.Copy(existingDb, path);
            }

            var iOSPlatform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.Net.SQLiteConnection(iOSPlatform, path);

            // Return the database connection 
            return connection;
        }
    }
}