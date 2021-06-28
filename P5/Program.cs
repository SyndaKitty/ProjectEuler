using System;

class Program {
    static void Main(string[] args) {
        // Number gotten on paper, confirmed with code
        int v = 2*2*2*2 * 3*3 * 5 * 7 * 11 * 13 * 17 * 19;
        for (int i = 1; i <= 20; i++) {
            if (v % i != 0) {
                Console.WriteLine("Invalid");
                return;
            }
        }
        Console.WriteLine(v);
    }
}
