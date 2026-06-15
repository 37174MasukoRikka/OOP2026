using System.Text;

namespace Section05 {
    internal class Program {
        static void Main(string[] args) {
            //var language = GetWords();
            //var separator = ",";
            var result = String.Join(",", GetWords());
            Console.WriteLine(result);
            //var sb = new StringBuilder();
            //foreach (var word in GetWords()) {
            //sb.Append(word);
            //}
        }
        private static IEnumerable<string> GetWords() {
            return ["Orange", "Lemon", "Strawberry"];
        }
    }
}
