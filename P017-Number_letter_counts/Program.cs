using System;

class Program {
    static void Main(string[] args) {
        // Could have done this in a much simpler way, analyzing instead of contructing
        int total = 0;
        for (int i = 1; i <= 1000; i++) {
            string w = ConstructWord(i);
            Console.WriteLine($"{i}: {w}");
            total += w.Length;;
        }
        Console.WriteLine(total);
    }

    static string[] digitsStrings = {"one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
    static string[] tensStrings = {"ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"};

    static string ConstructWord(int n) {
        if (n == 0) return "";
        if (n < 20) {
            return digitsStrings[n-1]; 
        }
        else if (n < 100) {
            int tens = (n / 10) % 10;
            int digits = n % 10;
            return tensStrings[tens-1] + (digits > 0 ? digitsStrings[digits-1] : "");
        }

        int thousand = n / 1000;
        int hundred = (n / 100) % 10;
        int tensAndDigits = n % 100;
        
        string res = "";
        if (thousand > 0) {
            res += ConstructWord(thousand) + "thousand";
        }
        if (hundred > 0) {
            res += ConstructWord(hundred) + "hundred";
        }
        if ((thousand > 0 || hundred > 0) && tensAndDigits > 0) {
            res += "and";
        }
        res += ConstructWord(tensAndDigits);
        return res;
    }
}
