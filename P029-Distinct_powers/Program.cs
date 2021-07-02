using System;
using System.Collections.Generic;
using System.Numerics;

class Program {
    static void Main(string[] args) {
        var nums = new HashSet<BigInteger>();
        
        for (int a = 2; a <= 100; a++) {
            for(int b = 2; b <= 100; b++) {
                nums.Add(BigInteger.Pow(a, b));
            }
        }

        Console.WriteLine(nums.Count);
    }
}