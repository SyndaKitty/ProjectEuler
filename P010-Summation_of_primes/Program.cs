using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        const int limit = 2_000_000;
        var primes = Primes(limit);
        decimal total = 2;
        for (int i = 3; i < limit; i += 2) {
            if (primes.Contains(i)) {
                total += i;
            }
        }
        Console.WriteLine(total);
    }

    static HashSet<int> Primes(int n) {
        // Sieve of Erotosthenes
        bool[] isPrime = new bool[n];
        for (int i = 2; i < n; i++) {
            isPrime[i] = true;
        }
        for (int i = 3; i < (int)(Math.Sqrt(n) + 1); i += 2) {
            int index = i * 2;
            while (index < n) {
                isPrime[index] = false;
                index += i;
            }
        }
        HashSet<int> result = new HashSet<int>(n);
        for (int i = 3; i < n; i += 2) {
            if (isPrime[i]) 
                result.Add(i);
        }
        return result;
    }
}