using System;

class Program {
    static void Main(string[] args) {
        decimal sum = 0;
        decimal m = 10_000_000_000;
        for (decimal i = 1; i <= 1000; i++) {
            decimal subSum = 1;
            for (int p = 0; p < i; p++) {
                subSum = (subSum * i) % m;
            }
            sum += subSum;
        }
        Console.WriteLine(sum % m);
    }
}