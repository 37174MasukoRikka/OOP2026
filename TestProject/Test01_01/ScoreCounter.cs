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
            







            return sales;
        }

        //メソッドの概要：
        public IDictionary<string, int> GetPerStudentScore() {
            var dict = new Dictionary<string, int>();






            return dict;
        }
    }
}
