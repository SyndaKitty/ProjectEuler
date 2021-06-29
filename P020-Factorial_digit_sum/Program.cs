using System;
using System.Linq;
using System.Numerics;
class Program {
    static void Main(string[] args) {
        BigInteger product = new BigInteger(1);
        for (int i = 2; i <= 99; i++) {
            product *= i;
        }

        Console.WriteLine(product.ToString().ToCharArray().Sum(w => (w - '0')));
    }
}