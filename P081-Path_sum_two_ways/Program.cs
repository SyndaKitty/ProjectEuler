using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        var lines = File.ReadAllLines("p081_matrix.txt");
        int size = 80;
        int[,] matrix = new int[size, size];
        for (int line = 0; line < size; line++) {
            var vals = lines[line].Split(",");
            for (int val = 0; val < size; val++) {
                matrix[val, line] = Int32.Parse(vals[val]);
            }
        }

        for (int n = 1; n < size; n++) {
            matrix[n, 0] += matrix[n-1, 0];
            matrix[0, n] += matrix[0, n-1];
        }

        for (int y = 1; y < size; y++) {
            for (int x = 1; x < size; x++) {
                matrix[x,y] += Math.Min(matrix[x-1,y], matrix[x,y-1]);
            }
        }

        Console.WriteLine(matrix[size-1, size-1]);
    }
}