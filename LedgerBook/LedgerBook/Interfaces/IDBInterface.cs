using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Text;

namespace LedgerBook.Interfaces
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
