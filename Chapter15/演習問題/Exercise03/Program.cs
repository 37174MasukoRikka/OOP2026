using Exercise03;

var service = new Take20Processor();
var processor = new TextFileProcessor(service);
string fileName = @"C:\Users\infosys\source\repos\OOP2026\Chapter15\演習問題\Exercise03\枕草子.txt";
//Console.WriteLine("パスの入力：");
processor.Run(fileName);
