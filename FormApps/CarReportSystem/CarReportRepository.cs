using System.Drawing.Imaging;
using System.Globalization;
using static CarReportSystem.CarReport;

namespace CarReportSystem {
    public class CarReportRepository {
        public List<CarReport> GetAll() {

            var reports = new List<CarReport>();
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
                reports.Add(new CarReport {
                    Id = reader.GetInt32(0),    
                    Date = DateTime.ParseExact(
                       reader.GetString(1),
                       "yyyy-mm-dd",
                       CultureInfo.InvariantCulture),                       
                    Author = reader.GetString(2),  
                    Maker = (CarReport.MakerGroup)reader.GetInt32(3), 
                    CarName = reader.GetString(4), 
                    Report = reader.GetString(5), 
                    Picture = reader.IsDBNull(6) 
                                  ? null : BytesToImage(reader.GetFieldValue < byte[]>(6))                  
                });
            }
            return reports;
        }      

        public int Add(DateTime date, string author, MakerGroup maker, string carName, string report, Image? picture) {
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

            command.Parameters.AddWithValue("$date", date);
            command.Parameters.AddWithValue("$author", author);
            command.Parameters.AddWithValue("$maker", maker);
            command.Parameters.AddWithValue("$carName", carName);
            command.Parameters.AddWithValue("$report", report);
            command.Parameters.AddWithValue("$picture", picture);

            //一つの値を返しSQLを実行する
            var result = command.ExecuteScalar();

            if (result is null)
                throw new InvalidOperationException("登録した商品のIDを取得できませんでした。");

            //SQLiteのINTEGERはlongとして返るため、intへ変換する。
            return Convert.ToInt32((long)result);
        }
        public void Update(CarReport carReport) {
            //接続オブジェクトを生成する。
            using var connection = Database.GetConnection();
            connection.Open();
            using var command = connection.CreateCommand();

            command.CommandText =
                """
                UPDATE CarReports
                SET Date = $date, Author = $author, Maker = $maker,
                    CarName = $carName, Report = $report, Picture = $picture
                WHERE Id = $id;                               
                """;
        }

        public void Delete(int id) {
            using var connection = Database.GetConnection();
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText =
                """
                DELETE FROM CarReports
                WHERE Id = $id;

                """;
             
            command.Parameters.AddWithValue("$id", id);
            command.ExecuteNonQuery();
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

