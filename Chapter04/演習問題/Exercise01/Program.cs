
using System.Threading.Channels;

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

            foreach (var lang in langs) {
                if (lang.Contains('S'))
                    Console.WriteLine(lang);

            }

            //for文
            Console.WriteLine("\nfor文で出力");
            for (int i = 0; i < langs.Count; i++) {
                if (langs[i].Contains('S'))
                    Console.WriteLine(langs[i]);
            }

            //while文
            Console.WriteLine("\nwhile文で出力");
            int count = 0;
            while (count < langs.Count) {
                if (langs[count].Contains('S'))
                    Console.WriteLine(langs[count]);
                count++;
            }
        }

        private static void Exercise2(List<string> langs) {
            Console.WriteLine("\n---4.1.2---");
            //LINQを使用する(Where)
            var selected = langs.Where(s => s.Contains('S'));
            foreach (var lang in selected) {
                Console.WriteLine(lang);
            }
        }

        private static void Exercise3(List<string> langs) {
            var name = langs.Find(s => s.Length == 10);
            var message = name ??= "unknown";
            Console.WriteLine(message);
        }
    }
}
