using System;

class Program {
    static void Main(string[] args) {
        decimal sum = 0;
        for (int i = 1; i <= 100; i++) {
            sum += i;
        }
        decimal squareOfSums = sum * sum;

        decimal sumOfSquares = 0;
        for (int i = 1; i <= 100; i++) {
            sumOfSquares += i * i;
        }

        Console.WriteLine(squareOfSums - sumOfSquares);
    }
}