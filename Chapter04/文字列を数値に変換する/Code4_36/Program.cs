namespace Code4_36
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var str = "1234";

            if (int.TryParse(str, out var height))
            {
                Console.WriteLine(height + "変換成功");
            }
            else
            {
                Console.WriteLine("変換できません");
            }

            //Parseで変換する場合は例外処理が必要となる
            try
            {
                int num = int.Parse(str);
            }
            catch (Exception)
            {
                Console.WriteLine("変換できません");
            }
        }
    }
}
