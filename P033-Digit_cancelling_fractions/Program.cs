using System;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        int totalNum = 1;
        int totalDom = 1;
        for (int a = 12; a <= 98; a++) {
            if (a % 10 == 0 || a % 10 == a / 10) continue;
            for (int b = a + 1; b <= 99; b++) {
                if (b % 10 == 0 || b % 10 == b / 10) continue;
                
                var intersect = Digits(a).Intersect(Digits(b));
                if (intersect.Count() != 1) continue;
                var newNum = Int32.Parse(Digits(a).Where(x => x != intersect.First()).ToArray());
                var newDenom = Int32.Parse(Digits(b).Where(x => x != intersect.First()).ToArray());
                var gcd = GCD(newNum, newDenom);
                newNum /= gcd;
                newDenom /= gcd;

                if (newDenom == b / GCD(a, b) && newNum == a / GCD(a, b)) {
                    totalNum *= newNum;
                    totalDom *= newDenom;
                }
            }
        }
        Console.WriteLine(totalDom / GCD(totalNum, totalDom));
    }

    static int GCD(int num, int dom) {
        while (dom != 0) {
            (num, dom) = (dom, num % dom);
        }
        return num;
    }

    static IEnumerable<char> Digits(int num) {
        return num.ToString().ToCharArray().Select(x => x);
    }
}