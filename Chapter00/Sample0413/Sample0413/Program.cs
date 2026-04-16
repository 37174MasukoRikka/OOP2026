namespace Sample0413
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("表示回数：");
            string? inputNum = Console.ReadLine();//入力

            int count = int.Parse(inputNum);    //整数に変換
            int i = 0;
            while (i < count ){
                if ((i + 1) % 2 == 0){
                    Console.WriteLine((i + 1) + ":" + "群馬県太田市");//画面出力
                }
                i++;
            }
        }
    }
}
