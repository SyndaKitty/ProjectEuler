using System;

class Program {
    static void Main(string[] args) {
        decimal tn = 2; decimal t = 3;
        decimal pn = 2; decimal p = 5;
        for (int n = 144;; n++) {
            decimal h = 2 * n * n - n;
            while (t < h) {
                tn++;
                t = (tn * tn + tn) / 2;
            }
            while (p < h) {
                pn++;
                p = (3 * pn * pn - pn) / 2;
            }
            if (h == t && h == p) {
                Console.WriteLine(h);
                return;
            }
        }
    }
}