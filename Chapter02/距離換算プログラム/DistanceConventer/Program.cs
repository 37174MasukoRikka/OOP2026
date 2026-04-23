
namespace DistanceConventer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 3 && int.TryParse(args[1], out int start) && int.TryParse(args[2], out int end))
            {

                if (args[0] == "-tom")
                {
                    PrintFeetToMeterList(start, end); //-tom メートルへの変換
                }
                else if (args[0] == "-tof")
                {
                    PrintMeterToFeetList(start, end); //-tof フィートへの変換
                }
                else
                {
                    Console.WriteLine("引数形式エラー");
                }
            }
            else
            {
                Console.WriteLine("引数エラー");
            }
        }
        //フィートからメートルへの対応表を出力
        private static void PrintFeetToMeterList(int start, int end)
        {           
            for (int feet = start; feet <= end; feet++)
            {
                double meter = FeetConverter.ToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");  //$"{}
            }

        }
        //メートルからフィートへの対応表を出力
        private static void PrintMeterToFeetList(int start, int end)
        {           
            for (int meter = start; meter <= end; meter++)
            {
                double feet = FeetConverter.FromMeter(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }

    }
}

