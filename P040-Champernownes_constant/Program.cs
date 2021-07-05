using System;
using System.Text;

class Program {
    static void Main(string[] args) {
        StringBuilder s = new StringBuilder();
        for (int i = 1; s.Length < 1000000; i++) {
            s.Append(i);
        }
    
        string digits = s.ToString();
        int product = 1;
        int lookup = 1;
        for (int i = 0; i < 7; i++) {
            product *= digits[lookup - 1] - '0';
            lookup *= 10;
        }

        Console.WriteLine(product);
    }
}