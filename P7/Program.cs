using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<int> primes = new List<int>(2);
        int count = 2;
        for (int i = 3;; i += 2) {
            bool valid = true;
            foreach (var p in primes) {
                if (i % p == 0) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                if (count++ == 10_001) {
                    Console.WriteLine(i);
                    return;
                }
                primes.Add(i);
            }
        }
    }
}