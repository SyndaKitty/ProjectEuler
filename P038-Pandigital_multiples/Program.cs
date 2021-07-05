using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        int largest = 0;
        for (int i = 0; i < 99999; i++) {
            string product = "";
            for (int n = 1; product.Length < 9; n++) {
                product += (i * n);
            }
            if (product.Length != 9 || !IsPandigital(product)) continue;
            int p = Int32.Parse(product);
            if (p > largest) largest = p;
        }

        Console.WriteLine(largest);
    }

    static bool IsPandigital(string s) {
        bool[] digits = new bool[10];
        foreach (var c in s) {
            int d = c - '0';
            if (d == 0) return false;
            if (digits[d]) return false;
            digits[d] = true;
        }
        return true;
    }
}