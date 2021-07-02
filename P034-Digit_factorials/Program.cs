using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        
        Console.WriteLine(Enumerable.Range(3, 1_000_000).Where(x => Digits(x).Select(c => Factorial(c)).Sum() == x).Sum());
    }

    static IEnumerable<int> Digits(int n) {
        return n.ToString().ToCharArray().Select(x => x - '0');
    }

    static int Factorial(int n) {
        int total = 1;
        for (int i = 2; i <= n; i++) {
            total *= i;
        }
        return total;
    }
}