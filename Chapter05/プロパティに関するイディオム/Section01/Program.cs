using System.Collections.Immutable;

namespace Section01 {
    internal class Program {
        static void Main(string[] args) {
            //var obj = new PasswordPolicy("aaaaa", "bbbbbb");
            //var data = obj.Name;

            var ms = new MySample();
            //変更不可のオブジェクトなので、Add、RemoveAtは新たなインスタンスを返す
            var newList = ms.MyList.Add(6).RemoveAt(0);
            ms.MyList.ForEach(n => Console.Write($"{n} "));
            Console.WriteLine();  //改行
            newList.ForEach(n => Console.Write($"{n} "));
            Console.WriteLine();  //改行
        }
    }

    class MySample {
        public ImmutableList<int> MyList { get; private set; }


        public MySample() {
            var list = new List<int>() { 1, 2, 3, 4, 5 };
            MyList = list.ToImmutableList();
        }
    }

    class PasswordPolicy {
        //プロパティの初期化
        public int MinimumLength { get; set; } = 8;

        //読み取り専用プロパティ
        public string GivenName { get; init; } = null!;
        public string FamilyName { get; init; } = null!;


        //getアクセサーのみを定義した読み取り専用プロパティ
        //public string Name {
        //    get { return FamilyName + " " + GivenName; }
        //}

        public string Name => FamilyName + " " + GivenName;

        public PasswordPolicy(string familyName, string givenName) {
            FamilyName = familyName;
            GivenName = givenName;
        }
    }
}
