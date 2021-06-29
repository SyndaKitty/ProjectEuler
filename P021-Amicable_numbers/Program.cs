using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        int total = 0;
        for (int i = 1; i < 10_000; i++) {
            int f = d(i);
            if (f != i && d(f) == i) {
                total += i;
            }
        }
        Console.WriteLine(total);
    }

    static int d(int n) {
        HashSet<int> divisors = new HashSet<int>();
        divisors.Add(1);
        for (int i = 2; i < Math.Sqrt(n); i++) {
            if (n % i == 0) {
                divisors.Add(i);
                divisors.Add(n / i);
            }
        }
        return divisors.Sum();
    }
}