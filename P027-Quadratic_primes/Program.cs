using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        Primes p = new Primes(200_000);

        int result = 0;
        int length = 0;
        // B must be prime, A must be odd
        foreach (var b in p.List) {
            if (b > 1000) break;
            for (int a = -999; a <= 999; a += 2) {
                int l = Length(a, b, p);
                if (l > length) {
                    length = l;
                    result = a * b;
                }
            }
        }

        Console.WriteLine(result);
    }

    public static int Length(int a, int b, Primes p) {
        for (int n = 0;; n++) {
            if (!p.IsPrime(n * n + a * n + b)) {
                return n;
            }
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
        for (int i = 3; i < (int)(Math.Sqrt(n) + 1); i += 2) {
            int index = i * 2;
            while (index < n) {
                isPrime[index] = false;
                index += i;
            }
        }

        int approximateCount = n < 128 ? n / 2 : (int)(n * 1.1 / Math.Log(n - 1));
        List = new HashSet<int>(approximateCount);
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