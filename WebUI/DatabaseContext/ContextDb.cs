using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SQLite;
using Dapper;
using System.Data;
using System.Data.Common;

namespace WebUI.DatabaseContext
{
    public class ContextDb : IDisposable
    {
        public IDbConnection _connection;
        private string _connectionString = @"Data Source=d:\mydb.db;Version=3;";

        public ContextDb()
        {
            _connection = new SQLiteConnection(_connectionString);
            _connection.Open();
        }

        public void Dispose() //işlemi sonlandırır ve bellekten atar
        {
            if (_connection != null)
                _connection.Dispose();
        }
    }
}