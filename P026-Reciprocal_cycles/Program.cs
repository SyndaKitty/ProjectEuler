using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        int largest = 0;
        int num = 0;
        for (int i = 1; i < 1000; i++) {
            int p = PatternLength(i);
            if (p > largest) {
                largest = p;
                num = i;
            }
        }
        Console.WriteLine(num);
    }

    static int PatternLength(int n) {
        // Simulate long division
        var remainders = new Dictionary<int, int>();
        int place = 1;
        int remainder = 1;
        while (true) {
            if (remainder == 0) return 0;
            if (remainder / n > 0) {
                remainder %= n;
                if (remainders.ContainsKey(remainder)) {
                    return place - remainders[remainder];
                }
                remainders.Add(remainder, place);
            }
            remainder *= 10;
            place++;
        }
    }
}