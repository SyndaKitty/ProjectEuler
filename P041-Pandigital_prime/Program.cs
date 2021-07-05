using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        // 9 and 8 digits can be ruled out because
        //the digits sum to 45 and 36 which are divisible by 3
        var sw = System.Diagnostics.Stopwatch.StartNew();
        var p = new Primes(7654321);
        Console.WriteLine(p.List.Reverse().First(x => IsPandigital(x)));
        
    }

    static bool IsPandigital(int n) {
        bool[] digits = new bool[10];
        var chars = n.ToString().ToCharArray();
        foreach (var c in chars) {
            var d = c - '0';
            if (d == 0) return false;
            if (digits[d]) return false;
            digits[d] = true;
        }
        // Ensure no gaps
        bool firstFound = false;
        for (int i = 9; i >= 1; i--) {
            if (digits[i]) firstFound = true;
            if (firstFound && !digits[i]) return false;
        }

        return true;
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