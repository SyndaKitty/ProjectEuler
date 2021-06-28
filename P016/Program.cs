using System;
using System.Numerics;
class Program {
    static void Main(string[] args) {
        var b = BigInteger.Pow(2, 1000);

        int total = 0;
        foreach (var c in b.ToString().ToCharArray()) {
            total += c - '0';
        }
        Console.WriteLine(total);
    }
}