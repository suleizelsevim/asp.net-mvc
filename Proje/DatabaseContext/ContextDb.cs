using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;

namespace Proje.DatabaseContext
{
    public class ContextDb
    {
        private string _connectionString = "Data Source=Database.sqlite;Version=3;";

        public ContextDb()
        {
            var con = new SQLiteConnection(_connectionString);
        }
    }
}