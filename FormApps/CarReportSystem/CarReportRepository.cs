using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing.Imaging;
using System.Xml.Linq;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CarReportSystem {
    public class CarReportRepository {
        public List<CarReport> GetAll() {

            var carreports = new List<CarReport>();
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();

            //CarReportsテーブルを作るSQL
            command.CommandText =
            """
            SELECT Id, Date, Author, Maker, CarName, Report, Picture
            FROM CarReports
            ORDER BY Id;
            """;
            //結果業を返さないSQLを実行する
            using var reader = command.ExecuteReader();

            while (reader.Read()) {
                carreports.Add(new CarReport {
                    Id = reader.GetInt32(0),    //0列目:Id
                    Date = reader.GetDateTime(1), //1列目:Date
                    Author = reader.GetString(2),  //2列目:Author
                    Maker = (CarReport.MakerGroup)reader.GetInt32(3), //3列目:Maker
                    CarName = reader.GetString(4), //4列目:CarName
                    Report = reader.GetString(5), //5列目:Report
                    //Picture =          //6列目:Picture
                });
            }
            return carreports;
        }

        public int Add(string name, int price) {
            //接続オブジェクトを生成する。
            using var connection = Database.GetConnection();
            //DBを開く
            connection.Open();

            //SQLを実行するためのコマンドオブジェクトを作る
            using var command = connection.CreateCommand();

            command.CommandText =
                """
                INSERT INTO CarReports
                (Date, Author, Maker, CarName, Report, Picture)
                VALUES 
                ($date, $author, $maker, $carName, $report, picture);
                
                SELECT last_insert_rowid(); 
                     
                """;

            command.Parameters.AddWithValue("$date", name);
            command.Parameters.AddWithValue("$author", price);
            command.Parameters.AddWithValue("$maker", price);
            command.Parameters.AddWithValue("$carName", price);
            command.Parameters.AddWithValue("$report", price);
            command.Parameters.AddWithValue("$picture", price);

            //一つの値を返しSQLを実行する
            var result = command.ExecuteScalar();

            if (result is null)
                throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");

            //SQLiteのINTEGERはlongとして返るため、intへ変換する。
            return Convert.ToInt32((long)result);
        }


        // ImageをSQLiteへ保存できるbyte[]へ変換する
        private static byte[]? ImageToBytes(Image? image) {
            if (image is null) return null;

            using var stream = new MemoryStream();
            // DBへはPNG形式で保存
            image.Save(stream, ImageFormat.Png);
            return stream.ToArray();
        }

        // SQLiteのBLOB（byte[]）をImageへ変換する
        private static Image BytesToImage(byte[] data) {
            using var stream = new MemoryStream(data);
            using var image = Image.FromStream(stream);
            // MemoryStream破棄後も利用できるようBitmapとしてコピーする。
            return new Bitmap(image);
        }
    }
}
