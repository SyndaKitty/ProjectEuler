using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class Program {
    static void Main(string[] args) {
        var products = new HashSet<int>();
        for (int a = 1; a < 9999; a++) {
            if (!IsPandigital(a.ToString())) continue;
            for (int b = 1; b < 9999; b++) {
                int product = a * b;
                string all = a.ToString() + b.ToString() + product.ToString();
                if (all.Length != 9 || all.Contains('0') || !IsPandigital(all)) continue;
                products.Add(product);
            }
        }
        Console.WriteLine(products.Sum());
    }

    static bool IsPandigital(string s) {
        bool[] digits = new bool[10];
        foreach (var c in s.ToCharArray()) {
            int d = c - '0';
            if (digits[d]) return false;
            else digits[d] = true;
        }
        return true;
    }
}