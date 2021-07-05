using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var best = (0, 0);
        for (int p = 1; p <= 1000; p++) {
            int solutions = 0;
            for (int a = 1; a < p-2; a++) {
                for (int b = 1; b < p-a; b++) {
                    int c = p - a - b;
                    if (a * a + b * b != c * c) continue;
                    solutions++;
                }
            }
            if (solutions > best.Item1) {
                best = (solutions, p);
            }
        }
        Console.WriteLine(best.Item2);
    }
}