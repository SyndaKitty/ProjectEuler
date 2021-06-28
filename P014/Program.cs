using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        int largest = 0;
        int largestStarting = 0;
        for (int i = 5; i <= 1_000_000; i++) {
            var len = ChainLength(i);
            if (len > largest) {
                largest = len;
                largestStarting = i;
            }
        }
        Console.WriteLine($"{largestStarting} {largest}");
    }

    static Dictionary<decimal, int> C = new Dictionary<decimal, int>();
    static int ChainLength(decimal startN) {
        if (C.ContainsKey(startN)) {
            return C[startN];
        }
        
        int count = 1;
        decimal n = startN;
        while (n != 1) {
            if (n % 2 == 0) {
                n = n / 2;
            }
            else {
                n = 3 * n + 1;
            }
            if (C.ContainsKey(n)) {
                count += C[n];
                C.Add(startN, count);
                return count;
            }
            
            count++;
        }
        C.Add(startN, count);
        return count;
    }
}