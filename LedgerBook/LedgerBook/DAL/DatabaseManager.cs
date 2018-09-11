using SQLite.Net;
using System.Collections.Generic;
using Xamarin.Forms;
using LedgerBook.Models;
using LedgerBook.Interfaces;

namespace LedgerBook.DAL
{
    public class DatabaseManager
    {
        SQLiteConnection dbConnection;
        public DatabaseManager()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }


        public List<AppInfo> GetAllAppInfo()
        {
            return dbConnection.Query<AppInfo>("Select * From [AppInfo]");
        }

        //public int SaveEmployee(Employee aEmployee)

        //{
        //    return dbConnection.Insert(aEmployee);
        //}
    }
}
