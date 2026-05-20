namespace Section04 {
    internal class Program {
        static void Main(string[] args) {
            var cities = new List<string> {
                "Tokyo",
                "New Delhi",
                "Bangkok",
                "London",
                "Paris",
                "Berlin",
                "Canberra",
                "Hong Kong",
            };

            var query = cities.Where(s => s.Length <= 5).ToList();
            foreach (var item in query) {
                Console.WriteLine(item);
                                
            }

            Console.WriteLine("--------");

            cities[0] = "Osaka";
            foreach (var item in query) {
                Console.WriteLine(item);
            }
        }
    }
}
