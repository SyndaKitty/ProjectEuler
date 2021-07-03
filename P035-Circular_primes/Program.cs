using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        int count = 0;
        Primes p = new Primes(1_000_000);
        foreach (var prime in p.List) {
            int s = 0;
            bool valid = true;
            for (int i = 1; s != prime; i++) {
                s = Shift(prime, i);
                if (!p.IsPrime(s)) {
                    valid = false;
                    break;
                }
            }
            if (valid) count++;
        }
        Console.WriteLine(count);
    }

    static int Shift(int n, int r) {
        int maxDigit = 1;
        while (n > maxDigit) {
            maxDigit *= 10;
        }

        for (int i = 0; i < r; i++) {
            n *= 10;
            n = n % maxDigit + n / maxDigit;
        }

        return n;
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