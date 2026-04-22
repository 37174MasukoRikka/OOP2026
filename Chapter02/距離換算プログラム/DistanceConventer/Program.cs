
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
        private static void PrintFeetToMeterList(int height, int stop)
        {
            //フィートからメートルへの対応表を出力
            for (int feet = height; feet <= stop; feet++)
            {
                double meter = FeetToMeter(feet);
                Console.WriteLine($"{feet}ft = {meter:0.0000}m");  //$"{}
            }

        }
        private static void PrintMeterToFeetList(int start, int stop)
        {
            //メートルからフィートへの対応表を出力
            for (int meter = start; meter <= stop; meter++)
            {
                double feet = MeterToFeet(meter);
                Console.WriteLine($"{meter}m = {feet:0.0000}ft");
            }
        }

        //フィートからメートルを求める
        static double FeetToMeter(int feet)
        {
            return feet * 0.3048;
        }

        //メートルからフィートを求める
        static double MeterToFeet(int meter)
        {
            return meter / 0.3048;
        }
    }
}
