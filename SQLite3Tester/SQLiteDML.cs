using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace SQLite3Tester
{
    public class SQLiteDML
    {
        /// <summary>建立資料庫連線</summary>
        /// <param name="database">DB路徑</param>
        /// <returns></returns>
        public SQLiteConnection OpenConnection(string database)
        {
            var conntion = new SQLiteConnection()
            {
                ConnectionString = $@"Data Source={database};Version=3;New=False;Compress=True;"
            };
            if (conntion.State == ConnectionState.Open) conntion.Close();
            conntion.Open();
            return conntion;
        }
    }
}
