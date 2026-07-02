using System.Threading.Channels;

namespace Section01 {
    internal class Program {
        static private Dictionary<string, string> prefOfficeDict = new Dictionary<string, string>();


        static void Main(string[] args) {
            string? pref, prefCaptalLocation;

            Console.WriteLine("県庁所在地の登録【入力終了：Ctrl + 'Z'】");

            while (true) {
                //①都道府県入力
                Console.Write("都道府県:");
                pref = Console.ReadLine();

                if (pref == null) break;   //無限ループを抜ける(Ctrl + Z)

                //②県庁所在地入力
                Console.Write("県庁所在地:");
                prefCaptalLocation = Console.ReadLine();

                //既に都道府県が登録されているか？
                if (prefOfficeDict.ContainsKey(pref)) {
                    Console.WriteLine("上書きしますか?(Y/N)");
                    if (Console.ReadLine() == "N") continue;
                }

                //③県庁所在地登録処理
                prefOfficeDict[pref] = prefCaptalLocation;
                Console.WriteLine();　//改行
            }

            Boolean endFlag = false;    //終了フラグ(メニューの無限ループを抜ける用)
            while (!endFlag) {
                switch (menuDisp()) {
                    case 1: //一覧出力
                        allDisp();
                        break;
                    case 2: //検索処理
                        searchPrefCaptalLocation();
                        break;
                    default:
                        endFlag = true;
                        break;
                }
            }
        }


        //メニュー表示
        private static int menuDisp() {
            Console.WriteLine("***メニュー***\n1:一覧表示\n2:検索\n9:終了");
            Console.Write(">");
            //メニュー番号を入力させて呼び出し元へ返却
            return int.Parse(Console.ReadLine());
            //var line = Console.ReadLine();
            //int num = int.Parse(line);
            //return (num);
        }

        //一覧表示
        private static void allDisp() {
            foreach (var item in prefOfficeDict) {
                Console.WriteLine($"{item.Key}の県庁所在地は{item.Value}です。");
            }
        }

        //検索処理
        private static void searchPrefCaptalLocation() {
            Console.Write("都道府県:");
            var searchPref = Console.ReadLine();
            var location = prefOfficeDict[searchPref];
            if (searchPref is null) return;
            //検索した結果を表示
            if (prefOfficeDict.ContainsKey(searchPref)) {
                Console.WriteLine($"{searchPref}の県庁所在地は{location}です。");

            //Console.Write("都道府県:");
            //var key = Console.ReadLine();
            //if (prefOfficeDict.ContainsKey(key)) {
            //var location = prefOfficeDict[key];
            //Console.WriteLine($"{key}の県庁所在地は{location}です。");
            }
        }
    }
}
