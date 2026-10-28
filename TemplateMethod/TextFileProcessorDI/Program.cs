using TextFileProcessorDI;

var service = new LineCounterService();
var processor = new TextFileProcessor(service);
string fileName = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\演習問題\Exercise01_WPF\吾輩は猫である.txt";
Console.WriteLine("パスの入力：");
processor.Run(Console.ReadLine());