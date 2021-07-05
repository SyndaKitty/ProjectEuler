using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var triangleNums = new TriangleNumbers(200);
        var txt = File.ReadAllText("p042_words.txt");
        var words = txt.Substring(1, txt.Length-2).Split("\",\"");
        Console.WriteLine(words.Count(w => triangleNums.IsTriangle(WordValue(w))));
    }

    static int WordValue(string s) => s.ToCharArray().Sum(c => c - 'A' + 1);
}

class TriangleNumbers {
    public HashSet<int> List = new HashSet<int>();
    public int MaxChecked;
    int MaxN = 1;

    public TriangleNumbers(int max) {
        Generate(max);
    }
    
    void Generate(int max) {
        int t = 0;
        while (t < max) {
            t = (MaxN * MaxN + MaxN) / 2;
            List.Add(t);
            MaxN++;
        }
        MaxChecked = max;
    }

    public bool IsTriangle(int n) => List.Contains(n);
}