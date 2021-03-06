using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        bool[] res = new bool[4];
        int j = 0;
        for (int i = 644;; i++) {
            res[j++ % 4] = PrimeFactorization(i).Keys.Count == 4;
            
            if (res[0] && res[1] && res[2] && res[3]) {
                Console.WriteLine(i-3);
                return;
            }
        }
    }

    static Dictionary<int,int> PrimeFactorization(int n) {
        var res = new Dictionary<int, int>();
        int p = 2;
        while (n >= p * p) {
            if (n % p == 0) {
                if (!res.ContainsKey(p)) res.Add(p, 0);
                res[p]++;
                n = n / p;
            }
            else p++;
        }
        if (!res.ContainsKey(n)) res.Add(n, 0);
        res[n]++;

        return res;
    }
}