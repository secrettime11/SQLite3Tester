using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SQLite3Tester
{
    class SQliteDb
    {
        string savePath = Application.StartupPath + @"\Data.db";
        string ConnectionString = string.Empty;


        /// <summary>建立資料庫連線</summary>
        /// <param name="database">資料庫名稱</param>
        /// <returns></returns>
        public SQLiteConnection OpenConnection(string database)
        {
            var conntion = new SQLiteConnection()
            {
                ConnectionString = $@"Data Source={database};Version=3;New=False;Compress=True;"
            };
            ConShutdown(conntion);
            conntion.Open();
            return conntion;
        }
        /// <summary>建立新資料庫</summary>
        /// <param name="database">資料庫名稱</param>
        public void CreateDatabase(string database)
        {
            var connection = new SQLiteConnection()
            {
                ConnectionString = $"Data Source={database};Version=3;New=True;Compress=True;"
            };
            connection.Open();
            ConShutdown(connection);
        }
        /// <summary>建立新資料表</summary>
        /// <param name="database">資料庫名稱</param>
        /// <param name="sqlCreateTable">建立資料表的 SQL 語句</param>
        public bool CreateTable(string database, string sqlCreateTable)
        {
            var connection = OpenConnection(database);
            var command = new SQLiteCommand(sqlCreateTable, connection);
            var mySqlTransaction = connection.BeginTransaction();
            try
            {
                command.Transaction = mySqlTransaction;
                command.ExecuteNonQuery();
                mySqlTransaction.Commit();
            }
            catch (Exception)
            {
                mySqlTransaction.Rollback();
                return false;
            }
            ConShutdown(connection);
            return true;
        }
        /// <summary>新增\修改\刪除資料</summary>
        /// <param name="database">資料庫名稱</param>
        /// <param name="sqlManipulate">資料操作的 SQL 語句</param>
        public void Manipulate(string database, string sqlManipulate)
        {
            using (SQLiteConnection connection = new SQLiteConnection(GetConnectString()))
            {
                connection.Open();
                var command = new SQLiteCommand(sqlManipulate, connection);
                var mySqlTransaction = connection.BeginTransaction();
                try
                {
                    command.Transaction = mySqlTransaction;
                    command.ExecuteNonQuery();
                    mySqlTransaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    mySqlTransaction.Rollback();
                }
                ConShutdown(connection);
            }
        }
        /// <summary>
        /// 檢查資料表存不存在 True = 存在
        /// </summary>
        /// <param name="database">database</param>
        /// <param name="tableName">table name</param>
        /// <returns></returns>
        public bool CheckDatatable(string tableName)
        {
            var connection = OpenConnection(savePath);
            SQLiteCommand mDbCmd = connection.CreateCommand();
            mDbCmd.CommandText = $"SELECT COUNT(*) FROM sqlite_master where type='table' and name='{tableName}';";
            if (0 == Convert.ToInt32(mDbCmd.ExecuteScalar()))
            {
                ConShutdown(connection);
                return false;
            }
            else
            {
                ConShutdown(connection);
                return true;
            }
        }
        /// <summary>
        /// 檢查資料表有沒該日期資料 false = 沒有
        /// </summary>
        /// <param name="database"></param>
        /// <param name="tableName"></param>
        /// <param name="date">20200828</param>
        /// <returns></returns>
        public bool CheckDateExist(string database, string tableName, string date)
        {
            var connection = OpenConnection(database);
            SQLiteCommand mDbCmd = connection.CreateCommand();
            mDbCmd.CommandText = $"SELECT * FROM {tableName} where Date = '{date}' LIMIT 1;";
            if (mDbCmd.ExecuteScalar() == null)
            {
                ConShutdown(connection);
                return false;
            }
            else
            {
                ConShutdown(connection);
                return true;
            }
        }
        /// <summary>
        /// 建立資料表字串
        /// </summary>
        /// <param name="tableName">資料表名稱</param>
        /// <param name="header_">資料表欄位名稱</param>
        /// <returns></returns>
        public string CreateTableString(string tableName, List<string> header_)
        {
            int header_count = header_.Count();
            int counter = 1;
            // 建立資料表 TestTable
            var createtablestring = $@"CREATE TABLE {tableName} (";

            foreach (var header in header_)
            {
                if (counter == header_count)
                    createtablestring += $"{header} VARCHAR(32));";
                else
                    createtablestring += $"{header} VARCHAR(32),";
                counter++;
            }
            return createtablestring;
        }
        /// <summary>
        /// Add data to sqlite
        /// </summary>
        /// <param name="database">database name</param>
        /// <param name="tableName">table name</param>
        /// <param name="header_">header</param>
        /// <param name="data_">data list</param>
        /// <param name="insertString">command</param>
        public bool DataAdd(string database, string tableName, List<string> header_, List<string> data_)
        {
            string insertString = String.Empty;
            int header_count = header_.Count();
            int counter = 1;
            // 建立 SQLite 資料庫
            if (!File.Exists(database))
                CreateDatabase(database);

            // Final string send to SQL
            try
            {
                foreach (var data in data_)
                {
                    counter = 1;

                    insertString += $@"INSERT INTO {tableName} (";
                    foreach (var header in header_)
                    {
                        // Last column
                        if (counter == header_count)
                            insertString += $"{header})";
                        else
                            insertString += $"{header}, ";
                        counter++;
                    }
                    insertString += $" VALUES (";
                    string[] value = data.Split('_');
                    for (int i = 0; i < value.Count(); i++)
                    {
                        if (i == value.Count() - 1)
                            insertString += $"'{value[i]}');" + Environment.NewLine;
                        else
                            insertString += $"'{value[i]}', ";
                    }
                }
                // Insert into datatable
                Manipulate(database, insertString);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public DataTable TableInfo(string database)
        {
            using (SQLiteConnection conn = new SQLiteConnection($@"Data Source={database};Version=3;New=False;Compress=True;"))
            {
                conn.Open();
                DataTable schemaTable = conn.GetSchema("TABLES");
                //  Remove specific columns in the data table
                schemaTable.Columns.Remove("TABLE_CATALOG");
                //  Set the sequence number of a specific column
                schemaTable.Columns["TABLE_NAME"].SetOrdinal(1);
                return schemaTable;
            }
        }

        private void ConShutdown(SQLiteConnection connection)
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
                connection.Dispose();
            }
        }

        string GetConnectString()
        {
            return ConnectionString = $@"Data Source={savePath};Version=3;New=False;Compress=True;";
        }
    }
}
