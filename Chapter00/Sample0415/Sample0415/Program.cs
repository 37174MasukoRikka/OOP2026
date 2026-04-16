using System.Security.Cryptography.X509Certificates;

namespace Sample0415
{
    internal class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[10];
            int sum = 0;
            //入力
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + i + "]=");
                array[i] = int.Parse(Console.ReadLine());
            }
            //集計
            //for (int i = 0; i < array.Length; i++)
            //{
            //    sum += array[i];
            //}
            Console.WriteLine(); //改行

            //出力(配列の)
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("array[" + i + "]:");
                //アスタリスク出力
                astOut(array[i]);
            }
            //合計を出力
            Console.WriteLine("合計" + array.Where(n => n % 2 == 0).Sum());
        }      
        static void astOut(int num){
            for (int j = 0; j < num; j++) { 
                Console.Write("*");
            }
            Console.WriteLine();//改行
        }
    }
}



