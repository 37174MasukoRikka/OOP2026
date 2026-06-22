namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            int[] numbers = [5, 10, 17, 9, 3, 21, 10, 40, 21, 3, 35];
            #region
            Console.WriteLine("\n7.1.1");
            Exercise1(numbers);

            Console.WriteLine("\n7.1.2");
            Exercise2(numbers);

            Console.WriteLine("\n7.1.3");
            Exercise3(numbers);

            Console.WriteLine("\n7.1.4");
            Exercise4(numbers);

            Console.WriteLine("\n7.1.5");
            Exercise5(numbers);
            #endregion
        }

        private static void Exercise1(int[] numbers) {
            Console.WriteLine(numbers.Max());
        }

        private static void Exercise2(int[] numbers) {
            foreach (var n in numbers.TakeLast(2)) {
                Console.WriteLine(n);
            }
        }

        private static void Exercise3(int[] numbers) {
            //P173を参考
            var strings = numbers.Select(n => n.ToString("000"));
            foreach (var s in strings) {
                Console.WriteLine(s);
            }
        }

        private static void Exercise4(int[] numbers) {
            //P175を参考
            foreach (var n in numbers.Order().Take(3)) {
                Console.WriteLine(n);
            }
        }

        private static void Exercise5(int[] numbers) {
            //P174を参考
            var count = numbers.Distinct().Count(n => 10 < n);
            Console.WriteLine(count);
        }
    }
}
