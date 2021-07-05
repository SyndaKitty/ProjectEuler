using System;

class Program {
    static void Main(string[] args) {
        decimal pn = 2; decimal p = 5;
        for (int n = 144;; n++) {
            decimal h = 2 * n * n - n;
            while (p < h) {
                pn++;
                p = (3 * pn * pn - pn) / 2;
            }
            if (h == p) {
                Console.WriteLine(h);
                return;
            }
        }
    }
}