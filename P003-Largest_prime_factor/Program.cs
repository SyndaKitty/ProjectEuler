using System;

class Program {
    static void Main(string[] args) {
        decimal v = 600851475143;
        for (int i = 2;; i++) {
            if (v % i == 0 && IsPrime(v / i)) {
                Console.WriteLine(v / i);
                return;
            }
        }
    }

    static bool IsPrime(decimal a) {
        for (int i = 2; i < a / 2; i++) {
            if (a % i == 0) {
                return false;
            }
        }
        return true;
    }
}