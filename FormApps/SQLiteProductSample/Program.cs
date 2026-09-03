namespace SQLiteProductSample;

internal static class Program {
    [STAThread]
    static void Main() {
        ApplicationConfiguration.Initialize();

        try {
            //SQLiteデータベースを初期化する
            //products.dbが存在しない場合は作成され
            //Productsテーブルも存在しない場合だけ作成される
            Database.Initializ();
            Application.Run(new Form1());
        }
        catch (Exception ex) {
            MessageBox.Show(
                $"アプリケーションの起動に失敗しました。\n\n{ex.Message}",
                "起動エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
