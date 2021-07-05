using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var p = new Primes(9999);
        for (int i = 0; i < p.List.Count; i++) {
            int prime = p.List[i];
            if (prime < 1000) continue;
            //Console.WriteLine(prime);
            for (int j = i + 1; j < p.List.Count; j++) {
                int prime2 = p.List[j];
                int diff = prime2 - prime;
                int prime3 = prime2 + diff;
                if (prime3 > 9999) continue;
                if (p.Set.Contains(prime2 + diff)) {
                    string p1s = String.Concat(prime.ToString().OrderBy(c => c));
                    string p2s = String.Concat(prime2.ToString().OrderBy(c => c));
                    string p3s = String.Concat(prime3.ToString().OrderBy(c => c));
                    if (p1s == p2s && p2s == p3s) {
                        Console.WriteLine($"{prime}{prime2}{prime3}");
                    }
                }
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