using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        // Generate all abundant numbers
        HashSet<int> A = new HashSet<int>();
        for (int i = 12; i < 28123; i++) {
            if (d(i) > i) {
                A.Add(i);
            }
        }
    
        decimal total = 0;
        for (int i = 1; i < 28123; i++) {
            bool valid = true;
            foreach (var a in A) {
                if (A.Contains(i - a)) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                total += i;
            }
        }

        Console.WriteLine(total);
    }

    static int d(int n) {
        HashSet<int> divisors = new HashSet<int>();
        divisors.Add(1);
        for (int i = 2; i * i <= n; i++) {
            if (n % i == 0) {
                divisors.Add(i);
                divisors.Add(n / i);
            }
        }
        return divisors.Sum();
    }
}