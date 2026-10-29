using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise03;
public class Take20Processor : ITextFileService {
    private int _count = 0;

    public void Initialize(string fname) => _count = 0;

    public bool Execute(string line) {
        Console.WriteLine(line);
        _count++;

        return _count < 20;
    }

    public void Terminate() {
    }
}


