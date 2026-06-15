using System.Text;

namespace Exercise03 {
    internal class Program {
        static void Main(string[] args) {
            var text = "Jackdaws love my big sphinx of quartz";
            #region
            Console.WriteLine("6.3.1");
            Exercise1(text);
            Console.WriteLine();

            Console.WriteLine("6.3.2");
            Exercise2(text);
            Console.WriteLine();

            Console.WriteLine("6.3.3");
            Exercise3(text);
            Console.WriteLine();

            Console.WriteLine("6.3.4");
            Exercise4(text);
            Console.WriteLine();

            Console.WriteLine("6.3.5");
            Exercise5(text);
            Console.WriteLine();

            Console.WriteLine("6.3.6");
            Exercise6(text);
            #endregion
        }

        private static void Exercise1(string text) {
            var count = text.Count(c => c == ' ');
            Console.WriteLine("空白数:" + count);
            //別の書き方
            //Console.WriteLine("$空白数：{0}", count);
        }

        private static void Exercise2(string text) {
            Console.Write("検索：");
            var search = Console.ReadLine();
            Console.Write("置換：");
            var replace = Console.ReadLine();

            var replaced = text.Replace(search, replace);
            Console.WriteLine(replaced);
        }

        private static void Exercise3(string text) {
            var array = text.Split(' ');
            var sb = new StringBuilder(array[0]);

            foreach (var word in array.Skip(1)) {
                sb.Append(' ');
                sb.Append(word);
            }

            //for (int i = 1; i < array.Length; i++) {
            //sb.Append(' ');
            //sb.Append(array[i]);               
            //}

            //末尾はピリオド(.)で終わる
            Console.WriteLine(sb + ".");
        }

        private static void Exercise4(string text) {
            var count = text.Split(' ');
            Console.WriteLine($"単語数:{count}");
        }

        private static void Exercise5(string text) {
            text.Split(' ').Where(s => s.Length <= 4).ToList().ForEach(Console.WriteLine);
            //foreach (var s in words) {              ToList()で即時実行
            //    Console.WriteLine(s);
            //}
        }


        //アルファベットの数をカウントして表示
        private static void Exercise6(string text) {
            var str = text.ToLower().Replace(" ", "");
            //辞書(ディクショナリ)を使った集計
            var alphDicCount = Enumerable.Range('a', 26).
            ToDictionary(num => (char)num, num => 0);

            //var dict = new SortedDictionary<char, int>();
            foreach (var c in str) {
                alphDicCount[c]++;
            }
            foreach (var word in alphDicCount) {
                Console.WriteLine(word.Key + ":" + word.Value);
            }

            //配列を使った集計
            var array = Enumerable.Repeat(0, 26).ToArray();
            foreach (var alph in str) {
                array[alph - 'a']++;
            }
            for (char ch = 'a'; ch <= 'Z'; ch++) {
                Console.WriteLine($"{ch}:{array[ch - 'a']}");
            }

            Console.WriteLine(); //改行

            //'a'から順にカウントして集計
            for (char ch = 'a'; ch <= 'z'; ch++) {
                Console.WriteLine($"{ch}:{str.Count(c => c == ch)}");
            }
        }
    }
}



