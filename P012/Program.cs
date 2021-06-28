using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program {
    static void Main(string[] args) {
        int triangle = 0;
        for (int i = 1;; i++) {
            triangle += i;

            if (CountFactors(triangle) > 500) {
                Console.WriteLine(triangle);
                return;
            }
        }
    }

    static int CountFactors(int n) {
        HashSet<int> factors = new HashSet<int>(100);
        for (int i = 1; i < Math.Sqrt(n); i++) {
            if (n % i == 0) {
                int d = n / i;
                factors.Add(i);
                factors.Add(d);
            }
        }
        return factors.Count;
    }
}