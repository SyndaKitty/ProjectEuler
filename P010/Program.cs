using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<int> primes = new List<int>(2);
        decimal total = 2;
        for (int i = 3; i < 2_000_000; i += 2) {
            bool valid = true;
            foreach (var p in primes) {
                if (i % p == 0) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                total += i;
                primes.Add(i);
            }
        }
        Console.WriteLine(total);
    }
}