
namespace Exercise01 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Cozy lummox gives smart squid who asks for job pen";

            Exercise1(text);
            Console.WriteLine();
            Exercise2(text);

        }

        private static void Exercise1(string text) {
            var dict = new Dictionary<char, int>();
            var str = text.ToLower().Replace(" ", "");
            

            foreach (var ch in text) {
                if ('A' <= ch && ch <= 'Z') {
                    dict[ch]++;
                } else {


                } 
            }
        }

        private static void Exercise2(string text) {

        }
    }
}
