
namespace Exercise02 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo", "New Delhi", "Bangkok", "London",
                "Paris", "Berlin", "Canberra", "Hong Kong",
            };

            Console.WriteLine("***** 3.2.1 *****");
            Exercise2_1(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.2 *****");
            Exercise2_2(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.3 *****");
            Exercise2_3(cities);
            Console.WriteLine();

            Console.WriteLine("***** 3.2.4 *****");
            Exercise2_4(cities);
            Console.WriteLine();

        }

        private static void Exercise2_1(List<string> cities) {
            //できたらGitのコメント「問題3.2.1完成」
            Console.WriteLine("都市名を入力。空白で終了。");
            var name = Console.ReadLine();  //入力処理
            int index = cities.FindIndex(s => s.Equals(name));
            Console.WriteLine(index);

        }

        private static void Exercise2_2(List<string> cities) {
            //できたらGitのコメント「問題3.2.2完成」
            var cnt = cities.Count(s => s.Contains('o'));
            Console.WriteLine(cnt);
        }

        private static void Exercise2_3(List<string> cities) {
            //できたらGitのコメント「問題3.2.3完成」
            var selected = cities.Where(s => s.Contains('o')).ToArray();
            foreach (var name in selected) {
                Console.WriteLine(name);
            }
        }

        private static void Exercise2_4(List<string> cities) {
            //できたらGitのコメント「問題3.2.4完成」
            var obj = cities.Where(s => s.StartsWith("B"))
                .Select(s => new { s, s.Length });
            foreach (var data in obj) {
                Console.WriteLine(data.s + ":" + data.Length + "文字");
            }
        }
    }
}
