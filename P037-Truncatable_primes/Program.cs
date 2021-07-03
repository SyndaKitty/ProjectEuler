using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        // This is a brute force check, but one could also
        // approach this from a construction persepctive
        Primes p = new Primes(1_000_000);
        int count = 0;
        int sum = 0;

        while (true) {
            foreach (var prime in p.List.Skip(4).ToList()) {
                bool valid = true;
                
                string s1 = prime.ToString();
                string s2 = prime.ToString();
                while (s1.Length > 1) {
                    s1 = new String(s1.Take(s1.Length - 1).ToArray());
                    s2 = new String(s2.Skip(1).Take(s2.Length - 1).ToArray());
                    if (!p.IsPrime(Int32.Parse(s1)) || !p.IsPrime(Int32.Parse(s2))) {
                        valid = false;
                        break;
                    }
                }
                if (!valid) continue;

                count++;
                sum += prime;

                if (count == 11) {
                    Console.WriteLine(sum);
                    return;
                }
            }
            p = new Primes(p.MaxChecked * 2);
            count = 0;
        }
    }
}

class Primes {
    public int MaxChecked;
    public HashSet<int> List;
    public Primes(int n) {
        Generate(n);
    }
    void Generate(int n) {
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
        List = new HashSet<int>(approximateCount);
        List.Add(2);
        for (int i = 3; i < n; i += 2) {
            if (isPrime[i])
                List.Add(i);
        }
    }

    public bool IsPrime(int n) {
        if (n > MaxChecked) {
            Generate(n * 2);
        }
        return List.Contains(n);
    }
}