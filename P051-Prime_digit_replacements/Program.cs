using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var primes = Primes(1000000);

        foreach (var prime in primes) {
            var p = prime.ToString().Reverse().ToArray();
            for (int i = 0; i < p.Length; i++) {
                p[i] = (char)(p[i] - '0');
            }

            for (int i = 1; i < Math.Pow(2, p.Length); i++) {
                HashSet<int> check = new HashSet<int>();
                int count = 0;
                int smallestFamilyMember = int.MaxValue;
                for (int d = 0; d <= 9; d++) {
                    int newNum = 0;
                    int digit = 1;
                    for (int j = 0; j < p.Length; j++) {
                        if (((1<<j) & i) > 0) {
                            newNum += d * digit;
                        }
                        else {
                            newNum += p[j] * digit;
                        }
                        digit *= 10;
                    }
                    if (primes.Contains(newNum) && !check.Contains(newNum) && newNum.ToString().Length == p.Length) {
                        if (newNum < smallestFamilyMember) {
                            smallestFamilyMember = newNum;
                        }
                        count++;
                        if (count == 8) {
                            Console.WriteLine(smallestFamilyMember);
                            return;
                        }
                    }
                    check.Add(newNum);
                }
            }
        }
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