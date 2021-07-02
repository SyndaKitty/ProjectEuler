using System;

class Program {
    static void Main(string[] args) {
        int total = 1;
        for (int n = 1; n <= 500; n++) {
            total += 16 * n * n + 4 * n + 4;
        }
        Console.WriteLine(total);
    }

    // Not used for this solution, but nice to have around:
    static int Spiral(int x, int y) {
        if (x == 0 && y == 0) return 1;
        int r = Math.Max(Math.Abs(x), Math.Abs(y));

        int val = (2 * r + 1) * (2 * r + 1);
        if (-x < y && y <= x) return val - 7 * r + y;
        if (-y <= x && x < y) return val - 5 * r - x;
        if (x <= y && y < -x) return val - 3 * r - y;
        return val - r + x;
    }
}