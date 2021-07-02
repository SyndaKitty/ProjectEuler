using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        int upperBound = (int)(6 * Math.Pow(9, 5));

        int total = Enumerable.Range(10, upperBound)
                .Where(n => 
                    Digits(n).Select(n => n*n*n*n*n).Sum() == n
                ).Sum();
        Console.WriteLine(total);
    }

    static IEnumerable<int> Digits(int n) {
        return n.ToString().ToCharArray().Select(c => c - '0');
    }
}