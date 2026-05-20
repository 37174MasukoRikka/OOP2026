using System;
using static Section01.Program;

namespace Section01 {
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

            var exists = cities.FindAll(s => s.Length >= 6 && s.Contains('o') && s.EndsWith('n'));
            foreach (var s in exists) {
                Console.WriteLine(s);
            }
        }
    }
}

