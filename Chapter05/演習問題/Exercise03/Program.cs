using Exercise01;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var p1 = new YearMonth(2002, 10);
            var p2 = new YearMonth(2002, 10);
            if (p1 == p2)
                Console.WriteLine("等しい");
            else
                Console.WriteLine("等しくない");

        }
    }
}
