using System;

namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            Console.WriteLine("---4.2.1---");
            Exercise1();
            Console.WriteLine("\n---4.2.2---");
            Exercise2();
            Console.WriteLine("\n---4.2.3---");
            Exercise3();
        }

        //P89～P90を参考
        private static void Exercise1() {
            //if-else文を使用(コード4.9)
            var line = Console.ReadLine();
            int num = int.Parse(line);
            if (num < 0) {
                Console.WriteLine(num);
            }
        }

        private static void Exercise2() {
            //switch文を使用(コード4.10)
        }

        private static void Exercise3() {
            //switch式を使用(コード4.11)
        }
    }
}
