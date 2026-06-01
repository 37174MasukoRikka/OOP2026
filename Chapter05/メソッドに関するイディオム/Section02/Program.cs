namespace Section02 {
    internal class Program {
        static void Main(string[] args) {

            DoSomething(100);
            DoSomething(100, "エラーです");           
            DoSomething(100, "エラーです", 5);

        }

        public static void DoSomething(int num, string message = "エラーです", int retryCount = 5) {
            //仮コード
            Console.WriteLine($"{num} {message} {retryCount}");
        }
    }
}
