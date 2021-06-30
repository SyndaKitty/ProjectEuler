using System;
using System.IO;

class Program {
    static void Main(string[] args) {
        var lines = File.ReadAllLines("p102_triangles.txt");
        int count = 0;
        foreach (var line in lines) {
            var components = line.Split(",");
            var a = new Vector2(Convert.ToInt32(components[0]), Convert.ToInt32(components[1]));
            var b = new Vector2(Convert.ToInt32(components[2]), Convert.ToInt32(components[3]));
            var c = new Vector2(Convert.ToInt32(components[4]), Convert.ToInt32(components[5]));
            var origin = new Vector2(0, 0);

            // Ensure points are counter-clockwise
            if (Orientation(a, b, c) == 1) {
                (b, c) = (c, b);
            }

            if (b.Subtract(a).CCW90().Dot(origin.Subtract(a)) < 0) continue;
            if (c.Subtract(b).CCW90().Dot(origin.Subtract(b)) < 0) continue;
            if (a.Subtract(c).CCW90().Dot(origin.Subtract(c)) < 0) continue;

            count++;
        }
        Console.WriteLine(count);
    }

    // 0 is colinear, 1 is counter-clockwise, 2 is clockwise
    static int Orientation(Vector2 a, Vector2 b, Vector2 c) {
        int val = (b.Y - a.Y) * (c.X - b.X) - (b.X - a.X) * (c.Y - b.Y);
        if (val == 0) return 0;
        return val > 0 ? 1 : 2;
    }

    struct Vector2 {
        public int X;
        public int Y;
        public Vector2(int x, int y) {
            X = x;
            Y = y;
        }

        public int Dot(Vector2 b) {
            return X * b.X + Y * b.Y;
        }

        public Vector2 CCW90() {
            return new Vector2(-Y, X);
        }

        public Vector2 Subtract(Vector2 b) {
            return new Vector2(X - b.X, Y - b.Y);
        }
    }
}