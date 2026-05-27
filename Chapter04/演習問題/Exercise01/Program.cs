
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            List<string> langs = [
                "C#", "Java", "Ruby", "PHP", "Python", "TypeScript",
                "JavaScript", "Swift", "Go",
            ];

            Exercise1(langs);
            Console.WriteLine("---");
            Exercise2(langs);
            Console.WriteLine("---");
            Exercise3(langs);
        }

        private static void Exercise1(List<string> langs) {
            Console.WriteLine("---4.1.1---");

            //foreach文
            Console.WriteLine("foreach文で出力");
            var name = langs.FindAll(s => s.Contains('S'));
            foreach (var item in name) {
                Console.WriteLine(item);
            }


            //for文
            Console.WriteLine("\nfor文で出力");

            var x = langs.Where(s => s.Contains('S')).ToArray();
            for (int i = 0; i < x.Length; i++) {
                Console.WriteLine(x[i]);
            }


            //while文
            Console.WriteLine("\nwhile文で出力");
            //var y = langs.Where(s => s.Contains('S')).ToArray();
            //while (true) {
               // Console.WriteLine(y);

            //}
        }

        private static void Exercise2(List<string> langs) {
            //LINQを使用する(Where)

        }

        private static void Exercise3(List<string> langs) {

        }
    }
}
