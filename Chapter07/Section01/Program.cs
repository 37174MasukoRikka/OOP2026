namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            var numbers = new List<int> { 9, 7, 5, 4, 2, 5, 4, 0, 4, 1, 0, 4 };

            var books = Books.GetBooks();
            var priceAverage = books.Average(x => x.Price);
            var pageAverage = books.Sum(x => x.Pages);
            var maxPrice = books.Max(x => x.Price);

            Console.WriteLine("平均金額：" + priceAverage);
            Console.WriteLine("合計ページ：" + pageAverage);
            Console.WriteLine("高価な本：" + maxPrice);

            Console.WriteLine("--- 500円以上のタイトル ---");
            foreach (var book in books.Where(x => x.Price >= 500)) {
                Console.WriteLine(book.Title);
            }
            Console.WriteLine();
            //２５０ページ以上の本を上位３冊出力
            var data = books.Where(x => 250 <= x.Pages).Take(3);
            foreach (var book in data) {
                Console.WriteLine(book.Title);
            }


        }
    }
}
