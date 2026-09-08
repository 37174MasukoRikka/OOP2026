using Microsoft.Data.Sqlite;

namespace CarReportSystem {
    internal class Database {
        private static readonly string DatabasePath =
            Path.Combine(AppContext.BaseDirectory, "carreport.db");

        private static readonly string ConnectionString =
            $"Data Source={DatabasePath}";

        
        public static SqliteConnection GetConnection()
            => new SqliteConnection(ConnectionString);
        
        public static void Initialize() {
            //接続してCREATE TABLE IF NOT EXISTSを実行
            using var connection = GetConnection();

            //DBを開く
            connection.Open();

            //SQLを実行するためのコマンドオブジェクトを作る
            using var command = connection.CreateCommand();

            //CarReportsテーブルを作るSQL
            //IF NOT EXISTSにより、既にテーブルがあってもエラーにならない
            command.CommandText =
                """
            CREATE TABLE IF NOT EXISTS CarReports(
                Id      INTEGER PRIMARY KEY AUTOINCREMENT,
                Date    TEXT NOT NULL,
                Author  TEXT NOT NULL,
                Maker   INTEGER NOT NULL,
                CarName TEXT NOT NULL,
                Report  TEXT NOT NULL,
                Picture BLOB
                        
            );
            """;
            //結果行を返さないSQLを実行する
            command.ExecuteNonQuery();
        }
    }
}
