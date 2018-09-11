using System;
using SQLite;
using SQLite.Net.Attributes;

namespace LedgerBook.Models
{
    [Table("AppInfo")]
    public class AppInfo
    {
        [PrimaryKey,Unique, Column("AppName")]
        public string AppName { get; set; }
        [Column("AppVersion")]
        public string AppVersion { get; set; }
        [Column("AppAuthur")]
        public string AppAuthur { get; set; }
        [Column("ContactPhone")]
        public string ContactPhone { get; set; }
        [Column("ContactEmail")]
        public string ContactEmail { get; set; }
         
    }
}