namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();


        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");

            while (true) {
                //都道府県入力
                Console.Write("都道府県:");
                pref = Console.ReadLine();

                if (pref == null) break;   //無限ループを抜ける(Ctrl + Z)

                //県庁所在地入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();

                //県庁所在地登録処理
                prefOfficeDict.Add(pref, prefCaptalLocation);

            }

            while (true) {
                switch (menuDisp()) {
                    case 1:
                        allDisp();
                        break;
                    case 2:
                        searchPrefCaptalLocation();
                        break;
                    case 9:
                        return;
                }
            }
        }


        private static int menuDisp() {
            Console.WriteLine("***メニュー***\n1:一覧表示\n2:検索\n9:終了");
            Console.Write(">");
            var line = Console.ReadLine();
            int num = int.Parse(line);
            return (num);
        }
        private static void allDisp() {
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
        }
        private static void searchPrefCaptalLocation() {
            Console.Write("都道府県:");
            var key = Console.ReadLine();
            if (prefOfficeDict.ContainsKey(key)) {
                var location = prefOfficeDict[key];
                Console.WriteLine($"{key}の県庁所在地は{location}です。");
            }
        }
    }
}
