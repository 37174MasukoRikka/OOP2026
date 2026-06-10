using System;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.Write("整数文字列：");
            var str = Console.ReadLine();

            if (int.TryParse(str, out var num)) {
                Console.WriteLine($"{num:#,0}");
            } else {
                Console.WriteLine("変換できません");
            }
        }
    }
}
