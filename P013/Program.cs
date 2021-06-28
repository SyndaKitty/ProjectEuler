using System;
using System.IO;
using System.Numerics;


class Program {
    static void Main(string[] args) {
        var lines = File.ReadAllLines("numbers.txt");
        
        BigInteger sum = new BigInteger(0);
        foreach (var line in lines) {
            sum += BigInteger.Parse(line);
        }

        Console.WriteLine(sum.ToString().Substring(0, 10));
    }
}