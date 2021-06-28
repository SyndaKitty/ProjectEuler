using System;

class Program {
    static void Main(string[] args) {
        int largest = 0;
        for (int a = 999; a >= 900; a--) {
            for (int b = 999; b >= 900; b--) {
                int product = a * b;
                if (IsPalindromic(product) && product > largest) {
                    largest = product;
                }
            }    
        }

        Console.WriteLine(largest);
    }

    static bool IsPalindromic(int v) {
        var c = v.ToString().ToCharArray();
        for (int i = 0; i < c.Length; i++) {
            if (c[c.Length - 1 - i] != c[i]) return false;
        }

        return true;
    }
}