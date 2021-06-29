using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var file = File.ReadAllText("p022_names.txt");
        var names = file.Substring(1, file.Length-2).Split("\",\"");
        names = names.OrderBy(n => n).ToArray();

        int total = 0;
        for (int i = 0; i < names.Length; i++) {
            int value = names[i].ToCharArray().Sum(n => n - 'A' + 1);
            total += (i + 1) * value;
        }

        Console.WriteLine(total);
    }
}