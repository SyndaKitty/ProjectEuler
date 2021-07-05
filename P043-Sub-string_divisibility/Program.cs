using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var primes = new int[] {2, 3, 5, 7, 11, 13, 17};
        var permutations = new List<string>();
        Permute("0123456789".ToCharArray(), permutations);
        decimal total = 0;
        foreach (var p in permutations) {
            bool valid = true;
            for (int i = 0; i < 7; i++) {
                var n = Int32.Parse(p.Substring(i + 1, 3));
                if (n % primes[i] != 0) {
                    valid = false;
                    break;
                }
            }
            if (valid) {
                total += decimal.Parse(p);
            }
        }
        Console.WriteLine(total);
    }

    static void Permute(char[] array, List<string> permutations) {
        int n = array.Length;
        int[] c = new int[n];

        permutations.Add(new String(array));

        int i = 1;
        while (i < n) {
            if (c[i] < i) {
                if (i % 2 == 0) {
                    (array[0], array[i]) = (array[i], array[0]);
                }
                else {
                    (array[c[i]], array[i]) = (array[i], array[c[i]]);
                }

                // Optimization specific to this problem
                // check if fourth digit is even
                if ((array[3] - '0') % 2 == 0) {
                    permutations.Add(new String(array));
                }

                c[i] += 1;
                i = 1;
            }
            else {
                c[i] = 0;
                i += 1;
            }
        }
    }
}