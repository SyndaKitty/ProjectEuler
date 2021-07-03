using System;
using System.Linq;
using System.Text;

class Program {
    static void Main(string[] args) {
        Console.WriteLine(Enumerable.Range(0, 1_000_000).Where(x => IsPalindromic(x.ToString()) && IsPalindromic(Binary(x))).Sum());
    }

    static string Binary(int n) {
        bool firstDigit = false;
        StringBuilder result = new StringBuilder();
        
        int bitMask = 1 << 30;
        for (int i = 30; i >= 0; i--) {
            int digit = (n & bitMask) >> i;
            if (firstDigit || digit > 0) {
                firstDigit = true;
                result.Append(digit);
            }
            bitMask >>= 1;
        }
        return result.ToString();
    }
    
    static bool IsPalindromic(string s) {
        for (int i = 0; i < s.Length / 2; i++) {
            if (s[i] != s[s.Length - 1 - i]) {
                return false;
            }
        }
        return true;
    }
}