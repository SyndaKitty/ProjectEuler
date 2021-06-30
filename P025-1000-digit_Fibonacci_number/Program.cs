using System;
using System.Numerics;

class Program {
    static void Main(string[] args) {
        BigInteger a = 1;
        BigInteger b = 1;
        int index = 3;
        while (true) {
            BigInteger c = a + b;
            if (c.ToString().Length >= 1000) {
                Console.WriteLine(index);
                return;
            }
            index++;
            a = b;
            b = c;
        }
    }
}