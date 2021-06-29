using System;

class Program {
    static void Main(string[] args) {
        // Generate all possible values of a,b,c then check for validity
        for (int c = 335; c <= 997; c++) {
            int r = 1000 - c;
            for (int b = c - 1; b > r / 2; b--) {
                int a = r - b;
                if (c * c - b * b - a * a == 0) {
                    Console.WriteLine($"{a}*{b}*{c} = {a * b * c}");
                    return;
                }
            }
        }
    }
}