namespace SQLiteProductSample;

internal static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();

        try
        {
            
            Application.Run(new Form1());
        }
        catch (Exception ex)
        {
            MessageBox.Show(
                $"アプリケーションの起動に失敗しました。\n\n{ex.Message}",
                "起動エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
