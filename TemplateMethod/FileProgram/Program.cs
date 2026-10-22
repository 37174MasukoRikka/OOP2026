using System.Threading.Channels;
using TextFileProcessor;

string path = @"C:\Users\infosys\source\repos\OOP2026\Chapter14\Section04\Program.cs";
TextProcessor.Run<StaticCounterProcessor>(path);


public class StaticCounterProcessor : TextProcessor {
    private int _count = 0;
    private string _word = "";

    protected override void Initialize(string fname) {
        _count = 0;
        Console.Write("カウントしたい単語:");
        _word = Console.ReadLine();
    }

    protected override void Execute(string line) {
        _count += line.Split(_word).Length - 1;

    }

    protected override void Terminate() =>
        Console.WriteLine($"{_word}は{_count} つ出現します", _count);
}