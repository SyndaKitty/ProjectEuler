using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        
        var p = new Primes(10_000);
        var s = new HashSet<int>();
        for (int i = 1; i < 10_000; i++) {
            s.Add(2 * i * i);
        }
        for (int i = 3;; i+=2) {
            if (p.Set.Contains(i)) continue;
            bool valid = false;
            foreach (var prime in p.List) {
                if (prime > i) break;
                if (s.Contains(i - prime)) {
                    valid = true;
                    break;
                }
            }
            if (!valid) {
                Console.WriteLine(i);
                return;
            }
        }
    }
}

class Primes {
    public int MaxChecked;
    public List<int> List;
    public HashSet<int> Set;
    public Primes(int n) {
        Generate(n);
    }
    void Generate(int n) {
        if (MaxChecked >= n) return;
        MaxChecked = n;
        // Sieve of Erotosthenes
        bool[] isPrime = new bool[n];
        for (int i = 2; i < n; i++) {
            isPrime[i] = true;
        }
        for (int i = 3; i * i <= n; i += 2) {
            int index = i * 2;
            while (index < n) {
                isPrime[index] = false;
                index += i;
            }
        }

        int approximateCount = n < 128 ? n / 2 : (int)(n * 1.1 / Math.Log(n - 1));
        List = new List<int>(approximateCount);
        List.Add(2);
        Set = new HashSet<int>(approximateCount);
        Set.Add(2);
        for (int i = 3; i < n; i += 2) {
            if (isPrime[i]) {
                List.Add(i);
                Set.Add(i);
            }
        }
    }
}