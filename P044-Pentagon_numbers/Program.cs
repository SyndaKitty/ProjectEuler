using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var p = new List<int>(5_000);
        var isP = new HashSet<int>();
        for (int n = 1; n <= 5_000; n++) {
            var i = (3 * n * n - n) / 2;
            isP.Add(i);
            p.Add(i);
        }

        var best = int.MaxValue;
        foreach (var a in p) {
            foreach (var b in p) {
                if (!isP.Contains(a + b)) continue;
                if (!isP.Contains(a - b)) continue;
                var score = Math.Abs(a - b);
                if (score < best) best = score;
            }
        }
        Console.WriteLine(best);
    }
}