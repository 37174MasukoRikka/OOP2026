namespace Test01_01 {
    public class ScoreCounter {
        private IEnumerable<Student> _score;

        // コンストラクタ
        public ScoreCounter(string filePath) {
            _score = ReadScore(filePath);
        }

        //メソッドの概要：
        private static IEnumerable<Student> ReadScore(string filePath) {
            var sales = new List<Student>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines) {
                var items = line.Split(','); //カンマ区切りで分割
                var student = new Student {
                    Name = items[0],
                    Subject = items[1],
                    Score = int.Parse(items[2])
                };
                sales.Add(student);
            }
            return sales;
        }

        //メソッドの概要：教科別点数を集計
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();
            foreach (var item in _score) {
                if (dict.ContainsKey(item.Name))
                    //登録されている場合
                    dict[item.Name] += item.Score;
                else
                    //未登録の場合
                    dict[item.Name] = item.Score;
            }
            return dict;
        }
    }
}






